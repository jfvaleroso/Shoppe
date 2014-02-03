using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Configuration;
using Exchange.Web.Models;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        System.Configuration.Configuration configuration;
        ExchangeConfig config;
        public SettingController()
        {
            this.configuration = ConfigManager.GetConfig();
            this.config = ConfigManager.GetSection(this.configuration);
        }


        public ActionResult Index()
        {
            SettingModel model = new SettingModel();
            model.CompanyName = this.config.CompanyName;
            model.Owner = this.config.Owner;
            return View(model);
        }

        public ActionResult Modify()
        {
            SettingModel model = new SettingModel();
            model.CompanyName = this.config.CompanyName;
            model.Owner = this.config.Owner;
            return View(model);
        }
        [HttpPost]
        public ActionResult Modify(SettingModel model)
        {

            if (ModelState.IsValid)
            {
                this.config.CompanyName = model.CompanyName;
                this.config.Owner = model.Owner;
                this.configuration.Save();
                return RedirectToAction("Index");
            }
            return View(model);



        }
    }
}
