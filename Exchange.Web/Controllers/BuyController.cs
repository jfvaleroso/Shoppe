using Exchange.Core.Services.IServices;
using Exchange.Web.Helper;
using Exchange.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class BuyController : Controller
    {
        private readonly Service service;
        private readonly IProductService productService;
        public BuyController(IProductService productService)
        {
            this.productService = productService;
            this.service = new Service(this.productService);
        }

        public ActionResult Index()
        {
            BuyModel model = new BuyModel();
            model.ProductList = this.service.GetProductList(0);
            return View(model);
        }
    }
}
