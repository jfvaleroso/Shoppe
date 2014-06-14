using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class HelpController : Controller
    {
        //
        // GET: /Help/

        public ActionResult Index()
        {
            return View();
        }
    }
}