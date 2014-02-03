using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Web.Areas.Admin.Models;
using Exchange.Web.Filters;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using System.Globalization;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        #region Constructor
        private readonly IProductService productService;
        private readonly IProductTypeService productTypeService;
        private readonly IProductHistoryService productHistoryService;
        private Exchange.Web.Helper.Service service;
        public ProductController(IProductService productService, IProductTypeService productTypeService, IProductHistoryService productHistoryService)
        {
            this.productService = productService;
            this.productTypeService = productTypeService;
            this.productHistoryService = productHistoryService;
            this.service = new Helper.Service(this.productTypeService);
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
                var productList =this.productService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    Active = x.Active,
                    Code = x.Code,
                    Cost = string.Format(new CultureInfo("en-PH"),"{0:C}", x.Cost),
                    Description = x.Description,
                    Id = x.Id,
                    SecuredId = Base.Encrypt(x.Id.ToString()),
                    Name = x.Name,
                    ProductType= x.ProductType.Name
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });

            }
        }

        [CrytoProvider]
        public ActionResult History(int id)
        {
            try
            {
                ProductModel model = new ProductModel();
                Product product = this.productService.GetDataById(id);
                model.Id = product.Id;
                model.Active = product.Active;
                model.Code =  product.Code;
                model.Cost = product.Cost;
                model.Name = product.Name;
                model.DateModified = product.DateModified != null ? product.DateModified : product.DateCreated;
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
                var productList = this.productHistoryService.GetDataListWithPagingAndSearch(id, jtStartIndex, jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    
                    Cost = string.Format(new CultureInfo("en-PH"), "{0:C}", x.Cost),
                    ProductName = string.Format("{0}- {1}:{2}", x.Product.ProductType.Name, x.Product.Code, x.Product.Name),
                    ModifiedBy= x.ModifiedBy,
                    DateModified= x.DateModified
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });
            }
        }

        #endregion
        #region New
        public ActionResult New()
        {
            ProductModel product = new ProductModel();
            product.ProductTypeList = this.service.GetProductTypeList(0);
            return View(product);
        }
        [HttpPost]
        public JsonResult New(ProductModel model)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.productService.CheckDataIfExists(model);
                    if (!ifExists)
                    {
                        Product product = new Product();
                        product.Active = true;
                        product.DateCreated = DateTime.Now;
                        product.CreatedBy = User.Identity.Name.ToString();
                        product.Name = model.Name;
                        product.Code = model.Code.ToUpper();
                        product.Cost = model.Cost;
                        product.Description = model.Description;
                        product.ProductType = this.productTypeService.GetDataById(model.ProductTypeId);
                        product.Id = this.productService.Create(product);
                        model.Id = product.Id;
                        return Json(new { result = Base.Encrypt(product.Id.ToString()), message = MessageCode.saved, code = StatusCode.saved, content = product.Name.ToString() });

                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content = model.Name });
            }


        }
        #endregion
        #region Manage
        [CrytoProvider]
        public ActionResult Manage(int id)
        {
            try
            {
                ProductModel model = new ProductModel();
                Product product = this.productService.GetDataById(id);
                model.Id = product.Id;
                model.Active = product.Active;
                model.Code = product.Code;
                model.Cost = product.Cost;
                model.Name = product.Name;
                model.Description = product.Description;
                model.ProductTypeList = this.service.GetProductTypeList(product.ProductType.Id);
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
               
                int productTypeId= model.ProductTypeId > 0 ?  model.ProductTypeId : 0;
                model.ProductType = this.productTypeService.GetDataById(productTypeId);
                if (ModelState.IsValid)
                {
                    bool ifExists = this.productService.CheckDataIfExists(model);
                    if (!ifExists)
                    {
                        //product
                        Product product = new Product();
                        product = this.productService.GetDataById(model.Id);
                        decimal previousCost = product.Cost;
                        decimal latestCost = model.Cost;
                        product.Code = model.Code.ToUpper();
                        product.Cost = latestCost;
                        product.Description = model.Description;
                        product.Name = model.Name; 
                        product.Active = model.Active;
                        product.DateModified = DateTime.Now;
                        product.ModifiedBy = User.Identity.Name.ToString();
                        this.productService.SaveChanges(product);
                        //save to history
                        bool costChanged =!previousCost.Equals(latestCost);
                        if(costChanged){
                        ProductHistory productHistory = new ProductHistory();
                        productHistory.Cost = model.Cost;
                        productHistory.Product = product;
                        productHistory.DateModified = DateTime.Now;
                        productHistory.ModifiedBy = User.Identity.Name.ToString();
                        this.productHistoryService.Save(productHistory);
                        }
                        return Json(new { result = Base.Encrypt(product.Id.ToString()), message = MessageCode.modified, code = StatusCode.modified, content = product.Name });
                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed });
            }

        }
        #endregion
        #region Item
        [CrytoProvider]
        public ActionResult Item(int id)
        {
            try
            {
                Product product = this.productService.GetDataById(id);
                if (product != null)
                    return View(product);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        public JsonResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    this.productTypeService.Delete(id);
                    return Json(new { result = StatusCode.done, message = MessageCode.deleted, code = StatusCode.deleted });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString() });
            }
            return Json(new { result = StatusCode.failed, message = MessageCode.error });
        }
        #endregion
        #region Common
        public ActionResult CheckAvailability(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                bool ifExists = this.productService.CheckDataIfExists(param);
                if (!ifExists)
                {
                    return Json(new { result = StatusCode.valid, MessageCode.valid, code = StatusCode.valid });
                }
                else
                {
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
            }
            return Json(new { result = StatusCode.empty, message = MessageCode.empty, code = StatusCode.empty });
        }
        #endregion

    }
}
