using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.AppConfiguration;

namespace CompanyForm.Entities
{
    public class Owner
    {
        // ID
        public int OwnerId { get; set; }


        // Name
        [Required, MaxLength(ConfigurationSettings.NameMaxLength)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string OwnerName { get; set; }


        // Email
        [Required, MaxLength(ConfigurationSettings.EmailMaxLength), EmailAddress]
        public string OwnerEmail { get; set; }

        public int? UserId { get; set; }
        public AppUser User { get; set; }

    }
}
