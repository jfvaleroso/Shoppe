using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Core.Entities
{
    public class ProductType : Entity<Guid>
    {
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

        public ProductType()
        {
            this.Products = new List<Product>();
            this.DateCreated = DateTime.Now;
            this.Active = true;
        }

        public virtual void AddProduct(Product product)
        {
            product.ProductType = this;
            Products.Add(product);
        }

    }
}
