using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Entities;

namespace Exchange.Web.Models
{
    public class ProductModel
    {

        public IList<Product> ProductList { get; set; }
        public int NumberOfOnline { get; set; }

        public ProductModel()
        {
            this.ProductList = new List<Product>();
        }
    }
}