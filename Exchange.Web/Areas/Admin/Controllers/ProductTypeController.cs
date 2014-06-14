using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        #region Constructor

        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        #endregion Constructor

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
                List<ProductType> productList = _productTypeService.GetDataListWithPagingAndSearch(searchString,
                    jtStartIndex, jtPageSize, out total);
                var collection = productList.Select(x => new
                {
                    x.Active,
                    x.Code,
                    x.Description,
                    x.Id,
                    SecuredId = Base.Encrypt(x.Id.ToString()),
                    x.Name
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
            return View();
        }

        [HttpPost]
        public JsonResult New(ProductType productType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = _productTypeService.CheckDataIfExists(productType);
                    if (!ifExists)
                    {
                        productType.Code = productType.Code.ToUpper();
                        productType.Active = true;
                        productType.DateCreated = DateTime.Now;
                        productType.CreatedBy = User.Identity.Name;
                        //  productType.Id = _._productTypeService.Create(productType);
                        _productTypeService.SaveOrUpdate(productType);

                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(productType.Id.ToString()),
                                    message = MessageCode.saved,
                                    code = StatusCode.saved,
                                    content = productType.Name
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
                            content = productType.Name
                        });
            }
        }

        #endregion New

        #region Manage

        public ActionResult Manage(string id)
        {
            try
            {
                ProductType productType = _productTypeService.GetDataById(new Guid(id));
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
                    bool ifExists = _productTypeService.CheckDataIfExists(productType);
                    if (!ifExists)
                    {
                        var entity = new ProductType();
                        entity = _productTypeService.GetDataById(productType.Id);
                        entity.Code = productType.Code.ToUpper();
                        entity.Name = productType.Name;
                        entity.Description = productType.Description;
                        entity.DateModified = DateTime.Now;
                        entity.ModifiedBy = User.Identity.Name;
                        entity.Active = productType.Active;
                        _productTypeService.SaveChanges(entity);
                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(productType.Id.ToString()),
                                    message = MessageCode.modified,
                                    code = StatusCode.modified,
                                    content = productType.Name
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

        #region Display Item

        public ActionResult Item(string id)
        {
            try
            {
                ProductType productType = _productTypeService.GetDataById(new Guid(id));
                if (productType != null)
                    return View(productType);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion Display Item

        #region Delete

        public JsonResult Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _productTypeService.Delete(new Guid(id));
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
                bool ifExists = _productTypeService.CheckDataIfExists(param);
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