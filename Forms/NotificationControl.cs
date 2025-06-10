using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyForm.Entities;
using CompnayForm.Context;

namespace CompanyForm.Forms
{
    public partial class NotificationControl : UserControl
    {
        private readonly NotificationService _notificationService;
        private readonly int _currentUserId;

        public NotificationControl(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            _notificationService = new NotificationService(new CompanyWarehouseContext());

            // Set up UI elements
            LoadNotifications();
        }

        public void LoadNotifications()
        {
            var notifications = _notificationService.GetUserNotifications(_currentUserId, true);

            // Update badge count
            NotificationCountLabel.Text = notifications.Count > 0 ? notifications.Count.ToString() : "";
            NotificationCountLabel.Visible = notifications.Count > 0;

            // Update notification list
            notificationListView.Items.Clear();
            foreach (var notification in notifications)
            {
                var item = new ListViewItem(notification.Message);
                item.SubItems.Add(notification.CreatedAt.ToString("g"));
                item.Tag = notification.NotificationId;

                notificationListView.Items.Add(item);
            }
        }

        private void notificationListView_ItemActivate(object sender, EventArgs e)
        {
            if (notificationListView.SelectedItems.Count > 0)
            {
                var notificationId = (int)notificationListView.SelectedItems[0].Tag;
                _notificationService.MarkAsRead(notificationId);
                LoadNotifications();

                // Handle the notification based on EntityType and EntityId if needed
            }
        }
    }
}
