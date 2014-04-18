using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class SecurityCode : Entity<Guid>
    {
        public virtual string PassCode { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateUsed { get; set; }
        public virtual string UsedBy { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual decimal Bonus { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }
        
        public SecurityCode()
        {
            this.DateCreated = DateTime.Now;
            this.Purchases= new List<Purchase>();
        }

    }
}
