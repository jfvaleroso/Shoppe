using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exchange.Web.Models
{
    public class BonusModel
    {
        [Required]
        public string PassCode { get; set; }
    }
}