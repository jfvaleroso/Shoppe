using System;
using System.Collections.Generic;

namespace Exchange.Core.Entities
{
    public class SecurityCode : Entity<Guid>
    {
        public SecurityCode()
        {
            DateCreated = DateTime.Now;
            Purchases = new List<Purchase>();
        }

        public virtual string PassCode { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual DateTime? DateUsed { get; set; }

        public virtual string UsedBy { get; set; }

        public virtual bool IsUsed { get; set; }

        public virtual decimal Bonus { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }
    }
}