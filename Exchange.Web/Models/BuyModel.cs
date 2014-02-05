using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exchange.Web.Models
{
    public class BuyModel
    {
        //public float Quantity { get; set; }
        //public float Rate { get; set; }
        //public float Amount { get; set; }
        //public float Bonus { get; set; }
        //public float SubTotal { get; set; }
        public int ProductId { get; set; }
        public IList<SelectListItem> ProductList { get; set; }
        public BuyModel()
        {

            this.ProductList = new List<SelectListItem>();
        }

    }
}