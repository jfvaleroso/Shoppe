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
    public class StoreController : Controller
    {
        #region Constructor

        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        #endregion Constructor

        #region Index

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult StoreListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                List<Store> storeList = _storeService.GetDataListWithPagingAndSearch(searchString, jtStartIndex,
                    jtPageSize, out total);
                var collection = storeList.Select(x => new
                {
                    x.Active,
                    x.Id,
                    x.Code,
                    x.Name,
                    x.Address,
                    x.PermitNo,
                    UserCount = x.UsersInStore.Count().ToString()
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
        public JsonResult New(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = _storeService.CheckDataIfExists(store);
                    if (!ifExists)
                    {
                        store.Code = store.Code.ToUpper();
                        store.Active = true;
                        store.DateCreated = DateTime.Now;
                        store.CreatedBy = User.Identity.Name;
                        //  store.Id = _storeService.Create(store);
                        _storeService.SaveOrUpdate(store);

                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(store.Id.ToString()),
                                    message = MessageCode.saved,
                                    code = StatusCode.saved,
                                    content = store.Name
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
                            content = store.Name
                        });
            }
        }

        #endregion New

        #region Manage

        public ActionResult Manage(string id)
        {
            try
            {
                Store store = _storeService.GetDataById(new Guid(id));
                if (store != null)
                    return View(store);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Manage(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = _storeService.CheckDataIfExists(store);
                    if (!ifExists)
                    {
                        var entity = new Store();
                        entity = _storeService.GetDataById(store.Id);
                        entity.Code = store.Code.ToUpper();
                        entity.Address = store.Address;
                        entity.Name = store.Name;
                        entity.DateModified = DateTime.Now;
                        entity.ModifiedBy = User.Identity.Name;
                        entity.PermitNo = store.PermitNo;
                        entity.TelephoneNo = store.TelephoneNo;
                        entity.TINNo = store.TINNo;
                        entity.Active = store.Active;
                        _storeService.SaveChanges(entity);
                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(store.Id.ToString()),
                                    message = MessageCode.modified,
                                    code = StatusCode.modified,
                                    content = store.Name
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
                Store store = _storeService.GetDataById(new Guid(id));
                if (store != null)
                    return View(store);
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
                    _storeService.Delete(new Guid(id));
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
                bool ifExists = _storeService.CheckDataIfExists(param);
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