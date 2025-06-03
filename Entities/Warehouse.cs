using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.AppConfiguration;
using CompanyForm.Entities;

namespace CompnayForm.Entities
{
    public class Warehouse
    {
        // ID
        public int WarehouseId { get; set; }

        // WName
        [Required, MaxLength(ConfigurationSettings.NameMaxLength)]
        public string WarehouseName { get; set; }

        // Address
        [Required, MaxLength(ConfigurationSettings.AddressMaxLength)]
        [RegularExpression(@"^[A-Za-z0-9\s\.,\-\/'#()]{5,100}$", ErrorMessage = "Address can contain letters, numbers, spaces, and common punctuation, and must be 5 to 100 characters.")]
        public string WarehouseAddress { get; set; }

        // PersonName
        [Required, MaxLength(ConfigurationSettings.NameMaxLength)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string WarehousePersonName { get; set; }


        // Navigation Properties (Ternary Operations)
        public ICollection<SupplyVoucher> SupplyVouchers { get; set; }
        public ICollection<DisbursementVoucher> DisbursementVouchers { get; set; }
    }
}
