using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;
using Exchange.Helper;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Web.Filters;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class StoreController : Controller
    {

        #region Constructor
        private readonly IStoreService storeService;
        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        #endregion
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
                var storeList = this.storeService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = storeList.Select(x => new
                {
                    Active = x.Active,
                    Id = x.Id,
                    
                    Code = x.Code,
                    Name = x.Name,
                    Address= x.Address,
                    PermitNo= x.PermitNo,
                    UserCount = x.UsersInStore.Count().ToString()
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
        public JsonResult New(Store store)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.storeService.CheckDataIfExists(store);
                    if (!ifExists)
                    {
                        store.Code = store.Code.ToUpper();
                        store.Active = true;
                        store.DateCreated = DateTime.Now;
                        store.CreatedBy = User.Identity.Name.ToString();
                        //  store.Id = this.storeService.Create(store);
                        this.storeService.SaveOrUpdate(store);

                        return Json(new { result = Base.Encrypt(store.Id.ToString()), message = MessageCode.saved, code = StatusCode.saved, content = store.Name.ToString() });

                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content = store.Name.ToString() });
            }

        }
        #endregion
        #region Manage
        
        public ActionResult Manage(string id)
        {
            try
            {
                Store store = this.storeService.GetDataById(new Guid(id));
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
                    bool ifExists = this.storeService.CheckDataIfExists(store);
                    if (!ifExists)
                    {

                        Store entity = new Store();
                        entity = this.storeService.GetDataById(store.Id);
                        entity.Code = store.Code.ToUpper();
                        entity.Address = store.Address;
                        entity.Name = store.Name;
                        entity.DateModified = DateTime.Now;
                        entity.ModifiedBy = User.Identity.Name.ToString();
                        entity.PermitNo = store.PermitNo;
                        entity.TelephoneNo = store.TelephoneNo;
                        entity.TINNo = store.TINNo;
                        entity.Active = store.Active;
                        this.storeService.SaveChanges(entity);
                        return Json(new { result = Base.Encrypt(store.Id.ToString()), message = MessageCode.modified, code = StatusCode.modified, content = store.Name });
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
        
        public ActionResult Item(string id)
        {
            try
            {
                Store store = this.storeService.GetDataById(new Guid(id));
                if (store != null)
                    return View(store);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        public JsonResult Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    this.storeService.Delete(new Guid(id));
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
                bool ifExists = this.storeService.CheckDataIfExists(param);
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
