using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Web.Areas.Admin.Models;
using Exchange.Helper.Transaction;
using System.Web.Security;
using Exchange.Provider.Profile;
using Exchange.Helper.Common;
using Exchange.Web.Helper;

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
        public EmployeeController(IUserService userService, IStoreService storeService, IProfileService profileService,IRoleService roleService)
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
                    Address =x.Address
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
                    
                        //MembershipUser user = Membership.GetUser(model.UserName, false);
                        //user.Email = "test@gmail.com";
                        //Membership.UpdateUser(user);
                        //create Profile
                    CreateProfile(model);
                    //Add user to Role
                    System.Web.Security.Roles.AddUserToRole(model.UserName, model.RoleName);

                  
                  


                    //Users employee = this.userService.GetUserByUsernameApplicationName(user.UserName, "Exchange");
                    //store.AddEmployee(employee);

                    //  this.storeService.SaveOrUpdate(store);
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
        #region Profile Private Method
        private void CreateProfile(RegisterModel model)
        {
            UserProfileBase profile = UserProfileBase.GetUserProfile(model.UserName);
            if (profile != null)
            {
                profile.FirstName = model.FirstName;
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




    }
}
