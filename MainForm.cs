using CompanyForm;

namespace CompnayForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.OnResize(EventArgs.Empty);
        }


        private void OwnerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ownerForm = new Owner();
            ownerForm.OwnerGridView.Visible = false;
            ownerForm.ShowDialog(this);
        }

        private void CustomerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var navigationForm = new NavigationForm();
            navigationForm.ShowDialog(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Calculate proportional sizes
            int buttonWidth = (int)(this.ClientSize.Width * 0.5);
            int buttonHeight = (int)(this.ClientSize.Height * 0.12);
            int labelWidth = (int)(this.ClientSize.Width * 0.7);
            int labelHeight = (int)(this.ClientSize.Height * 0.13);

            buttonWidth = Math.Max(buttonWidth, 200);
            buttonHeight = Math.Max(buttonHeight, 40);
            labelWidth = Math.Max(labelWidth, 300);
            labelHeight = Math.Max(labelHeight, 50);

            float labelFontSize = Math.Max(8f, labelHeight * 0.26f); // 26% of button height, min 8
            WelcomeLbl.Size = new Size(labelWidth, labelHeight);
            WelcomeLbl.Left = (this.ClientSize.Width - WelcomeLbl.Width) / 2;
            WelcomeLbl.Top = 30;
            WelcomeLbl.Font = new Font("Segoe UI", labelFontSize, FontStyle.Bold);

            float buttonFontSize = Math.Max(8f, buttonHeight * 0.26f);
            OwnerBtn.Size = new Size(buttonWidth, buttonHeight);
            OwnerBtn.Font = new Font("Segoe UI", buttonFontSize, FontStyle.Bold);

            CustomerBtn.Size = new Size(buttonWidth, buttonHeight);
            CustomerBtn.Font = new Font("Segoe UI", buttonFontSize, FontStyle.Bold);

            SupplierBtn.Size = new Size(buttonWidth, buttonHeight);
            SupplierBtn.Font = new Font("Segoe UI", buttonFontSize, FontStyle.Bold);

            int spacing = 20;
            int totalHeight = OwnerBtn.Height + CustomerBtn.Height + SupplierBtn.Height + 2 * spacing;
            int startY = (this.ClientSize.Height - totalHeight) / 2 + 40;

            OwnerBtn.Left = (this.ClientSize.Width - buttonWidth) / 2;
            OwnerBtn.Top = startY;

            CustomerBtn.Left = (this.ClientSize.Width - buttonWidth) / 2;
            CustomerBtn.Top = OwnerBtn.Bottom + spacing;

            SupplierBtn.Left = (this.ClientSize.Width - buttonWidth) / 2;
            SupplierBtn.Top = CustomerBtn.Bottom + spacing;
        }
    }
}
