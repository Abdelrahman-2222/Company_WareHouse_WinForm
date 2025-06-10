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
using CompanyForm.Forms;
using CompanyForm.Services;
using CompnayForm.Context;

namespace CompanyForm
{
    public partial class SupplierForm : Form
    {
        private readonly CompanyWarehouseContext context;
        private int currentSupplierId;

        public SupplierForm()
        {
            InitializeComponent();
            context = new CompanyWarehouseContext();

            // Set current supplier ID from the logged-in user
            if (AuthService.CurrentUser != null)
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.UserId == AuthService.CurrentUser.UserId);
                if (supplier != null)
                {
                    currentSupplierId = supplier.SupplierId;
                }
            }

            // Load initial data
            LoadCategories();
            RefreshMyItems();
            RefreshRelationshipsPanel();
        }

        private void LoadCategories()
        {
            // Add "All Categories" option
            categoryComboBox.Items.Add("All Categories");

            // Add distinct categories from items
            var categories = context.Items
                .Select(i => i.Category)
                .Distinct()
                .Where(c => !string.IsNullOrEmpty(c))
                .OrderBy(c => c)
                .ToList();

            foreach (var category in categories)
            {
                categoryComboBox.Items.Add(category);
            }

            // Select the first item
            if (categoryComboBox.Items.Count > 0)
                categoryComboBox.SelectedIndex = 0;
        }

        private void RefreshMyItems()
        {
            var selectedCategory = categoryComboBox.SelectedItem?.ToString();

            // Get items supplied by this supplier through SupplyVouchers
            var query = from svl in context.SupplyVoucherLists
                        join sv in context.SupplyVouchers on svl.SupplyVoucherId equals sv.SupplyVoucherId
                        join i in context.Items on svl.ItemId equals i.ItemId
                        join w in context.Warehouses on i.WarehouseId equals w.WarehouseId
                        where sv.SupplierId == currentSupplierId
                        select new
                        {
                            i.ItemId,
                            i.ItemCode,
                            i.ItemName,
                            i.Category,
                            svl.SupplyVoucherListQuantity,
                            WarehouseName = w.WarehouseName,
                            ProductionDate = svl.SupplyVoucherListProductionDate,
                            ExpirationDate = svl.SupplyVoucherListExpirationDate,
                            DaysUntilExpiration = svl.SupplyVoucherListDaysUntilExpiration
                        };

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All Categories")
            {
                query = query.Where(i => i.Category == selectedCategory);
            }

            myItemsGridView.DataSource = query.ToList();
        }

        private void RefreshRelationshipsPanel()
        {
            ownerRelationshipsPanel.Controls.Clear();

            var relationships = context.SupplierOwnerRelationships
                .Where(r => r.SupplierId == currentSupplierId)
                .Join(context.Owners, r => r.OwnerId, o => o.OwnerId,
                      (r, o) => new { Relationship = r, Owner = o })
                .ToList();

            foreach (var item in relationships)
            {
                var panel = new Panel();
                panel.Width = ownerRelationshipsPanel.Width - 25;
                panel.Height = 70;
                panel.BorderStyle = BorderStyle.FixedSingle;

                var nameLabel = new Label();
                nameLabel.Text = item.Owner.OwnerName;
                nameLabel.Location = new Point(5, 5);
                nameLabel.AutoSize = true;
                panel.Controls.Add(nameLabel);

                var statusLabel = new Label();
                statusLabel.Text = $"Status: {item.Relationship.Status}";
                statusLabel.Location = new Point(5, 30);
                statusLabel.ForeColor = item.Relationship.Status == RelationshipStatus.Approved ?
                    Color.Green : (item.Relationship.Status == RelationshipStatus.Rejected ?
                    Color.Red : Color.Orange);
                panel.Controls.Add(statusLabel);

                ownerRelationshipsPanel.Controls.Add(panel);
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            // Open a dialog to add new item
            using (var addItemDialog = new AddItemDialog(currentSupplierId, context))
            {
                if (addItemDialog.ShowDialog() == DialogResult.OK)
                {
                    RefreshMyItems();
                }
            }
        }

        private void myItemsGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Show details of selected item
            if (myItemsGridView.SelectedRows.Count > 0)
            {
                var selectedItem = myItemsGridView.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedItem != null)
                {
                    itemNameLabel.Text = $"Item: {selectedItem.ItemName}";
                    itemCodeLabel.Text = $"Code: {selectedItem.ItemCode}";
                    categoryLabel.Text = $"Category: {selectedItem.Category}";
                    quantityLabel.Text = $"Quantity: {selectedItem.SupplyVoucherListQuantity}";
                    warehouseLabel.Text = $"Warehouse: {selectedItem.WarehouseName}";
                    expirationLabel.Text = $"Expires in: {selectedItem.DaysUntilExpiration} days";

                    // Show expiration warning if close to expiration
                    if (selectedItem.DaysUntilExpiration < 30)
                    {
                        expirationLabel.ForeColor = Color.Red;
                    }
                    else
                    {
                        expirationLabel.ForeColor = SystemColors.ControlText;
                    }
                }
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMyItems();
        }

        private void requestToOwnerButton_Click(object sender, EventArgs e)
        {
            if (myItemsGridView.SelectedRows.Count > 0)
            {
                var selectedItem = myItemsGridView.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedItem != null)
                {
                    int itemId = selectedItem.ItemId;
                    Item item = context.Items.Find(itemId);

                    if (item != null)
                    {
                        RequestToSupplyItem(item);
                    }
                }
            }
        }

        private void RequestToSupplyItem(Item item)
        {
            // Find the owner of the warehouse where this item is stored
            var owner = context.Warehouses
                .Where(w => w.WarehouseId == item.WarehouseId)
                .Select(w => w.Owner)
                .FirstOrDefault();

            if (owner != null && owner.UserId.HasValue)
            {
                // Check if relationship exists
                var relationship = context.SupplierOwnerRelationships
                    .FirstOrDefault(r => r.SupplierId == currentSupplierId && r.OwnerId == owner.OwnerId);

                if (relationship == null)
                {
                    // Create new relationship request
                    relationship = new SupplierOwnerRelationship
                    {
                        SupplierId = currentSupplierId,
                        OwnerId = owner.OwnerId,
                        Status = RelationshipStatus.Pending,
                        RequestDate = DateTime.Now
                    };
                    context.SupplierOwnerRelationships.Add(relationship);
                    context.SaveChanges();

                    // Send notification to owner
                    NotificationService.SendNotification(
                        owner.UserId.Value,
                        $"New supplier {AuthService.CurrentUser.Username} wants to supply {item.ItemName}",
                        "Request",
                        "SupplierRelationship",
                        relationship.Id
                    );

                    MessageBox.Show("Request sent to owner.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshRelationshipsPanel();
                }
                else if (relationship.Status == RelationshipStatus.Approved)
                {
                    MessageBox.Show("You are already approved by this owner.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Request is already pending with this owner.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void viewNotificationsButton_Click(object sender, EventArgs e)
        {
            using (var notificationsForm = new NotificationForm(AuthService.CurrentUser.UserId))
            {
                notificationsForm.ShowDialog();
            }
        }
    }

    // Helper dialog to add new items
    public class AddItemDialog : Form
    {
        private ComboBox itemComboBox;
        private ComboBox warehouseComboBox;
        private TextBox quantityTextBox;
        private DateTimePicker productionDatePicker;
        private DateTimePicker expirationDatePicker;
        private Button addButton;
        private Button cancelButton;
        private Label itemLabel;
        private Label warehouseLabel;
        private Label quantityLabel;
        private Label productionDateLabel;
        private Label expirationDateLabel;

        private readonly CompanyWarehouseContext _context;
        private readonly int _supplierId;

        public AddItemDialog(int supplierId, CompanyWarehouseContext context)
        {
            _supplierId = supplierId;
            _context = context;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Add New Supply Item";
            this.Size = new Size(400, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Create controls
            itemLabel = new Label { Text = "Item:", Location = new Point(20, 20), AutoSize = true };
            warehouseLabel = new Label { Text = "Warehouse:", Location = new Point(20, 60), AutoSize = true };
            quantityLabel = new Label { Text = "Quantity:", Location = new Point(20, 100), AutoSize = true };
            productionDateLabel = new Label { Text = "Production Date:", Location = new Point(20, 140), AutoSize = true };
            expirationDateLabel = new Label { Text = "Expiration Date:", Location = new Point(20, 180), AutoSize = true };

            itemComboBox = new ComboBox { Location = new Point(150, 17), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            warehouseComboBox = new ComboBox { Location = new Point(150, 57), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            quantityTextBox = new TextBox { Location = new Point(150, 97), Width = 200 };

            productionDatePicker = new DateTimePicker
            {
                Location = new Point(150, 137),
                Width = 200,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };

            expirationDatePicker = new DateTimePicker
            {
                Location = new Point(150, 177),
                Width = 200,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddMonths(6)
            };

            addButton = new Button
            {
                Text = "Add",
                Location = new Point(150, 220),
                DialogResult = DialogResult.OK
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new Point(250, 220),
                DialogResult = DialogResult.Cancel
            };

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                itemLabel, warehouseLabel, quantityLabel, productionDateLabel, expirationDateLabel,
                itemComboBox, warehouseComboBox, quantityTextBox, productionDatePicker, expirationDatePicker,
                addButton, cancelButton
            });

            // Set event handlers
            addButton.Click += AddButton_Click;
            itemComboBox.SelectedIndexChanged += ItemComboBox_SelectedIndexChanged;
        }

        private void LoadData()
        {
            // Load items
            var items = _context.Items
                .Select(i => new { i.ItemId, i.ItemName, i.ItemCode })
                .OrderBy(i => i.ItemName)
                .ToList();

            itemComboBox.DisplayMember = "ItemName";
            itemComboBox.ValueMember = "ItemId";
            itemComboBox.DataSource = items;

            // Load warehouses
            LoadWarehousesForItem();
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWarehousesForItem();
        }

        private void LoadWarehousesForItem()
        {
            if (itemComboBox.SelectedValue != null)
            {
                int selectedItemId = (int)itemComboBox.SelectedValue;

                // Load warehouses that have this item
                var warehouses = _context.Warehouses
                    .Where(w => w.WarehouseId == _context.Items.FirstOrDefault(i => i.ItemId == selectedItemId).WarehouseId)
                    .Select(w => new { w.WarehouseId, w.WarehouseName })
                    .ToList();

                warehouseComboBox.DisplayMember = "WarehouseName";
                warehouseComboBox.ValueMember = "WarehouseId";
                warehouseComboBox.DataSource = warehouses;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (itemComboBox.SelectedValue == null || warehouseComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select an item and warehouse", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            if (productionDatePicker.Value > DateTime.Today)
            {
                MessageBox.Show("Production date cannot be in the future", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            if (expirationDatePicker.Value <= productionDatePicker.Value)
            {
                MessageBox.Show("Expiration date must be after production date", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            // Create supply voucher
            try
            {
                // Create a new supply voucher
                var maxVoucherNumber = _context.SupplyVouchers
                    .Select(sv => (int?)sv.SupplyVoucherNumber)
                    .Max() ?? 0;

                var supplyVoucher = new SupplyVoucher
                {
                    SupplyVoucherNumber = maxVoucherNumber + 1,
                    SupplierId = _supplierId,
                    WarehouseId = (int)warehouseComboBox.SelectedValue,
                    SupplyVoucherDate = DateTime.Now
                };

                _context.SupplyVouchers.Add(supplyVoucher);
                _context.SaveChanges();

                // Add supply voucher list item
                var supplyVoucherList = new SupplyVoucherList
                {
                    SupplyVoucherId = supplyVoucher.SupplyVoucherId,
                    ItemId = (int)itemComboBox.SelectedValue,
                    SupplyVoucherListQuantity = quantity,
                    SupplyVoucherListProductionDate = productionDatePicker.Value,
                    SupplyVoucherListExpirationDate = expirationDatePicker.Value
                };

                _context.SupplyVoucherLists.Add(supplyVoucherList);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding supply item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}