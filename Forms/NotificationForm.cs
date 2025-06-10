using System;
using System.Windows.Forms;
using CompanyForm.Entities;
using CompnayForm.Context;

namespace CompanyForm.Forms
{
    public partial class NotificationForm : Form
    {
        private readonly NotificationService _notificationService;
        private readonly int _userId;

        public NotificationForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _notificationService = new NotificationService(new CompanyWarehouseContext());
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            notificationListView.Items.Clear();
            var notifications = _notificationService.GetUserNotifications(_userId);

            foreach (var notification in notifications)
            {
                var item = new ListViewItem(notification.Message);
                item.SubItems.Add(notification.CreatedAt.ToString("g"));
                item.Tag = notification.NotificationId;
                notificationListView.Items.Add(item);
            }

            notificationCountLabel.Text = $"Notifications: {notifications.Count}";
        }

        private void notificationListView_ItemActivate(object sender, EventArgs e)
        {
            if (notificationListView.SelectedItems.Count > 0)
            {
                int notificationId = (int)notificationListView.SelectedItems[0].Tag;
                _notificationService.MarkAsRead(notificationId);
                LoadNotifications();
            }
        }

        private void markAsReadButton_Click(object sender, EventArgs e)
        {
            if (notificationListView.SelectedItems.Count > 0)
            {
                int notificationId = (int)notificationListView.SelectedItems[0].Tag;
                _notificationService.MarkAsRead(notificationId);
                LoadNotifications();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}