using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Exchange.Web.Models;
using Exchange.Core.Services.IServices;
using Exchange.Helper;
using Exchange.Core.Entities;
using System.Web.Profile;
using Exchange.Core.Services.Implementation;
using Exchange.Provider.Profile;
using Exchange.Helper.Common;



namespace Exchange.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {


        //private readonly IUserService userService;
        //private readonly IProfileService profileService;
        //private readonly IRoleService roleService;
        //private readonly NHMembershipProvider membershipProvider;
        //private readonly NHProfileProvider profileProvider;
        //private readonly NHRoleProvider roleProvider;
        //private readonly UserProfileBase userProfileBase;
        private readonly IStoreService storeService;
        private readonly IUserService userService;
        public AccountController(IStoreService storeService, IUserService userService)//(IUserService userService, IProfileService profileService, IRoleService roleService)
        {
            //this.profileService = profileService;
            //this.userService = userService;
            //this.roleService = roleService;
            //this.membershipProvider = Exchange.Web.Helper.Provider.membershipProvider;
            //this.profileProvider = Exchange.Web.Helper.Provider.profileProvider;
            //this.userProfileBase = Exchange.Web.Helper.Provider.userProfileBase;
            //this.roleProvider = Exchange.Web.Helper.Provider.roleProvider; //new NHRoleProvider(this.userService, this.roleService);

            this.storeService = storeService;
            this.userService= userService;
        }
       
       

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            //var userRoles = System.Web.Security.Roles.GetAllRoles();
            //var stores = _storeService.GetAll();
            var model = new RegisterModel();
            //{
            //    UserRoles = userRoles.Select(x => new SelectListItem
            //    {
            //        Value = x,
            //        Text = x
            //    }),

            //    StoreList = stores.Select(y => new SelectListItem
            //    {
            //        Value = y.Code,
            //        Text = y.Name
            //    })
            //};
            return View(model);

        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                   // List<Users> users = userService.GetAll().ToList();
                    string password = Base.GenearateKey(8);
                    MembershipCreateStatus status = MembershipCreateStatus.UserRejected;
                    Membership.CreateUser(model.UserName, password, model.UserName + "@gmail.com","what is","yes",true,null, out status);
                    MembershipUser user = Membership.GetUser(model.UserName, false);
                    user.Email = "test@gmail.com";
                    Membership.UpdateUser(user);




                  // Profiles profile = this.profileProvider.CreateProfile(model.UserName, true);
                    
                   UserProfileBase profile = UserProfileBase.GetUserProfile(model.UserName);

                   

                    if (profile != null)
                    {
                        profile.FirstName = "jeffrey";
                        profile.LastName = "Valeroso";
                        profile.Address = "Taytay, Rizal";
                        profile.Gender = "M";
                        profile.Language = "English";
                        profile.Position = "Senior Software Developer";
                        profile.Subscription = "None";
                        profile.Save();
                      
                    }


                   bool check= System.Web.Security.Roles.RoleExists("MVP");
                 
                    string[] usernames = new string[] { model.UserName};
                    string[] roles = new string[] { "MVP" };

                    System.Web.Security.Roles.AddUsersToRoles(usernames, roles);
                    //add user to role
                    //System.Web.Security.Roles.AddUserToRole(model.UserName, model.RoleName);

                    Store store = new Store();
                    store.Address = "Makati City";
                    store.Active = true;
                    store.Code = "MC2012";
                    store.Name = "Greenbelt";
                    store.DateCreated = DateTime.Now;
                    store.PermitNo = "1223423";

                    Users employee = this.userService.GetUserByUsernameApplicationName(user.UserName, "Exchange");
                    store.AddEmployee(employee);

                  //  this.storeService.SaveOrUpdate(store);
                    
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }






        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = false;
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {

            ViewBag.ReturnUrl = Url.Action("Manage");

            if (ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {

                    MembershipUser user = Membership.GetUser(User.Identity.Name, true);
                    changePasswordSucceeded = user.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }




        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }



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
