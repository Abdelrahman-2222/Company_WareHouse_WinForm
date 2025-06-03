using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.AppConfiguration;

namespace CompanyForm.Entities
{
    public class Customer
    {
        // ID
        public int CustomerId { get; set; }


        // Name
        [Required, MaxLength(ConfigurationSettings.NameMaxLength)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string CustomerName { get; set; }


        // Email
        [Required, MaxLength(ConfigurationSettings.EmailMaxLength), EmailAddress]
        public string CustomerEmail { get; set; }


        // Mobile Number
        [Required, MaxLength(ConfigurationSettings.PhoneMaxLength)]
        [RegularExpression(@"^\+?\d{8,15}$", ErrorMessage = "Mobile number must be 8 to 15 digits, optionally starting with '+'.")]
        public string CustomerMobileNumber { get; set; }


        // Fax
        [MaxLength(ConfigurationSettings.EmailMaxLength)]
        [RegularExpression(@"^\+?[\d\s\-\(\)]{8,20}$", ErrorMessage = "Fax number must be 8 to 20 characters and can include digits, spaces, dashes, parentheses, and an optional '+'.")]

        public string? CustomerFax { get; set; }


        // Phone Number
        [MaxLength(ConfigurationSettings.PhoneMaxLength)]
        [RegularExpression(@"^\+?[\d\s\-\(\)]{8,20}$", ErrorMessage = "Phone number must be 8 to 20 characters and can include digits, spaces, dashes, parentheses, and an optional '+'.")]
        public string? CustomerPhone { get; set; }

        public ICollection<DisbursementVoucher> DisbursementVouchers { get; set; }
    }
}
