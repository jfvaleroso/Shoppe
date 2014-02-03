using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Helper;
using Exchange.Web.Filters;
using Exchange.Web.Models;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        #region Constructor
        private readonly IProductTypeService productTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }
        #endregion
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ProductTypeListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
           
            try
            {
                long total = 0;
                var productList = this.productTypeService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    Active = x.Active,
                    Code = x.Code,
                    Description = x.Description,
                    Id = x.Id,
                    SecuredId= Base.Encrypt(x.Id.ToString()),
                    Name = x.Name
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
            return View();
        }
        [HttpPost]
        public JsonResult New(ProductType productType)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.productTypeService.CheckDataIfExists(productType);
                    if (!ifExists)
                    {
                        productType.Code = productType.Code.ToUpper();
                        productType.Active = true;
                        productType.DateCreated = DateTime.Now;
                        productType.CreatedBy = User.Identity.Name.ToString();
                      //  productType.Id = this.productTypeService.Create(productType);
                        this.productTypeService.SaveOrUpdate(productType);
                        
                        return Json(new { result = Base.Encrypt(productType.Id.ToString()), message = MessageCode.saved, code = StatusCode.saved, content = productType.Name.ToString() });

                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content = productType.Name.ToString() });
            }

        }
        #endregion
        #region Manage
        [CrytoProvider]
        public ActionResult Manage(int id)
        {
            try
            {
                ProductType productType = this.productTypeService.GetDataById(id);
                if (productType != null)
                    return View(productType);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Manage(ProductType productType)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.productTypeService.CheckDataIfExists(productType);
                    if (!ifExists)
                    {

                        ProductType entity = new ProductType();
                        entity = this.productTypeService.GetDataById(productType.Id);
                        entity.Code = productType.Code.ToUpper();
                        entity.Name = productType.Name;
                        entity.Description = productType.Description;
                        entity.DateModified = DateTime.Now;
                        entity.ModifiedBy = User.Identity.Name;
                        entity.Active = productType.Active;
                        this.productTypeService.SaveChanges(entity);
                        return Json(new { result = Base.Encrypt(productType.Id.ToString()), message = MessageCode.modified, code = StatusCode.modified, content = productType.Name });
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
        #region Display Item
        [CrytoProvider]
        public ActionResult Item(int id)
        {
            try
            {
                ProductType productType = this.productTypeService.GetDataById(id);
                if (productType != null)
                    return View(productType);

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
                bool ifExists = this.productTypeService.CheckDataIfExists(param);
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
