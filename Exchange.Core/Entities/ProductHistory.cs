using System;

namespace Exchange.Core.Entities
{
    public class ProductHistory : Entity<Guid>
    {
        public virtual decimal Cost { get; set; }

        public virtual Product Product { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual string ModifiedBy { get; set; }
    }
}