using System;
using System.Collections.Generic;

namespace Exchange.Core.Entities
{
    public class Invoice : Entity<Guid>
    {
        #region Invoice details

        public virtual string InvoiceNo { get; set; }

        public virtual decimal SubTotal { get; set; }

        public virtual decimal TotalBonus { get; set; }

        public virtual decimal GrandTotal { get; set; }

        #endregion Invoice details

        #region Prereq

        public virtual Users Cashier { get; set; }

        public virtual Users Appraiser { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Store Store { get; set; }

        public virtual Status Status { get; set; }

        #endregion Prereq

        #region General details

        public virtual DateTime? DateIssued { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual DateTime DateCreated { get; set; }

        #endregion General details

        #region Connection

        public virtual IList<Purchase> Purchases { get; set; }

        public virtual IList<Note> Notes { get; set; }

        #endregion Connection

        public Invoice()
        {
            Purchases = new List<Purchase>();
            Notes = new List<Note>();
            DateCreated = DateTime.Now;
        }
    }
}