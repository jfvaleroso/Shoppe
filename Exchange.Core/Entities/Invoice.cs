using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class Invoice : Entity<Guid>
    {
        #region Invoice details
        public virtual string InvoiceNo { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal TotalBonus { get; set; }
        public virtual decimal GrandTotal { get; set; }
        #endregion


        #region Prereq
        public virtual Users Cashier { get; set; }
        public virtual Users Appraiser { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual Status Status { get; set; }
       
        #endregion

        #region General details
        public virtual DateTime? DateIssued { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual DateTime DateCreated { get; set; }
        #endregion


        #region Connection
        public virtual IList<Purchase> Purchases { get; set; }
        public virtual IList<Note> Notes { get; set; }
        #endregion

        public Invoice()
        {
            this.Purchases = new List<Purchase>();
            this.Notes= new List<Note>();
            this.DateCreated = DateTime.Now;
        }
    }
}
