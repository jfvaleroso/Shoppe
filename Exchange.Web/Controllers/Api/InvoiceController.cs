using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exchange.Web.Models.Api;
using System.Web.Mvc;

namespace Exchange.Web.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private readonly IProductService productService;
        public InvoiceController(IProductService productService)
        {
            this.productService = productService;
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

    }
}
