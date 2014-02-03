using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class Purchase: Entity<long>
    {
        public virtual string ProductCode { get; set; }
        public virtual decimal Grams { get; set; }
        public virtual int Quantity { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Cost { get; set; }  
        public virtual float Bonus { get; set; }
        public virtual decimal Total { get; set; }
        public virtual string Rate { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Cashier { get; set; }
        public virtual int InvoiceId { get; set; }
        public virtual string Appraiser { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int Status { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Customer Customer { get; set; }

        public Purchase()
        {
            this.DateCreated = DateTime.Now;
        }


    }
}
