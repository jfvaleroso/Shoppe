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
        public static string GetCurrentUser()
        {
            var profile= UserProfileBase.GetUserProfile(HttpContext.Current.User.Identity.Name);
            return Base.GenerateFullName(profile.FirstName,profile.MiddleName, profile.LastName);    
        }
    }
}