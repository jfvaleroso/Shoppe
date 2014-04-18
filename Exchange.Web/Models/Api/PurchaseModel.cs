using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exchange.Web.Models.Api
{
    public class PurchaseModel
    {
        #region Purchase data
        public int Quantity { get; set; }
        public decimal Grams { get; set; }
        public decimal Rate { get; set; }
        public decimal Cost { get; set; }
        public decimal Bonus { get; set; }
        public decimal Total { get; set; }
        public string Description { get; set; }

        public string ProductId { get; set; }
        public string InvoiceId { get; set; }
        #endregion

        //#region Prereq
        //public int InvoiceId { get; set; }
      
        //public int SecurityCodeId { get; set; }
        //#endregion



        
      
    }
}