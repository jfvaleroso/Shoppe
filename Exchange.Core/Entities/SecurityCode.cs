using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class SecurityCode : Entity<int>
    {
        public virtual string PassCode { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string UsedBy { get; set; }
        public virtual int Status { get; set; }
        public SecurityCode()
        {
            this.DateCreated = DateTime.Now;
        }

    }
}
