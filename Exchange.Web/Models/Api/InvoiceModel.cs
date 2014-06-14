using System;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Web.Models.Api
{
    public class InvoiceModel
    {
        #region Invoice details

        public string InvoiceNo { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalBonus { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please add atleast one item.")]
        public decimal GrandTotal { get; set; }

        public string StoreId { get; set; }

        #endregion Invoice details

        #region

        public string Cashier { get; set; }
        public string CashierId { get; set; }

        public string Appraiser { get; set; }

        [Required(ErrorMessage = "Please input the customer.")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Please input the appraiser.")]
        public string AppraiserId { get; set; }

        public int StatusId { get; set; }

        #endregion

        #region details

        public DateTime? DateIssued { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion
    }
}