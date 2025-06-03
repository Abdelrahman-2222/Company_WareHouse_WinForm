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
            NewCustBtn = new Button();
            RegistBtn = new Button();
            NewSBtn = new Button();
            RegistSBtn = new Button();
            backBtn = new Button();
            SuspendLayout();
            // 
            // NewCustBtn
            // 
            NewCustBtn.Location = new Point(87, 112);
            NewCustBtn.Name = "NewCustBtn";
            NewCustBtn.Size = new Size(160, 29);
            NewCustBtn.TabIndex = 0;
            NewCustBtn.Text = "New Customer";
            NewCustBtn.UseVisualStyleBackColor = true;
            // 
            // RegistBtn
            // 
            RegistBtn.Location = new Point(473, 112);
            RegistBtn.Name = "RegistBtn";
            RegistBtn.Size = new Size(195, 29);
            RegistBtn.TabIndex = 1;
            RegistBtn.Text = "Registered Customer";
            RegistBtn.UseVisualStyleBackColor = true;
            // 
            // NewSBtn
            // 
            NewSBtn.Location = new Point(87, 305);
            NewSBtn.Name = "NewSBtn";
            NewSBtn.Size = new Size(160, 29);
            NewSBtn.TabIndex = 2;
            NewSBtn.Text = "New Supplier";
            NewSBtn.UseVisualStyleBackColor = true;
            // 
            // RegistSBtn
            // 
            RegistSBtn.Location = new Point(473, 305);
            RegistSBtn.Name = "RegistSBtn";
            RegistSBtn.Size = new Size(195, 29);
            RegistSBtn.TabIndex = 3;
            RegistSBtn.Text = "Registered Supplier";
            RegistSBtn.UseVisualStyleBackColor = true;
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
            // NavigationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(800, 450);
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

        private Button NewCustBtn;
        private Button RegistBtn;
        private Button NewSBtn;
        private Button RegistSBtn;
        private Button backBtn;
    }
}