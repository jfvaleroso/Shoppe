using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class ActivityLogsController : Controller
    {
        private readonly IActivityLogsService activityLogsService;
        public ActivityLogsController(IActivityLogsService activityLogsService)
        {
            this.activityLogsService = activityLogsService;
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
                var activityLogsList = !string.IsNullOrEmpty(searchString) ?
                    this.activityLogsService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total) :
                   this.activityLogsService.GetDataListWithPaging(jtStartIndex, jtPageSize, out total);
                return Json(new { Result = "OK", Records = activityLogsList, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.InnerException.Message });

            }
        }

        public ActionResult Item(long id)
        {
            try
            {
                ActivityLogs activityLogs = this.activityLogsService.GetDataById(id);
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
