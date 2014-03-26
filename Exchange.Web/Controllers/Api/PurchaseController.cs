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
using Exchange.Helper.Transaction;


namespace Exchange.Web.Controllers.Api
{
    public class PurchaseController : ApiController
    {
        private readonly IProductService productService;
        private readonly IPurchaseService purchaseService;
        private readonly IInvoiceService invoiceService;
        private readonly IStatusService statusService;
        public PurchaseController(IProductService productService, IPurchaseService purchaseService, IInvoiceService invoiceService, IStatusService statusService)
        {
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.invoiceService = invoiceService;
            this.statusService = statusService;
        }


        public ProductModel GetProductById(int id)
        {
            var product = this.productService.GetDataById(id);
            if (product == null)
            {
                return null;
            }
            ProductModel model = new ProductModel();
            model.Code = product.Code;
            model.Rate = product.Cost;
            return model;
        }


        [HttpPost]
        public HttpResponseMessage PostPurchase(PurchaseModel model)
        {
            try
            {
                if (model != null)
                {
                    Purchase purchase = new Purchase();
                    purchase.Quantity = model.Quantity;
                    purchase.Grams = model.Grams;
                    purchase.Rate = model.Rate;
                    purchase.Cost = model.Cost;
                    purchase.Bonus = model.Bonus;
                    purchase.Total = model.Total;
                    purchase.DateCreated = DateTime.Now;
                    purchase.Invoice = this.invoiceService.GetDataById(model.InvoiceId);
                    purchase.CreatedBy = User.Identity.Name;
                    purchase.Product = this.productService.GetDataById(model.ProductId);
                    purchase.Status = this.statusService.GetDataById((int)Common.Status.SavedToDraft);
                    purchase.Description = string.Format("{0}: {1}", purchase.Product.Name, purchase.Product.Description);

                    this.purchaseService.Create(purchase);

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, StatusCode.saved);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { status = StatusCode.saved }));

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
