namespace CompanyForm
{
    partial class AdvancedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedForm));
            toolStrip1 = new ToolStrip();
            SupplyVoucherDrop1 = new ToolStripDropDownButton();
            addSupply = new ToolStripMenuItem();
            updateSupply = new ToolStripMenuItem();
            DisbursementVoucherDrop = new ToolStripDropDownButton();
            addDisbursement = new ToolStripMenuItem();
            updateDisbursement = new ToolStripMenuItem();
            TransferDrop = new ToolStripDropDownButton();
            insertToolStripMenuItem = new ToolStripMenuItem();
            ReportDrop = new ToolStripDropDownButton();
            warehouseToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem = new ToolStripMenuItem();
            itemToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem1 = new ToolStripMenuItem();
            itemMovementToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem2 = new ToolStripMenuItem();
            expiredItemsToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem3 = new ToolStripMenuItem();
            nearExpirationItemsToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem4 = new ToolStripMenuItem();
            AdvancedGridView = new DataGridView();
            itemLblName = new Label();
            itemNameTbx = new TextBox();
            DisplayLbl = new Label();
            DownlBtn = new Button();
            TransferDateLbl = new Label();
            itemIdLbl = new Label();
            SupplierIdLbl = new Label();
            F_WarehouseIdLbl = new Label();
            T_WarehouseLbl = new Label();
            transferDateTxtBox = new TextBox();
            ItemComboBox = new ComboBox();
            SupplierComboBox = new ComboBox();
            FromWarehouseComboBox = new ComboBox();
            ToWarehouseComboBox = new ComboBox();
            InsertBtn = new Button();
            ProductionLbl = new Label();
            QuantityTxtBox = new TextBox();
            ExpirationLbl = new Label();
            ExpirationDate = new DateTimePicker();
            ProductionDate = new DateTimePicker();
            UpdateBtn = new Button();
            supplierVoucherIDLbl = new Label();
            SupplierVoucherIdCbx = new ComboBox();
            itemIdLblSupply = new Label();
            itemComboUpdate = new ComboBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AdvancedGridView).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { SupplyVoucherDrop1, DisbursementVoucherDrop, TransferDrop, ReportDrop });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1143, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // SupplyVoucherDrop1
            // 
            SupplyVoucherDrop1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SupplyVoucherDrop1.DropDownItems.AddRange(new ToolStripItem[] { addSupply, updateSupply });
            SupplyVoucherDrop1.Image = (Image)resources.GetObject("SupplyVoucherDrop1.Image");
            SupplyVoucherDrop1.ImageTransparentColor = Color.Magenta;
            SupplyVoucherDrop1.Name = "SupplyVoucherDrop1";
            SupplyVoucherDrop1.Size = new Size(125, 24);
            SupplyVoucherDrop1.Text = "Supply Voucher";
            SupplyVoucherDrop1.Click += SupplyVoucherDrop1_Click;
            // 
            // addSupply
            // 
            addSupply.Name = "addSupply";
            addSupply.Size = new Size(141, 26);
            addSupply.Text = "Add";
            addSupply.Click += addSupply_Click;
            // 
            // updateSupply
            // 
            updateSupply.Name = "updateSupply";
            updateSupply.Size = new Size(141, 26);
            updateSupply.Text = "Update";
            updateSupply.Click += updateSupply_Click;
            // 
            // DisbursementVoucherDrop
            // 
            DisbursementVoucherDrop.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DisbursementVoucherDrop.DropDownItems.AddRange(new ToolStripItem[] { addDisbursement, updateDisbursement });
            DisbursementVoucherDrop.Image = (Image)resources.GetObject("DisbursementVoucherDrop.Image");
            DisbursementVoucherDrop.ImageTransparentColor = Color.Magenta;
            DisbursementVoucherDrop.Name = "DisbursementVoucherDrop";
            DisbursementVoucherDrop.Size = new Size(171, 24);
            DisbursementVoucherDrop.Text = "Disbursement Voucher";
            DisbursementVoucherDrop.Click += DisbursementVoucherDrop_Click;
            // 
            // addDisbursement
            // 
            addDisbursement.Name = "addDisbursement";
            addDisbursement.Size = new Size(141, 26);
            addDisbursement.Text = "Add";
            addDisbursement.Click += addDisbursement_Click;
            // 
            // updateDisbursement
            // 
            updateDisbursement.Name = "updateDisbursement";
            updateDisbursement.Size = new Size(141, 26);
            updateDisbursement.Text = "Update";
            updateDisbursement.Click += updateDisbursement_Click;
            // 
            // TransferDrop
            // 
            TransferDrop.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TransferDrop.DropDownItems.AddRange(new ToolStripItem[] { insertToolStripMenuItem });
            TransferDrop.Image = (Image)resources.GetObject("TransferDrop.Image");
            TransferDrop.ImageTransparentColor = Color.Magenta;
            TransferDrop.Name = "TransferDrop";
            TransferDrop.Size = new Size(146, 24);
            TransferDrop.Text = "Transfer Operation";
            TransferDrop.Click += TransferDrop_Click;
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new Size(224, 26);
            insertToolStripMenuItem.Text = "Insert";
            insertToolStripMenuItem.Click += insertToolStripMenuItem_Click;
            // 
            // ReportDrop
            // 
            ReportDrop.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ReportDrop.DropDownItems.AddRange(new ToolStripItem[] { warehouseToolStripMenuItem, itemToolStripMenuItem, itemMovementToolStripMenuItem, expiredItemsToolStripMenuItem, nearExpirationItemsToolStripMenuItem });
            ReportDrop.Image = (Image)resources.GetObject("ReportDrop.Image");
            ReportDrop.ImageTransparentColor = Color.Magenta;
            ReportDrop.Name = "ReportDrop";
            ReportDrop.Size = new Size(74, 24);
            ReportDrop.Text = "Reports";
            // 
            // warehouseToolStripMenuItem
            // 
            warehouseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadToolStripMenuItem });
            warehouseToolStripMenuItem.Name = "warehouseToolStripMenuItem";
            warehouseToolStripMenuItem.Size = new Size(237, 26);
            warehouseToolStripMenuItem.Text = "Warehouse";
            warehouseToolStripMenuItem.Click += warehouseToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem
            // 
            downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            downloadToolStripMenuItem.Size = new Size(161, 26);
            downloadToolStripMenuItem.Text = "Download";
            downloadToolStripMenuItem.Click += downloadToolStripMenuItem_Click;
            // 
            // itemToolStripMenuItem
            // 
            itemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadToolStripMenuItem1 });
            itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            itemToolStripMenuItem.Size = new Size(237, 26);
            itemToolStripMenuItem.Text = "Item";
            itemToolStripMenuItem.Click += itemToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem1
            // 
            downloadToolStripMenuItem1.Name = "downloadToolStripMenuItem1";
            downloadToolStripMenuItem1.Size = new Size(161, 26);
            downloadToolStripMenuItem1.Text = "Download";
            downloadToolStripMenuItem1.Click += downloadToolStripMenuItem1_Click;
            // 
            // itemMovementToolStripMenuItem
            // 
            itemMovementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadToolStripMenuItem2 });
            itemMovementToolStripMenuItem.Name = "itemMovementToolStripMenuItem";
            itemMovementToolStripMenuItem.Size = new Size(237, 26);
            itemMovementToolStripMenuItem.Text = "Item movement";
            itemMovementToolStripMenuItem.Click += itemMovementToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem2
            // 
            downloadToolStripMenuItem2.Name = "downloadToolStripMenuItem2";
            downloadToolStripMenuItem2.Size = new Size(161, 26);
            downloadToolStripMenuItem2.Text = "Download";
            downloadToolStripMenuItem2.Click += downloadToolStripMenuItem2_Click;
            // 
            // expiredItemsToolStripMenuItem
            // 
            expiredItemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadToolStripMenuItem3 });
            expiredItemsToolStripMenuItem.Name = "expiredItemsToolStripMenuItem";
            expiredItemsToolStripMenuItem.Size = new Size(237, 26);
            expiredItemsToolStripMenuItem.Text = "Items Aging";
            expiredItemsToolStripMenuItem.Click += expiredItemsToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem3
            // 
            downloadToolStripMenuItem3.Name = "downloadToolStripMenuItem3";
            downloadToolStripMenuItem3.Size = new Size(224, 26);
            downloadToolStripMenuItem3.Text = "Download";
            downloadToolStripMenuItem3.Click += downloadToolStripMenuItem3_Click;
            // 
            // nearExpirationItemsToolStripMenuItem
            // 
            nearExpirationItemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadToolStripMenuItem4 });
            nearExpirationItemsToolStripMenuItem.Name = "nearExpirationItemsToolStripMenuItem";
            nearExpirationItemsToolStripMenuItem.Size = new Size(237, 26);
            nearExpirationItemsToolStripMenuItem.Text = "Near-Expiration Items";
            nearExpirationItemsToolStripMenuItem.Click += nearExpirationItemsToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem4
            // 
            downloadToolStripMenuItem4.Name = "downloadToolStripMenuItem4";
            downloadToolStripMenuItem4.Size = new Size(161, 26);
            downloadToolStripMenuItem4.Text = "Download";
            downloadToolStripMenuItem4.Click += downloadToolStripMenuItem4_Click;
            // 
            // AdvancedGridView
            // 
            AdvancedGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AdvancedGridView.Location = new Point(489, 63);
            AdvancedGridView.Name = "AdvancedGridView";
            AdvancedGridView.RowHeadersWidth = 51;
            AdvancedGridView.Size = new Size(642, 365);
            AdvancedGridView.TabIndex = 1;
            AdvancedGridView.Visible = false;
            // 
            // itemLblName
            // 
            itemLblName.AutoSize = true;
            itemLblName.Location = new Point(8, 215);
            itemLblName.Name = "itemLblName";
            itemLblName.Size = new Size(83, 20);
            itemLblName.TabIndex = 3;
            itemLblName.Text = "Item Name";
            itemLblName.Visible = false;
            // 
            // itemNameTbx
            // 
            itemNameTbx.Location = new Point(172, 212);
            itemNameTbx.Name = "itemNameTbx";
            itemNameTbx.Size = new Size(178, 27);
            itemNameTbx.TabIndex = 4;
            itemNameTbx.Visible = false;
            itemNameTbx.KeyPress += itemNameTbx_KeyPress;
            // 
            // DisplayLbl
            // 
            DisplayLbl.AutoSize = true;
            DisplayLbl.Location = new Point(12, 63);
            DisplayLbl.Name = "DisplayLbl";
            DisplayLbl.Size = new Size(433, 20);
            DisplayLbl.TabIndex = 5;
            DisplayLbl.Text = "Enter the item name you want to download or * to download all";
            DisplayLbl.Visible = false;
            // 
            // DownlBtn
            // 
            DownlBtn.Location = new Point(104, 206);
            DownlBtn.Name = "DownlBtn";
            DownlBtn.Size = new Size(163, 29);
            DownlBtn.TabIndex = 6;
            DownlBtn.Text = "Download";
            DownlBtn.UseVisualStyleBackColor = true;
            DownlBtn.Visible = false;
            DownlBtn.Click += DownlBtn_Click;
            // 
            // TransferDateLbl
            // 
            TransferDateLbl.AutoSize = true;
            TransferDateLbl.Location = new Point(8, 269);
            TransferDateLbl.Name = "TransferDateLbl";
            TransferDateLbl.Size = new Size(97, 20);
            TransferDateLbl.TabIndex = 7;
            TransferDateLbl.Text = "Transfer Date";
            TransferDateLbl.Visible = false;
            // 
            // itemIdLbl
            // 
            itemIdLbl.AutoSize = true;
            itemIdLbl.Location = new Point(8, 357);
            itemIdLbl.Name = "itemIdLbl";
            itemIdLbl.Size = new Size(83, 20);
            itemIdLbl.TabIndex = 8;
            itemIdLbl.Text = "Item Name";
            itemIdLbl.Visible = false;
            // 
            // SupplierIdLbl
            // 
            SupplierIdLbl.AutoSize = true;
            SupplierIdLbl.Location = new Point(8, 312);
            SupplierIdLbl.Name = "SupplierIdLbl";
            SupplierIdLbl.Size = new Size(108, 20);
            SupplierIdLbl.TabIndex = 9;
            SupplierIdLbl.Text = "Supplier Name";
            SupplierIdLbl.Visible = false;
            // 
            // F_WarehouseIdLbl
            // 
            F_WarehouseIdLbl.AutoSize = true;
            F_WarehouseIdLbl.Location = new Point(8, 408);
            F_WarehouseIdLbl.Name = "F_WarehouseIdLbl";
            F_WarehouseIdLbl.Size = new Size(139, 20);
            F_WarehouseIdLbl.TabIndex = 10;
            F_WarehouseIdLbl.Text = "F_Warehouse Name";
            F_WarehouseIdLbl.Visible = false;
            // 
            // T_WarehouseLbl
            // 
            T_WarehouseLbl.AutoSize = true;
            T_WarehouseLbl.Location = new Point(8, 460);
            T_WarehouseLbl.Name = "T_WarehouseLbl";
            T_WarehouseLbl.Size = new Size(142, 20);
            T_WarehouseLbl.TabIndex = 11;
            T_WarehouseLbl.Text = "T_Warehouse_Name";
            T_WarehouseLbl.Visible = false;
            // 
            // transferDateTxtBox
            // 
            transferDateTxtBox.Location = new Point(172, 262);
            transferDateTxtBox.Name = "transferDateTxtBox";
            transferDateTxtBox.ReadOnly = true;
            transferDateTxtBox.Size = new Size(178, 27);
            transferDateTxtBox.TabIndex = 16;
            transferDateTxtBox.Visible = false;
            // 
            // ItemComboBox
            // 
            ItemComboBox.FormattingEnabled = true;
            ItemComboBox.Location = new Point(172, 349);
            ItemComboBox.Name = "ItemComboBox";
            ItemComboBox.Size = new Size(178, 28);
            ItemComboBox.TabIndex = 17;
            ItemComboBox.Visible = false;
            // 
            // SupplierComboBox
            // 
            SupplierComboBox.FormattingEnabled = true;
            SupplierComboBox.Location = new Point(172, 304);
            SupplierComboBox.Name = "SupplierComboBox";
            SupplierComboBox.Size = new Size(178, 28);
            SupplierComboBox.TabIndex = 18;
            SupplierComboBox.Visible = false;
            // 
            // FromWarehouseComboBox
            // 
            FromWarehouseComboBox.FormattingEnabled = true;
            FromWarehouseComboBox.Location = new Point(172, 400);
            FromWarehouseComboBox.Name = "FromWarehouseComboBox";
            FromWarehouseComboBox.Size = new Size(178, 28);
            FromWarehouseComboBox.TabIndex = 19;
            FromWarehouseComboBox.Visible = false;
            // 
            // ToWarehouseComboBox
            // 
            ToWarehouseComboBox.FormattingEnabled = true;
            ToWarehouseComboBox.Location = new Point(172, 452);
            ToWarehouseComboBox.Name = "ToWarehouseComboBox";
            ToWarehouseComboBox.Size = new Size(178, 28);
            ToWarehouseComboBox.TabIndex = 20;
            ToWarehouseComboBox.Visible = false;
            // 
            // InsertBtn
            // 
            InsertBtn.Location = new Point(104, 609);
            InsertBtn.Name = "InsertBtn";
            InsertBtn.Size = new Size(163, 29);
            InsertBtn.TabIndex = 21;
            InsertBtn.Text = "Add";
            InsertBtn.UseVisualStyleBackColor = true;
            InsertBtn.Visible = false;
            InsertBtn.Click += InsertBtn_Click;
            // 
            // ProductionLbl
            // 
            ProductionLbl.AutoSize = true;
            ProductionLbl.Location = new Point(8, 509);
            ProductionLbl.Name = "ProductionLbl";
            ProductionLbl.Size = new Size(117, 20);
            ProductionLbl.TabIndex = 22;
            ProductionLbl.Text = "Production Date";
            ProductionLbl.Visible = false;
            // 
            // QuantityTxtBox
            // 
            QuantityTxtBox.Location = new Point(172, 304);
            QuantityTxtBox.Name = "QuantityTxtBox";
            QuantityTxtBox.Size = new Size(178, 27);
            QuantityTxtBox.TabIndex = 24;
            QuantityTxtBox.Visible = false;
            // 
            // ExpirationLbl
            // 
            ExpirationLbl.AutoSize = true;
            ExpirationLbl.Location = new Point(8, 562);
            ExpirationLbl.Name = "ExpirationLbl";
            ExpirationLbl.Size = new Size(112, 20);
            ExpirationLbl.TabIndex = 26;
            ExpirationLbl.Text = "Expiration Date";
            ExpirationLbl.Visible = false;
            // 
            // ExpirationDate
            // 
            ExpirationDate.Location = new Point(172, 555);
            ExpirationDate.Name = "ExpirationDate";
            ExpirationDate.Size = new Size(250, 27);
            ExpirationDate.TabIndex = 27;
            ExpirationDate.Value = new DateTime(2025, 6, 2, 0, 0, 0, 0);
            ExpirationDate.Visible = false;
            // 
            // ProductionDate
            // 
            ProductionDate.Location = new Point(172, 502);
            ProductionDate.Name = "ProductionDate";
            ProductionDate.Size = new Size(250, 27);
            ProductionDate.TabIndex = 28;
            ProductionDate.Value = new DateTime(2025, 6, 2, 0, 0, 0, 0);
            ProductionDate.Visible = false;
            // 
            // UpdateBtn
            // 
            UpdateBtn.Location = new Point(104, 609);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(163, 29);
            UpdateBtn.TabIndex = 29;
            UpdateBtn.Text = "Update";
            UpdateBtn.UseVisualStyleBackColor = true;
            UpdateBtn.Visible = false;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // supplierVoucherIDLbl
            // 
            supplierVoucherIDLbl.AutoSize = true;
            supplierVoucherIDLbl.Location = new Point(8, 157);
            supplierVoucherIDLbl.Name = "supplierVoucherIDLbl";
            supplierVoucherIDLbl.Size = new Size(138, 20);
            supplierVoucherIDLbl.TabIndex = 30;
            supplierVoucherIDLbl.Text = "Supplier Voucher Id";
            supplierVoucherIDLbl.Visible = false;
            // 
            // SupplierVoucherIdCbx
            // 
            SupplierVoucherIdCbx.FormattingEnabled = true;
            SupplierVoucherIdCbx.Location = new Point(172, 149);
            SupplierVoucherIdCbx.Name = "SupplierVoucherIdCbx";
            SupplierVoucherIdCbx.Size = new Size(78, 28);
            SupplierVoucherIdCbx.TabIndex = 31;
            SupplierVoucherIdCbx.Visible = false;
            SupplierVoucherIdCbx.SelectedIndexChanged += SupplierVoucherIdCbx_SelectedIndexChanged;
            // 
            // itemIdLblSupply
            // 
            itemIdLblSupply.AutoSize = true;
            itemIdLblSupply.Location = new Point(8, 115);
            itemIdLblSupply.Name = "itemIdLblSupply";
            itemIdLblSupply.Size = new Size(56, 20);
            itemIdLblSupply.TabIndex = 32;
            itemIdLblSupply.Text = "Item Id";
            itemIdLblSupply.Visible = false;
            // 
            // itemComboUpdate
            // 
            itemComboUpdate.FormattingEnabled = true;
            itemComboUpdate.Location = new Point(172, 97);
            itemComboUpdate.Name = "itemComboUpdate";
            itemComboUpdate.Size = new Size(78, 28);
            itemComboUpdate.TabIndex = 34;
            itemComboUpdate.Visible = false;
            // 
            // AdvancedForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 678);
            Controls.Add(itemComboUpdate);
            Controls.Add(itemIdLblSupply);
            Controls.Add(SupplierVoucherIdCbx);
            Controls.Add(supplierVoucherIDLbl);
            Controls.Add(UpdateBtn);
            Controls.Add(ProductionDate);
            Controls.Add(ExpirationDate);
            Controls.Add(ExpirationLbl);
            Controls.Add(QuantityTxtBox);
            Controls.Add(ProductionLbl);
            Controls.Add(InsertBtn);
            Controls.Add(ToWarehouseComboBox);
            Controls.Add(FromWarehouseComboBox);
            Controls.Add(SupplierComboBox);
            Controls.Add(ItemComboBox);
            Controls.Add(transferDateTxtBox);
            Controls.Add(T_WarehouseLbl);
            Controls.Add(F_WarehouseIdLbl);
            Controls.Add(SupplierIdLbl);
            Controls.Add(itemIdLbl);
            Controls.Add(TransferDateLbl);
            Controls.Add(DownlBtn);
            Controls.Add(DisplayLbl);
            Controls.Add(itemNameTbx);
            Controls.Add(itemLblName);
            Controls.Add(AdvancedGridView);
            Controls.Add(toolStrip1);
            Name = "AdvancedForm";
            Text = "AdvancedForm";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AdvancedGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton SupplyVoucherDrop1;
        private ToolStripMenuItem addSupply;
        private ToolStripMenuItem updateSupply;
        private DataGridView AdvancedGridView;
        private ToolStripDropDownButton DisbursementVoucherDrop;
        private ToolStripMenuItem addDisbursement;
        private ToolStripMenuItem updateDisbursement;
        private ToolStripDropDownButton TransferDrop;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripDropDownButton ReportDrop;
        private ToolStripMenuItem warehouseToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem;
        private ToolStripMenuItem itemToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem1;
        private ToolStripMenuItem itemMovementToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem2;
        private ToolStripMenuItem expiredItemsToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem3;
        private ToolStripMenuItem nearExpirationItemsToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem4;
        private Label itemLblName;
        private TextBox itemNameTbx;
        private Label DisplayLbl;
        private Button DownlBtn;
        private Label TransferDateLbl;
        private Label itemIdLbl;
        private Label SupplierIdLbl;
        private Label F_WarehouseIdLbl;
        private Label T_WarehouseLbl;
        private TextBox transferDateTxtBox;
        private ComboBox ItemComboBox;
        private ComboBox SupplierComboBox;
        private ComboBox FromWarehouseComboBox;
        private ComboBox ToWarehouseComboBox;
        private Button InsertBtn;
        private Label ProductionLbl;
        private TextBox QuantityTxtBox;
        private Label ExpirationLbl;
        private DateTimePicker ExpirationDate;
        private DateTimePicker ProductionDate;
        private Button UpdateBtn;
        private Label supplierVoucherIDLbl;
        private ComboBox SupplierVoucherIdCbx;
        private Label itemIdLblSupply;
        private ComboBox itemComboUpdate;
    }
}