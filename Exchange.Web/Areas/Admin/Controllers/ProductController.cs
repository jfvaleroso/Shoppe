using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Web.Areas.Admin.Models;
using Exchange.Web.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        #region Constructor

        private readonly IProductHistoryService _productHistoryService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly Service _service;

        public ProductController(IProductService productService, IProductTypeService productTypeService,
            IProductHistoryService productHistoryService)
        {
            _productService = productService;
            _productTypeService = productTypeService;
            _productHistoryService = productHistoryService;
            _service = new Service(_productTypeService);
        }

        #endregion Constructor

        #region Index

        public ActionResult Index()
        {
            List<Product> data = _productService.GetAllData();
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
                    x.Id,
                    x.Name,
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

        public ActionResult History(string id)
        {
            try
            {
                var model = new ProductModel();
                Product product = _productService.GetDataById(new Guid(id));
                model.Id = product.Id;
                model.Active = product.Active;
                model.Code = product.Code;
                model.Cost = product.Cost;
                model.Name = product.Name;
                model.DateModified = product.DateModified ?? product.DateCreated;
                model.ProductType = product.ProductType;
                model.Description = product.Description;
                ViewBag.RenderCost = string.Format(new CultureInfo("en-PH"), "{0:C}", product.Cost);
                if (product != null)
                    return View(model);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public JsonResult ProductHistoryListWithPaging(string id = "0", int jtStartIndex = 1, int jtPageSize = 20)
        {
            try
            {
                long total = 0;
                List<ProductHistory> productList = _productHistoryService.GetDataListWithPagingAndSearch(id,
                    jtStartIndex,
                    jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    Cost = string.Format(new CultureInfo("en-PH"), "{0:C}", x.Cost),
                    ProductName =
                        string.Format("{0}- {1}:{2}", x.Product.ProductType.Name, x.Product.Code, x.Product.Name),
                    x.ModifiedBy,
                    x.DateModified
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

        #region New

        public ActionResult New()
        {
            var product = new ProductModel();
            product.ProductTypeList = _service.GetProductTypeList(new Guid());
            return View(product);
        }

        [HttpPost]
        public JsonResult New(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = _productService.CheckDataIfExists(model);
                    if (!ifExists)
                    {
                        var product = new Product();
                        product.Active = true;
                        product.DateCreated = DateTime.Now;
                        product.CreatedBy = User.Identity.Name;
                        product.Name = model.Name;
                        product.Code = model.Code.ToUpper();
                        product.Cost = model.Cost;
                        product.Description = model.Description;
                        product.ProductType = _productTypeService.GetDataById(new Guid(model.ProductTypeId));
                        product.Id = _productService.Create(product);
                        model.Id = product.Id;
                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(product.Id.ToString()),
                                    message = MessageCode.saved,
                                    code = StatusCode.saved,
                                    content = product.Name
                                });
                    }
                    return
                        Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return
                    Json(
                        new
                        {
                            result = StatusCode.failed,
                            message = ex.Message,
                            code = StatusCode.failed,
                            content = model.Name
                        });
            }
        }

        #endregion New

        #region Manage

        public ActionResult Manage(string id)
        {
            try
            {
                var model = new ProductModel();
                Product product = _productService.GetDataById(new Guid(id));
                model.Id = product.Id;
                model.Active = product.Active;
                model.Code = product.Code;
                model.Cost = product.Cost;
                model.Name = product.Name;
                model.Description = product.Description;
                model.ProductTypeList = _service.GetProductTypeList(product.ProductType.Id);
                if (product != null)
                    return View(model);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Manage(ProductModel model)
        {
            try
            {
                string productTypeId = model.ProductTypeId ?? string.Empty;
                model.ProductType = _productTypeService.GetDataById(new Guid(productTypeId));
                if (ModelState.IsValid)
                {
                    bool ifExists = _productService.CheckDataIfExists(model);
                    if (!ifExists)
                    {
                        //product
                        var product = new Product();
                        product = _productService.GetDataById(model.Id);
                        decimal previousCost = product.Cost;
                        decimal latestCost = model.Cost;
                        product.Code = model.Code.ToUpper();
                        product.Cost = latestCost;
                        product.Description = model.Description;
                        product.Name = model.Name;
                        product.Active = model.Active;
                        product.DateModified = DateTime.Now;
                        product.ModifiedBy = User.Identity.Name;
                        _productService.SaveChanges(product);
                        //save to history
                        bool costChanged = !previousCost.Equals(latestCost);
                        if (costChanged)
                        {
                            var productHistory = new ProductHistory();
                            productHistory.Cost = model.Cost;
                            productHistory.Product = product;
                            productHistory.DateModified = DateTime.Now;
                            productHistory.ModifiedBy = User.Identity.Name;
                            _productHistoryService.Save(productHistory);
                        }
                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(product.Id.ToString()),
                                    message = MessageCode.modified,
                                    code = StatusCode.modified,
                                    content = product.Name
                                });
                    }
                    return
                        Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message, code = StatusCode.failed });
            }
        }

        #endregion Manage

        #region Item

        public ActionResult Item(string id)
        {
            try
            {
                Product product = _productService.GetDataById(new Guid(id));
                if (product != null)
                    return View(product);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion Item

        #region Delete

        public JsonResult Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _productService.Delete(new Guid(id));
                    return Json(new { result = StatusCode.done, message = MessageCode.deleted, code = StatusCode.deleted });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message });
            }
            return Json(new { result = StatusCode.failed, message = MessageCode.error });
        }

        #endregion Delete

        #region Common

        public ActionResult CheckAvailability(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                bool ifExists = _productService.CheckDataIfExists(param);
                if (!ifExists)
                {
                    return Json(new { result = StatusCode.valid, MessageCode.valid, code = StatusCode.valid });
                }
                return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
            }
            return Json(new { result = StatusCode.empty, message = MessageCode.empty, code = StatusCode.empty });
        }

        #endregion Common
    }
}