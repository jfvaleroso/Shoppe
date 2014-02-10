using Castle.Windsor;
using Exchange.Core.Services.IServices;
using Exchange.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exchange.Web.Filters
{
    public class AuditAttribute : System.Web.Mvc.ActionFilterAttribute
    {

        WindsorContainer container = (WindsorContainer)System.Web.HttpContext.Current.Application["Windsor"];
        private readonly IActivityLogsService activityLogsService;

        public AuditAttribute()
        {
             this.activityLogsService = container.Resolve<IActivityLogsService>();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;



            //Generate an audit
            AuditModel audit = new AuditModel()
            {
                //Your Audit Identifier     
                AuditID = Guid.NewGuid(),
                //Our Username (if available)
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                //The IP Address of the Request
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                //The URL that was accessed
                AreaAccessed = request.RawUrl,
                //Creates our Timestamp
                TimeAccessed = DateTime.UtcNow,
                //controller and action
                Action = string.Format("Controller: {0} | Action: {1}", controllerName, actionName),
                //result
                Result = GetResult(filterContext.Result)
            };


            this.activityLogsService.CreateAuditLog(audit.UserName, audit.IPAddress, audit.AreaAccessed, audit.TimeAccessed, audit.Action, audit.Result);

        }

        public static string GetResult(ActionResult actionResult)
        {
            if (actionResult is JsonResult)
            {
                JsonResult result = (JsonResult)actionResult;
                var data = new RouteValueDictionary(result.Data);
                StringBuilder sb = new StringBuilder();
                foreach (var item in data)
                {
                    sb.Append(string.Format("{0} : {1}; ", item.Key, item.Value));
                }
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}