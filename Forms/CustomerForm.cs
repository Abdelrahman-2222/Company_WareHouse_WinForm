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

namespace CompanyForm
{

    public partial class CustomerForm : Form
    {
        private readonly CompanyWarehouseContext context;
        private int currentCustomerId;

        public CustomerForm()
        {
            InitializeComponent();
            context = new CompanyWarehouseContext();

            // Set current customer ID from the logged-in user
            if (AuthService.CurrentUser != null)
            {
                var customer = context.Customers.FirstOrDefault(c => c.UserId == AuthService.CurrentUser.UserId);
                if (customer != null)
                {
                    currentCustomerId = customer.CustomerId;
                }
            }

            // Load categories into combo box
            LoadCategories();
            RefreshItemsList();
        }

        private void LoadCategories()
        {
            // Add "All Categories" option
            categoryFilterComboBox.Items.Add("All Categories");

            // Add distinct categories from items
            var categories = context.Items
                .Select(i => i.Category)
                .Distinct()
                .Where(c => !string.IsNullOrEmpty(c))
                .OrderBy(c => c)
                .ToList();

            foreach (var category in categories)
            {
                categoryFilterComboBox.Items.Add(category);
            }

            // Select the first item
            if (categoryFilterComboBox.Items.Count > 0)
                categoryFilterComboBox.SelectedIndex = 0;
        }

        private void RefreshRelationshipsPanel()
        {
            ownerRelationshipsPanel.Controls.Clear();

            var relationships = context.CustomerOwnerRelationships
                .Where(r => r.CustomerId == currentCustomerId)
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

        private void SelectItem(Item item)
        {
            var owner = context.Warehouses
                .Where(w => w.WarehouseId == item.WarehouseId)
                .Select(w => w.Owner)
                .FirstOrDefault();

            if (owner != null && owner.UserId.HasValue)
            {
                // Check if relationship exists
                var relationship = context.CustomerOwnerRelationships
                    .FirstOrDefault(r => r.CustomerId == currentCustomerId && r.OwnerId == owner.OwnerId);

                if (relationship == null)
                {
                    // Create new relationship request
                    relationship = new CustomerOwnerRelationship
                    {
                        CustomerId = currentCustomerId,
                        OwnerId = owner.OwnerId,
                        Status = RelationshipStatus.Pending,
                        RequestDate = DateTime.Now
                    };
                    context.CustomerOwnerRelationships.Add(relationship);
                    context.SaveChanges();

                    // Send notification to owner
                    NotificationService.SendNotification(
                        owner.UserId.Value,
                        $"New customer {AuthService.CurrentUser.Username} wants to purchase {item.ItemName}",
                        "Request",
                        "CustomerRelationship",
                        relationship.Id
                    );
                }
            }
        }

        private void categoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filter items by selected category
            RefreshItemsList();
        }

        private void itemsGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Show details of selected item
            if (itemsGridView.SelectedRows.Count > 0)
            {
                var selectedItem = itemsGridView.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedItem != null)
                {
                    itemNameLabel.Text = $"Item: {selectedItem.ItemName}";
                    itemOwnerLabel.Text = $"Owner: {selectedItem.OwnerName}";
                    warehouseLabel.Text = $"Warehouse: {selectedItem.WarehouseName}";

                    // Enable request button if relationship allows
                    Item item = context.Items.Find(selectedItem.ItemId);
                    EnableRequestButtonIfAllowed(item);
                }
            }
        }

        private void requestItemButton_Click(object sender, EventArgs e)
        {
            if (itemsGridView.SelectedRows.Count > 0)
            {
                var selectedItem = itemsGridView.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedItem != null)
                {
                    int itemId = selectedItem.ItemId;
                    Item item = context.Items.Find(itemId);

                    if (item != null && int.TryParse(quantityTextBox.Text, out int quantity) && quantity > 0)
                    {
                        // Call your existing SelectItem method
                        SelectItem(item);

                        MessageBox.Show("Request submitted to the owner.", "Request Sent",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshRelationshipsPanel();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid quantity.", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void RefreshItemsList()
        {
            var selectedCategory = categoryFilterComboBox.SelectedItem?.ToString();

            var query = from i in context.Items
                        join w in context.Warehouses on i.WarehouseId equals w.WarehouseId
                        join o in context.Owners on w.OwnerId equals o.OwnerId into ownerJoin
                        from owner in ownerJoin.DefaultIfEmpty()
                        select new
                        {
                            i.ItemId,
                            i.ItemCode,
                            i.ItemName,
                            i.Category,
                            OwnerName = owner != null ? owner.OwnerName : "Unknown",
                            WarehouseName = w.WarehouseName
                        };

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All Categories")
            {
                query = query.Where(i => i.Category == selectedCategory);
            }

            itemsGridView.DataSource = query.ToList();
        }

        private void EnableRequestButtonIfAllowed(Item item)
        {
            if (item == null)
            {
                requestItemButton.Enabled = false;
                return;
            }

            var owner = context.Warehouses
                .Where(w => w.WarehouseId == item.WarehouseId)
                .Select(w => w.Owner)
                .FirstOrDefault();

            if (owner != null)
            {
                var relationship = context.CustomerOwnerRelationships
                    .FirstOrDefault(r => r.CustomerId == currentCustomerId && r.OwnerId == owner.OwnerId);

                // Enable button if no relationship exists yet or if relationship is approved
                requestItemButton.Enabled = relationship == null ||
                    relationship.Status == RelationshipStatus.Approved;
            }
            else
            {
                requestItemButton.Enabled = false;
            }
        }

    }
}
