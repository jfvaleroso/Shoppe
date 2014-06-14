using Castle.Windsor;
using Exchange.Core.Services.IServices;
using Exchange.Web.Models;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exchange.Web.Filters
{
    public class AuditAttribute : ActionFilterAttribute
    {
        private readonly IActivityLogsService activityLogsService;
        private readonly WindsorContainer container = (WindsorContainer)HttpContext.Current.Application["Windsor"];

        public AuditAttribute()
        {
            activityLogsService = container.Resolve<IActivityLogsService>();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            //Generate an audit
            var audit = new AuditModel
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

            activityLogsService.CreateAuditLog(audit.UserName, audit.IPAddress, audit.AreaAccessed, audit.TimeAccessed,
                audit.Action, audit.Result);
        }

        public static string GetResult(ActionResult actionResult)
        {
            if (actionResult is JsonResult)
            {
                var result = (JsonResult)actionResult;
                var data = new RouteValueDictionary(result.Data);
                var sb = new StringBuilder();
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