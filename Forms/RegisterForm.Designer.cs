namespace CompanyForm.Forms
{
    partial class RegisterForm
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
            EmailLbl = new Label();
            PasswordLbl = new Label();
            RoleLbl = new Label();
            EmailTextbox = new TextBox();
            NameTextbox = new TextBox();
            RepeatPassTextbox = new TextBox();
            RepeatPassLbl = new Label();
            PasswordTxtbox = new TextBox();
            MobileNumberLbl = new Label();
            MobileNumberTxtBox = new TextBox();
            SignUpBtn = new Button();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // UserNameLbl
            // 
            UserNameLbl.AutoSize = true;
            UserNameLbl.Location = new Point(117, 138);
            UserNameLbl.Name = "UserNameLbl";
            UserNameLbl.Size = new Size(49, 20);
            UserNameLbl.TabIndex = 1;
            UserNameLbl.Text = "Name";
            // 
            // EmailLbl
            // 
            EmailLbl.AutoSize = true;
            EmailLbl.Location = new Point(117, 203);
            EmailLbl.Name = "EmailLbl";
            EmailLbl.Size = new Size(46, 20);
            EmailLbl.TabIndex = 2;
            EmailLbl.Text = "Email";
            // 
            // PasswordLbl
            // 
            PasswordLbl.AutoSize = true;
            PasswordLbl.Location = new Point(117, 265);
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new Size(70, 20);
            PasswordLbl.TabIndex = 3;
            PasswordLbl.Text = "Password";
            // 
            // RoleLbl
            // 
            RoleLbl.AutoSize = true;
            RoleLbl.Font = new Font("Segoe UI", 15F);
            RoleLbl.Location = new Point(283, 50);
            RoleLbl.Name = "RoleLbl";
            RoleLbl.Size = new Size(120, 35);
            RoleLbl.TabIndex = 4;
            RoleLbl.Text = "Your Role";
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new Point(483, 196);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new Size(190, 27);
            EmailTextbox.TabIndex = 6;
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(483, 131);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(190, 27);
            NameTextbox.TabIndex = 7;
            // 
            // RepeatPassTextbox
            // 
            RepeatPassTextbox.Location = new Point(483, 321);
            RepeatPassTextbox.Name = "RepeatPassTextbox";
            RepeatPassTextbox.Size = new Size(190, 27);
            RepeatPassTextbox.TabIndex = 9;
            // 
            // RepeatPassLbl
            // 
            RepeatPassLbl.AutoSize = true;
            RepeatPassLbl.Location = new Point(117, 328);
            RepeatPassLbl.Name = "RepeatPassLbl";
            RepeatPassLbl.Size = new Size(121, 20);
            RepeatPassLbl.TabIndex = 12;
            RepeatPassLbl.Text = "Repeat Password";
            // 
            // PasswordTxtbox
            // 
            PasswordTxtbox.Location = new Point(483, 258);
            PasswordTxtbox.Name = "PasswordTxtbox";
            PasswordTxtbox.Size = new Size(190, 27);
            PasswordTxtbox.TabIndex = 13;
            // 
            // MobileNumberLbl
            // 
            MobileNumberLbl.AutoSize = true;
            MobileNumberLbl.Location = new Point(117, 404);
            MobileNumberLbl.Name = "MobileNumberLbl";
            MobileNumberLbl.Size = new Size(114, 20);
            MobileNumberLbl.TabIndex = 15;
            MobileNumberLbl.Text = "Mobile Number";
            // 
            // MobileNumberTxtBox
            // 
            MobileNumberTxtBox.Location = new Point(483, 397);
            MobileNumberTxtBox.Name = "MobileNumberTxtBox";
            MobileNumberTxtBox.Size = new Size(190, 27);
            MobileNumberTxtBox.TabIndex = 16;
            // 
            // SignUpBtn
            // 
            SignUpBtn.Location = new Point(493, 454);
            SignUpBtn.Name = "SignUpBtn";
            SignUpBtn.Size = new Size(166, 29);
            SignUpBtn.TabIndex = 17;
            SignUpBtn.Text = "Sign Up";
            SignUpBtn.UseVisualStyleBackColor = true;
            SignUpBtn.Click += SignUpBtn_Click;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(117, 454);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(166, 29);
            LoginBtn.TabIndex = 18;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 561);
            Controls.Add(LoginBtn);
            Controls.Add(SignUpBtn);
            Controls.Add(MobileNumberTxtBox);
            Controls.Add(MobileNumberLbl);
            Controls.Add(PasswordTxtbox);
            Controls.Add(RepeatPassLbl);
            Controls.Add(RepeatPassTextbox);
            Controls.Add(NameTextbox);
            Controls.Add(EmailTextbox);
            Controls.Add(RoleLbl);
            Controls.Add(PasswordLbl);
            Controls.Add(EmailLbl);
            Controls.Add(UserNameLbl);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label UserNameLbl;
        private Label EmailLbl;
        private Label PasswordLbl;
        private Label RoleLbl;
        private TextBox EmailTextbox;
        private TextBox NameTextbox;
        private TextBox RepeatPassTextbox;
        private Label RepeatPassLbl;
        private TextBox PasswordTxtbox;
        private Label MobileNumberLbl;
        private TextBox MobileNumberTxtBox;
        private Button SignUpBtn;
        private Button LoginBtn;
    }
}