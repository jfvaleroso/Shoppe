﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Exchange.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi_action",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );


            config.Routes.MapHttpRoute(
                  name: "DefaultApi_Purchase",
                  routeTemplate: "api/{controller}/{action}/{quantity}/{grams}/{rate}/{total}",
                  defaults: new { id = RouteParameter.Optional }
              );
        }
    }
}
