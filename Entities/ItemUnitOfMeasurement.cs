using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyForm.Entities
{
    public class ItemUnitOfMeasurement
    {
        // FKs and Composite PKs
        public int ItemId { get; set; }
        public int UnitOfMeasurementId { get; set; }

        public Item Item { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
