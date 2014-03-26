using Exchange.Core.Entities;
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
        public long CustomerId { get; set; }

        public string Cashier { get; set; }
        public int CashierId { get; set; }

        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public string Appraiser { get; set; }
        public string InvoiceNo { get; set; }
        public IList<SelectListItem> ProductList { get; set; }
        public IList<SelectListItem> CustomerList { get; set; }
        public IList<Purchase> Purchases { get; set; }


        //for view
        public decimal GrandTotal { get; set; }
        public decimal TotalBonus { get; set; }
        public decimal SubTotal { get; set; }
        public string Customer { get; set; }



        public BuyModel()
        {

            this.ProductList = new List<SelectListItem>();
            this.CustomerList = new List<SelectListItem>();
            this.Purchases = new List<Purchase>();
        }

    }
}