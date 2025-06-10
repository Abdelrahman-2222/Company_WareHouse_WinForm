namespace CompanyForm.Forms
{
    partial class NotificationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.notificationListView = new System.Windows.Forms.ListView();
            this.messageHeader = new System.Windows.Forms.ColumnHeader();
            this.dateHeader = new System.Windows.Forms.ColumnHeader();
            this.markAsReadButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.notificationCountLabel = new System.Windows.Forms.Label();

            // notificationListView
            this.notificationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.messageHeader,
                this.dateHeader});
            this.notificationListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.notificationListView.FullRowSelect = true;
            this.notificationListView.HideSelection = false;
            this.notificationListView.Location = new System.Drawing.Point(0, 0);
            this.notificationListView.Name = "notificationListView";
            this.notificationListView.Size = new System.Drawing.Size(800, 350);
            this.notificationListView.TabIndex = 0;
            this.notificationListView.UseCompatibleStateImageBehavior = false;
            this.notificationListView.View = System.Windows.Forms.View.Details;
            this.notificationListView.ItemActivate += new System.EventHandler(this.notificationListView_ItemActivate);

            // messageHeader
            this.messageHeader.Text = "Message";
            this.messageHeader.Width = 500;

            // dateHeader
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 200;

            // markAsReadButton
            this.markAsReadButton.Location = new System.Drawing.Point(12, 365);
            this.markAsReadButton.Name = "markAsReadButton";
            this.markAsReadButton.Size = new System.Drawing.Size(120, 30);
            this.markAsReadButton.TabIndex = 1;
            this.markAsReadButton.Text = "Mark as Read";
            this.markAsReadButton.UseVisualStyleBackColor = true;
            this.markAsReadButton.Click += new System.EventHandler(this.markAsReadButton_Click);

            // closeButton
            this.closeButton.Location = new System.Drawing.Point(668, 365);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 30);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);

            // notificationCountLabel
            this.notificationCountLabel.AutoSize = true;
            this.notificationCountLabel.Location = new System.Drawing.Point(12, 410);
            this.notificationCountLabel.Name = "notificationCountLabel";
            this.notificationCountLabel.Size = new System.Drawing.Size(103, 15);
            this.notificationCountLabel.TabIndex = 3;
            this.notificationCountLabel.Text = "No notifications";

            // NotificationForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.notificationCountLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.markAsReadButton);
            this.Controls.Add(this.notificationListView);
            this.Name = "NotificationForm";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView notificationListView;
        private System.Windows.Forms.ColumnHeader messageHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.Button markAsReadButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label notificationCountLabel;
    }
}