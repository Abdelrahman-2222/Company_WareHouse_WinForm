using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyForm.Entities
{
    public class DisbursementVoucherList
    {
        public int DisbursementVoucherListQuantity { get; set; }

        // PK / FK
        public int ItemId { get; set; }
        public int DisbursementVoucherId { get; set; }

        public Item Item { get; set; }
        public DisbursementVoucher DisbursementVoucher { get; set; }
    }
}
