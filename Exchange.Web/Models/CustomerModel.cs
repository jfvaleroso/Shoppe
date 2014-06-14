using System.ComponentModel.DataAnnotations;

namespace Exchange.Web.Models
{
    public class CustomerModel
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        public string TelephoneNo { get; set; }

        public string CellphoneNo { get; set; }

        public string Email { get; set; }

        [Required]
        public string BirthDate { get; set; }

        public string Gender { get; set; }

        public string OfficeAddress { get; set; }

        [Required]
        public string ResidentialAddress { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string TypeOfID { get; set; }

        public string IDNo { get; set; }
    }
}