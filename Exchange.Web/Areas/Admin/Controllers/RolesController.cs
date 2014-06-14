using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        #region Constructor

        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion Constructor

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
                List<Roles> roleList = _roleService.GetDataListWithPagingAndSearch(searchString, jtStartIndex,
                    jtPageSize,
                    out total);
                var collection = roleList.Select(x => new
                {
                    x.RoleName,
                    x.Description,
                    x.Id,
                    IsSuperAdmin = Access.IsSuperAdmin() ? "YES" : "NO"
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
        public JsonResult New(Roles roles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = _roleService.CheckDataIfExists(roles);
                    if (!ifExists)
                    {
                        roles.ApplicationName = ConfigManager.Exchange.ApplicationName;
                        _roleService.SaveOrUpdate(roles);
                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(roles.Id.ToString()),
                                    message = MessageCode.saved,
                                    code = StatusCode.saved,
                                    content = roles.RoleName
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
                            content = roles.RoleName
                        });
            }
        }

        #endregion New

        #region Manage

        public ActionResult Manage(string id)
        {
            try
            {
                Roles roles = _roleService.GetDataById(new Guid(id));
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
                    bool ifExists = _roleService.CheckDataIfExists(roles);
                    if (!ifExists)
                    {
                        var entity = new Roles();
                        entity = _roleService.GetDataById(roles.Id);
                        entity.RoleName = roles.RoleName;
                        entity.Description = roles.Description;
                        _roleService.SaveChanges(entity);
                        return
                            Json(
                                new
                                {
                                    result = Base.Encrypt(roles.Id.ToString()),
                                    message = MessageCode.modified,
                                    code = StatusCode.modified,
                                    content = roles.RoleName
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
                Roles roles = _roleService.GetDataById(new Guid(id));
                if (roles != null)
                    return View(roles);
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
                    _roleService.Delete(new Guid(id));
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
                bool ifExists = _roleService.CheckDataIfExists(param);
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