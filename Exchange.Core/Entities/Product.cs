using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Core.Entities
{
    public class Product : Entity<int>
    {

       
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Code { get; set; }
         [Required]
        public virtual string Description { get; set; }


        [Range(0.01, 1000000000000000.00, ErrorMessage = "Price must be between 0.01 and 1000000000000000.00")]
        public virtual decimal Cost { get; set; }


        public virtual string CreatedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual bool Active { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual IList<ProductHistory> ProductHistories { get; set; }


        public Product()
        {
            
            this.Active = true;
            this.DateCreated = DateTime.Now;
            this.ProductHistories = new List<ProductHistory>();
        }

       
    }
}