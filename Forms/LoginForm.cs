using System;
using System.Windows.Forms;
using CompanyForm.Entities;
using CompanyForm.Services;
using CompnayForm.Context;

namespace CompanyForm.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm(UserRole role)
        {
            InitializeComponent();
            _authService = new AuthService(new CompanyWarehouseContext());
            RoleComboBox.DataSource = Enum.GetValues(typeof(UserRole));
            RoleComboBox.SelectedIndex = 0;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserNameTxtBox.Text;
            string password = PassTxtBox.Text;

            // Replace the direct cast with proper enum parsing
            UserRole selectedRole;
            if (RoleComboBox.SelectedItem is string roleString)
            {
                selectedRole = (UserRole)Enum.Parse(typeof(UserRole), roleString);
            }
            else
            {
                selectedRole = (UserRole)RoleComboBox.SelectedItem;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_authService.Login(username, password))
            {
                if (AuthService.CurrentUser.Role == selectedRole)
                {
                    // Open appropriate form based on role
                    Form mainForm = null;
                    switch (selectedRole)
                    {
                        case UserRole.Owner:
                            mainForm = new OwnerForm();
                            break;
                        case UserRole.Customer:
                            mainForm = new CustomerForm();
                            break;
                        case UserRole.Supplier:
                            mainForm = new SupplierForm();
                            break;
                    }

                    if (mainForm != null)
                    {
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show($"You are not registered as a {selectedRole}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _authService.Logout();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            UserRole selectedRole = (UserRole)RoleComboBox.SelectedItem;
            var registerForm = new RegisterForm(selectedRole);
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}