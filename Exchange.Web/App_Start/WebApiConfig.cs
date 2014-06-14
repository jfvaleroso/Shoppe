using System.Web.Http;

namespace Exchange.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute("DefaultApi_action", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute("DefaultApi_Purchase",
                "api/{controller}/{action}/{quantity}/{grams}/{rate}/{total}", new { id = RouteParameter.Optional }
                );
        }
    }
}