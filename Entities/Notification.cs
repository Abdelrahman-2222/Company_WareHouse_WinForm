using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyForm.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int RecipientUserId { get; set; }
        public AppUser Recipient { get; set; }

        [Required, MaxLength(500)]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;

        public string EntityType { get; set; }
        public int? EntityId { get; set; }

        [MaxLength(50)]
        public string NotificationType { get; set; } = "Info";
    }
}
