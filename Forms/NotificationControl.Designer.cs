namespace CompanyForm.Forms
{
    partial class NotificationControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            notificationListView = new ListView();
            NotificationCountLabel = new Label();
            SuspendLayout();
            // 
            // notificationListView
            // 
            notificationListView.Location = new Point(212, 31);
            notificationListView.Name = "notificationListView";
            notificationListView.Size = new Size(260, 208);
            notificationListView.TabIndex = 0;
            notificationListView.UseCompatibleStateImageBehavior = false;
            // 
            // NotificationCountLabel
            // 
            NotificationCountLabel.AutoSize = true;
            NotificationCountLabel.Location = new Point(22, 101);
            NotificationCountLabel.Name = "NotificationCountLabel";
            NotificationCountLabel.Size = new Size(131, 20);
            NotificationCountLabel.TabIndex = 1;
            NotificationCountLabel.Text = "Notification Count";
            // 
            // NotificationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NotificationCountLabel);
            Controls.Add(notificationListView);
            Name = "NotificationControl";
            Size = new Size(490, 358);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView notificationListView;
        private Label NotificationCountLabel;
    }
}
