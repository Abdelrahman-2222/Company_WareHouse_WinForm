namespace CompnayForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OwnerBtn = new Button();
            CustomerBtn = new Button();
            SupplierBtn = new Button();
            WelcomeLbl = new Label();
            SuspendLayout();
            // 
            // OwnerBtn
            // 
            OwnerBtn.BackColor = Color.MediumSlateBlue;
            OwnerBtn.FlatAppearance.BorderSize = 0;
            OwnerBtn.FlatStyle = FlatStyle.Flat;
            OwnerBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            OwnerBtn.ForeColor = Color.White;
            OwnerBtn.Location = new Point(253, 165);
            OwnerBtn.Name = "OwnerBtn";
            OwnerBtn.Size = new Size(300, 45);
            OwnerBtn.TabIndex = 0;
            OwnerBtn.Text = "Are you the Owner?";
            OwnerBtn.UseVisualStyleBackColor = false;
            OwnerBtn.Click += OwnerBtn_Click;
            // 
            // CustomerBtn
            // 
            CustomerBtn.BackColor = Color.MediumSeaGreen;
            CustomerBtn.FlatAppearance.BorderSize = 0;
            CustomerBtn.FlatStyle = FlatStyle.Flat;
            CustomerBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            CustomerBtn.ForeColor = Color.White;
            CustomerBtn.Location = new Point(253, 233);
            CustomerBtn.Name = "CustomerBtn";
            CustomerBtn.Size = new Size(300, 45);
            CustomerBtn.TabIndex = 1;
            CustomerBtn.Text = "Are you the Customer?";
            CustomerBtn.UseVisualStyleBackColor = false;
            CustomerBtn.Click += CustomerBtn_Click;
            // 
            // SupplierBtn
            // 
            SupplierBtn.BackColor = Color.Coral;
            SupplierBtn.FlatAppearance.BorderSize = 0;
            SupplierBtn.FlatStyle = FlatStyle.Flat;
            SupplierBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            SupplierBtn.ForeColor = Color.White;
            SupplierBtn.Location = new Point(253, 304);
            SupplierBtn.Name = "SupplierBtn";
            SupplierBtn.Size = new Size(300, 45);
            SupplierBtn.TabIndex = 2;
            SupplierBtn.Text = "Are you the Supplier?";
            SupplierBtn.UseVisualStyleBackColor = true;
            SupplierBtn.Click += SupplierBtn_Click;
            // 
            // WelcomeLbl
            // 
            WelcomeLbl.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            WelcomeLbl.ForeColor = Color.White;
            WelcomeLbl.Location = new Point(162, 59);
            WelcomeLbl.Name = "WelcomeLbl";
            WelcomeLbl.Size = new Size(487, 46);
            WelcomeLbl.TabIndex = 3;
            WelcomeLbl.Text = "Welcome to Company Portal!";
            WelcomeLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(800, 450);
            Controls.Add(WelcomeLbl);
            Controls.Add(SupplierBtn);
            Controls.Add(CustomerBtn);
            Controls.Add(OwnerBtn);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button OwnerBtn;
        private Button CustomerBtn;
        private Button SupplierBtn;
        private Label WelcomeLbl;
    }
}
