using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Web.Helper;
using Exchange.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class BuyController : Controller
    {
        private readonly Service service;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public BuyController(IProductService productService, ICustomerService customerService)
        {
            this.productService = productService;
            this.customerService = customerService;
            this.service = new Service(this.productService);
        }

        public ActionResult Index()
        {
            BuyModel model = new BuyModel();
            model.ProductList = this.service.GetProductList(0);
       
            return View(model);
        }

        #region Customer
        public ActionResult AddCustomer()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }
        [HttpPost]
        public JsonResult AddCustomer(CustomerModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = false;
                    if (!ifExists)
                    {
                        Customer customer = new Customer();
                        customer.LastName = model.LastName;
                        customer.MiddleName = model.MiddleName;
                        customer.FirstName = model.FirstName;
                        customer.Active = true;
                        customer.Gender = model.Gender;
                        customer.BirthDate = model.BirthDate;
                        customer.CellphoneNo = model.CellphoneNo;
                        customer.Email = model.Email;
                        customer.ResidentialAddress = model.ResidentialAddress;
                        customer.OfficeAddress = model.OfficeAddress;
                        customer.TypeOfID = model.TypeOfID;
                        customer.IDNo = model.IDNo;
                        customer.DateCreated = DateTime.Now;
                        customer.CreatedBy = User.Identity.Name;

                        this.customerService.Create(customer);

                        return Json(new { result = customer.Id.ToString(), message = MessageCode.saved, code = StatusCode.saved, content = Base.GenerateFullName(customer.FirstName, customer.MiddleName, customer.LastName) });

                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content =ex.Message.ToString() });
            }


        }
        #endregion
        

      
    }
}
