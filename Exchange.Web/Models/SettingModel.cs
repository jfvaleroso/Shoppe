using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Web.Models
{
    public class SettingModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Owner { get; set; }
    }
}