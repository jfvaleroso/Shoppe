using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Web.Areas.Admin.Models;
using Exchange.Helper.Transaction;
using Exchange.Provider.Profile;
using Exchange.Helper.Common;
using Exchange.Web.Helper;
using Exchange.Web.Filters;
using System.Web.Security;
using Exchange.Configuration;

namespace Exchange.Web.Areas.Admin.Controllers
{
  
    public class EmployeeController : Controller
    {
        #region Constructor
        private readonly IStoreService storeService;
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IRoleService roleService;
        private readonly Service service;
        public EmployeeController(IUserService userService, IStoreService storeService, IProfileService profileService, IRoleService roleService)
        {
            this.userService = userService;
            this.storeService = storeService;
            this.profileService = profileService;
            this.roleService= roleService;
            this.service = new Service(storeService, roleService);
        }
        #endregion
        #region Index
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult EmployeeListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                var employeeList = this.profileService.GetDataWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = employeeList.Select(x => new
                {
                    Name = string.Format("{0}, {1}",x.LastName,x.FirstName),
                    Position = x.Position,
                    Address =x.Address,
                    Id=  x.Users_Id.ToString(),
                    SecuredId= Base.Encrypt(x.Users_Id.ToString())
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "Web service is currently unavailable." });

            }
        }

        #endregion
        #region Register
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            model.StoreList = this.service.GetStoreList(0);
            model.RoleList = this.service.GetRoleList(0);
            return View(model);
        }
        [HttpPost]
        public JsonResult Register(RegisterModel model)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    // List<Users> users = userService.GetAll().ToList();
                    string password = Base.GenearateKey(8);
                    MembershipCreateStatus status;
                    model.UserName = Base.GenerateUsername(model.FirstName, model.MiddleName, model.LastName);
                    Membership.CreateUser(model.UserName, password, model.Email, "na", "na", true, null, out status);
                    
                    MembershipUser user = Membership.GetUser(model.UserName, false);
                        //user.Email = "test@gmail.com";
                        //Membership.UpdateUser(user);
                        //create Profile
                    CreateProfile(model);
                    //Add user to Role
                    if (!System.Web.Security.Roles.IsUserInRole(model.UserName,model.RoleName))
                    { 
                       System.Web.Security.Roles.AddUserToRole(model.UserName, model.RoleName);
                    }

                     Users employee = this.userService.GetUserByUsernameApplicationName(user.UserName, ConfigManager.Exchange.ApplicationName);
                     Store store= this.storeService.GetDataById(model.StoreId);

                     AddUserIsInStore(employee, store);


                    return Json(new { result = "", message = MessageCode.saved, code = StatusCode.saved, content = "" });
                }
                catch(Exception ex)
                {

                    return Json(new { result = StatusCode.failed, message = ex.Message, code = StatusCode.invalid });
                }
            }
            return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });

            
          

        }

    
        #endregion
        #region Manage
        [CrytoProvider]
        public ActionResult Manage(int Id)
        {
            RegisterModel model = new RegisterModel();
            Profiles profile = this.profileService.GetProfileByUserId(Id);
            Users user = this.userService.GetUserById(Id);
            //get roles
            string[] roles = Access.GetUserRoles(user.Username);
            Exchange.Core.Entities.Roles role= this.roleService.GetDataByName(roles[0].ToString());
            //get store
            int storeId = user.Stores.Count() > 0  ? user.Stores.FirstOrDefault().Id : 0;

            if (profile != null)
            {
                model.Address = profile.Address;
                model.BirthDate = profile.BirthDate.ToString();
                model.Email = user.Email;
                model.FirstName = profile.FirstName;
                model.Gender = profile.Gender;
                model.LastName = profile.LastName;
                model.MiddleName = profile.MiddleName;
                model.Position = profile.Position;
                model.StoreList =this.service.GetStoreList(storeId);
                model.RoleList = this.service.GetRoleList(role.Id);
                model.UserName = user.Username;
            }
          
            return View(model);
        }
        [HttpPost]
        public JsonResult Manage(RegisterModel model)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Users employee = this.userService.GetUserByUsernameApplicationName(model.UserName, ConfigManager.Exchange.ApplicationName);             
                    MembershipUser user = Membership.GetUser(model.UserName, false);
                    Store store = this.storeService.GetDataById(model.StoreId);

                    employee.Roles.Clear();
                    employee.Stores.Clear();
                    this.userService.SaveOrUpdate(employee);
                    //add roles and store
                    System.Web.Security.Roles.AddUserToRole(model.UserName, model.RoleName);
                    AddUserIsInStore(employee, store);

                    return Json(new { result = "", message = MessageCode.saved, code = StatusCode.saved, content = "" });
                }
                catch (Exception ex)
                {

                    return Json(new { result = StatusCode.failed, message = ex.Message, code = StatusCode.invalid });
                }
            }
            return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });




        }
        #endregion
        #region Profile Private Method
        private void CreateProfile(RegisterModel model)
        {
            UserProfileBase profile = UserProfileBase.GetUserProfile(model.UserName);
            if (profile != null)
            {
                profile.FirstName = model.FirstName;
                profile.MiddleName = model.MiddleName;
                profile.LastName = model.LastName;
                profile.Address = model.Address;
                profile.Gender = model.Gender;
                profile.Language = model.Language;
                profile.Position = model.Position;
                profile.Subscription = !string.IsNullOrEmpty(model.Subscription) ? model.Subscription : string.Empty;
                profile.Language = !string.IsNullOrEmpty(model.Language) ? model.Language : string.Empty;
                profile.Save();
            }       
        }
	#endregion
        #region Helpers
         private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        #region Test
     

         bool CheckIfUserIsInStore(Users user, Store store)
         {
             bool userIsInStore = false;
             List<Store> stores = user.Stores.ToList();
             foreach (var item in stores)
             {
                 if (item.Equals(store))
                 {
                     userIsInStore = true;
                     break;
                 }
             }
             return userIsInStore;
         }

         void AddUserIsInStore(Users user, Store store)
         {
             if (!CheckIfUserIsInStore(user, store))
             {
                 store.AddUser(user);
                 this.storeService.SaveOrUpdate(store);
             }
         }


        #endregion




    }
}
