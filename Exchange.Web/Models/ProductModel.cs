using Exchange.Core.Entities;
using System.Collections.Generic;

namespace Exchange.Web.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            ProductList = new List<Product>();
        }

        public IList<Product> ProductList { get; set; }

        public int NumberOfOnline { get; set; }
    }
}