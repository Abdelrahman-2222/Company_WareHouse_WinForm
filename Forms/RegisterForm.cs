using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyForm.Entities;
using CompanyForm.Services;
using CompnayForm.Context;
using CompnayForm.Entities;

namespace CompanyForm.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserRole _role;
        private readonly AuthService _authService;
        private readonly CompanyWarehouseContext _context;

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        public RegisterForm(UserRole role)
        {
            InitializeComponent();
            _role = role;
            _context = new CompanyWarehouseContext();
            _authService = new AuthService(_context);

            // Set form title based on role
            this.Text = $"New User as {_role}";
            RoleLbl.Text = $"New User as {_role}";

            // Configure role-specific fields
            SetupRoleSpecificFields();
        }

        private void SetupRoleSpecificFields()
        {
            switch (_role)
            {
                case UserRole.Owner:
                    MobileNumberLbl.Visible = false;
                    MobileNumberTxtBox.Visible = false;
                    break;
                case UserRole.Customer:
                    MobileNumberLbl.Visible = true;
                    MobileNumberTxtBox.Visible = true;
                    break;
                case UserRole.Supplier:
                    MobileNumberLbl.Visible = true;
                    MobileNumberTxtBox.Visible = true;
                    break;
            }
        }


        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Basic validation
                if (string.IsNullOrWhiteSpace(NameTextbox.Text) ||
                    string.IsNullOrWhiteSpace(EmailTextbox.Text) ||
                    string.IsNullOrWhiteSpace(PasswordTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(RepeatPassTextbox.Text))
                {
                    MessageBox.Show("Please fill in all required fields", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Password confirmation
                if (RepeatPassTextbox.Text != PasswordTxtbox.Text)
                {
                    MessageBox.Show("Passwords do not match", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool success = _authService.RegisterUser(
                    NameTextbox.Text,
                    PasswordTxtbox.Text,
                    EmailTextbox.Text,
                    _role
                );

                if (!success)
                {
                    MessageBox.Show("Username or email already exists", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the newly created user
                var user = _context.Users.FirstOrDefault(u => u.Username == NameTextbox.Text);
                if (user == null)
                {
                    MessageBox.Show("Error creating user account", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create the role-specific entity
                switch (_role)
                {
                    case UserRole.Owner:
                        var owner = new Owner
                        {
                            OwnerName = NameTextbox.Text,
                            OwnerEmail = EmailTextbox.Text
                        };
                        _context.Owners.Add(owner);
                        _context.SaveChanges();
                        MessageBox.Show("Owner account created. You are redirecting now.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case UserRole.Customer:
                        if (string.IsNullOrWhiteSpace(MobileNumberTxtBox.Text))
                        {
                            MessageBox.Show("Please fill in all required fields", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var customer = new Customer
                        {
                            CustomerName = NameTextbox.Text,
                            CustomerEmail = EmailTextbox.Text,
                            CustomerMobileNumber = MobileNumberTxtBox.Text
                        };
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                        MessageBox.Show("Customer account created. You are redirecting now.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case UserRole.Supplier:
                        if (string.IsNullOrWhiteSpace(MobileNumberTxtBox.Text))
                        {
                            MessageBox.Show("Please fill in all required fields", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var supplier = new Supplier
                        {
                            SupplierName = NameTextbox.Text,
                            SupplierEmail = EmailTextbox.Text,
                            SupplierMobileNumber = MobileNumberTxtBox.Text
                        };
                        _context.Suppliers.Add(supplier);
                        _context.SaveChanges();
                        MessageBox.Show("Supplier account created. You are redirecting now.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                if (_authService.Login(NameTextbox.Text, PasswordTxtbox.Text))
                {
                    Form mainForm = null;
                    switch (_role)
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
                        // Close all parent forms and show the new form
                        this.Hide();
                        if (this.Owner is NavigationForm navForm)
                        {
                            navForm.Hide();
                        }
                        mainForm.ShowDialog();
                        this.Close();
                        if (this.Owner is NavigationForm nav)
                        {
                            nav.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_role);
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }
    }
}
