using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using Castle.Windsor;
using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Providers;
using Exchange.Web.Areas.Admin.Models;
using Roles = System.Web.Security.Roles;

namespace Exchange.Web.Helper
{
    public class Initialize
    {
        private readonly WindsorContainer _container = (WindsorContainer)HttpContext.Current.Application["Windsor"];
        private static IUserService _userService;
        private static IStoreService _storeService;

        public Initialize()
        {
            if (!Settings.EnableInitialization) return;
            _userService = _container.Resolve<IUserService>(); ;
            _storeService = _container.Resolve<IStoreService>(); ;
        }

        public void ActivateInitialUser()
        {
            if (!Settings.EnableInitialization) return;
            MembershipCreateStatus status;
            var userName = Base.GenerateUsername("Jeffrey", "Fuensalida", "Valeroso");
            Membership.CreateUser(userName, "admin@2014", "jfvaleroso.smart@gmail.com", "na", "na", true, null,
                out status);

            var user = Membership.GetUser(userName, false);
            var profile = new RegisterModel
            {
                FirstName = "Jeffrey",
                LastName = "Valeroso",
                MiddleName = "Fuensalida",
                Address = "Manila, Philippines",
                Gender = "M",
                Language = "EN",
                Position = "Software Developer",
                BirthDate = "10/29/1986",
                UserName = userName
            };

            CreateProfile(profile);
            //create Admin Role
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            if (!Roles.RoleExists("Super Admin"))
            {
                Roles.CreateRole("Super Admin");
            }


            //Add user to Role
            if (!Roles.IsUserInRole(userName, "Super Admin"))
            {
                Roles.AddUserToRole(userName, "Super Admin");
            }

            //Create new strore
            var store = new Store
            {
                Name = "Main",
                Address = "Manila, Philippines",
                Active = true,
                Code = "000",
                CreatedBy = "Admin",
                DateCreated = DateTime.Now,
                PermitNo = "NA",
                TINNo = "NA"
            };
            _storeService.Create(store);



            var employee = _userService.GetUserByUsernameApplicationName(userName,
                ConfigManager.Exchange.ApplicationName);
            var myStore = _storeService.GetDataById(store.Id);

            if (!CheckIfUserIsInStore(employee, myStore))
            {
                store.AddUser(employee);
                _storeService.SaveOrUpdate(myStore);
            }
        }

        private static void CreateProfile(RegisterModel model)
        {
            var profile = UserProfileBase.GetUserProfile(model.UserName);
            if (profile == null) return;
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.MiddleName = model.MiddleName;
            profile.Address = model.Address;
            profile.Gender = model.Gender;
            profile.Position = model.Position;
            profile.BirthDate = Convert.ToDateTime(model.BirthDate);
            profile.Subscription = !string.IsNullOrEmpty(model.Subscription) ? model.Subscription : string.Empty;
            profile.Language = !string.IsNullOrEmpty(model.Language) ? model.Language : string.Empty;
            profile.Save();
        }

        private static bool CheckIfUserIsInStore(Users user, Store store)
        {
            bool userIsInStore = false;
            var stores = user.Stores.ToList();
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
    }
}