using Exchange.Configuration;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;
using Exchange.Helper.Transaction;
using Exchange.Web.Helper;
using Exchange.Web.Models;
using RazorPDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class BuyController : Controller
    {
        #region Constructor

        private readonly Common _common;
        private readonly ICustomerService _customerService;
        private readonly IInvoiceService _invoiceService;
        private readonly IProfileService _profileService;
        private readonly ISecurityCodeService _securityCodeService;
        private readonly Service _service;

        public BuyController(IProductService productService, ICustomerService customerService,
            IProfileService profileService, IUserService userService, IInvoiceService invoiceService,
            ISecurityCodeService securityCodeService)
        {
            _customerService = customerService;
            _profileService = profileService;
            _invoiceService = invoiceService;
            _securityCodeService = securityCodeService;
            _service = new Service(productService);
            _common = new Common(userService);
        }

        #endregion Constructor

        #region Index

        public ActionResult Index()
        {
            var model = new BuyModel();
            var store = _common.GetCurrentUserStoreAccess();
            var profile = _common.GetCurrentUserProfile();

            model.ProductList = _service.GetProductList(new Guid());
            model.StoreId = store.Id;
            model.StoreName = store.StoreName;
            model.InvoiceNo = Base.GenerateInvoiceNumber("INV", store.StoreCode,
                _invoiceService.GetTotalInvoiceBySTore(new Guid(store.Id)));
            model.Cashier = profile.Name;
            model.CashierId = profile.UserId;
            return View(model);
        }

        public ActionResult View(string id)
        {
            var invoice = new Invoice();
            invoice = _invoiceService.GetDataById(new Guid(id));

            var model = new BuyModel();
            var store = new StoreModel();
            var cashier = new Profiles();
            var appraiser = new Profiles();
            var customer = new Customer();
            cashier = _profileService.GetProfileByUserId(invoice.Cashier.Id);
            appraiser = _profileService.GetProfileByUserId(invoice.Appraiser.Id);
            customer = _customerService.GetDataById(invoice.Customer.Id);

            model.StoreId = invoice.Store.Id.ToString();
            model.StoreName = invoice.Store.Name;
            model.StoreAddress = invoice.Store.Address;
            model.StoreTelephoneNo = invoice.Store.TelephoneNo;

            model.InvoiceNo = invoice.InvoiceNo;
            model.Cashier = Base.GenerateFullName(cashier.FirstName, cashier.MiddleName, cashier.LastName);
            model.Appraiser = Base.GenerateFullName(appraiser.FirstName, appraiser.MiddleName, appraiser.LastName);
            model.Customer = Base.GenerateFullName(customer.FirstName, customer.MiddleName, customer.LastName);
            //summary
            model.SubTotal = invoice.SubTotal;
            model.TotalBonus = invoice.TotalBonus;
            model.GrandTotal = invoice.GrandTotal;
            //purchases
            model.Purchases = invoice.Purchases;
            //company
            model.CompanyName = ConfigManager.Exchange.CompanyName;

            TempData["Invoice"] = model;

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var invoice = new Invoice();
            invoice = _invoiceService.GetDataById(new Guid(id));

            var model = new BuyModel();
            var store = new StoreModel();
            var cashier = new Profiles();
            var appraiser = new Profiles();
            var customer = new Customer();
            cashier = _profileService.GetProfileByUserId(invoice.Cashier.Id);
            appraiser = _profileService.GetProfileByUserId(invoice.Appraiser.Id);
            customer = _customerService.GetDataById(invoice.Customer.Id);

            model.StoreId = invoice.Store.Id.ToString();
            model.StoreName = invoice.Store.Name;
            model.StoreAddress = invoice.Store.Address;
            model.StoreTelephoneNo = invoice.Store.TelephoneNo;

            model.InvoiceNo = invoice.InvoiceNo;
            model.Cashier = Base.GenerateFullName(cashier.FirstName, cashier.MiddleName, cashier.LastName);
            model.Appraiser = Base.GenerateFullName(appraiser.FirstName, appraiser.MiddleName, appraiser.LastName);
            model.Customer = Base.GenerateFullName(customer.FirstName, customer.MiddleName, customer.LastName);
            //summary
            model.SubTotal = invoice.SubTotal;
            model.TotalBonus = invoice.TotalBonus;
            model.GrandTotal = invoice.GrandTotal;
            //purchases
            model.Purchases = invoice.Purchases;
            //company
            model.CompanyName = ConfigManager.Exchange.CompanyName;
            model.ProductList = _service.GetProductList(new Guid());

            TempData["Invoice"] = model;

            return View(model);
        }

        #endregion Index

        #region Customer

        public ActionResult Customer()
        {
            var model = new CustomerModel();
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
                        var customer = new Customer();
                        customer.LastName = model.LastName;
                        customer.MiddleName = model.MiddleName;
                        customer.FirstName = model.FirstName;
                        customer.Active = true;
                        customer.Gender = model.Gender;
                        customer.BirthDate = Convert.ToDateTime(model.BirthDate);
                        customer.CellphoneNo = model.CellphoneNo;
                        customer.Email = model.Email;
                        customer.ResidentialAddress = model.ResidentialAddress;
                        customer.OfficeAddress = model.OfficeAddress;
                        customer.TypeOfID = model.TypeOfID;
                        customer.IDNo = model.IDNo;
                        customer.DateCreated = DateTime.Now;
                        customer.CreatedBy = User.Identity.Name;

                        _customerService.Create(customer);

                        return
                            Json(
                                new
                                {
                                    result = customer.Id.ToString(),
                                    message = MessageCode.saved,
                                    code = StatusCode.saved,
                                    content =
                                        Base.GenerateFullName(customer.FirstName, customer.MiddleName, customer.LastName)
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
                            content = ex.Message
                        });
            }
        }

        #endregion Customer

        #region Bonus

        public ActionResult Bonus()
        {
            return View();
        }

        #endregion Bonus

        #region Search and Auto complete

        public JsonResult SearchEmployee(string searchString)
        {
            long total = 0;
            List<Profiles> employeeList = _profileService.GetDataWithPagingAndSearch(searchString, 1, 20, out total);
            var data = employeeList.Select(x => new
            {
                name = string.Format("{0}, {1}", x.LastName, x.FirstName),
                id = x.UserId.ToString()
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchAllEmployee()
        {
            var employeeList = _profileService.GetAllData();
            var data = employeeList.Select(x => new
            {
                name = string.Format("{0}, {1}", x.LastName, x.FirstName),
                id = x.UserId.ToString()
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchCustomer(string searchString)
        {
            long total = 0;
            List<Customer> customerList = _customerService.GetDataListWithPagingAndSearch(searchString, 1, 20, out total);
            var data = customerList.Select(x => new
            {
                name = string.Format("{0}, {1}", x.LastName, x.FirstName),
                id = x.Id.ToString()
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchPassCode(string searchString)
        {
            if (ModelState.IsValid)
            {
                SecurityCode data = _securityCodeService.GetDataByCode(searchString);
                if (data != null)
                {
                    return Json(new { result = data, message = MessageCode.valid, code = StatusCode.valid },
                        JsonRequestBehavior.AllowGet);
                }
                return Json(new { result = StatusCode.empty, message = MessageCode.empty, code = StatusCode.empty },
                    JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = StatusCode.invalid, message = MessageCode.error, code = StatusCode.invalid },
                JsonRequestBehavior.AllowGet);
        }

        #endregion Search and Auto complete

        #region Receipt

        public ActionResult Receipt()
        {
            var model = new BuyModel();
            if (TempData["Invoice"] != null)
            {
                model = (BuyModel)TempData["Invoice"];
            }
            var pdf = new PdfResult(model, "Receipt");
            return pdf;
        }

        #endregion Receipt
    }
}