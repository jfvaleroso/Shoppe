using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class ActivityLogsController : Controller
    {
        private readonly IActivityLogsService _activityLogsService;

        public ActivityLogsController(IActivityLogsService activityLogsService)
        {
            _activityLogsService = activityLogsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ActivityLogsListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                List<ActivityLogs> activityLogsList = !string.IsNullOrEmpty(searchString)
                    ? _activityLogsService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize,
                        out total)
                    : _activityLogsService.GetDataListWithPaging(jtStartIndex, jtPageSize, out total);
                return Json(new { Result = "OK", Records = activityLogsList, TotalRecordCount = total },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.InnerException.Message });
            }
        }

        public ActionResult Item(string id)
        {
            try
            {
                ActivityLogs activityLogs = _activityLogsService.GetDataById(new Guid(id));
                if (activityLogs != null)
                    return View(activityLogs);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }
    }
}