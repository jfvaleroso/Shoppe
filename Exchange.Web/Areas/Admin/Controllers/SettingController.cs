using Exchange.Configuration;
using Exchange.Web.Models;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly ExchangeConfig _config;
        private readonly System.Configuration.Configuration _configuration;

        public SettingController()
        {
            _configuration = ConfigManager.GetConfig();
            _config = ConfigManager.GetSection(_configuration);
        }

        public ActionResult Index()
        {
            var model = new SettingModel();
            model.CompanyName = _config.CompanyName;
            model.Owner = _config.Owner;
            return View(model);
        }

        public ActionResult Modify()
        {
            var model = new SettingModel();
            model.CompanyName = _config.CompanyName;
            model.Owner = _config.Owner;
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(SettingModel model)
        {
            if (ModelState.IsValid)
            {
                _config.CompanyName = model.CompanyName;
                _config.Owner = model.Owner;
                _configuration.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}