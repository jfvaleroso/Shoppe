using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;


namespace Exchange.Web.Areas.Admin.Models
{
    public class ProductModel :Product
    {
        [Required]
        [Display(Name="Product Type")]
        public int ProductTypeId { get; set; }
        public List<SelectListItem> ProductTypeList { get; set; }
        public ProductModel()
        {
            this.ProductTypeList = new List<SelectListItem>();
        }
    }
}