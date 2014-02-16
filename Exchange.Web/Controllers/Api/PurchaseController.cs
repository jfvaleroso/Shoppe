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


namespace Exchange.Web.Controllers.Api
{
    public class PurchaseController : ApiController
    {
        private readonly IProductService productService;
        private readonly IPurchaseService purchaseService;
        private readonly IInvoiceService invoiceService;
        public PurchaseController(IProductService productService, IPurchaseService purchaseService, IInvoiceService invoiceService)
        {
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.invoiceService = invoiceService;
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
                    purchase.CreatedBy = User.Identity.Name;
                    purchase.Product = this.productService.GetDataById(model.ProductId);

                    long id= this.purchaseService.Create(purchase);

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, model);

                    //result.Headers.Location =
                    //    new Uri(Url.Link("DefaultApi", new { id = purchase.Id }));

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
