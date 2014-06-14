using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Transaction;
using Exchange.Web.Models.Api;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exchange.Web.Controllers.Api
{
    public class PurchaseController : ApiController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;
        private readonly IStatusService _statusService;

        public PurchaseController(IProductService productService, IPurchaseService purchaseService,
            IInvoiceService invoiceService, IStatusService statusService)
        {
            _productService = productService;
            _purchaseService = purchaseService;
            _invoiceService = invoiceService;
            _statusService = statusService;
        }

        public ProductModel GetProductById(string id)
        {
            var product = _productService.GetDataById(new Guid(id));
            if (product == null)
            {
                return null;
            }
            var model = new ProductModel { Code = product.Code, Rate = product.Cost };
            return model;
        }

        [HttpPost]
        public HttpResponseMessage PostPurchase(PurchaseModel model)
        {
            try
            {
                if (model != null)
                {
                    var purchase = new Purchase
                    {
                        Quantity = model.Quantity,
                        Grams = model.Grams,
                        Rate = model.Rate,
                        Cost = model.Cost,
                        Bonus = model.Bonus,
                        Total = model.Total,
                        DateCreated = DateTime.Now,
                        Invoice = _invoiceService.GetDataById(new Guid(model.InvoiceId)),
                        CreatedBy = User.Identity.Name,
                        Product = _productService.GetDataById(new Guid(model.ProductId))
                    };
                    purchase.Description = string.Format("{0}: {1}", purchase.Product.Name, purchase.Product.Description);

                    _purchaseService.Create(purchase);

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, StatusCode.saved);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { status = StatusCode.saved }));

                    return result;
                }
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}