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
using CompnayForm.Context;
using CompnayForm.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyForm
{
    public partial class AdvancedForm : Form
    {
        private readonly CompanyWarehouseContext context = new CompanyWarehouseContext();
        string option;
        char type;
        public AdvancedForm()
        {
            InitializeComponent();


        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            context.Dispose();
            Application.Exit();
        }

        private void SupplyVoucherDrop1_Click(object sender, EventArgs e)
        {
            ResetButtons();
            AdvancedGridView.Visible = true;
            var result = (from w in context.Warehouses
                          join sv in context.SupplyVouchers on w.WarehouseId equals sv.WarehouseId
                          join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                          join i in context.Items on svl.ItemId equals i.ItemId
                          select new
                          {
                              sv.SupplyVoucherId,
                              i.ItemId,
                              w.WarehouseName,
                              sv.SupplyVoucherNumber,
                              sv.SupplyVoucherDate,
                              svl.SupplyVoucherListQuantity,
                              i.ItemName

                          }).ToList();
            AdvancedGridView.DataSource = result;
        }

        private void addSupply_Click(object sender, EventArgs e)
        {
            ResetButtons();
            DisplayLbl.Text = "Enter all the details of Supply Voucher to insert a new one";
            DisplayLbl.Visible = true;

            // ----- Warehouse -----
            F_WarehouseIdLbl.Text = "Warehouse";
            F_WarehouseIdLbl.Visible = true;
            FromWarehouseComboBox.DataSource = context.Warehouses.ToList();
            FromWarehouseComboBox.DisplayMember = "WarehouseName";
            FromWarehouseComboBox.ValueMember = "WarehouseId";
            FromWarehouseComboBox.Visible = true;

            // ----- SupplyVoucherNumber -----
            itemLblName.Text = "Supply V#";
            itemLblName.Visible = true;
            int supplyVoucherNumber = GenerateUniqueTransferNumber('S');
            itemNameTbx.Text = supplyVoucherNumber.ToString();
            itemNameTbx.PlaceholderText = "6 digits required";
            itemNameTbx.Visible = true;

            // ----- Supplier -----
            T_WarehouseLbl.Text = "Supplier";
            T_WarehouseLbl.Visible = true;
            ToWarehouseComboBox.DataSource = context.Suppliers.ToList();
            ToWarehouseComboBox.DisplayMember = "SupplierName";
            ToWarehouseComboBox.ValueMember = "SupplierId";
            ToWarehouseComboBox.Visible = true;

            // ----- SupplyVoucherDate -----
            TransferDateLbl.Text = "Date";
            TransferDateLbl.Visible = true;
            transferDateTxtBox.Visible = true;

            // ----- Quantity -----
            SupplierIdLbl.Text = "Quantity";
            SupplierIdLbl.Visible = true;
            QuantityTxtBox.PlaceholderText = "Required";
            QuantityTxtBox.Visible = true;

            // ----- Item -----
            itemIdLbl.Text = "Item";
            itemIdLbl.Visible = true;
            ItemComboBox.DataSource = context.Items.ToList();
            ItemComboBox.DisplayMember = "ItemName";
            ItemComboBox.ValueMember = "ItemId";
            ItemComboBox.Visible = true;

            // ----- Production Date -----
            ProductionLbl.Text = "Production Date";
            ProductionLbl.Visible = true;
            ProductionDate.Value = DateTime.Today;
            ProductionDate.Visible = true;

            // ----- Expiration Date -----
            ExpirationLbl.Text = "Expiration Date";
            ExpirationLbl.Visible = true;
            ExpirationDate.Value = DateTime.Today;
            ExpirationDate.Visible = true;

            InsertBtn.Visible = true;
            type = 'S';
        }

        private void updateSupply_Click(object sender, EventArgs e)
        {
            ResetButtons();
            InsertBtn.Visible = false;
            DisplayLbl.Text = "Enter all the details of Supplier Voucher to Update Existing One";
            DisplayLbl.Visible = true;
            // ----- SupplierVoucherId -----
            supplierVoucherIDLbl.Visible = true;
            SupplierVoucherIdCbx.DisplayMember = "SupplyVoucherId";
            SupplierVoucherIdCbx.ValueMember = "SupplyVoucherId";
            SupplierVoucherIdCbx.DataSource = context.SupplyVouchers.ToList();
            SupplierVoucherIdCbx.Visible = true;
            //// ----- Warehouse -----
            //F_WarehouseIdLbl.Text = "Warehouse";
            //F_WarehouseIdLbl.Visible = true;
            //FromWarehouseComboBox.DataSource = context.Warehouses.ToList();
            //FromWarehouseComboBox.DisplayMember = "WarehouseName";
            //FromWarehouseComboBox.ValueMember = "WarehouseId";
            //FromWarehouseComboBox.Visible = true;

            // ----- SupplyVoucherNumber -----
            itemLblName.Text = "Supply V#";
            itemLblName.Visible = true;
            int supplyVoucherNumber = GenerateUniqueTransferNumber('S');
            itemNameTbx.Text = supplyVoucherNumber.ToString();
            itemNameTbx.PlaceholderText = "6 digits required";
            itemNameTbx.Visible = true;

            //// ----- Supplier -----
            //T_WarehouseLbl.Text = "Supplier";
            //T_WarehouseLbl.Visible = true;
            //ToWarehouseComboBox.DataSource = context.Suppliers.ToList();
            //ToWarehouseComboBox.DisplayMember = "SupplierName";
            //ToWarehouseComboBox.ValueMember = "SupplierId";
            //ToWarehouseComboBox.Visible = true;

            // ----- SupplyVoucherDate -----
            TransferDateLbl.Text = "Date";
            TransferDateLbl.Visible = true;
            transferDateTxtBox.Visible = true;

            // ----- Quantity -----
            SupplierIdLbl.Text = "Quantity";
            SupplierIdLbl.Visible = true;
            QuantityTxtBox.PlaceholderText = "Required";
            QuantityTxtBox.Visible = true;

            //// ----- Item -----
            //itemIdLbl.Text = "Item";
            //itemIdLbl.Visible = true;
            //ItemComboBox.DataSource = context.Items.ToList();
            //ItemComboBox.DisplayMember = "ItemName";
            //ItemComboBox.ValueMember = "ItemId";
            //ItemComboBox.Visible = true;

            // ----- Production Date -----
            ProductionLbl.Text = "Production Date";
            ProductionLbl.Location = new Point(8, 357);
            ProductionLbl.Visible = true;
            ProductionDate.Value = DateTime.Today;
            ProductionDate.Location = new Point(172, 349);
            ProductionDate.Visible = true;

            // ----- Expiration Date -----
            ExpirationLbl.Text = "Expiration Date";
            ExpirationLbl.Location = new Point(8, 408);
            ExpirationLbl.Visible = true;
            ExpirationDate.Value = DateTime.Today;
            ExpirationDate.Location = new Point(172, 400);
            ExpirationDate.Visible = true;

            UpdateBtn.Location = new Point(104, 451);
            UpdateBtn.Visible = true;
            type = 'S';
        }

        private void DisbursementVoucherDrop_Click(object sender, EventArgs e)
        {
            ResetButtons();
            AdvancedGridView.Visible = true;
            var result = (from w in context.Warehouses
                          join dv in context.DisbursementVouchers on w.WarehouseId equals dv.WarehouseId
                          join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                          join i in context.Items on dvl.ItemId equals i.ItemId
                          select new
                          {
                              dv.DisbursementVoucherId,
                              i.ItemId,
                              w.WarehouseName,
                              dv.DisbursementVoucherNumber,
                              dv.DisbursementVoucherDate,
                              dvl.DisbursementVoucherListQuantity,
                              i.ItemName
                          }).ToList();
            AdvancedGridView.DataSource = result;
        }

        private void addDisbursement_Click(object sender, EventArgs e)
        {
            ResetButtons();
            DisplayLbl.Text = "Enter all the details of Disbursement Voucher to insert a new one";
            DisplayLbl.Visible = true;
            // ----- Warehouse -----
            F_WarehouseIdLbl.Text = "Warehouse";
            F_WarehouseIdLbl.Visible = true;
            FromWarehouseComboBox.DataSource = context.Warehouses.ToList();
            FromWarehouseComboBox.DisplayMember = "WarehouseName";
            FromWarehouseComboBox.ValueMember = "WarehouseId";
            FromWarehouseComboBox.Visible = true;

            // ----- DisbursementVoucherNumber -----
            itemLblName.Text = "Disbursement V#";
            itemLblName.Visible = true;
            int disbursement = GenerateUniqueTransferNumber('D');
            itemNameTbx.Text = disbursement.ToString();
            itemNameTbx.PlaceholderText = "6 digits required";
            itemNameTbx.Visible = true;

            // ----- Customers -----
            T_WarehouseLbl.Text = "Customer";
            T_WarehouseLbl.Visible = true;
            ToWarehouseComboBox.DataSource = context.Customers.ToList();
            ToWarehouseComboBox.DisplayMember = "CustomerName";
            ToWarehouseComboBox.ValueMember = "CustomerId";
            ToWarehouseComboBox.Visible = true;

            // ----- DisbursementVoucherDate -----
            TransferDateLbl.Text = "Date";
            TransferDateLbl.Visible = true;
            transferDateTxtBox.Visible = true;

            // ----- Quantity -----
            SupplierIdLbl.Text = "Quantity";
            SupplierIdLbl.Visible = true;
            QuantityTxtBox.PlaceholderText = "Required";
            QuantityTxtBox.Visible = true;

            // ----- Item -----
            itemIdLbl.Text = "Item";
            itemIdLbl.Visible = true;
            ItemComboBox.DataSource = context.Items.ToList();
            ItemComboBox.DisplayMember = "ItemName";
            ItemComboBox.ValueMember = "ItemId";
            ItemComboBox.Visible = true;

            InsertBtn.Visible = true;
            type = 'D';
        }

        private void updateDisbursement_Click(object sender, EventArgs e)
        {
            ResetButtons();
            InsertBtn.Visible = false;
            DisplayLbl.Text = "Enter all the details of Disbursement Voucher to Update Existing One";
            DisplayLbl.Visible = true;

            // ----- DisbursementVoucherId -----
            supplierVoucherIDLbl.Text = "Disbursement V Id";
            supplierVoucherIDLbl.Visible = true;
            SupplierVoucherIdCbx.DisplayMember = "DisbursementVoucherId";
            SupplierVoucherIdCbx.ValueMember = "DisbursementVoucherId";
            SupplierVoucherIdCbx.DataSource = context.DisbursementVouchers.ToList();
            SupplierVoucherIdCbx.Visible = true;

            // ----- DisbursementVoucherNumber -----
            itemLblName.Text = "Disbursement V#";
            itemLblName.Visible = true;
            int disbursementVoucherNumber = GenerateUniqueTransferNumber('D');
            itemNameTbx.Text = disbursementVoucherNumber.ToString();
            itemNameTbx.PlaceholderText = "6 digits required";
            itemNameTbx.Visible = true;

            // ----- DisbursementVoucherDate -----
            TransferDateLbl.Text = "Date";
            TransferDateLbl.Visible = true;
            transferDateTxtBox.Visible = true;

            // ----- Quantity -----
            SupplierIdLbl.Text = "Quantity";
            SupplierIdLbl.Visible = true;
            QuantityTxtBox.PlaceholderText = "Required";
            QuantityTxtBox.Visible = true;


            UpdateBtn.Location = new Point(104, 451);
            UpdateBtn.Visible = true;
            type = 'D';
        }

        private void SupplierVoucherIdCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supplierVoucherIDLbl.Text == "Supplier Voucher Id")
            {
                if (SupplierVoucherIdCbx.SelectedValue == null)
                    return;

                int selectedVoucherId = (int)SupplierVoucherIdCbx.SelectedValue;

                // Get the voucher
                var voucher = context.SupplyVouchers.FirstOrDefault(sv => sv.SupplyVoucherId == selectedVoucherId);
                if (voucher == null)
                    return;

                // Fill master fields
                itemNameTbx.Text = voucher.SupplyVoucherNumber.ToString();
                FromWarehouseComboBox.SelectedValue = voucher.WarehouseId;
                ToWarehouseComboBox.SelectedValue = voucher.SupplierId;
                transferDateTxtBox.Text = voucher.SupplyVoucherDate.ToString("yyyy-MM-dd");

                // Get the first detail row (if you want to support multiple, you need a grid)
                var detail = context.SupplyVoucherLists.FirstOrDefault(svl => svl.SupplyVoucherId == selectedVoucherId);
                if (detail != null)
                {
                    ItemComboBox.SelectedValue = detail.ItemId;
                    QuantityTxtBox.Text = detail.SupplyVoucherListQuantity.ToString();
                    ProductionDate.Value = detail.SupplyVoucherListProductionDate;
                    ExpirationDate.Value = detail.SupplyVoucherListExpirationDate;
                }
                else
                {
                    // Clear detail fields if no detail exists
                    ItemComboBox.SelectedIndex = -1;
                    QuantityTxtBox.Text = "";
                    ProductionDate.Value = DateTime.Today;
                    ExpirationDate.Value = DateTime.Today;
                }
            }
            else
            {
                if (SupplierVoucherIdCbx.SelectedValue == null)
                    return;

                int selectedVoucherId = (int)SupplierVoucherIdCbx.SelectedValue;

                // Get the voucher
                var voucher = context.DisbursementVouchers.FirstOrDefault(dv => dv.DisbursementVoucherId == selectedVoucherId);
                if (voucher == null)
                    return;

                // Fill master fields
                itemNameTbx.Text = voucher.DisbursementVoucherNumber.ToString();
                FromWarehouseComboBox.SelectedValue = voucher.WarehouseId;
                ToWarehouseComboBox.SelectedValue = voucher.CustomerId;
                transferDateTxtBox.Text = voucher.DisbursementVoucherDate.ToString("yyyy-MM-dd");

                // Get the first detail row (if you want to support multiple, you need a grid)
                var detail = context.DisbursementVoucherLists.FirstOrDefault(dvl => dvl.DisbursementVoucherId == selectedVoucherId);
                if (detail != null)
                {
                    ItemComboBox.SelectedValue = detail.ItemId;
                    QuantityTxtBox.Text = detail.DisbursementVoucherListQuantity.ToString();
                }
                else
                {
                    // Clear detail fields if no detail exists
                    ItemComboBox.SelectedIndex = -1;
                    QuantityTxtBox.Text = "";
                }
            }

        }
        // Update Btn for Supply and Disbursement
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case 'S':
                    // 1) Validate input
                    if (string.IsNullOrWhiteSpace(itemNameTbx.Text) ||
                        !System.Text.RegularExpressions.Regex.IsMatch(itemNameTbx.Text, @"^\d{6}$") ||
                        //FromWarehouseComboBox.SelectedValue == null ||
                        //ToWarehouseComboBox.SelectedValue == null ||
                        //ItemComboBox.SelectedValue == null ||
                        string.IsNullOrWhiteSpace(QuantityTxtBox.Text))
                    {
                        MessageBox.Show(
                            "Please fill all fields and ensure the Supply Voucher Number is exactly 6 digits.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    try
                    {
                        // 2) Parse all values from the UI
                        int voucherNumber = int.Parse(itemNameTbx.Text);
                        //int warehouseId = (int)FromWarehouseComboBox.SelectedValue;
                        //int supplierId = (int)ToWarehouseComboBox.SelectedValue;
                        //int itemId = (int)ItemComboBox.SelectedValue;
                        int quantity = int.Parse(QuantityTxtBox.Text);
                        DateTime prodDate = ProductionDate.Value.Date;
                        DateTime expDate = ExpirationDate.Value.Date;

                        if (expDate <= prodDate)
                        {
                            MessageBox.Show(
                                "Expiration date must be after the production date.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        // 3) Retrieve the existing SupplyVoucher by its ID (e.g., from a selected row)
                        int supplyVoucherId = (int)SupplierVoucherIdCbx.SelectedValue;
                        var supplyVoucher = context.SupplyVouchers
                            .Include(sv => sv.SupplyVoucherLists)
                            .FirstOrDefault(sv => sv.SupplyVoucherId == supplyVoucherId);

                        if (supplyVoucher == null)
                        {
                            MessageBox.Show("Supply voucher not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 4) Update the parent SupplyVoucher fields
                        supplyVoucher.SupplyVoucherNumber = voucherNumber;
                        supplyVoucher.SupplyVoucherDate = DateTime.Today;
                        //supplyVoucher.WarehouseId = warehouseId;
                        //supplyVoucher.SupplierId = supplierId;

                        // 5) Update the detail row (assuming one detail per voucher)
                        var supplyVoucherItem = supplyVoucher.SupplyVoucherLists.FirstOrDefault();
                        if (supplyVoucherItem != null)
                        {
                            //supplyVoucherItem.ItemId = itemId;
                            supplyVoucherItem.SupplyVoucherListQuantity = quantity;
                            supplyVoucherItem.SupplyVoucherListProductionDate = prodDate;
                            supplyVoucherItem.SupplyVoucherListExpirationDate = expDate;
                        }
                        else
                        {
                            // Optionally add a new detail if none exists
                        }

                        // 6) Save changes
                        context.SaveChanges();

                        // 7) Refresh the grid (AdvancedGridView) with the latest data
                        AdvancedGridView.DataSource = (from w in context.Warehouses
                                                       join sv in context.SupplyVouchers on w.WarehouseId equals sv.WarehouseId
                                                       join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                                                       join i in context.Items on svl.ItemId equals i.ItemId
                                                       select new
                                                       {
                                                           sv.SupplyVoucherId,
                                                           i.ItemId,
                                                           w.WarehouseName,
                                                           sv.SupplyVoucherNumber,
                                                           sv.SupplyVoucherDate,
                                                           svl.SupplyVoucherListQuantity,
                                                           i.ItemName

                                                       }).ToList();

                        // 8) Generate a new 6-digit Supply Voucher Number for the next insertion
                        int newVoucherNumber = GenerateUniqueTransferNumber('S');
                        itemNameTbx.Text = newVoucherNumber.ToString();

                        // 9) Clear the quantity field (and any other fields you choose)
                        QuantityTxtBox.Text = "";

                        MessageBox.Show(
                            "Supply voucher and its item were updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Update failed: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    break;
                case 'D':
                    // 1) Validate input
                    if (string.IsNullOrWhiteSpace(itemNameTbx.Text) ||
                        !System.Text.RegularExpressions.Regex.IsMatch(itemNameTbx.Text, @"^\d{6}$") ||
                        string.IsNullOrWhiteSpace(QuantityTxtBox.Text))
                    {
                        MessageBox.Show(
                            "Please fill all fields and ensure the Disbursement Voucher Number is exactly 6 digits.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    try
                    {
                        // 2) Parse all values from the UI
                        int voucherNumber = int.Parse(itemNameTbx.Text);
                        int quantity = int.Parse(QuantityTxtBox.Text);

                        // 3) Retrieve the existing SupplyVoucher by its ID (e.g., from a selected row)
                        int disbursementVoucherId = (int)SupplierVoucherIdCbx.SelectedValue;
                        var disbursementVoucher = context.DisbursementVouchers
                            .Include(dv => dv.DisbursementVoucherLists)
                            .FirstOrDefault(dv => dv.DisbursementVoucherId == disbursementVoucherId);

                        if (disbursementVoucher == null)
                        {
                            MessageBox.Show("Supply voucher not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 4) Update the parent SupplyVoucher fields
                        disbursementVoucher.DisbursementVoucherNumber = voucherNumber;
                        disbursementVoucher.DisbursementVoucherDate = DateTime.Today;
                        //supplyVoucher.WarehouseId = warehouseId;
                        //supplyVoucher.SupplierId = supplierId;

                        // 5) Update the detail row (assuming one detail per voucher)
                        var disbursementVoucherItem = disbursementVoucher.DisbursementVoucherLists.FirstOrDefault();
                        if (disbursementVoucherItem != null)
                        {
                            disbursementVoucherItem.DisbursementVoucherListQuantity = quantity;
                        }
                        else
                        {
                            // Optionally add a new detail if none exists
                        }

                        // 6) Save changes
                        context.SaveChanges();

                        // 7) Refresh the grid (AdvancedGridView) with the latest data
                        AdvancedGridView.DataSource = (from w in context.Warehouses
                                                       join dv in context.DisbursementVouchers on w.WarehouseId equals dv.WarehouseId
                                                       join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                                                       join i in context.Items on dvl.ItemId equals i.ItemId
                                                       select new
                                                       {
                                                           dv.DisbursementVoucherId,
                                                           i.ItemId,
                                                           w.WarehouseName,
                                                           dv.DisbursementVoucherNumber,
                                                           dv.DisbursementVoucherDate,
                                                           dvl.DisbursementVoucherListQuantity,
                                                           i.ItemName
                                                       }).ToList();

                        RefreshComboBoxes();

                        // 8) Generate a new 6-digit Supply Voucher Number for the next insertion
                        int newVoucherNumber = GenerateUniqueTransferNumber('D');
                        itemNameTbx.Text = newVoucherNumber.ToString();

                        // 9) Clear the quantity field (and any other fields you choose)
                        QuantityTxtBox.Text = "";

                        MessageBox.Show(
                            "Disbursement voucher and its item were updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Update failed: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    break;
            }
        }
        private void TransferDrop_Click(object sender, EventArgs e)
        {
            ResetButtons();
            AdvancedGridView.Visible = true;
            var result = (from t in context.TransferOperations
                          select new
                          {
                              t.TransferOperationNumber,
                              TransferOperationDate = t.TransferOperationDate.ToString("MM/dd/yyyy"),
                              t.ItemId,
                              t.SupplierId,
                              t.FromWarehouseId,
                              t.ToWarehouseId
                          }).ToList();
            AdvancedGridView.DataSource = result;

            // Fill Item ComboBox
            ItemComboBox.DataSource = context.Items.ToList();
            ItemComboBox.DisplayMember = "ItemName";
            ItemComboBox.ValueMember = "ItemId";

            // Fill Supplier ComboBox
            SupplierComboBox.DataSource = context.Suppliers.ToList();
            SupplierComboBox.DisplayMember = "SupplierName";
            SupplierComboBox.ValueMember = "SupplierId";

            // Fill FromWarehouse ComboBox
            FromWarehouseComboBox.DataSource = context.Warehouses.ToList();
            FromWarehouseComboBox.DisplayMember = "WarehouseName";
            FromWarehouseComboBox.ValueMember = "WarehouseId";

            // Fill ToWarehouse ComboBox
            ToWarehouseComboBox.DataSource = context.Warehouses.ToList();
            ToWarehouseComboBox.DisplayMember = "WarehouseName";
            ToWarehouseComboBox.ValueMember = "WarehouseId";
        }

        // Transfer Inset Drop Down
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetButtons();
            itemLblName.Text = "Transfer Number";
            itemLblName.Visible = true;

            // Always set a unique 6-digit number as default
            int transferNumber = GenerateUniqueTransferNumber('T');
            itemNameTbx.Text = transferNumber.ToString();
            itemNameTbx.PlaceholderText = "6 digits required";
            itemNameTbx.Visible = true;

            TransferDateLbl.Visible = true;
            transferDateTxtBox.Visible = true;

            itemIdLbl.Visible = true;
            ItemComboBox.Visible = true;

            SupplierIdLbl.Visible = true;
            SupplierComboBox.Visible = true;

            F_WarehouseIdLbl.Visible = true;
            FromWarehouseComboBox.Visible = true;

            T_WarehouseLbl.Visible = true;
            ToWarehouseComboBox.Visible = true;

            //InsertBtn.Location = new Point(104, 424);
            InsertBtn.Visible = true;
            type = 't';
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case 't':
                    // default location 104, 424
                    // new location 104, 563
                    // Validate input
                    if (string.IsNullOrWhiteSpace(itemNameTbx.Text) ||
                        !System.Text.RegularExpressions.Regex.IsMatch(itemNameTbx.Text, @"^\d{6}$") ||
                        ItemComboBox.SelectedValue == null ||
                        SupplierComboBox.SelectedValue == null ||
                        FromWarehouseComboBox.SelectedValue == null ||
                        ToWarehouseComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Please fill all fields and ensure Transfer Number is a unique 6 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int transferNumber = int.Parse(itemNameTbx.Text);

                    if (FromWarehouseComboBox.SelectedValue.Equals(ToWarehouseComboBox.SelectedValue))
                    {
                        MessageBox.Show("From and To Warehouse cannot be the same.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Create new TransferOperation
                    var transfer = new TransferOperation
                    {
                        TransferOperationNumber = transferNumber,
                        TransferOperationDate = DateTime.Today,
                        ItemId = (int)ItemComboBox.SelectedValue,
                        SupplierId = (int)SupplierComboBox.SelectedValue,
                        FromWarehouseId = (int)FromWarehouseComboBox.SelectedValue,
                        ToWarehouseId = (int)ToWarehouseComboBox.SelectedValue
                    };

                    context.TransferOperations.Add(transfer);

                    try
                    {
                        context.SaveChanges();
                        RefreshComboBoxes();
                        AdvancedGridView.DataSource = context.TransferOperations
                            .Select(t => new
                            {
                                t.TransferOperationNumber,
                                TransferOperationDate = t.TransferOperationDate.ToString("MM/dd/yyyy"),
                                t.ItemId,
                                t.SupplierId,
                                t.FromWarehouseId,
                                t.ToWarehouseId
                            })
                            .ToList();

                        int newTransferNumber = GenerateUniqueTransferNumber('T');
                        itemNameTbx.Text = newTransferNumber.ToString();

                        MessageBox.Show("TransferOperation inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 'S':
                    // 1) Validate input
                    if (string.IsNullOrWhiteSpace(itemNameTbx.Text) ||
                        !System.Text.RegularExpressions.Regex.IsMatch(itemNameTbx.Text, @"^\d{6}$") ||
                        FromWarehouseComboBox.SelectedValue == null ||
                        ToWarehouseComboBox.SelectedValue == null ||
                        ItemComboBox.SelectedValue == null ||
                        string.IsNullOrWhiteSpace(QuantityTxtBox.Text))
                    {
                        MessageBox.Show(
                            "Please fill all fields and ensure the Supply Voucher Number is exactly 6 digits.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    try
                    {
                        // 2) Parse all values from the UI
                        int voucherNumber = int.Parse(itemNameTbx.Text);
                        int warehouseId = (int)FromWarehouseComboBox.SelectedValue;
                        int supplierId = (int)ToWarehouseComboBox.SelectedValue;
                        int itemId = (int)ItemComboBox.SelectedValue;
                        int quantity = int.Parse(QuantityTxtBox.Text);
                        DateTime prodDate = ProductionDate.Value.Date;
                        DateTime expDate = ExpirationDate.Value.Date;

                        // 3) Create the SupplyVoucher (parent)
                        var supplyVoucher = new SupplyVoucher
                        {
                            SupplyVoucherNumber = voucherNumber,
                            SupplyVoucherDate = DateTime.Today,
                            WarehouseId = warehouseId,
                            SupplierId = supplierId,
                            //Items = new List<SupplyVoucherList>()
                        };

                        context.SupplyVouchers.Add(supplyVoucher);
                        context.SaveChanges();
                        // → supplyVoucher.SupplyVoucherId is now populated

                        // 4) Create the SupplyVoucherItem (detail row)
                        var supplyVoucherItem = new SupplyVoucherList
                        {
                            SupplyVoucherId = supplyVoucher.SupplyVoucherId,
                            ItemId = itemId,
                            SupplyVoucherListQuantity = quantity,
                            SupplyVoucherListProductionDate = prodDate,
                            SupplyVoucherListExpirationDate = expDate
                        };

                        context.SupplyVoucherLists.Add(supplyVoucherItem);

                        // 5) Commit both parent + detail to the database
                        context.SaveChanges();

                        // 6) Refresh the grid (AdvancedGridView) with the latest data
                        AdvancedGridView.DataSource = (from w in context.Warehouses
                                                       join sv in context.SupplyVouchers on w.WarehouseId equals sv.WarehouseId
                                                       join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                                                       join i in context.Items on svl.ItemId equals i.ItemId
                                                       select new
                                                       {
                                                           sv.SupplyVoucherId,
                                                           i.ItemId,
                                                           w.WarehouseName,
                                                           sv.SupplyVoucherNumber,
                                                           sv.SupplyVoucherDate,
                                                           svl.SupplyVoucherListQuantity,
                                                           i.ItemName

                                                       }).ToList();

                        // 7) Generate a new 6-digit Supply Voucher Number for the next insertion
                        //--
                        RefreshComboBoxes();
                        int newVoucherNumber = GenerateUniqueTransferNumber('S');
                        itemNameTbx.Text = newVoucherNumber.ToString();

                        // 8) Clear the quantity field (and any other fields you choose)
                        QuantityTxtBox.Text = "";

                        MessageBox.Show(
                            "Supply voucher and its item were inserted successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Insert failed: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    break;
                case 'D':
                    if (string.IsNullOrWhiteSpace(itemNameTbx.Text) ||
                        !System.Text.RegularExpressions.Regex.IsMatch(itemNameTbx.Text, @"^\d{6}$") ||
                        FromWarehouseComboBox.SelectedValue == null ||
                        ToWarehouseComboBox.SelectedValue == null ||
                        ItemComboBox.SelectedValue == null ||
                        string.IsNullOrWhiteSpace(QuantityTxtBox.Text))
                    {
                        MessageBox.Show(
                            "Please fill all fields and ensure the Disbursement Voucher Number is exactly 6 digits.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    try
                    {
                        // 2) Parse all values from the UI
                        int voucherNumber = int.Parse(itemNameTbx.Text);
                        int warehouseId = (int)FromWarehouseComboBox.SelectedValue;
                        int supplierId = (int)ToWarehouseComboBox.SelectedValue;
                        int itemId = (int)ItemComboBox.SelectedValue;
                        int quantity = int.Parse(QuantityTxtBox.Text);

                        // 3) Create the SupplyVoucher (parent)
                        var disbursementVoucher = new DisbursementVoucher
                        {
                            DisbursementVoucherNumber = voucherNumber,
                            DisbursementVoucherDate = DateTime.Today,
                            WarehouseId = warehouseId,
                            CustomerId = supplierId,
                            //Items = new List<SupplyVoucherList>()
                        };

                        context.DisbursementVouchers.Add(disbursementVoucher);
                        context.SaveChanges();
                        // → supplyVoucher.SupplyVoucherId is now populated

                        // 4) Create the SupplyVoucherItem (detail row)
                        var disbursementVoucherLst = new DisbursementVoucherList
                        {
                            DisbursementVoucherId = disbursementVoucher.DisbursementVoucherId,
                            ItemId = itemId,
                            DisbursementVoucherListQuantity = quantity
                        };

                        context.DisbursementVoucherLists.Add(disbursementVoucherLst);

                        // 5) Commit both parent + detail to the database
                        context.SaveChanges();

                        // 6) Refresh the grid (AdvancedGridView) with the latest data
                        AdvancedGridView.DataSource = (from w in context.Warehouses
                                                       join dv in context.DisbursementVouchers on w.WarehouseId equals dv.WarehouseId
                                                       join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                                                       join i in context.Items on dvl.ItemId equals i.ItemId
                                                       select new
                                                       {
                                                           dv.DisbursementVoucherId,
                                                           i.ItemId,
                                                           w.WarehouseName,
                                                           dv.DisbursementVoucherNumber,
                                                           dv.DisbursementVoucherDate,
                                                           dvl.DisbursementVoucherListQuantity,
                                                           i.ItemName
                                                       }).ToList();

                        RefreshComboBoxes();
                        // 7) Generate a new 6-digit Supply Voucher Number for the next insertion
                        int newVoucherNumber = GenerateUniqueTransferNumber('D');
                        itemNameTbx.Text = newVoucherNumber.ToString();

                        // 8) Clear the quantity field (and any other fields you choose)
                        QuantityTxtBox.Text = "";

                        MessageBox.Show(
                            "Disbursement voucher and its item were inserted successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Insert failed: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    break;
            }
        }

        // Warehouse
        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedGridView.Visible = true;
            int warehouseId = 1; // You can change or parameterize this as needed

            // Supply part
            var supplyQuery = from sv in context.SupplyVouchers
                              join w in context.Warehouses on sv.WarehouseId equals w.WarehouseId
                              join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                              join i in context.Items on svl.ItemId equals i.ItemId
                              // where w.WarehouseId == warehouseId
                              select new
                              {
                                  Type = "Supply",
                                  //w.WarehouseId,
                                  Date = sv.SupplyVoucherDate,
                                  WarehouseName = w.WarehouseName,
                                  ItemName = i.ItemName,
                                  Quantity = svl.SupplyVoucherListQuantity
                              };

            // Disbursement part
            var disbursementQuery = from dv in context.DisbursementVouchers
                                    join w in context.Warehouses on dv.WarehouseId equals w.WarehouseId
                                    join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                                    join i in context.Items on dvl.ItemId equals i.ItemId
                                    //where w.WarehouseId == warehouseId
                                    select new
                                    {
                                        Type = "Disbursement",
                                        //w.WarehouseName,
                                        Date = dv.DisbursementVoucherDate,
                                        WarehouseName = w.WarehouseName,
                                        ItemName = i.ItemName,
                                        Quantity = dvl.DisbursementVoucherListQuantity
                                    };

            // Union all
            var result = supplyQuery.Concat(disbursementQuery).ToList();

            AdvancedGridView.DataSource = result;
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLbl.Text = "Enter the warehouse name you want to download or * to download all";
            DisplayLbl.Visible = true;
            itemLblName.Location = new Point(8, 157);
            itemLblName.Text = "Warehouse Name";
            itemLblName.Visible = true;
            itemNameTbx.Location = new Point(172, 149);
            itemNameTbx.Visible = true;
            DownlBtn.Visible = true;
            option = "Warehouse";
        }
        // Item
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedGridView.Visible = true;
            //int itemId = 1; // You can parameterize this as needed

            // Supply transactions
            var supplyQuery = from svl in context.SupplyVoucherLists
                              join sv in context.SupplyVouchers on svl.SupplyVoucherId equals sv.SupplyVoucherId
                              join w in context.Warehouses on sv.WarehouseId equals w.WarehouseId
                              join i in context.Items on svl.ItemId equals i.ItemId
                              //where i.ItemId == itemId
                              select new
                              {
                                  i.ItemName,
                                  w.WarehouseName,
                                  TransactionType = "SUPPLY",
                                  TransactionDate = sv.SupplyVoucherDate,
                                  Quantity = svl.SupplyVoucherListQuantity
                              };

            // Disbursement transactions
            var disbursementQuery = from dvl in context.DisbursementVoucherLists
                                    join dv in context.DisbursementVouchers on dvl.DisbursementVoucherId equals dv.DisbursementVoucherId
                                    join w in context.Warehouses on dv.WarehouseId equals w.WarehouseId
                                    join i in context.Items on dvl.ItemId equals i.ItemId
                                    //where i.ItemId == itemId
                                    select new
                                    {
                                        i.ItemName,
                                        w.WarehouseName,
                                        TransactionType = "DISBURSEMENT",
                                        TransactionDate = dv.DisbursementVoucherDate,
                                        Quantity = dvl.DisbursementVoucherListQuantity
                                    };

            // Combine and display
            var result = supplyQuery.Concat(disbursementQuery).ToList();
            AdvancedGridView.DataSource = result;
        }

        private void downloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayLbl.Text = "Enter the item name you want to download or * to download all";
            DisplayLbl.Visible = true;
            itemLblName.Location = new Point(8, 157);
            itemLblName.Text = "Item Name";
            itemLblName.Visible = true;
            itemNameTbx.Location = new Point(172, 149);
            itemNameTbx.Visible = true;
            DownlBtn.Visible = true;
            option = "Item";
        }
        // Item Movement
        private void itemMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedGridView.Visible = true;
            //int itemId = 1; // You can make this dynamic if needed

            // SUPPLY movements
            var supplyMovements = from sv in context.SupplyVouchers
                                  join w in context.Warehouses on sv.WarehouseId equals w.WarehouseId
                                  join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                                  join i in context.Items on svl.ItemId equals i.ItemId
                                  //where i.ItemId == itemId
                                  select new
                                  {
                                      TransactionType = "Supply",
                                      TransactionDate = sv.SupplyVoucherDate,
                                      WarehouseName = w.WarehouseName,
                                      ItemName = i.ItemName,
                                      Quantity = svl.SupplyVoucherListQuantity
                                  };

            // DISBURSEMENT movements
            var disbursementMovements = from dv in context.DisbursementVouchers
                                        join w in context.Warehouses on dv.WarehouseId equals w.WarehouseId
                                        join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                                        join i in context.Items on dvl.ItemId equals i.ItemId
                                        //where i.ItemId == itemId
                                        select new
                                        {
                                            TransactionType = "Disbursement",
                                            TransactionDate = dv.DisbursementVoucherDate,
                                            WarehouseName = w.WarehouseName,
                                            ItemName = i.ItemName,
                                            Quantity = dvl.DisbursementVoucherListQuantity
                                        };

            // TRANSFER-OUT movements (from warehouse)
            var transferOutMovements = from t in context.TransferOperations
                                       join wFrom in context.Warehouses on t.FromWarehouseId equals wFrom.WarehouseId
                                       join i in context.Items on t.ItemId equals i.ItemId
                                       //where i.ItemId == itemId
                                       select new
                                       {
                                           TransactionType = "Transfer-Out",
                                           TransactionDate = t.TransferOperationDate,
                                           WarehouseName = wFrom.WarehouseName,
                                           ItemName = i.ItemName,
                                           Quantity = 1 // Adjust if you have a quantity field
                                       };

            // TRANSFER-IN movements (to warehouse)
            var transferInMovements = from t in context.TransferOperations
                                      join wTo in context.Warehouses on t.ToWarehouseId equals wTo.WarehouseId
                                      join i in context.Items on t.ItemId equals i.ItemId
                                      //where i.ItemId == itemId
                                      select new
                                      {
                                          TransactionType = "Transfer-In",
                                          TransactionDate = t.TransferOperationDate,
                                          WarehouseName = wTo.WarehouseName,
                                          ItemName = i.ItemName,
                                          Quantity = 1 // Adjust if you have a quantity field
                                      };

            // Combine all and order by TransactionDate
            var result = supplyMovements
                .Concat(disbursementMovements)
                .Concat(transferOutMovements)
                .Concat(transferInMovements)
                .OrderBy(x => x.TransactionDate)
                .ToList();

            AdvancedGridView.DataSource = result;
        }

        private void downloadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DisplayLbl.Text = "Enter the item movement name you want to download or * to download all";
            DisplayLbl.Visible = true;
            itemLblName.Text = "Item Name";
            itemLblName.Location = new Point(8, 157);
            itemLblName.Visible = true;
            itemNameTbx.Location = new Point(172, 149);
            itemNameTbx.Visible = true;
            DownlBtn.Visible = true;
            option = "Item Movement";
        }
        // Items Aging Filter Report
        private void expiredItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedGridView.Visible = true;

            var result = (from i in context.Items
                        join svl in context.SupplyVoucherLists on i.ItemId equals svl.ItemId
                        join sv in context.SupplyVouchers on svl.SupplyVoucherId equals sv.SupplyVoucherId
                        join s in context.Suppliers on sv.SupplierId equals s.SupplierId
                        //where svl.SupplyVoucherListDaysUntilExpiration < 0
                        select new
                        {
                            i.ItemId,
                            i.ItemName,
                            s.SupplierName,
                            svl.SupplyVoucherListQuantity,
                            sv.SupplyVoucherDate,
                        }).ToList();

            AdvancedGridView.DataSource = result;
            
        }

        private void downloadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DisplayLbl.Text = "Enter the item age you want to download";
            DisplayLbl.Visible = true;
            itemLblName.Text = "Item Days";
            itemLblName.Location = new Point(8, 157);
            itemLblName.Visible = true;
            itemNameTbx.Location = new Point(172, 149);
            itemNameTbx.Visible = true;
            DownlBtn.Visible = true;
            option = "Items Aging";
        }
        // Near Expired Items
        private void nearExpirationItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedGridView.Visible = true;

            var output = (from I in context.Items
                          join SVL in context.SupplyVoucherLists on I.ItemId equals SVL.ItemId
                          where SVL.SupplyVoucherListDaysUntilExpiration > 0
                          select new
                          {
                              SVL.ItemId,
                              I.ItemCode,
                              I.ItemName,
                              SVL.SupplyVoucherListQuantity,
                              SVL.SupplyVoucherListProductionDate,
                              SVL.SupplyVoucherListExpirationDate,
                              SVL.SupplyVoucherListDaysUntilExpiration
                          }).ToList();

            AdvancedGridView.DataSource = output;
        }

        private void downloadToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DisplayLbl.Text = "Enter the items near expiration or * for all to download";
            DisplayLbl.Visible = true;
            itemLblName.Text = "Expired Item Days";
            itemLblName.Location = new Point(8, 157);
            itemLblName.Visible = true;
            itemNameTbx.Location = new Point(172, 149);
            itemNameTbx.Visible = true;
            DownlBtn.Visible = true;
            option = "Items Near Expired";
        }
        // Download Button
        private void DownlBtn_Click(object sender, EventArgs e)
        {
            switch (option)
            {
                case "Warehouse":
                    string warehouseName = itemNameTbx.Text.Trim();

                    // Supply part
                    var supplyQuery1 = from sv in context.SupplyVouchers
                                       join w in context.Warehouses on sv.WarehouseId equals w.WarehouseId
                                       join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                                       join i in context.Items on svl.ItemId equals i.ItemId
                                       select new
                                       {
                                           TransactionType = "Supply",
                                           TransactionDate = sv.SupplyVoucherDate,
                                           w.WarehouseName,
                                           i.ItemName,
                                           Quantity = svl.SupplyVoucherListQuantity
                                       };

                    // Disbursement part
                    var disbursementQuery1 = from dv in context.DisbursementVouchers
                                             join w in context.Warehouses on dv.WarehouseId equals w.WarehouseId
                                             join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                                             join i in context.Items on dvl.ItemId equals i.ItemId
                                             select new
                                             {
                                                 TransactionType = "Disbursement",
                                                 TransactionDate = dv.DisbursementVoucherDate,
                                                 w.WarehouseName,
                                                 i.ItemName,
                                                 Quantity = dvl.DisbursementVoucherListQuantity
                                             };

                    // Apply filter if not *
                    if (warehouseName != "*")
                    {
                        supplyQuery1 = supplyQuery1.Where(x => x.WarehouseName.ToUpper() == warehouseName.ToUpper());
                        disbursementQuery1 = disbursementQuery1.Where(x => x.WarehouseName.ToUpper() == warehouseName.ToUpper());
                    }

                    var result1 = supplyQuery1.Concat(disbursementQuery1).ToList();

                    if (result1.Count == 0)
                    {
                        MessageBox.Show("No data found for the specified warehouse.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "CSV files (*.csv)|*.csv";
                        sfd.FileName = "WarehouseTransactions.csv";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var sb = new StringBuilder();

                                // Write headers
                                sb.AppendLine("WarehouseName,ItemName,TransactionType,TransactionDate,Quantity");

                                // Write data
                                foreach (var row in result1)
                                {
                                    sb.AppendLine($"{row.WarehouseName},{row.ItemName},{row.TransactionType},{row.TransactionDate:yyyy-MM-dd},{row.Quantity}");
                                }

                                System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                                MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Export failed: " + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                case "Item":
                    string itemName = itemNameTbx.Text.Trim();

                    // Build supply query
                    var supplyQuery2 = from svl in context.SupplyVoucherLists
                                      join sv in context.SupplyVouchers on svl.SupplyVoucherId equals sv.SupplyVoucherId
                                      join w in context.Warehouses on sv.WarehouseId equals w.WarehouseId
                                      join i in context.Items on svl.ItemId equals i.ItemId
                                      select new
                                      {
                                          i.ItemName,
                                          w.WarehouseName,
                                          TransactionType = "SUPPLY",
                                          TransactionDate = sv.SupplyVoucherDate,
                                          Quantity = svl.SupplyVoucherListQuantity
                                      };

                    // Build disbursement query
                    var disbursementQuery2 = from dvl in context.DisbursementVoucherLists
                                            join dv in context.DisbursementVouchers on dvl.DisbursementVoucherId equals dv.DisbursementVoucherId
                                            join w in context.Warehouses on dv.WarehouseId equals w.WarehouseId
                                            join i in context.Items on dvl.ItemId equals i.ItemId
                                            select new
                                            {
                                                i.ItemName,
                                                w.WarehouseName,
                                                TransactionType = "DISBURSEMENT",
                                                TransactionDate = dv.DisbursementVoucherDate,
                                                Quantity = dvl.DisbursementVoucherListQuantity
                                            };

                    // Apply filter if not *
                    if (itemName != "*")
                    {
                        supplyQuery2 = supplyQuery2.Where(x => x.ItemName.ToUpper() == itemName.ToUpper());
                        disbursementQuery2 = disbursementQuery2.Where(x => x.ItemName.ToUpper() == itemName.ToUpper());
                    }

                    var result2 = supplyQuery2.Concat(disbursementQuery2).ToList();

                    if (result2.Count == 0)
                    {
                        MessageBox.Show("No data found for the specified item.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "CSV files (*.csv)|*.csv";
                        sfd.FileName = ".csv";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var sb = new StringBuilder();

                                // Write headers
                                sb.AppendLine("ItemName,WarehouseName,TransactionType,TransactionDate,Quantity");

                                // Write data
                                foreach (var row in result2)
                                {
                                    sb.AppendLine($"{row.ItemName},{row.WarehouseName},{row.TransactionType},{row.TransactionDate},{row.Quantity}");
                                }

                                System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                                MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Export failed: " + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                case "Item Movement":
                    string itemName3 = itemNameTbx.Text.Trim();

                    // SUPPLY movements
                    var supplyMovements3 = from sv in context.SupplyVouchers
                                           join w in context.Warehouses on sv.WarehouseId equals w.WarehouseId
                                           join svl in context.SupplyVoucherLists on sv.SupplyVoucherId equals svl.SupplyVoucherId
                                           join i in context.Items on svl.ItemId equals i.ItemId
                                           select new
                                           {
                                               TransactionType = "Supply",
                                               TransactionDate = sv.SupplyVoucherDate,
                                               WarehouseName = w.WarehouseName,
                                               ItemName = i.ItemName,
                                               Quantity = svl.SupplyVoucherListQuantity
                                           };

                    // DISBURSEMENT movements
                    var disbursementMovements3 = from dv in context.DisbursementVouchers
                                                 join w in context.Warehouses on dv.WarehouseId equals w.WarehouseId
                                                 join dvl in context.DisbursementVoucherLists on dv.DisbursementVoucherId equals dvl.DisbursementVoucherId
                                                 join i in context.Items on dvl.ItemId equals i.ItemId
                                                 select new
                                                 {
                                                     TransactionType = "Disbursement",
                                                     TransactionDate = dv.DisbursementVoucherDate,
                                                     WarehouseName = w.WarehouseName,
                                                     ItemName = i.ItemName,
                                                     Quantity = dvl.DisbursementVoucherListQuantity
                                                 };

                    // TRANSFER-OUT movements (from warehouse)
                    var transferOutMovements3 = from t in context.TransferOperations
                                                join wFrom in context.Warehouses on t.FromWarehouseId equals wFrom.WarehouseId
                                                join i in context.Items on t.ItemId equals i.ItemId
                                                select new
                                                {
                                                    TransactionType = "Transfer-Out",
                                                    TransactionDate = t.TransferOperationDate,
                                                    WarehouseName = wFrom.WarehouseName,
                                                    ItemName = i.ItemName,
                                                    Quantity = 1 
                                                };

                    // TRANSFER-IN movements (to warehouse)
                    var transferInMovements3 = from t in context.TransferOperations
                                               join wTo in context.Warehouses on t.ToWarehouseId equals wTo.WarehouseId
                                               join i in context.Items on t.ItemId equals i.ItemId
                                               select new
                                               {
                                                   TransactionType = "Transfer-In",
                                                   TransactionDate = t.TransferOperationDate,
                                                   WarehouseName = wTo.WarehouseName,
                                                   ItemName = i.ItemName,
                                                   Quantity = 1
                                               };

                    // Apply filter if not *
                    if (itemName3 != "*")
                    {
                        supplyMovements3 = supplyMovements3.Where(x => x.ItemName.ToUpper() == itemName3.ToUpper());
                        disbursementMovements3 = disbursementMovements3.Where(x => x.ItemName.ToUpper() == itemName3.ToUpper());
                        transferOutMovements3 = transferOutMovements3.Where(x => x.ItemName.ToUpper() == itemName3.ToUpper());
                        transferInMovements3 = transferInMovements3.Where(x => x.ItemName.ToUpper() == itemName3.ToUpper());
                    }

                    // Combine all and order by TransactionDate
                    var result3 = supplyMovements3
                        .Concat(disbursementMovements3)
                        .Concat(transferOutMovements3)
                        .Concat(transferInMovements3)
                        .OrderBy(x => x.TransactionDate)
                        .ToList();

                    if (result3.Count == 0)
                    {
                        MessageBox.Show("No data found for the specified item.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "CSV files (*.csv)|*.csv";
                        sfd.FileName = "ItemMovements.csv";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var sb = new StringBuilder();

                                // Write headers
                                sb.AppendLine("WarehouseName,ItemName,TransactionType,TransactionDate,Quantity");

                                // Write data
                                foreach (var row in result3)
                                {
                                    sb.AppendLine($"{row.WarehouseName},{row.ItemName},{row.TransactionType},{row.TransactionDate:yyyy-MM-dd},{row.Quantity}");
                                }

                                System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                                MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Export failed: " + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                case "Items Aging":
                    // 1) Read input from itemNameTbx
                    string input = itemNameTbx.Text.Trim();
                    bool filterByDays = int.TryParse(input, out int daysAgo);

                    // 2) Compute targetDate if filtering by days
                    DateTime targetDate = DateTime.Today.AddDays(-daysAgo);

                    // 3) Build base query
                    var query4 = from i in context.Items
                                 join svl in context.SupplyVoucherLists
                                     on i.ItemId equals svl.ItemId
                                 join sv in context.SupplyVouchers
                                     on svl.SupplyVoucherId equals sv.SupplyVoucherId
                                 join s in context.Suppliers
                                     on sv.SupplierId equals s.SupplierId
                                 select new
                                 {
                                     i.ItemId,
                                     ItemName = i.ItemName,
                                     s.SupplierName,
                                     svl.SupplyVoucherListQuantity,
                                     svl.SupplyVoucherListProductionDate,
                                     svl.SupplyVoucherListExpirationDate,
                                     SupplyDate = sv.SupplyVoucherDate
                                 };

                    // 4) Apply filter only if user entered a valid integer (daysAgo)
                    if (filterByDays)
                    {
                        query4 = query4.Where(x => x.SupplyDate.Date == targetDate);
                    }
                    // else, if they typed "*" or any non-integer, skip filtering and return all rows

                    var result4 = query4.ToList();

                    if (result4.Count == 0)
                    {
                        MessageBox.Show(
                            "No data found for the specified days filter.",
                            "Export",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }

                    // 5) Prompt user to save CSV
                    using (var sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "CSV files (*.csv)|*.csv";
                        sfd.FileName = "ItemsAging.csv";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var sb = new StringBuilder();

                                // 6) Write CSV header
                                sb.AppendLine("ItemId,ItemName,SupplierName,Quantity,ProductionDate,ExpirationDate,SupplyDate");

                                // 7) Write each row
                                foreach (var row in result4)
                                {
                                    sb.AppendLine(
                                        $"{row.ItemId}," +
                                        $"{row.ItemName}," +
                                        $"{row.SupplierName}," +
                                        $"{row.SupplyVoucherListQuantity}," +
                                        $"{row.SupplyVoucherListProductionDate:yyyy-MM-dd}," +
                                        $"{row.SupplyVoucherListExpirationDate:yyyy-MM-dd}," +
                                        $"{row.SupplyDate:yyyy-MM-dd}"
                                    );
                                }

                                System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                                MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Export failed: " + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                case "Items Near Expired":
                    string nearExpiryInput = itemNameTbx.Text.Trim();
                    IQueryable<dynamic> outputQuery;

                    // Try to parse the input as an integer for exact match, otherwise "*" for all > 0
                    if (int.TryParse(nearExpiryInput, out int daysUntilExpiration))
                    {
                        outputQuery = from I in context.Items
                                      join SVL in context.SupplyVoucherLists on I.ItemId equals SVL.ItemId
                                      where SVL.SupplyVoucherListDaysUntilExpiration == daysUntilExpiration
                                      select new
                                      {
                                          SVL.ItemId,
                                          I.ItemCode,
                                          I.ItemName,
                                          SVL.SupplyVoucherListQuantity,
                                          SVL.SupplyVoucherListProductionDate,
                                          SVL.SupplyVoucherListExpirationDate,
                                          SVL.SupplyVoucherListDaysUntilExpiration
                                      };
                    }
                    else
                    {
                        outputQuery = from I in context.Items
                                      join SVL in context.SupplyVoucherLists on I.ItemId equals SVL.ItemId
                                      where SVL.SupplyVoucherListDaysUntilExpiration > 0
                                      select new
                                      {
                                          SVL.ItemId,
                                          I.ItemCode,
                                          I.ItemName,
                                          SVL.SupplyVoucherListQuantity,
                                          SVL.SupplyVoucherListProductionDate,
                                          SVL.SupplyVoucherListExpirationDate,
                                          SVL.SupplyVoucherListDaysUntilExpiration
                                      };
                    }

                    var output = outputQuery.ToList();

                    if (output.Count == 0)
                    {
                        MessageBox.Show("No data found for the specified filter.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "CSV files (*.csv)|*.csv";
                        sfd.FileName = "ItemsNearExpired.csv";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var sb = new StringBuilder();

                                // Write headers
                                sb.AppendLine("ItemId,ItemCode,ItemName,Quantity,ProductionDate,ExpirationDate,DaysUntilExpiration");

                                // Write data
                                foreach (var row in output)
                                {
                                    sb.AppendLine($"{row.ItemId},{row.ItemCode},{row.ItemName},{row.SupplyVoucherListQuantity},{row.SupplyVoucherListProductionDate:yyyy-MM-dd},{row.SupplyVoucherListExpirationDate:yyyy-MM-dd},{row.SupplyVoucherListDaysUntilExpiration}");
                                }

                                System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                                MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Export failed: " + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
            }
        }

        private int GenerateUniqueTransferNumber(char type)
        {
            switch (type)
            {
                case 'T':
                    var randT = new Random();
                    int numberT;
                    do
                    {
                        numberT = randT.Next(100000, 1000000); // 6-digit number
                    }
                    while (context.TransferOperations.Any(t => t.TransferOperationNumber == numberT));
                    return numberT;
                case 'S':
                    var randS = new Random();
                    int numberS;
                    do
                    {
                        numberS = randS.Next(100000, 1000000); // 6-digit number
                    }
                    while (context.SupplyVouchers.Any(S => S.SupplyVoucherNumber == numberS));
                    return numberS;
                case 'D':
                    var randD = new Random();
                    int numberD;
                    do
                    {
                        numberD = randD.Next(100000, 1000000); // 6-digit number
                    }
                    while (context.DisbursementVouchers.Any(D => D.DisbursementVoucherNumber == numberD));
                    return numberD;
            }
            return 0;
        }

        private void itemNameTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (itemNameTbx.Location == new Point(172, 212))
            {
                // Only allow digits and control keys (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Prevent more than 6 digits
                if (char.IsDigit(e.KeyChar) && itemNameTbx.Text.Length >= 6 && itemNameTbx.SelectionLength == 0)
                {
                    e.Handled = true;
                }
            }
        }

        private void RefreshComboBoxes()
        {
            // It's a good idea to clear the DataSource first to force a refresh
            ItemComboBox.DataSource = null;
            ItemComboBox.DataSource = context.Items.ToList();
            ItemComboBox.DisplayMember = "ItemName";
            ItemComboBox.ValueMember = "ItemId";

            SupplierComboBox.DataSource = null;
            SupplierComboBox.DataSource = context.Suppliers.ToList();
            SupplierComboBox.DisplayMember = "SupplierName";
            SupplierComboBox.ValueMember = "SupplierId";

            FromWarehouseComboBox.DataSource = null;
            FromWarehouseComboBox.DataSource = context.Warehouses.ToList();
            FromWarehouseComboBox.DisplayMember = "WarehouseName";
            FromWarehouseComboBox.ValueMember = "WarehouseId";

            ToWarehouseComboBox.DataSource = null;
            ToWarehouseComboBox.DataSource = context.Warehouses.ToList();
            ToWarehouseComboBox.DisplayMember = "WarehouseName";
            ToWarehouseComboBox.ValueMember = "WarehouseId";
        }

        private void ResetButtons()
        {
            DisplayLbl.Visible = false;
            supplierVoucherIDLbl.Visible = false;
            SupplierVoucherIdCbx.Visible = false;
            itemLblName.Visible = false;
            DownlBtn.Visible = false;
            itemNameTbx.Visible = false;
            transferDateTxtBox.Visible = false;
            TransferDateLbl.Visible = false;
            SupplierIdLbl.Visible = false;
            QuantityTxtBox.Visible = false;
            itemIdLbl.Visible = false;
            ItemComboBox.Visible = false;
            F_WarehouseIdLbl.Visible = false;
            FromWarehouseComboBox.Visible = false;
            T_WarehouseLbl.Visible = false;
            ToWarehouseComboBox.Visible = false;
            ProductionLbl.Visible = false;
            ProductionDate.Visible = false;
            ExpirationLbl.Visible = false;
            ExpirationDate.Visible = false;
            UpdateBtn.Visible = false;
            InsertBtn.Visible = false;
            SupplierComboBox.Visible = false;
        }


    }
}
