namespace CompanyForm
{
    partial class OwnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerForm));
            OwnerGridView = new DataGridView();
            SaveBtn = new Button();
            toolStrip1 = new ToolStrip();
            WarehouseDropBtn = new ToolStripDropDownButton();
            WarehouseAddTool = new ToolStripMenuItem();
            WarehouseUpdateTool = new ToolStripMenuItem();
            WarehouseDeleteTool = new ToolStripMenuItem();
            ItemsDropBtn = new ToolStripDropDownButton();
            ItemAddTool = new ToolStripMenuItem();
            ItemUpdateTool = new ToolStripMenuItem();
            ItemDeleteTool = new ToolStripMenuItem();
            SupplierDropBtn = new ToolStripDropDownButton();
            SupplierAddTool = new ToolStripMenuItem();
            SupplierUpdateTool = new ToolStripMenuItem();
            SupplierDeleteTool = new ToolStripMenuItem();
            CustomerDropBtn = new ToolStripDropDownButton();
            CustomerAddTool = new ToolStripMenuItem();
            CustomerUpdateTool = new ToolStripMenuItem();
            CustomerDeleteTool = new ToolStripMenuItem();
            AddWarehoueLbl = new Label();
            itemLbl2 = new Label();
            itemLbl1 = new Label();
            itemLbl3 = new Label();
            itemLbl4 = new Label();
            itemLbl5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            AdvancedBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)OwnerGridView).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // OwnerGridView
            // 
            OwnerGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OwnerGridView.Location = new Point(440, 57);
            OwnerGridView.Name = "OwnerGridView";
            OwnerGridView.RowHeadersWidth = 51;
            OwnerGridView.Size = new Size(488, 374);
            OwnerGridView.TabIndex = 0;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(785, 474);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(143, 29);
            SaveBtn.TabIndex = 5;
            SaveBtn.Text = "Save Changes";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { WarehouseDropBtn, ItemsDropBtn, SupplierDropBtn, CustomerDropBtn });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(940, 27);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // WarehouseDropBtn
            // 
            WarehouseDropBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            WarehouseDropBtn.DropDownItems.AddRange(new ToolStripItem[] { WarehouseAddTool, WarehouseUpdateTool, WarehouseDeleteTool });
            WarehouseDropBtn.Image = (Image)resources.GetObject("WarehouseDropBtn.Image");
            WarehouseDropBtn.ImageTransparentColor = Color.Magenta;
            WarehouseDropBtn.Name = "WarehouseDropBtn";
            WarehouseDropBtn.Size = new Size(160, 24);
            WarehouseDropBtn.Text = "Manage Warehouses";
            WarehouseDropBtn.Click += WarehouseDropButton_Click;
            // 
            // WarehouseAddTool
            // 
            WarehouseAddTool.Name = "WarehouseAddTool";
            WarehouseAddTool.Size = new Size(141, 26);
            WarehouseAddTool.Text = "Add";
            WarehouseAddTool.Click += WarehouseAddTool_Click;
            // 
            // WarehouseUpdateTool
            // 
            WarehouseUpdateTool.Name = "WarehouseUpdateTool";
            WarehouseUpdateTool.Size = new Size(141, 26);
            WarehouseUpdateTool.Text = "Update";
            WarehouseUpdateTool.Click += WarehouseUpdateTool_Click;
            // 
            // WarehouseDeleteTool
            // 
            WarehouseDeleteTool.Name = "WarehouseDeleteTool";
            WarehouseDeleteTool.Size = new Size(141, 26);
            WarehouseDeleteTool.Text = "Delete";
            WarehouseDeleteTool.Click += WarehouseDeleteTool_Click;
            // 
            // ItemsDropBtn
            // 
            ItemsDropBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ItemsDropBtn.DropDownItems.AddRange(new ToolStripItem[] { ItemAddTool, ItemUpdateTool, ItemDeleteTool });
            ItemsDropBtn.Image = (Image)resources.GetObject("ItemsDropBtn.Image");
            ItemsDropBtn.ImageTransparentColor = Color.Magenta;
            ItemsDropBtn.Name = "ItemsDropBtn";
            ItemsDropBtn.Size = new Size(117, 24);
            ItemsDropBtn.Text = "Manage Items";
            ItemsDropBtn.Click += ItemsDropBtn_Click;
            // 
            // ItemAddTool
            // 
            ItemAddTool.Name = "ItemAddTool";
            ItemAddTool.Size = new Size(141, 26);
            ItemAddTool.Text = "Add";
            ItemAddTool.Click += ItemAddTool_Click;
            // 
            // ItemUpdateTool
            // 
            ItemUpdateTool.Name = "ItemUpdateTool";
            ItemUpdateTool.Size = new Size(141, 26);
            ItemUpdateTool.Text = "Update";
            ItemUpdateTool.Click += ItemUpdateTool_Click;
            // 
            // ItemDeleteTool
            // 
            ItemDeleteTool.Name = "ItemDeleteTool";
            ItemDeleteTool.Size = new Size(141, 26);
            ItemDeleteTool.Text = "Delete";
            ItemDeleteTool.Click += ItemDeleteTool_Click;
            // 
            // SupplierDropBtn
            // 
            SupplierDropBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SupplierDropBtn.DropDownItems.AddRange(new ToolStripItem[] { SupplierAddTool, SupplierUpdateTool, SupplierDeleteTool });
            SupplierDropBtn.Image = (Image)resources.GetObject("SupplierDropBtn.Image");
            SupplierDropBtn.ImageTransparentColor = Color.Magenta;
            SupplierDropBtn.Name = "SupplierDropBtn";
            SupplierDropBtn.Size = new Size(136, 24);
            SupplierDropBtn.Text = "Manage Supplier";
            SupplierDropBtn.ToolTipText = "Manage Supplier";
            SupplierDropBtn.Click += SupplierDropBtn_Click;
            // 
            // SupplierAddTool
            // 
            SupplierAddTool.Name = "SupplierAddTool";
            SupplierAddTool.Size = new Size(224, 26);
            SupplierAddTool.Text = "Add";
            SupplierAddTool.Click += SupplierAddTool_Click;
            // 
            // SupplierUpdateTool
            // 
            SupplierUpdateTool.Name = "SupplierUpdateTool";
            SupplierUpdateTool.Size = new Size(224, 26);
            SupplierUpdateTool.Text = "Update";
            SupplierUpdateTool.Click += SupplierUpdateTool_Click;
            // 
            // SupplierDeleteTool
            // 
            SupplierDeleteTool.Name = "SupplierDeleteTool";
            SupplierDeleteTool.Size = new Size(224, 26);
            SupplierDeleteTool.Text = "Delete";
            SupplierDeleteTool.Click += SupplierDeleteTool_Click;
            // 
            // CustomerDropBtn
            // 
            CustomerDropBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CustomerDropBtn.DropDownItems.AddRange(new ToolStripItem[] { CustomerAddTool, CustomerUpdateTool, CustomerDeleteTool });
            CustomerDropBtn.Image = (Image)resources.GetObject("CustomerDropBtn.Image");
            CustomerDropBtn.ImageTransparentColor = Color.Magenta;
            CustomerDropBtn.Name = "CustomerDropBtn";
            CustomerDropBtn.Size = new Size(144, 24);
            CustomerDropBtn.Text = "Manage Customer";
            CustomerDropBtn.Click += CustomerDropBtn_Click;
            // 
            // CustomerAddTool
            // 
            CustomerAddTool.Name = "CustomerAddTool";
            CustomerAddTool.Size = new Size(224, 26);
            CustomerAddTool.Text = "Add";
            CustomerAddTool.Click += CustomerAddTool_Click;
            // 
            // CustomerUpdateTool
            // 
            CustomerUpdateTool.Name = "CustomerUpdateTool";
            CustomerUpdateTool.Size = new Size(224, 26);
            CustomerUpdateTool.Text = "Update";
            CustomerUpdateTool.Click += CustomerUpdateTool_Click;
            // 
            // CustomerDeleteTool
            // 
            CustomerDeleteTool.Name = "CustomerDeleteTool";
            CustomerDeleteTool.Size = new Size(224, 26);
            CustomerDeleteTool.Text = "Delete";
            CustomerDeleteTool.Click += CustomerDeleteTool_Click;
            // 
            // AddWarehoueLbl
            // 
            AddWarehoueLbl.AutoSize = true;
            AddWarehoueLbl.Location = new Point(70, 57);
            AddWarehoueLbl.Name = "AddWarehoueLbl";
            AddWarehoueLbl.Size = new Size(212, 20);
            AddWarehoueLbl.TabIndex = 7;
            AddWarehoueLbl.Text = "This is for adding a Warehouse";
            AddWarehoueLbl.Visible = false;
            // 
            // itemLbl2
            // 
            itemLbl2.AutoSize = true;
            itemLbl2.Location = new Point(12, 226);
            itemLbl2.Name = "itemLbl2";
            itemLbl2.Size = new Size(139, 20);
            itemLbl2.TabIndex = 8;
            itemLbl2.Text = "Warehouse Address";
            itemLbl2.Visible = false;
            // 
            // itemLbl1
            // 
            itemLbl1.AutoSize = true;
            itemLbl1.Location = new Point(12, 170);
            itemLbl1.Name = "itemLbl1";
            itemLbl1.Size = new Size(126, 20);
            itemLbl1.TabIndex = 9;
            itemLbl1.Text = "Warehouse Name";
            itemLbl1.Visible = false;
            // 
            // itemLbl3
            // 
            itemLbl3.AutoSize = true;
            itemLbl3.Location = new Point(12, 285);
            itemLbl3.Name = "itemLbl3";
            itemLbl3.Size = new Size(153, 20);
            itemLbl3.TabIndex = 10;
            itemLbl3.Text = "W_Responsible Name";
            itemLbl3.Visible = false;
            // 
            // itemLbl4
            // 
            itemLbl4.AutoSize = true;
            itemLbl4.Location = new Point(12, 343);
            itemLbl4.Name = "itemLbl4";
            itemLbl4.Size = new Size(131, 20);
            itemLbl4.TabIndex = 11;
            itemLbl4.Text = "C_Mobile_Number";
            itemLbl4.Visible = false;
            // 
            // itemLbl5
            // 
            itemLbl5.AutoSize = true;
            itemLbl5.Location = new Point(12, 411);
            itemLbl5.Name = "itemLbl5";
            itemLbl5.Size = new Size(105, 20);
            itemLbl5.TabIndex = 12;
            itemLbl5.Text = "C_Fax_Number";
            itemLbl5.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(195, 163);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Required";
            textBox1.Size = new Size(195, 27);
            textBox1.TabIndex = 13;
            textBox1.Visible = false;
            textBox1.Leave += textBox1_Leave;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(195, 219);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Required";
            textBox2.Size = new Size(195, 27);
            textBox2.TabIndex = 14;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(195, 278);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Required";
            textBox3.Size = new Size(195, 27);
            textBox3.TabIndex = 15;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(195, 336);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Required";
            textBox4.Size = new Size(195, 27);
            textBox4.TabIndex = 16;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(195, 404);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Required";
            textBox5.Size = new Size(195, 27);
            textBox5.TabIndex = 17;
            textBox5.Visible = false;
            // 
            // AdvancedBtn
            // 
            AdvancedBtn.Location = new Point(440, 474);
            AdvancedBtn.Name = "AdvancedBtn";
            AdvancedBtn.Size = new Size(188, 29);
            AdvancedBtn.TabIndex = 18;
            AdvancedBtn.Text = "Advanced queries";
            AdvancedBtn.UseVisualStyleBackColor = true;
            AdvancedBtn.Click += AdvancedBtn_Click;
            // 
            // Owner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 540);
            Controls.Add(AdvancedBtn);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(itemLbl5);
            Controls.Add(itemLbl4);
            Controls.Add(itemLbl3);
            Controls.Add(itemLbl1);
            Controls.Add(itemLbl2);
            Controls.Add(AddWarehoueLbl);
            Controls.Add(toolStrip1);
            Controls.Add(SaveBtn);
            Controls.Add(OwnerGridView);
            Name = "Owner";
            Text = "Owner";
            ((System.ComponentModel.ISupportInitialize)OwnerGridView).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView OwnerGridView;
        private Button SaveBtn;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton WarehouseDropBtn;
        private ToolStripMenuItem WarehouseAddTool;
        private ToolStripMenuItem WarehouseUpdateTool;
        private ToolStripMenuItem WarehouseDeleteTool;
        private ToolStripDropDownButton ItemsDropBtn;
        private ToolStripMenuItem ItemAddTool;
        private ToolStripMenuItem ItemUpdateTool;
        private ToolStripMenuItem ItemDeleteTool;
        private ToolStripDropDownButton SupplierDropBtn;
        private ToolStripMenuItem SupplierAddTool;
        private ToolStripMenuItem SupplierUpdateTool;
        private ToolStripMenuItem SupplierDeleteTool;
        private ToolStripDropDownButton CustomerDropBtn;
        private ToolStripMenuItem CustomerAddTool;
        private ToolStripMenuItem CustomerUpdateTool;
        private ToolStripMenuItem CustomerDeleteTool;
        private Label AddWarehoueLbl;
        private Label itemLbl2;
        private Label itemLbl1;
        private Label itemLbl3;
        private Label itemLbl4;
        private Label itemLbl5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button AdvancedBtn;
    }
}