using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IActivityLogsService _activityLogService;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, IActivityLogsService activityLogService)
        {
            _customerService = customerService;
            _activityLogService = activityLogService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CustomerListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                List<Customer> customerList = _customerService.GetDataListWithPagingAndSearch(searchString, jtStartIndex,
                    jtPageSize, out total);
                var collection = customerList.Select(x => new
                {
                    x.LastName,
                    x.FirstName,
                    x.MiddleName,
                    x.CellphoneNo,
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });
            }
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public JsonResult New(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customer.Active = true;
                    customer.DateCreated = DateTime.Now;
                    customer.CreatedBy = User.Identity.Name;
                    customer.Id = _customerService.Create(customer);
                    return Json(new { result = customer.Id, message = "Successfully Saved" });
                }
            }
            catch (Exception ex)
            {
                _activityLogService.Create(new ActivityLogs
                {
                    Description = ex.InnerException.Message,
                    ExecutedBy = User.Identity.Name,
                    Type = "Error: Adding Customer"
                });
            }
            return Json(new { result = customer.Id, message = "Please complete the fields" });
        }

        public ActionResult Manage(string id)
        {
            try
            {
                Customer customer = _customerService.GetDataById(new Guid(id));
                if (customer != null)
                    return View(customer);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Manage(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer entity = _customerService.GetDataById(customer.Id);
                    entity.LastName = customer.LastName;
                    entity.FirstName = customer.FirstName;
                    entity.MiddleName = customer.MiddleName;
                    entity.TelephoneNo = customer.TelephoneNo;
                    entity.CellphoneNo = customer.CellphoneNo;
                    entity.Email = customer.Email;
                    entity.BirthDate = customer.BirthDate;
                    entity.Gender = customer.Gender;
                    entity.OfficeAddress = customer.OfficeAddress;
                    entity.ResidentialAddress = customer.ResidentialAddress;
                    entity.PostalCode = customer.PostalCode;
                    entity.City = customer.City;
                    entity.Province = customer.Province;
                    entity.TypeOfID = customer.TypeOfID;
                    entity.IDNo = customer.IDNo;
                    entity.Active = customer.Active;
                    entity.DateModified = DateTime.Now;
                    entity.ModifiedBy = User.Identity.Name;
                    _customerService.SaveChanges(entity);
                    return Json(new { result = entity.Id, message = "Successfully saved" });
                }
            }
            catch (Exception)
            {
            }
            return Json(new { result = "0", message = "Please complete the fields" });
        }

        public ActionResult Item(string id)
        {
            try
            {
                Customer customer = _customerService.GetDataById(new Guid(id));
                if (customer != null)
                    return View(customer);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public JsonResult Delete(string id)
        {
            try
            {
                _customerService.Delete(new Guid(id));
                return Json(new { result = "1", message = "Successfully deleted" });
            }
            catch (Exception)
            {
            }
            return Json(new { result = "0", message = "Error" });
        }
    }
}