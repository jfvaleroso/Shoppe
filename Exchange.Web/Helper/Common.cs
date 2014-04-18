using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Provider.Profile;
using Exchange.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exchange.Web.Helper
{
    public class Common
    {
        private readonly IUserService userService;
        public Common(IUserService userService)
        {
            this.userService = userService;
        }

        public Common()
        {

        }

        public static string GetCurrentUser()
        {
            var profile= UserProfileBase.GetUserProfile(HttpContext.Current.User.Identity.Name);
            return Base.GenerateFullName(profile.FirstName,profile.MiddleName, profile.LastName);    
        }
        public ProfileModel GetCurrentUserProfile()
        {
            var user = UserProfileBase.GetUserProfile(HttpContext.Current.User.Identity.Name);
            ProfileModel profile = new ProfileModel();
            profile.Name = Base.GenerateFullName(user.FirstName, user.MiddleName, user.LastName);
            profile.UserId = user.Users_Id.ToString();
            return profile;
        }

        public StoreModel GetCurrentUserStoreAccess()
        {
            Users user = this.userService.GetUserByUsernameApplicationName(HttpContext.Current.User.Identity.Name, ConfigManager.Exchange.ApplicationName);
            StoreModel model = new StoreModel();
            model.Id = user.Stores.Select(x => x.Id).FirstOrDefault().ToString();
            model.StoreName = user.Stores.Select(x => x.Name).FirstOrDefault();
            model.StoreCode = user.Stores.Select(x => x.Code).FirstOrDefault();
            return model;
            
        }



      
    }
}