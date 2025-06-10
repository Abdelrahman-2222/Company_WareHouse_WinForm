namespace CompanyForm
{
    partial class NavigationForm
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
            backBtn = new Button();
            NOwnerBtn = new Button();
            RegisteredOwnerBtn = new Button();
            RegistSBtn = new Button();
            NewSBtn = new Button();
            RegistBtn = new Button();
            NewCustBtn = new Button();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(109, 41);
            backBtn.TabIndex = 4;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // NOwnerBtn
            // 
            NOwnerBtn.Location = new Point(87, 125);
            NOwnerBtn.Name = "NOwnerBtn";
            NOwnerBtn.Size = new Size(160, 29);
            NOwnerBtn.TabIndex = 5;
            NOwnerBtn.Text = "New Owner";
            NOwnerBtn.UseVisualStyleBackColor = true;
            NOwnerBtn.Visible = false;
            NOwnerBtn.Click += NOwnerBtn_Click;
            // 
            // RegisteredOwnerBtn
            // 
            RegisteredOwnerBtn.Location = new Point(473, 125);
            RegisteredOwnerBtn.Name = "RegisteredOwnerBtn";
            RegisteredOwnerBtn.Size = new Size(195, 29);
            RegisteredOwnerBtn.TabIndex = 6;
            RegisteredOwnerBtn.Text = "Registered Owner";
            RegisteredOwnerBtn.UseVisualStyleBackColor = true;
            RegisteredOwnerBtn.Visible = false;
            RegisteredOwnerBtn.Click += RegisteredOwnerBtn_Click;
            // 
            // RegistSBtn
            // 
            RegistSBtn.Location = new Point(473, 305);
            RegistSBtn.Name = "RegistSBtn";
            RegistSBtn.Size = new Size(195, 29);
            RegistSBtn.TabIndex = 3;
            RegistSBtn.Text = "Registered Supplier";
            RegistSBtn.UseVisualStyleBackColor = true;
            RegistSBtn.Visible = false;
            RegistSBtn.Click += RegistSBtn_Click;
            // 
            // NewSBtn
            // 
            NewSBtn.Location = new Point(87, 305);
            NewSBtn.Name = "NewSBtn";
            NewSBtn.Size = new Size(160, 29);
            NewSBtn.TabIndex = 2;
            NewSBtn.Text = "New Supplier";
            NewSBtn.UseVisualStyleBackColor = true;
            NewSBtn.Visible = false;
            NewSBtn.Click += NewSBtn_Click;
            // 
            // RegistBtn
            // 
            RegistBtn.Location = new Point(473, 214);
            RegistBtn.Name = "RegistBtn";
            RegistBtn.Size = new Size(195, 29);
            RegistBtn.TabIndex = 1;
            RegistBtn.Text = "Registered Customer";
            RegistBtn.UseVisualStyleBackColor = true;
            RegistBtn.Visible = false;
            RegistBtn.Click += RegistBtn_Click;
            // 
            // NewCustBtn
            // 
            NewCustBtn.Location = new Point(87, 214);
            NewCustBtn.Name = "NewCustBtn";
            NewCustBtn.Size = new Size(160, 29);
            NewCustBtn.TabIndex = 0;
            NewCustBtn.Text = "New Customer";
            NewCustBtn.UseVisualStyleBackColor = true;
            NewCustBtn.Visible = false;
            NewCustBtn.Click += NewCustBtn_Click;
            // 
            // NavigationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(800, 450);
            Controls.Add(RegisteredOwnerBtn);
            Controls.Add(NOwnerBtn);
            Controls.Add(backBtn);
            Controls.Add(RegistSBtn);
            Controls.Add(NewSBtn);
            Controls.Add(RegistBtn);
            Controls.Add(NewCustBtn);
            Name = "NavigationForm";
            Text = "NavigationForm";
            ResumeLayout(false);
        }

        #endregion
        public Button backBtn;
        public Button NOwnerBtn;
        public Button RegisteredOwnerBtn;
        public Button RegistSBtn;
        public Button NewSBtn;
        public Button RegistBtn;
        public Button NewCustBtn;
    }
}