﻿using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exchange.Web.Models.Api;
using System.Web.Security;


namespace Exchange.Web.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private readonly IProductService productService;
        private readonly IPurchaseService purchaseService;
        private readonly IInvoiceService invoiceService;
        private readonly IStoreService storeInvoice;
        public InvoiceController(IProductService productService, IPurchaseService purchaseService, IInvoiceService invoiceService, IStoreService storeInvoice)
        {
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.invoiceService = invoiceService;
            this.storeInvoice = storeInvoice;
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
                    invoice.Store = this.storeInvoice.GetDataById(model.StoreId);

                    invoice.Cashier = model.Cashier;
                    model.Appraiser = model.Appraiser;

                    this.invoiceService.Create(invoice);

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, invoice.Id);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = invoice.Id }));

                    return result;
                }
                else
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
      


    }
}
