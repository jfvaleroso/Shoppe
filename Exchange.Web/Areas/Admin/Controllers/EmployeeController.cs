using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Providers;
using Exchange.Web.Areas.Admin.Models;
using Exchange.Web.Filters;
using Exchange.Web.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Roles = System.Web.Security.Roles;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        #region Constructor

        private readonly IProfileService _profileService;
        private readonly IRoleService _roleService;
        private readonly Service _service;
        private readonly IStoreService _storeService;
        private readonly IUserService _userService;

        public EmployeeController(IUserService userService, IStoreService storeService, IProfileService profileService,
            IRoleService roleService)
        {
            _userService = userService;
            _storeService = storeService;
            _profileService = profileService;
            _roleService = roleService;
            _service = new Service(storeService, roleService);
        }

        #endregion Constructor

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
                List<Profiles> employeeList = _profileService.GetDataWithPagingAndSearch(searchString, jtStartIndex,
                    jtPageSize, out total);
                var collection = employeeList.Select(x => new
                {
                    Name = string.Format("{0}, {1}", x.LastName, x.FirstName),
                    x.Position,
                    x.Address,
                    Id = x.UserId.ToString(),
                    SecuredId = Base.Encrypt(x.UserId.ToString())
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "Web service is currently unavailable." });
            }
        }

        #endregion Index

        #region Register

        public ActionResult Register()
        {
            var model = new RegisterModel
            {
                StoreList = _service.GetStoreList(new Guid()),
                RoleList = _service.GetRoleList(new Guid())
            };
            return View(model);
        }

        [Audit]
        [HttpPost]
        public JsonResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var fullName = Base.GenerateFullName(model.FirstName, model.MiddleName, model.LastName);
                try
                {
                    string password = Base.GenearateKey(8);

                    MembershipCreateStatus status;
                    model.UserName = Base.GenerateUsername(model.FirstName, model.MiddleName, model.LastName);
                    Membership.CreateUser(model.UserName, password, model.Email, "na", "na", true, null, out status);

                    var user = Membership.GetUser(model.UserName, false);
                    //create Profile
                    CreateProfile(model);
                    //Add user to Role
                    if (!Roles.IsUserInRole(model.UserName, model.RoleName))
                    {
                        Roles.AddUserToRole(model.UserName, model.RoleName);
                    }

                    Users employee = _userService.GetUserByUsernameApplicationName(user.UserName,
                        ConfigManager.Exchange.ApplicationName);
                    Store store = _storeService.GetDataById(new Guid(model.StoreId));

                    AddUserIsInStore(employee, store);

                    return
                        Json(new { result = "", message = MessageCode.saved, code = StatusCode.saved, content = fullName });
                }
                catch (Exception ex)
                {
                    return
                        Json(
                            new
                            {
                                result = StatusCode.failed,
                                message = ex.Message,
                                code = StatusCode.invalid,
                                content = fullName
                            });
                }
            }
            return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
        }

        #endregion Register

        #region Manage

        public ActionResult Manage(string id)
        {
            var model = new RegisterModel();
            Profiles profile = _profileService.GetProfileByUserId(new Guid(id));
            Users user = _userService.GetUserById(new Guid(id));
            //get roles
            string[] roles = Access.GetUserRoles(user.Username);
            Core.Entities.Roles role = _roleService.GetDataByName(roles[0]);
            //get store
            Guid storeId = user.Stores.Any() ? user.Stores.First().Id : new Guid();

            if (profile != null)
            {
                model.Address = profile.Address;
                model.BirthDate = profile.BirthDate.ToString(CultureInfo.InvariantCulture);
                model.BirthDay = profile.BirthDate.Day.ToString(CultureInfo.InvariantCulture);
                model.BirthMonth = profile.BirthDate.Month.ToString(CultureInfo.InvariantCulture);
                model.BirthYear = profile.BirthDate.Year.ToString(CultureInfo.InvariantCulture);
                model.Email = user.Email;
                model.FirstName = profile.FirstName;
                model.Gender = profile.Gender;
                model.LastName = profile.LastName;
                model.MiddleName = profile.MiddleName;
                model.Position = profile.Position;
                model.StoreList = _service.GetStoreList(storeId);
                model.RoleList = _service.GetRoleList(role.Id);
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
                    Users employee = _userService.GetUserByUsernameApplicationName(model.UserName,
                        ConfigManager.Exchange.ApplicationName);
                    MembershipUser user = Membership.GetUser(model.UserName, false);
                    Store store = _storeService.GetDataById(new Guid(model.StoreId));

                    employee.Roles.Clear();
                    employee.Stores.Clear();
                    _userService.SaveOrUpdate(employee);
                    //add roles and store
                    Roles.AddUserToRole(model.UserName, model.RoleName);
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

        #endregion Manage

        #region Profile Private Method

        private static void CreateProfile(RegisterModel model)
        {
            UserProfileBase profile = UserProfileBase.GetUserProfile(model.UserName);
            if (profile == null) return;
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.MiddleName = model.MiddleName;
            profile.Address = model.Address;
            profile.Gender = model.Gender;
            profile.Language = model.Language;
            profile.Position = model.Position;
            profile.BirthDate = Convert.ToDateTime(model.BirthDate);
            profile.Subscription = !string.IsNullOrEmpty(model.Subscription) ? model.Subscription : string.Empty;
            profile.Language = !string.IsNullOrEmpty(model.Language) ? model.Language : string.Empty;
            profile.Save();
        }

        #endregion Profile Private Method

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
                    return
                        "A user name for that e-mail address already exists. Please enter a different e-mail address.";

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
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        #endregion Helpers

        #region Test

        private bool CheckIfUserIsInStore(Users user, Store store)
        {
            bool userIsInStore = false;
            List<Store> stores = user.Stores.ToList();
            foreach (Store item in stores)
            {
                if (item.Equals(store))
                {
                    userIsInStore = true;
                    break;
                }
            }
            return userIsInStore;
        }

        private void AddUserIsInStore(Users user, Store store)
        {
            if (!CheckIfUserIsInStore(user, store))
            {
                store.AddUser(user);
                _storeService.SaveOrUpdate(store);
            }
        }

        #endregion Test
    }
}