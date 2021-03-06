﻿using System;

namespace Exchange.Core.Entities
{
    public class Purchase : Entity<Guid>
    {
        #region Purchase data

        public virtual int Quantity { get; set; }

        public virtual decimal Grams { get; set; }

        public virtual decimal Rate { get; set; }

        public virtual decimal Cost { get; set; }

        public virtual decimal Bonus { get; set; }

        public virtual decimal Total { get; set; }

        public virtual string Description { get; set; }

        #endregion Purchase data

        #region Prereq

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product { get; set; }

        public virtual SecurityCode SecurityCode { get; set; }

        #endregion Prereq

        #region General

        public virtual DateTime DateCreated { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual string ModifiedBy { get; set; }

        #endregion General

        public Purchase()
        {
            DateCreated = DateTime.Now;
        }
    }
}