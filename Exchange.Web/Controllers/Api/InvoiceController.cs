using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exchange.Web.Models.Api;
using System.Web.Security;
using Exchange.Web.Helper;


namespace Exchange.Web.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private readonly IProductService productService;
        private readonly IPurchaseService purchaseService;
        private readonly IInvoiceService invoiceService;
        private readonly IStoreService storeInvoice;
        private readonly IUserService userService;
        private readonly ICustomerService customerService;
        private readonly IStatusService statusService;

        public InvoiceController(IProductService productService, IPurchaseService purchaseService, IInvoiceService invoiceService, IStoreService storeInvoice, IUserService userService, ICustomerService customerService, IStatusService statusService)
        {
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.invoiceService = invoiceService;
            this.storeInvoice = storeInvoice;
            this.userService = userService;
            this.customerService = customerService;
            this.statusService = statusService;
        }

        [HttpPost]
        public HttpResponseMessage PostInvoice(InvoiceModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Invoice invoice = new Invoice();
                    invoice.InvoiceNo = model.InvoiceNo;
                    invoice.SubTotal = model.SubTotal;
                    invoice.TotalBonus = model.TotalBonus;
                    invoice.GrandTotal = model.GrandTotal;
                    invoice.Store = this.storeInvoice.GetDataById(new Guid(model.StoreId));
                    string status = Helper.Status.SavedToDraft;

                    invoice.Cashier = this.userService.GetUserById(new Guid(model.Cashier));
                    invoice.Appraiser = this.userService.GetUserById(new Guid(model.AppraiserId));
                    invoice.Customer = this.customerService.GetDataById(new Guid(model.CustomerId));
                    invoice.Status = this.statusService.GetStatusByCode(status);

                    this.invoiceService.Create(invoice);

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
