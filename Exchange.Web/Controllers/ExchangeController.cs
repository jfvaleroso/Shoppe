using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Web.Areas.Admin.Models;
using Exchange.Web.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class ExchangeController : Controller
    {
         #region Constructor
        private readonly IProductService productService;
       
        private Exchange.Web.Helper.Service service;
        public ExchangeController(IProductService productService)
        {
            this.productService = productService;
        }
        #endregion



        #region Index
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ProductListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                var productList = this.productService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    Active = x.Active,
                    Code = x.Code,
                    Cost = string.Format(new CultureInfo("en-PH"), "{0:C}", x.Cost),
                    Description = x.Description,
                    Id = x.Id.ToString(),
                    
                    Name = x.Name,
                    DateModified= x.DateModified != null ? x.DateModified : x.DateCreated,
                    ProductType = x.ProductType.Name
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });

            }
        }

      

        #endregion

    }
}
