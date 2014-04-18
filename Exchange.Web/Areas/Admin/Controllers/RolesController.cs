using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Web.Filters;
using Exchange.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        #region Constructor
        private readonly IRoleService roleService;
        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        #endregion
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DataListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
           
            try
            {
                long total = 0;
                var roleList = this.roleService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = roleList.Select(x => new
                {
                   RoleName= x.RoleName,
                   Description=x.Description,
                   Id= x.Id,
                   
                   IsSuperAdmin= Access.IsSuperAdmin() ? "YES" : "NO"
                   
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
        public JsonResult New(Roles roles)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.roleService.CheckDataIfExists(roles);
                    if (!ifExists)
                    {
                        roles.ApplicationName = ConfigManager.Exchange.ApplicationName;
                        this.roleService.SaveOrUpdate(roles);
                        return Json(new { result = Base.Encrypt(roles.Id.ToString()), message = MessageCode.saved, code = StatusCode.saved, content = roles.RoleName.ToString() });

                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content = roles.RoleName.ToString() });
            }

        }
        #endregion
        #region Manage
        
        public ActionResult Manage(string id)
        {
            try
            {
                Roles roles = this.roleService.GetDataById(new Guid(id));
                if (roles != null)
                    return View(roles);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Manage(Roles roles)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.roleService.CheckDataIfExists(roles);
                    if (!ifExists)
                    {

                        Roles entity = new Roles();
                        entity = this.roleService.GetDataById(roles.Id);
                        entity.RoleName = roles.RoleName;
                        entity.Description = roles.Description;
                        this.roleService.SaveChanges(entity);
                        return Json(new { result = Base.Encrypt(roles.Id.ToString()), message = MessageCode.modified, code = StatusCode.modified, content = roles.RoleName });
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
                Roles roles = this.roleService.GetDataById(new Guid(id));
                if (roles != null)
                    return View(roles);

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
                    this.roleService.Delete(new Guid(id));
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
                bool ifExists = this.roleService.CheckDataIfExists(param);
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
