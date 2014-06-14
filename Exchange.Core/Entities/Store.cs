using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Core.Entities
{
    public class Store : Entity<Guid>
    {
        public Store()
        {
            UsersInStore = new List<Users>();
            Invoices = new List<Invoice>();
        }

        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Address { get; set; }

        public virtual string TelephoneNo { get; set; }

        public virtual string PermitNo { get; set; }

        public virtual string TINNo { get; set; }

        public virtual bool Active { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? DateCreated { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual IList<Users> UsersInStore { get; set; }

        public virtual IList<Invoice> Invoices { get; set; }

        public virtual void AddUser(Users user)
        {
            UsersInStore.Add(user);
        }
    }
}