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

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        #region Constructor
        private readonly IStoreService storeService;
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        public EmployeeController(IUserService userService, IStoreService storeService, IProfileService profileService)
        {
            this.userService = userService;
            this.storeService = storeService;
            this.profileService = profileService;
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
                    MembershipCreateStatus status = MembershipCreateStatus.UserRejected;
                    Membership.CreateUser(model.UserName, password, model.UserName + "@gmail.com", "what is", "yes", true, null, out status);
                    MembershipUser user = Membership.GetUser(model.UserName, false);
                    user.Email = "test@gmail.com";
                    Membership.UpdateUser(user);
                    //create Profile
                    CreateProfile(model);
                   

                  


                    //bool check = System.Web.Security.Roles.RoleExists("MVP");

                    //string[] usernames = new string[] { model.UserName };
                    //string[] roles = new string[] { "MVP" };

                   // System.Web.Security.Roles.AddUsersToRoles(usernames, roles);
                    //add user to role
                    //System.Web.Security.Roles.AddUserToRole(model.UserName, model.RoleName);

                    //Store store = new Store();
                    //store.Address = "Makati City";
                    //store.Active = true;
                    //store.Code = "MC2012";
                    //store.Name = "Greenbelt";
                    //store.DateCreated = DateTime.Now;
                    //store.PermitNo = "1223423";

                    //Users employee = this.userService.GetUserByUsernameApplicationName(user.UserName, "Exchange");
                    //store.AddEmployee(employee);

                    //  this.storeService.SaveOrUpdate(store);
                    return Json(new { result = "", message = MessageCode.saved, code = StatusCode.saved, content = "" });
                }
                catch
                {

                    return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
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
                profile.Subscription = model.Subscription;
                profile.Save();
            }       
        }
	#endregion
       

       

    }
}
