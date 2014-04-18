using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exchange.Core.Services.IServices;
using Exchange.Core.Entities;

namespace Exchange.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IActivityLogsService activityLogService;
        public CustomerController(ICustomerService customerService, IActivityLogsService activityLogService)
        {
            this.customerService = customerService;
            this.activityLogService = activityLogService;
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
                var customerList = this.customerService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total);
                var collection = customerList.Select(x => new
                {
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    CellphoneNo = x.CellphoneNo,
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
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
                    customer.CreatedBy = User.Identity.Name.ToString();
                    customer.Id = this.customerService.Create(customer);
                    return Json(new { result = customer.Id, message = "Successfully Saved" });
                }
            }
            catch (Exception ex)
            {
                this.activityLogService.Create(new ActivityLogs { Description = ex.InnerException.Message.ToString(), ExecutedBy = User.Identity.Name, Type = "Error: Adding Customer" });
            }
            return Json(new { result = customer.Id, message = "Please complete the fields" });

        }
        public ActionResult Manage(string id)
        {
            try
            {
                Customer customer = this.customerService.GetDataById(new Guid(id));
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
                    Customer entity = new Customer();
                    entity = this.customerService.GetDataById(customer.Id);
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
                    entity.ModifiedBy = User.Identity.Name.ToString();
                    this.customerService.SaveChanges(entity);
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
                Customer customer = this.customerService.GetDataById(new Guid(id));
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
                    this.customerService.Delete(new Guid(id));
                    return Json(new { result = "1", message = "Successfully deleted" });
            }
            catch (Exception)
            {

            }
            return Json(new { result = "0", message = "Error" });
        }
    }
}
