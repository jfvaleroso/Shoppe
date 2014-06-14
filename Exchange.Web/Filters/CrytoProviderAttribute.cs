using Exchange.Web.Helper;
using System.Web.Mvc;

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