using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.AppConfiguration;

namespace CompanyForm.Entities
{
    public class UnitOfMeasurement
    {
        // Id
        public int UnitOfMeasurementId { get; set; }


        // Name
        [Required, MaxLength((ConfigurationSettings.NameMaxLength) / 2)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string UnitOfMeasurementName { get; set; }


        // Property
        public ICollection<ItemUnitOfMeasurement> ItemUnitOfMeasurements { get; set; }
    }
}
