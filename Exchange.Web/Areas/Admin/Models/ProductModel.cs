using Exchange.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Models
{
    public class ProductModel : Product
    {
        public ProductModel()
        {
            ProductTypeList = new List<SelectListItem>();
        }

        [Required]
        [Display(Name = "Product Type")]
        public string ProductTypeId { get; set; }

        public List<SelectListItem> ProductTypeList { get; set; }
    }
}