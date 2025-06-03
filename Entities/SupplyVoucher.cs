using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompnayForm.Entities;

namespace CompanyForm.Entities
{
    public class SupplyVoucher
    {
        public int SupplyVoucherId {get; set; }
        //[Required] Redundant
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Code must be exactly 6 digits.")]

        public int SupplyVoucherNumber { get; set; }

        // [Required] Redundant
        public DateTime SupplyVoucherDate { get; set; }

        // FK
        public int WarehouseId { get; set; }
        public int SupplierId { get; set; }

        public Warehouse Warehouse { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<SupplyVoucherList> SupplyVoucherLists { get; set; }
    }
}
