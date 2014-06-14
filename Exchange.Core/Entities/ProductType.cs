using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Core.Entities
{
    public class ProductType : Entity<Guid>
    {
        public ProductType()
        {
            Products = new List<Product>();
            DateCreated = DateTime.Now;
            Active = true;
        }

        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Description { get; set; }

        public virtual bool Active { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual IList<Product> Products { get; set; }

        public virtual void AddProduct(Product product)
        {
            product.ProductType = this;
            Products.Add(product);
        }
    }
}