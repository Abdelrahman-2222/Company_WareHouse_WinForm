namespace CompanyForm
{
    partial class CustomerForm
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
            mainTabControl = new TabControl();
            browseItemsTab = new TabPage();
            categoryLabel = new Label();
            categoryFilterComboBox = new ComboBox();
            itemsGridView = new DataGridView();
            itemDetailsPanel = new Panel();
            itemNameLabel = new Label();
            itemOwnerLabel = new Label();
            warehouseLabel = new Label();
            quantityLabel = new Label();
            quantityTextBox = new TextBox();
            requestItemButton = new Button();
            myOrdersTab = new TabPage();
            notificationsTab = new TabPage();
            ownerRelationshipsPanel = new FlowLayoutPanel();
            mainTabControl.SuspendLayout();
            browseItemsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)itemsGridView).BeginInit();
            itemDetailsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(browseItemsTab);
            mainTabControl.Controls.Add(myOrdersTab);
            mainTabControl.Controls.Add(notificationsTab);
            mainTabControl.Dock = DockStyle.Fill;
            mainTabControl.Location = new Point(0, 0);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(832, 553);
            mainTabControl.TabIndex = 1;
            // 
            // browseItemsTab
            // 
            browseItemsTab.Controls.Add(categoryLabel);
            browseItemsTab.Controls.Add(categoryFilterComboBox);
            browseItemsTab.Controls.Add(itemsGridView);
            browseItemsTab.Controls.Add(itemDetailsPanel);
            browseItemsTab.Location = new Point(4, 29);
            browseItemsTab.Name = "browseItemsTab";
            browseItemsTab.Size = new Size(824, 520);
            browseItemsTab.TabIndex = 0;
            browseItemsTab.Text = "Browse Items";
            // 
            // categoryLabel
            // 
            categoryLabel.Location = new Point(10, 15);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(87, 23);
            categoryLabel.TabIndex = 0;
            categoryLabel.Text = "Category:";
            // 
            // categoryFilterComboBox
            // 
            categoryFilterComboBox.Location = new Point(116, 15);
            categoryFilterComboBox.Name = "categoryFilterComboBox";
            categoryFilterComboBox.Size = new Size(186, 28);
            categoryFilterComboBox.TabIndex = 1;
            categoryFilterComboBox.SelectedIndexChanged += categoryFilterComboBox_SelectedIndexChanged;
            // 
            // itemsGridView
            // 
            itemsGridView.ColumnHeadersHeight = 29;
            itemsGridView.Location = new Point(10, 49);
            itemsGridView.MultiSelect = false;
            itemsGridView.Name = "itemsGridView";
            itemsGridView.RowHeadersWidth = 51;
            itemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            itemsGridView.Size = new Size(600, 300);
            itemsGridView.TabIndex = 2;
            itemsGridView.SelectionChanged += itemsGridView_SelectionChanged;
            // 
            // itemDetailsPanel
            // 
            itemDetailsPanel.BorderStyle = BorderStyle.FixedSingle;
            itemDetailsPanel.Controls.Add(itemNameLabel);
            itemDetailsPanel.Controls.Add(itemOwnerLabel);
            itemDetailsPanel.Controls.Add(warehouseLabel);
            itemDetailsPanel.Controls.Add(quantityLabel);
            itemDetailsPanel.Controls.Add(quantityTextBox);
            itemDetailsPanel.Controls.Add(requestItemButton);
            itemDetailsPanel.Location = new Point(10, 360);
            itemDetailsPanel.Name = "itemDetailsPanel";
            itemDetailsPanel.Size = new Size(600, 150);
            itemDetailsPanel.TabIndex = 3;
            // 
            // itemNameLabel
            // 
            itemNameLabel.AutoSize = true;
            itemNameLabel.Location = new Point(10, 10);
            itemNameLabel.Name = "itemNameLabel";
            itemNameLabel.Size = new Size(0, 20);
            itemNameLabel.TabIndex = 0;
            // 
            // itemOwnerLabel
            // 
            itemOwnerLabel.AutoSize = true;
            itemOwnerLabel.Location = new Point(10, 40);
            itemOwnerLabel.Name = "itemOwnerLabel";
            itemOwnerLabel.Size = new Size(0, 20);
            itemOwnerLabel.TabIndex = 1;
            // 
            // warehouseLabel
            // 
            warehouseLabel.AutoSize = true;
            warehouseLabel.Location = new Point(10, 70);
            warehouseLabel.Name = "warehouseLabel";
            warehouseLabel.Size = new Size(0, 20);
            warehouseLabel.TabIndex = 2;
            // 
            // quantityLabel
            // 
            quantityLabel.Location = new Point(10, 100);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(76, 23);
            quantityLabel.TabIndex = 3;
            quantityLabel.Text = "Quantity:";
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(92, 100);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(86, 27);
            quantityTextBox.TabIndex = 4;
            quantityTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // requestItemButton
            // 
            requestItemButton.Location = new Point(356, 97);
            requestItemButton.Name = "requestItemButton";
            requestItemButton.Size = new Size(169, 27);
            requestItemButton.TabIndex = 5;
            requestItemButton.Text = "Request Item";
            requestItemButton.Click += requestItemButton_Click;
            // 
            // myOrdersTab
            // 
            myOrdersTab.Location = new Point(4, 29);
            myOrdersTab.Name = "myOrdersTab";
            myOrdersTab.Size = new Size(824, 520);
            myOrdersTab.TabIndex = 1;
            myOrdersTab.Text = "My Orders";
            // 
            // notificationsTab
            // 
            notificationsTab.Location = new Point(4, 29);
            notificationsTab.Name = "notificationsTab";
            notificationsTab.Size = new Size(824, 520);
            notificationsTab.TabIndex = 2;
            notificationsTab.Text = "Notifications";
            // 
            // ownerRelationshipsPanel
            // 
            ownerRelationshipsPanel.AutoScroll = true;
            ownerRelationshipsPanel.BorderStyle = BorderStyle.FixedSingle;
            ownerRelationshipsPanel.Dock = DockStyle.Right;
            ownerRelationshipsPanel.Location = new Point(632, 0);
            ownerRelationshipsPanel.Name = "ownerRelationshipsPanel";
            ownerRelationshipsPanel.Size = new Size(200, 553);
            ownerRelationshipsPanel.TabIndex = 0;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 553);
            Controls.Add(ownerRelationshipsPanel);
            Controls.Add(mainTabControl);
            Name = "CustomerForm";
            Text = "Customer Portal";
            mainTabControl.ResumeLayout(false);
            browseItemsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)itemsGridView).EndInit();
            itemDetailsPanel.ResumeLayout(false);
            itemDetailsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Add these to your CustomerForm.Designer.cs
        private TabControl mainTabControl;
        private TabPage browseItemsTab;
        private TabPage myOrdersTab;
        private TabPage notificationsTab;

        // Browse Items tab components
        private ComboBox categoryFilterComboBox;
        private Label categoryLabel;
        private DataGridView itemsGridView;
        private Panel itemDetailsPanel;
        private Label itemNameLabel;
        private Label itemOwnerLabel;
        private Label warehouseLabel;
        private Button requestItemButton;
        private TextBox quantityTextBox;
        private Label quantityLabel;

        // Relationship status components
        private FlowLayoutPanel ownerRelationshipsPanel;
    }
}