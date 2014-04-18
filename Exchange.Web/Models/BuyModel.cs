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
        public string ProductId { get; set; }
        public string CustomerId { get; set; }

        public string Cashier { get; set; }
        public string CashierId { get; set; }


        //store
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreTelephoneNo { get; set; }



        public string Appraiser { get; set; }
        public string AppraiserId { get; set; }
        public string InvoiceNo { get; set; }
        public IList<SelectListItem> ProductList { get; set; }
        public IList<SelectListItem> CustomerList { get; set; }
        public IList<Purchase> Purchases { get; set; }


        //for view
        public decimal GrandTotal { get; set; }
        public decimal TotalBonus { get; set; }
        public decimal SubTotal { get; set; }
        public string Customer { get; set; }

        //company details
        public string CompanyName { get; set; }


        public BuyModel()
        {

            this.ProductList = new List<SelectListItem>();
            this.CustomerList = new List<SelectListItem>();
            this.Purchases = new List<Purchase>();
        }

    }
}