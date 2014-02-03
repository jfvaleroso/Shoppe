using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class Invoice : Entity<int>
    {
        public virtual string TransactionCode { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime? DateIssued { get; set; }
        public virtual string Cashier { get; set; }
        public virtual string Appraiser { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual Status Status { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }
        public virtual IList<Note> Notes { get; set; }
        public Invoice()
        {
            this.Purchases = new List<Purchase>();
            this.Notes= new List<Note>();
        }
    }
}
