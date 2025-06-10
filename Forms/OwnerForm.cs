using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyForm.Entities;
using CompnayForm.Context;
using CompnayForm.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CompanyForm
{

    public partial class OwnerForm : Form
    {
        string option;
        private readonly CompanyWarehouseContext context = new CompanyWarehouseContext();

        public enum EntityType
        {
            Warehouse,
            Item,
            Supplier,
            Customer
        }

        public OwnerForm()
        {
            InitializeComponent();
        }

        private bool TryParseId(string text, out int id)
        {
            return int.TryParse(text.Trim(), out id);
        }

        private async Task DoAdd<T>(Func<T> createEntity, DbSet<T> dbSet, string successMsg, EntityType e) where T : class
        {
            var entity = createEntity();
            dbSet.Add(entity);
            await TrySave(context, successMsg, e);
        }

        private async Task DoUpdate<T>(int id, Func<CompanyWarehouseContext, T, bool> updateEntity, DbSet<T> dbSet,
            string keyName, string successMsg, EntityType e) where T : class
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                if (updateEntity(context, entity))
                {
                    await TrySave(context, successMsg, e);
                }
            }
            else
            {
                MessageBox.Show($"{typeof(T).Name} not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DoDelete<T>(int id, DbSet<T> dbSet, string keyName, Func<T, string> getName, string successMsg, EntityType e) where T : class
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                string name = getName(entity);
                var result =
                    MessageBox.Show($"Are you sure you want to delete this {typeof(T).Name} with {keyName} = {name}?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbSet.Remove(entity);
                    await TrySave(context, successMsg, e);
                }
            }
            else
            {
                MessageBox.Show($"{typeof(T).Name} not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TrySave(CompanyWarehouseContext context, string successMsg, EntityType entity)
        {
            try
            {
                await context.SaveChangesAsync();
                MessageBox.Show(successMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid(context, entity);
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            context.Dispose();
            Application.Exit();
        }

        private void WarehouseDropButton_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Visible = false;
            OwnerGridView.Visible = true;
            var warehouses = context.Warehouses
                .Select(w => new
                {
                    w.WarehouseId,
                    w.WarehouseName,
                    w.WarehouseAddress,
                    w.WarehousePersonName
                })
                //.Where(w => w.WarehouseId)
                .ToList();


            OwnerGridView.DataSource = warehouses;

        }

        private void WarehouseAddTool_Click(object sender, EventArgs e)
        {
            AddWarehoueLbl.Text = "This is for adding a Warehouse";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Visible = true;
            textBox1.Visible = true;
            itemLbl2.Visible = true;
            textBox2.Visible = true;
            itemLbl3.Visible = true;
            textBox3.Visible = true;
            option = "AddW";
        }

        private void WarehouseUpdateTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for updating a Warehouse";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Visible = true;
            itemLbl1.Text = "Warehouse Id";
            textBox1.Visible = true;

            itemLbl2.Visible = true;
            itemLbl2.Text = "Warehouse Name";
            textBox2.Visible = true;

            itemLbl3.Visible = true;
            itemLbl3.Text = "Warehouse Address";
            textBox3.Visible = true;

            itemLbl4.Visible = true;
            itemLbl4.Text = "W_Person Name";
            textBox4.Visible = true;
            option = "UpdateW";
        }

        private void WarehouseDeleteTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for deleting a Warehouse";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Warehouse Id";
            itemLbl1.Visible = true;
            textBox1.Visible = true;
            option = "DeleteW";
        }

        private void ItemsDropBtn_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Visible = false;
            OwnerGridView.Visible = true;
            var items = context.Items
                .Select(i => new
                {
                    i.ItemId,
                    i.ItemCode,
                    i.ItemName,
                })
                .ToList();


            OwnerGridView.DataSource = items;
        }

        private void ItemAddTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for adding an Item";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Item Code";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required, Must be uniqe 8 numbers";
            textBox1.Visible = true;
            itemLbl2.Text = "Item Name";
            itemLbl2.Visible = true;
            textBox2.Visible = true;
            option = "AddI";
        }

        private void ItemUpdateTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for updating an Item";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Visible = true;
            itemLbl1.Text = "Item Id";
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;

            itemLbl2.Visible = true;
            itemLbl2.Text = "Item Code";
            textBox2.PlaceholderText = "Required, Must be uniqe 8 numbers";
            textBox2.Visible = true;

            itemLbl3.Visible = true;
            itemLbl3.Text = "Item Name";
            textBox3.Visible = true;

            option = "UpdateI";
        }

        private void ItemDeleteTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for deleting an Item";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Item Id";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;
            option = "DeleteI";
        }

        private void SupplierDropBtn_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Visible = false;
            OwnerGridView.Visible = true;
            var suppliers = context.Suppliers
                .Select(s => new
                {
                    s.SupplierId,
                    s.SupplierName,
                    s.SupplierEmail,
                    s.SupplierMobileNumber
                })
                .ToList();


            OwnerGridView.DataSource = suppliers;
        }

        private void SupplierAddTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for adding a Supplier";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Supplier_Name";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;
            itemLbl2.Text = "Supplier_Email";
            itemLbl2.Visible = true;
            textBox2.PlaceholderText = "Required";
            textBox2.Visible = true;
            itemLbl3.Text = "Supplier_Mobile_Number";
            itemLbl3.Visible = true;
            textBox3.PlaceholderText = "Required";
            textBox3.Visible = true;
            option = "AddS";
        }

        private void SupplierUpdateTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for updating a Supplier";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Supplier Id";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;

            itemLbl2.Text = "Supplier_Name";
            itemLbl2.Visible = true;
            textBox2.PlaceholderText = "Required";
            textBox2.Visible = true;

            itemLbl3.Text = "Supplier_Email";
            itemLbl3.Visible = true;
            textBox3.PlaceholderText = "Required";
            textBox3.Visible = true;

            itemLbl4.Text = "Supplier_Mobile_Number";
            itemLbl4.Visible = true;
            textBox4.PlaceholderText = "Required";
            textBox4.Visible = true;

            option = "UpdateS";
        }

        private void SupplierDeleteTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for deleting a Supplier";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Supplier Id";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;
            option = "DeleteS";
        }

        private void CustomerDropBtn_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Visible = false;
            OwnerGridView.Visible = true;
            var customers = context.Customers
                .Select(c => new
                {
                    c.CustomerId,
                    c.CustomerName,
                    c.CustomerEmail,
                    c.CustomerMobileNumber,
                    c.CustomerFax,
                    c.CustomerPhone
                })
                .ToList();


            OwnerGridView.DataSource = customers;
        }

        private void CustomerAddTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for adding a a Customer";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Customer_Name";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;
            itemLbl2.Text = "Customer_Email";
            itemLbl2.Visible = true;
            textBox2.PlaceholderText = "Required";
            textBox2.Visible = true;
            itemLbl3.Text = "Customer_Mobile_Number";
            itemLbl3.Visible = true;
            textBox3.PlaceholderText = "Required";
            textBox3.Visible = true;
            itemLbl3.Text = "Customer_Fax_Number";
            itemLbl3.Visible = true;
            textBox3.Visible = true;
            itemLbl3.Text = "Customer_Phone_Number";
            itemLbl3.Visible = true;
            textBox3.Visible = true;
            option = "AddC";
        }

        private void CustomerUpdateTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for updating a Customer";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Customer Id";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;

            itemLbl2.Text = "Customer_Name";
            itemLbl2.Visible = true;
            textBox2.PlaceholderText = "Required";
            textBox2.Visible = true;

            itemLbl3.Text = "Customer_Email";
            itemLbl3.Visible = true;
            textBox3.PlaceholderText = "Required";
            textBox3.Visible = true;

            itemLbl4.Text = "Customer_Mobile_Number";
            itemLbl4.Visible = true;
            textBox4.PlaceholderText = "Required";
            textBox4.Visible = true;

            option = "UpdateC";
        }

        private void CustomerDeleteTool_Click(object sender, EventArgs e)
        {
            ResetDate();

            AddWarehoueLbl.Text = "This is for deleting a Customer";
            AddWarehoueLbl.Visible = true;
            itemLbl1.Text = "Customer Id";
            itemLbl1.Visible = true;
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = true;
            option = "DeleteC";
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            switch (option)
            {
                case "AddW":
                    await DoAdd(
                        () => new Warehouse
                        {
                            WarehouseName = textBox1.Text.Trim(),
                            WarehouseAddress = textBox2.Text.Trim(),
                            WarehousePersonName = textBox3.Text.Trim()
                        },
                        context.Warehouses,
                        "Warehouse added successfully!",
                        EntityType.Warehouse
                    );
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                    break;
                case "UpdateW":
                    if (TryParseId(textBox1.Text, out int warehouseId))
                    {
                        await DoUpdate(
                            warehouseId,
                            (ctx, entity) =>
                            {
                                var w = entity as Warehouse;
                                w.WarehouseName = textBox2.Text.Trim();
                                w.WarehouseAddress = textBox3.Text.Trim();
                                w.WarehousePersonName = textBox4.Text.Trim();
                                return true;
                            },
                            context.Warehouses,
                            "WarehouseId",
                            "Warehouse updated successfully!",
                            EntityType.Warehouse
                        );
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    }
                    break;
                case "DeleteW":
                    if (TryParseId(textBox1.Text, out int delWarehouseId))
                    {
                        await DoDelete(
                            delWarehouseId,
                            context.Warehouses,
                            "Warehouse Name",
                            w => w.WarehouseName,
                            "Warehouse deleted successfully!",
                            EntityType.Warehouse
                        );
                        textBox1.Text = "";
                    }
                    break;
                case "AddI":
                    await DoAdd(
                        () => new Item
                        {
                            ItemCode = int.Parse(textBox1.Text.Trim()),
                            ItemName = textBox2.Text.Trim()
                        },
                        context.Items,
                        "Item added successfully!",
                        EntityType.Item
                    );
                    textBox1.Text = textBox2.Text = "";
                    textBox1.PlaceholderText = textBox2.PlaceholderText = "";
                    break;
                case "UpdateI":
                    if (TryParseId(textBox1.Text, out int itemId))
                    {
                        await DoUpdate(
                            itemId,
                            (ctx, entity) =>
                            {
                                var i = entity as Item;
                                i.ItemCode = int.Parse(textBox2.Text.Trim());
                                i.ItemName = textBox3.Text.Trim();
                                return true;
                            },
                            context.Items,
                            "Item Name",
                            "Item updated successfully!",
                            EntityType.Item
                        );
                        textBox1.Text = textBox2.Text = textBox3.Text = "";
                        textBox1.PlaceholderText = textBox2.PlaceholderText = textBox3.PlaceholderText = "";
                    }
                    break;
                case "DeleteI":
                    if (TryParseId(textBox1.Text, out int delItemId))
                    {
                        await DoDelete(
                            delItemId,
                            context.Items,
                            "Item Name",
                            i => i.ItemName,
                            "Item deleted successfully!",
                            EntityType.Item
                        );
                        textBox1.Text = "";
                        textBox1.PlaceholderText = "";
                    }
                    break;
                case "AddS":
                    await DoAdd(
                        () => new Supplier
                        {
                            SupplierName = textBox1.Text,
                            SupplierEmail = textBox2.Text,
                            SupplierMobileNumber = textBox3.Text
                        },
                        context.Suppliers,
                        "Supplier Added Successfully",
                        EntityType.Supplier
                    );
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                    textBox1.PlaceholderText = textBox2.PlaceholderText = textBox3.PlaceholderText = "";
                    break;
                case "UpdateS":
                    if (TryParseId(textBox1.Text, out int supplierId))
                    {
                        await DoUpdate(
                            supplierId,
                            (ctx, entity) =>
                            {
                                var w = entity as Supplier;
                                w.SupplierName = textBox2.Text.Trim();
                                w.SupplierEmail = textBox3.Text.Trim();
                                w.SupplierMobileNumber = textBox4.Text.Trim();
                                return true;
                            },
                            context.Suppliers,
                            "SupplierId",
                            "Supplier updated successfully!",
                            EntityType.Supplier
                        );
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    }
                    break;
                case "DeleteS":
                    if (TryParseId(textBox1.Text, out int delSupplierId))
                    {
                        await DoDelete(
                            delSupplierId,
                            context.Suppliers,
                            "Supplier Name",
                            s => s.SupplierName,
                            "Supplier deleted successfully!",
                            EntityType.Supplier
                        );
                        textBox1.Text = "";
                        textBox1.PlaceholderText = "";
                    }
                    break;
                case "AddC":
                    await DoAdd(
                        () => new Customer
                        {
                            CustomerName = textBox1.Text,
                            CustomerEmail = textBox2.Text,
                            CustomerMobileNumber = textBox3.Text,
                            CustomerFax = textBox4.Text,
                            CustomerPhone = textBox5.Text
                        },
                        context.Customers,
                        "Customer Added Successfully",
                        EntityType.Customer
                    );
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                    textBox1.PlaceholderText = textBox2.PlaceholderText = textBox3.PlaceholderText = textBox4.PlaceholderText = textBox5.Text = "";
                    break;
                case "UpdateC":
                    if (TryParseId(textBox1.Text, out int customerId))
                    {
                        await DoUpdate(
                            customerId,
                            (ctx, entity) =>
                            {
                                var s = entity as Customer;
                                s.CustomerName = textBox2.Text.Trim();
                                s.CustomerEmail = textBox3.Text.Trim();
                                s.CustomerMobileNumber = textBox4.Text.Trim();
                                return true;
                            },
                            context.Customers,
                            "CustomerId",
                            "Customer updated successfully!",
                            EntityType.Customer
                        );
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    }
                    break;
                case "DeleteC":
                    if (TryParseId(textBox1.Text, out int delCustomerId))
                    {
                        await DoDelete(
                            delCustomerId,
                            context.Customers,
                            "Item Name",
                            c => c.CustomerName,
                            "Customer deleted successfully!",
                            EntityType.Customer
                        );
                        textBox1.Text = "";
                        textBox1.PlaceholderText = "";
                    }
                    break;
                default:
                    MessageBox.Show("No Choice is chosen");
                    break;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            switch (option)
            {
                case "UpdateW":
                    if (int.TryParse(textBox1.Text.Trim(), out int warehouseId))
                    {
                        var warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseId == warehouseId);
                        if (warehouse != null)
                        {
                            textBox2.Text = warehouse.WarehouseName;
                            textBox3.Text = warehouse.WarehouseAddress;
                            textBox4.Text = warehouse.WarehousePersonName;
                        }
                        else
                        {
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            MessageBox.Show("Warehouse not found.", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }

                    break;
                case "UpdateI":
                    if (int.TryParse(textBox1.Text.Trim(), out int itemId))
                    {
                        var item = context.Items.FirstOrDefault(i => i.ItemId == itemId);
                        if (item != null)
                        {
                            textBox2.Text = item.ItemCode.ToString();
                            textBox3.Text = item.ItemName;
                        }
                        else
                        {
                            textBox2.Text = "";
                            textBox3.Text = "";
                            MessageBox.Show("Item not found.", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    break;
                case "UpdateS":
                    if (int.TryParse(textBox1.Text.Trim(), out int supplierId))
                    {
                        var supplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                        if (supplier != null)
                        {
                            textBox2.Text = supplier.SupplierName;
                            textBox3.Text = supplier.SupplierEmail;
                            textBox4.Text = supplier.SupplierMobileNumber;
                        }
                        else
                        {
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            MessageBox.Show("Supplier not found.", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    break;
                case "UpdateC":
                    if (int.TryParse(textBox1.Text.Trim(), out int customerId))
                    {
                        var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                        if (customer != null)
                        {
                            textBox2.Text = customer.CustomerName;
                            textBox3.Text = customer.CustomerEmail;
                            textBox4.Text = customer.CustomerMobileNumber;
                        }
                        else
                        {
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            MessageBox.Show("Customer not found.", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    break;
            }
        }

        public void RefreshGrid(CompanyWarehouseContext context, EntityType entity)
        {
            switch (entity)
            {
                case EntityType.Warehouse:
                    OwnerGridView.DataSource = context.Warehouses
                        .Select(w => new
                        {
                            w.WarehouseId,
                            w.WarehouseName,
                            w.WarehouseAddress,
                            w.WarehousePersonName
                        })
                        .ToList();
                    break;

                case EntityType.Item:
                    OwnerGridView.DataSource = context.Items
                        .Select(i => new
                        {
                            i.ItemId,
                            i.ItemCode,
                            i.ItemName
                        })
                        .ToList();
                    break;

                case EntityType.Supplier:
                    OwnerGridView.DataSource = context.Suppliers
                        .Select(s => new
                        {
                            s.SupplierId,
                            s.SupplierName,
                            s.SupplierMobileNumber,
                            s.SupplierEmail
                        })
                        .ToList();
                    break;
                case EntityType.Customer:
                    OwnerGridView.DataSource = context.Customers
                        .Select(c => new
                        {
                            c.CustomerId,
                            c.CustomerName,
                            c.CustomerMobileNumber,
                            c.CustomerEmail,
                            c.CustomerPhone,
                            c.CustomerFax
                        })
                        .ToList();
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

        }

        public void ResetDate()
        {
            textBox1.Text = "";
            textBox1.PlaceholderText = "Required";
            textBox1.Visible = false;

            textBox2.Text = "";
            textBox2.PlaceholderText = "Required";
            textBox2.Visible = false;

            textBox3.Text = "";
            textBox3.PlaceholderText = "Required";
            textBox3.Visible = false;

            textBox4.Text = "";
            textBox4.PlaceholderText = "Required";
            textBox4.Visible = false;

            textBox5.Text = "";
            textBox5.PlaceholderText = "Required";
            textBox5.Visible = false;

            itemLbl1.Visible = false;
            itemLbl2.Visible = false;
            itemLbl3.Visible = false;
            itemLbl4.Visible = false;
            itemLbl5.Visible = false;

        }

        private void AdvancedBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var advancedForm = new AdvancedForm();
            advancedForm.ShowDialog(this);
        }


    }
}
