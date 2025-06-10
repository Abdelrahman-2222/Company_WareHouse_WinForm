using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.AppConfiguration;

namespace CompanyForm.Entities
{
    public class Supplier
    {
        // ID
        public int SupplierId { get; set; }

        // Name
        [Required, MaxLength(ConfigurationSettings.NameMaxLength)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string SupplierName { get; set; }

        // Email
        [Required, MaxLength(ConfigurationSettings.EmailMaxLength), EmailAddress]
        public string SupplierEmail { get; set; }

        // Mobile Number
        [Required, MaxLength(ConfigurationSettings.PhoneMaxLength)]
        [RegularExpression(@"^\+?\d{8,15}$", ErrorMessage = "Mobile number must be 8 to 15 digits, optionally starting with '+'.")]
        public string SupplierMobileNumber { get; set; }

        public ICollection<SupplyVoucher> SupplierVouchers { get; set; }
        public ICollection<TransferOperation> TransferOperations { get; set; }

        // Add to Customer class
        public int? UserId { get; set; }
        public AppUser User { get; set; }
    }
}
