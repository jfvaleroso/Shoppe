using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Exchange.Web.Models
{
   

    //[Table("UserProfile")]
    public class UserProfile
    {
        [Key]
      //  [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

  

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        //[Required]
        //[stringlength(100, errormessage = "the {0} must be at least {2} characters long.", minimumlength = 6)]
        //[datatype(datatype.password)]
        //[display(name = "password")]
        //public string password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        //provide initial profile
        //[Required]
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }

        //[Required]
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        //[Required]
        //[Display(Name = "Gender")]
        //public string Gender { get; set; }

        //[Required]
        //[Display(Name = "RoleName")]
        //public string RoleName { get; set; }

        //[Required]
        //[Display(Name = "StoreName")]
        //public string StoreName { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[Display(Name = "Birth Date")]
        //public string BirthDate { get; set; }

        //[Required]
        //[Display(Name = "Street")]
        //public string Street { get; set; }

        //[Required]
        //[Display(Name = "City")]
        //public string City { get; set; }

        //[Required]
        //[Display(Name = "State")]
        //public string State { get; set; }


        //[Required]
        //[Display(Name = "Zip")]
        //public string Zip { get; set; }


        //[Required]
        //[Display(Name = "Country")]
        //public string Country { get; set; }

        //[Required]
        //[Display(Name = "Language")]
        //public string Language { get; set; }

        //[Required]
        //[Display(Name = "Occupation")]
        //public string Occupation { get; set; }

        //[Required]
        //[Display(Name = "Subscription")]
        //public string Subscription { get; set; }
      
        public IEnumerable<SelectListItem> UserRoles { get; set; }
        public IEnumerable<SelectListItem> StoreList { get; set; }






    }

  
}
