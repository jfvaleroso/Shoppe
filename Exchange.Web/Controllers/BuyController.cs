﻿using Exchange.Core.Entities;
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

        #region Constructor
        private readonly Service service;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IProfileService profileService;
        private readonly IUserService userService;
        private readonly IInvoiceService invoiceService;
        private readonly Common common;

        public BuyController(IProductService productService, ICustomerService customerService, IProfileService profileService, IUserService userService, IInvoiceService invoiceService)
        {
            this.productService = productService;
            this.customerService = customerService;
            this.profileService = profileService;
            this.userService = userService;
            this.invoiceService = invoiceService;
            this.service = new Service(this.productService);
            this.common = new Common(this.userService);
        }
        #endregion


        #region Index
        public ActionResult Index()
        {
            BuyModel model = new BuyModel();
            StoreModel store = new StoreModel();
            store = this.common.GetCurrentUserStoreAccess();
            model.ProductList = this.service.GetProductList(0);
            model.StoreId = store.Id;
            model.StoreName = store.StoreName;
            model.InvoiceNo = Base.GenerateInvoiceNumber("INV", store.StoreCode, this.invoiceService.GetTotalInvoiceBySTore(store.Id));
            model.Cashier = Common.GetCurrentUser();


            return View(model);
        }
        #endregion
        #region Customer
        public ActionResult Customer()
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
        #region Search and Auto complete
        public JsonResult SearchEmployee(string searchString)
        {
            long total = 0;
            var employeeList = this.profileService.GetDataWithPagingAndSearch(searchString, 1, 20, out total);
            var data = employeeList.Select(x => new
            {
                name = string.Format("{0}, {1}", x.LastName, x.FirstName)         
                //value = x.Users_Id.ToString(),               
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchCustomer(string searchString)
        {
            long total = 0;
            var customerList = this.customerService.GetDataListWithPagingAndSearch(searchString, 1, 20, out total);
            var data = customerList.Select(x => new
            {
                name = string.Format("{0}, {1}", x.LastName, x.FirstName),
                id= x.Id.ToString()
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
