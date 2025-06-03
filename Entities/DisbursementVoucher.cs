using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompnayForm.Entities;

namespace CompanyForm.Entities
{
    public class DisbursementVoucher
    {
        public int DisbursementVoucherId {get; set; }
        
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Code must be exactly 6 digits.")]

        public int DisbursementVoucherNumber { get; set; }
        public DateTime DisbursementVoucherDate { get; set; }


        // FK
        public int WarehouseId { get; set; }
        public int CustomerId { get; set; }

        public Warehouse Warehouse { get; set; }

        public Customer Customer { get; set; }

        public ICollection<DisbursementVoucherList> DisbursementVoucherLists { get; set; }
    }
}
