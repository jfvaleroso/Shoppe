using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class ExchangeController : Controller
    {
        #region Constructor

        private readonly IProductService _productService;

        public ExchangeController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion Constructor

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
                List<Product> productList = _productService.GetDataListWithPagingAndSearch(searchString, jtStartIndex,
                    jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    x.Active,
                    x.Code,
                    Cost = string.Format(new CultureInfo("en-PH"), "{0:C}", x.Cost),
                    x.Description,
                    Id = x.Id.ToString(),
                    x.Name,
                    DateModified = x.DateModified ?? x.DateCreated,
                    ProductType = x.ProductType != null ? x.ProductType.Name : string.Empty
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });
            }
        }

        #endregion Index
    }
}