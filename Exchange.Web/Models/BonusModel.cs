using System.ComponentModel.DataAnnotations;

namespace Exchange.Web.Models
{
    public class BonusModel
    {
        [Required]
        public string PassCode { get; set; }
    }
}