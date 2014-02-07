using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Exchange.Web.Helper
{
    public class Access
    {
        public static bool IsSuperAdmin()
        {
           bool superAdmin= Roles.IsUserInRole("Super Admin");
           return superAdmin;
        }

        public static string[] GetUserRoles(string username)
        {
          return System.Web.Security.Roles.GetRolesForUser(username);
        }
    }
}