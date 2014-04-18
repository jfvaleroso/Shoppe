using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class CashOnHand : Entity<Guid>
    {
        public virtual decimal Cash { get; set; }
        public virtual string Note { get; set; }
        public virtual DateTime DateReceived { get; set; }
        public virtual string ReceivedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual Guid StoreId { get; set; }
    }
}
