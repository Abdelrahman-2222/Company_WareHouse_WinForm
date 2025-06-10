using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompnayForm.Context;

namespace CompanyForm.Entities
{
    public class NotificationService
    {
        private readonly CompanyWarehouseContext _context;

        public NotificationService(CompanyWarehouseContext context)
        {
            _context = context;
        }

        public static void SendNotification(int recipientUserId, string message,
            string notificationType = "Info", string entityType = null, int? entityId = null)
        {
            using (var context = new CompanyWarehouseContext())
            {
                var notification = new Notification
                {
                    RecipientUserId = recipientUserId,
                    Message = message,
                    NotificationType = notificationType,
                    EntityType = entityType,
                    EntityId = entityId
                };

                context.Notifications.Add(notification);
                context.SaveChanges();
            }
        }

        public List<Notification> GetUserNotifications(int userId, bool unreadOnly = false)
        {
            var query = _context.Notifications
                .Where(n => n.RecipientUserId == userId);

            if (unreadOnly)
                query = query.Where(n => !n.IsRead);

            return query.OrderByDescending(n => n.CreatedAt).ToList();
        }

        public void MarkAsRead(int notificationId)
        {
            var notification = _context.Notifications.Find(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.SaveChanges();
            }
        }
    }
}
