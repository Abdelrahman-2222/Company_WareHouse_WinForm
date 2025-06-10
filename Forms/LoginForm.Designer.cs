namespace CompanyForm.Forms
{
    partial class LoginForm
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
            UserNameLbl = new Label();
            PassLbl = new Label();
            RoleLbl = new Label();
            RoleComboBox = new ComboBox();
            PassTxtBox = new TextBox();
            UserNameTxtBox = new TextBox();
            SignUpBtn = new Button();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // UserNameLbl
            // 
            UserNameLbl.AutoSize = true;
            UserNameLbl.Location = new Point(47, 79);
            UserNameLbl.Name = "UserNameLbl";
            UserNameLbl.Size = new Size(78, 20);
            UserNameLbl.TabIndex = 0;
            UserNameLbl.Text = "UserName";
            // 
            // PassLbl
            // 
            PassLbl.AutoSize = true;
            PassLbl.Location = new Point(47, 173);
            PassLbl.Name = "PassLbl";
            PassLbl.Size = new Size(70, 20);
            PassLbl.TabIndex = 1;
            PassLbl.Text = "Password";
            // 
            // RoleLbl
            // 
            RoleLbl.AutoSize = true;
            RoleLbl.Location = new Point(47, 271);
            RoleLbl.Name = "RoleLbl";
            RoleLbl.Size = new Size(72, 20);
            RoleLbl.TabIndex = 2;
            RoleLbl.Text = "Your Role";
            // 
            // RoleComboBox
            // 
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Items.AddRange(new object[] { "Owner", "Customer", "Supplier" });
            RoleComboBox.Location = new Point(380, 263);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(202, 28);
            RoleComboBox.TabIndex = 3;
            // 
            // PassTxtBox
            // 
            PassTxtBox.Location = new Point(380, 166);
            PassTxtBox.Name = "PassTxtBox";
            PassTxtBox.Size = new Size(202, 27);
            PassTxtBox.TabIndex = 4;
            // 
            // UserNameTxtBox
            // 
            UserNameTxtBox.Location = new Point(380, 72);
            UserNameTxtBox.Name = "UserNameTxtBox";
            UserNameTxtBox.Size = new Size(202, 27);
            UserNameTxtBox.TabIndex = 5;
            // 
            // SignUpBtn
            // 
            SignUpBtn.Location = new Point(47, 379);
            SignUpBtn.Name = "SignUpBtn";
            SignUpBtn.Size = new Size(182, 29);
            SignUpBtn.TabIndex = 6;
            SignUpBtn.Text = "Sign Up";
            SignUpBtn.UseVisualStyleBackColor = true;
            SignUpBtn.Click += SignUpBtn_Click;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(400, 379);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(182, 29);
            LoginBtn.TabIndex = 7;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginBtn);
            Controls.Add(SignUpBtn);
            Controls.Add(UserNameTxtBox);
            Controls.Add(PassTxtBox);
            Controls.Add(RoleComboBox);
            Controls.Add(RoleLbl);
            Controls.Add(PassLbl);
            Controls.Add(UserNameLbl);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserNameLbl;
        private Label PassLbl;
        private Label RoleLbl;
        private ComboBox RoleComboBox;
        private TextBox PassTxtBox;
        private TextBox UserNameTxtBox;
        private Button SignUpBtn;
        private Button LoginBtn;
    }
}