using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Web.Helper;

namespace Exchange.Web.Filters
{
    
    public class CrytoProviderAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.ValueProvider = new CryptoProvider(filterContext.RouteData);
        }
    }
}

