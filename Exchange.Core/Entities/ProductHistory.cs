using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Core.Entities
{
    public class ProductHistory : Entity<long>
    {

        public virtual decimal Cost { get; set; }
        public virtual Product Product { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
