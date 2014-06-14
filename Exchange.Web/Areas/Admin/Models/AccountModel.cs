using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Exchange.Web.Areas.Admin.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            RoleList = new List<SelectListItem>();
            StoreList = new List<SelectListItem>();
        }

        public string Id { get; set; }

        // [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        //provide initial profile
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; }

        public string BirthMonth { get; set; }

        public string BirthDay { get; set; }

        public string BirthYear { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        // [Required]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        //[Required]
        [Display(Name = "Subscription")]
        public string Subscription { get; set; }

        //[Required]
        [Display(Name = "RoleName")]
        public string RoleName { get; set; }

        //[Required]
        [Display(Name = "StoreName")]
        public string StoreId { get; set; }

        public IList<SelectListItem> RoleList { get; set; }

        public IList<SelectListItem> StoreList { get; set; }
    }
}