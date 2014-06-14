using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Web.Models.Api;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Status = Exchange.Web.Helper.Status;

namespace Exchange.Web.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;
        private readonly IStatusService _statusService;
        private readonly IStoreService _storeInvoice;
        private readonly IUserService _userService;

        public InvoiceController(IProductService productService, IPurchaseService purchaseService,
            IInvoiceService invoiceService, IStoreService storeInvoice, IUserService userService,
            ICustomerService customerService, IStatusService statusService)
        {
            _productService = productService;
            _purchaseService = purchaseService;
            _invoiceService = invoiceService;
            _storeInvoice = storeInvoice;
            _userService = userService;
            _customerService = customerService;
            _statusService = statusService;
        }

        [HttpPost]
        public HttpResponseMessage PostInvoice(InvoiceModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var invoice = new Invoice
                    {
                        InvoiceNo = model.InvoiceNo,
                        SubTotal = model.SubTotal,
                        TotalBonus = model.TotalBonus,
                        GrandTotal = model.GrandTotal,
                        Store = _storeInvoice.GetDataById(new Guid(model.StoreId))
                    };
                    string status = Status.SavedToDraft;

                    invoice.Cashier = _userService.GetUserById(new Guid(model.Cashier));
                    invoice.Appraiser = _userService.GetUserById(new Guid(model.AppraiserId));
                    invoice.Customer = _customerService.GetDataById(new Guid(model.CustomerId));
                    invoice.Status = _statusService.GetStatusByCode(status);

                    _invoiceService.Create(invoice);

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, invoice.Id);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = invoice.Id }));

                    return result;
                }
                return Request.
                    CreateErrorResponse(HttpStatusCode.OK, ModelState);
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}