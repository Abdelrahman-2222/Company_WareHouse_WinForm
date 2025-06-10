namespace CompanyForm
{
    partial class SupplierForm
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
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.myItemsGridView = new System.Windows.Forms.DataGridView();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.itemCodeLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.warehouseLabel = new System.Windows.Forms.Label();
            this.expirationLabel = new System.Windows.Forms.Label();
            this.ownerRelationshipsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.requestToOwnerButton = new System.Windows.Forms.Button();
            this.viewNotificationsButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.itemDetailsPanel = new System.Windows.Forms.Panel();
            this.categoryFilterLabel = new System.Windows.Forms.Label();
            this.relationshipsLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.myItemsGridView)).BeginInit();
            this.itemDetailsPanel.SuspendLayout();
            this.SuspendLayout();

            // categoryFilterLabel
            this.categoryFilterLabel.AutoSize = true;
            this.categoryFilterLabel.Location = new System.Drawing.Point(12, 15);
            this.categoryFilterLabel.Name = "categoryFilterLabel";
            this.categoryFilterLabel.Size = new System.Drawing.Size(58, 15);
            this.categoryFilterLabel.TabIndex = 0;
            this.categoryFilterLabel.Text = "Category:";

            // categoryComboBox
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(76, 12);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(200, 23);
            this.categoryComboBox.TabIndex = 1;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);

            // myItemsGridView
            this.myItemsGridView.AllowUserToAddRows = false;
            this.myItemsGridView.AllowUserToDeleteRows = false;
            this.myItemsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.myItemsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myItemsGridView.Location = new System.Drawing.Point(12, 45);
            this.myItemsGridView.MultiSelect = false;
            this.myItemsGridView.Name = "myItemsGridView";
            this.myItemsGridView.ReadOnly = true;
            this.myItemsGridView.RowHeadersVisible = false;
            this.myItemsGridView.RowTemplate.Height = 25;
            this.myItemsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myItemsGridView.Size = new System.Drawing.Size(570, 250);
            this.myItemsGridView.TabIndex = 2;
            this.myItemsGridView.SelectionChanged += new System.EventHandler(this.myItemsGridView_SelectionChanged);

            // itemDetailsPanel
            this.itemDetailsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.itemDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemDetailsPanel.Controls.Add(this.itemNameLabel);
            this.itemDetailsPanel.Controls.Add(this.itemCodeLabel);
            this.itemDetailsPanel.Controls.Add(this.categoryLabel);
            this.itemDetailsPanel.Controls.Add(this.quantityLabel);
            this.itemDetailsPanel.Controls.Add(this.warehouseLabel);
            this.itemDetailsPanel.Controls.Add(this.expirationLabel);
            this.itemDetailsPanel.Controls.Add(this.requestToOwnerButton);
            this.itemDetailsPanel.Location = new System.Drawing.Point(12, 305);
            this.itemDetailsPanel.Name = "itemDetailsPanel";
            this.itemDetailsPanel.Size = new System.Drawing.Size(570, 133);
            this.itemDetailsPanel.TabIndex = 3;

            // itemNameLabel
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.itemNameLabel.Location = new System.Drawing.Point(10, 10);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(36, 15);
            this.itemNameLabel.TabIndex = 4;
            this.itemNameLabel.Text = "Item:";

            // itemCodeLabel
            this.itemCodeLabel.AutoSize = true;
            this.itemCodeLabel.Location = new System.Drawing.Point(10, 35);
            this.itemCodeLabel.Name = "itemCodeLabel";
            this.itemCodeLabel.Size = new System.Drawing.Size(38, 15);
            this.itemCodeLabel.TabIndex = 5;
            this.itemCodeLabel.Text = "Code:";

            // categoryLabel
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(10, 60);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(58, 15);
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "Category:";

            // quantityLabel
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(10, 85);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(56, 15);
            this.quantityLabel.TabIndex = 7;
            this.quantityLabel.Text = "Quantity:";

            // warehouseLabel
            this.warehouseLabel.AutoSize = true;
            this.warehouseLabel.Location = new System.Drawing.Point(250, 35);
            this.warehouseLabel.Name = "warehouseLabel";
            this.warehouseLabel.Size = new System.Drawing.Size(71, 15);
            this.warehouseLabel.TabIndex = 8;
            this.warehouseLabel.Text = "Warehouse:";

            // expirationLabel
            this.expirationLabel.AutoSize = true;
            this.expirationLabel.Location = new System.Drawing.Point(250, 60);
            this.expirationLabel.Name = "expirationLabel";
            this.expirationLabel.Size = new System.Drawing.Size(59, 15);
            this.expirationLabel.TabIndex = 9;
            this.expirationLabel.Text = "Expires in:";

            // requestToOwnerButton
            this.requestToOwnerButton.Location = new System.Drawing.Point(430, 95);
            this.requestToOwnerButton.Name = "requestToOwnerButton";
            this.requestToOwnerButton.Size = new System.Drawing.Size(125, 23);
            this.requestToOwnerButton.TabIndex = 10;
            this.requestToOwnerButton.Text = "Request to Owner";
            this.requestToOwnerButton.UseVisualStyleBackColor = true;
            this.requestToOwnerButton.Click += new System.EventHandler(this.requestToOwnerButton_Click);

            // viewNotificationsButton
            this.viewNotificationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewNotificationsButton.Location = new System.Drawing.Point(652, 12);
            this.viewNotificationsButton.Name = "viewNotificationsButton";
            this.viewNotificationsButton.Size = new System.Drawing.Size(136, 23);
            this.viewNotificationsButton.TabIndex = 11;
            this.viewNotificationsButton.Text = "View Notifications";
            this.viewNotificationsButton.UseVisualStyleBackColor = true;
            this.viewNotificationsButton.Click += new System.EventHandler(this.viewNotificationsButton_Click);

            // addItemButton
            this.addItemButton.Location = new System.Drawing.Point(282, 12);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(120, 23);
            this.addItemButton.TabIndex = 12;
            this.addItemButton.Text = "Add Supply Item";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);

            // relationshipsLabel
            this.relationshipsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.relationshipsLabel.AutoSize = true;
            this.relationshipsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.relationshipsLabel.Location = new System.Drawing.Point(652, 45);
            this.relationshipsLabel.Name = "relationshipsLabel";
            this.relationshipsLabel.Size = new System.Drawing.Size(81, 15);
            this.relationshipsLabel.TabIndex = 13;
            this.relationshipsLabel.Text = "Relationships";

            // ownerRelationshipsPanel
            this.ownerRelationshipsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerRelationshipsPanel.AutoScroll = true;
            this.ownerRelationshipsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ownerRelationshipsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ownerRelationshipsPanel.Location = new System.Drawing.Point(652, 63);
            this.ownerRelationshipsPanel.Name = "ownerRelationshipsPanel";
            this.ownerRelationshipsPanel.Size = new System.Drawing.Size(136, 375);
            this.ownerRelationshipsPanel.TabIndex = 14;
            this.ownerRelationshipsPanel.WrapContents = false;

            // SupplierForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.categoryFilterLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.myItemsGridView);
            this.Controls.Add(this.itemDetailsPanel);
            this.Controls.Add(this.viewNotificationsButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.relationshipsLabel);
            this.Controls.Add(this.ownerRelationshipsPanel);
            this.Name = "SupplierForm";
            this.Text = "Supplier Dashboard";

            ((System.ComponentModel.ISupportInitialize)(this.myItemsGridView)).EndInit();
            this.itemDetailsPanel.ResumeLayout(false);
            this.itemDetailsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.DataGridView myItemsGridView;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label itemCodeLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label warehouseLabel;
        private System.Windows.Forms.Label expirationLabel;
        private System.Windows.Forms.FlowLayoutPanel ownerRelationshipsPanel;
        private System.Windows.Forms.Button requestToOwnerButton;
        private System.Windows.Forms.Button viewNotificationsButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Panel itemDetailsPanel;
        private System.Windows.Forms.Label categoryFilterLabel;
        private System.Windows.Forms.Label relationshipsLabel;
    }
}