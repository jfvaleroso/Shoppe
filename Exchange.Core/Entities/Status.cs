﻿using System;

namespace Exchange.Core.Entities
{
    public class Status : Entity<Guid>
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Active { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? DateModified { get; set; }
    }
}