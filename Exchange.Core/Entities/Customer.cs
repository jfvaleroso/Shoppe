using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Core.Entities
{
    public class Customer : Entity<long>
    {

        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string MiddleName { get; set; }
        public virtual string TelephoneNo { get; set; }
        public virtual string CellphoneNo { get; set; }
        public virtual string Email { get; set; }
        [Required]
        public virtual DateTime BirthDate { get; set; }
        public virtual string Gender { get; set; }
        public virtual string OfficeAddress { get; set; }
        [Required]
        public virtual string ResidentialAddress { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Province { get; set; }
        public virtual string TypeOfID { get; set; }
        public virtual string IDNo { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
       

        public Customer()
        {

            this.DateCreated = DateTime.Now;
            this.Invoices = new List<Invoice>();
           
        }

    }
}
