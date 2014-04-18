using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class Note : Entity<Guid>
    {
        public virtual string Description { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Cashier { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
