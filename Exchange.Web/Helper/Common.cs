using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Provider.Profile;
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

        public string GetCurrentUserStoreAccess()
        {
            Users user = this.userService.GetUserByUsernameApplicationName(HttpContext.Current.User.Identity.Name, ConfigManager.Exchange.ApplicationName);       
            return string.Join(",", user.Stores.Select(x => x.Name));
        }

      
    }
}