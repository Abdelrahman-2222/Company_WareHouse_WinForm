using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyForm.Entities
{
    public class SupplyVoucherList
    {
        public int SupplyVoucherListQuantity { get; set; }
        public DateTime SupplyVoucherListProductionDate { get; set; }

        public DateTime SupplyVoucherListExpirationDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int SupplyVoucherListDaysUntilExpiration { get; private set; }


        // PK / FK
        public int SupplyVoucherId { get; set; }
        public int ItemId { get; set; }

        public SupplyVoucher SupplyVoucher { get; set; }
        public Item Item { get; set; }


    }
}
