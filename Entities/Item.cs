using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.AppConfiguration;

namespace CompanyForm.Entities
{
    public class Item
    {
        // ID
        public int ItemId { get; set; }

        // Code
        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Code must be exactly 8 digits.")]
        public int ItemCode { get; set; }

        // Name
        [Required, MaxLength(ConfigurationSettings.NameMaxLength)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string ItemName { get; set; }

        public ICollection<ItemUnitOfMeasurement> ItemUnitOfMeasurements { get; set; }
        public ICollection<SupplyVoucherList> SupplyVoucherLists { get; set; }
        public ICollection<DisbursementVoucherList> DisbursementVoucherLists { get; set; }
        public ICollection<TransferOperation> TransferOperations { get; set; }
    }
}
