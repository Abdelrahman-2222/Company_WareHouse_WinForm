using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyForm.Forms;
using CompnayForm;

namespace CompanyForm
{
    public partial class NavigationForm : Form
    {
        public NavigationForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainForm = new MainForm();
            mainForm.ShowDialog(this);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void NewCustBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RegiterdForm = new RegisterForm(Entities.UserRole.Customer);
            RegiterdForm.ShowDialog(this);
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm(Entities.UserRole.Customer);
            loginForm.ShowDialog(this);
        }

        private void NewSBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RegiterdForm = new RegisterForm(Entities.UserRole.Supplier);
            RegiterdForm.ShowDialog(this);
        }

        private void RegistSBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm(Entities.UserRole.Supplier);
            loginForm.ShowDialog(this);
        }

        private void NOwnerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RegiterdForm = new RegisterForm(Entities.UserRole.Owner);
            RegiterdForm.ShowDialog(this);
        }

        private void RegisteredOwnerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm(Entities.UserRole.Owner);
            loginForm.ShowDialog(this);
        }
    }
}
