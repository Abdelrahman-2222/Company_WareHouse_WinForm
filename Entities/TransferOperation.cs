using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using CompnayForm.Entities;

namespace CompanyForm.Entities
{
    public class TransferOperation
    {
        public int TransferOperationId { get; set; }
        public int TransferOperationNumber { get; set; }
        public DateTime TransferOperationDate { get; set; }
        
        // FK
        public int ItemId { get; set; }
        public int SupplierId { get; set; }
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get;set; }

        public Item Item { get; set; }
        public Supplier Supplier { get; set; }
        public Warehouse FromWarehouse { get; set; }
        public Warehouse ToWarehouse { get; set; }
    }
}
