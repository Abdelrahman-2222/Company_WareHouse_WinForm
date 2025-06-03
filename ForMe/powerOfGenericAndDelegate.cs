//private void SaveBtn_Click(object sender, EventArgs e)
//{
//    switch (option)
//    {
//        case "AddW":

//            context = new CompanyWarehouseContext();
//            var warehouse = new Warehouse
//            {
//                WarehouseName = textBox2.Text.Trim(),
//                WarehouseAddress = textBox3.Text.Trim(),
//                WarehousePersonName = textBox4.Text.Trim()
//            };
//            context.Warehouses.Add(warehouse);
//            try
//            {
//                context.SaveChanges();
//                MessageBox.Show("Warehouse added successfully!", "Success", MessageBoxButtons.OK,
//                    MessageBoxIcon.Information);

//                RefreshGrid(context, EntityType.Warehouse);

//                textBox1.Text = "";
//                textBox2.Text = "";
//                textBox3.Text = "";
//            }
//            catch (ValidationException vex)
//            {
//                MessageBox.Show(vex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//            }

//            break;
//        case "UpdateW":
//            context = new CompanyWarehouseContext();
//            int warehouseId = int.Parse(textBox1.Text.Trim());

//            warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseId == warehouseId);
//            if (warehouse != null)
//            {
//                warehouse.WarehouseName = textBox2.Text.Trim();
//                warehouse.WarehouseAddress = textBox3.Text.Trim();
//                warehouse.WarehousePersonName = textBox4.Text.Trim();
//                context.Warehouses.Update(warehouse);
//                try
//                {
//                    context.SaveChanges();
//                    MessageBox.Show("Warehouse updated successfully!", "Success", MessageBoxButtons.OK,
//                        MessageBoxIcon.Information);


//                    RefreshGrid(context, EntityType.Warehouse);

//                    textBox1.Text = "";
//                    textBox2.Text = "";
//                    textBox3.Text = "";
//                    textBox4.Text = "";
//                }
//                catch (ValidationException vex)
//                {
//                    MessageBox.Show(vex.Message, "Validation Error", MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("An error occurred while saving: " + ex.Message, "Error",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Warehouse not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            break;
//        case "DeleteW":
//            context = new CompanyWarehouseContext();
//            if (!int.TryParse(textBox1.Text.Trim(), out int deleteID))
//            {
//                MessageBox.Show("Please enter a valid id");
//                return;
//            }

//            var warhouseToDelete = context.Warehouses.FirstOrDefault(w => w.WarehouseId == deleteID);
//            if (warhouseToDelete != null)
//            {
//                var result =
//                    MessageBox.Show(
//                        $"Are you sure you want to delete this warehouse, where it's Name is {warhouseToDelete.WarehouseName} ?",
//                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//                if (result == DialogResult.Yes)
//                {
//                    context.Warehouses.Remove(warhouseToDelete);
//                }
//                else
//                {
//                    return;
//                }

//                try
//                {
//                    context.SaveChanges();
//                    MessageBox.Show("Warehouse deleted successfully!", "Success", MessageBoxButtons.OK,
//                        MessageBoxIcon.Information);

//                    RefreshGrid(context, EntityType.Warehouse);

//                    textBox1.Text = "";
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("An error occurred while deleting: " + ex.Message, "Error",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Warehouse not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            break;
//        case "AddI":
//            context = new CompanyWarehouseContext();
//            var item = new Item
//            {
//                ItemCode = int.Parse(textBox1.Text.Trim()),
//                ItemName = textBox2.Text.Trim()
//            };
//            context.Items.Add(item);
//            try
//            {
//                context.SaveChanges();
//                MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK,
//                    MessageBoxIcon.Information);

//                RefreshGrid(context, EntityType.Item);

//                textBox1.Text = textBox2.Text = "";
//                textBox1.PlaceholderText = textBox2.PlaceholderText = "";
//            }
//            catch (ValidationException vex)
//            {
//                MessageBox.Show(vex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//            }

//            break;
//        case "UpdateI":
//            context = new CompanyWarehouseContext();
//            int itemId = int.Parse(textBox1.Text.Trim());

//            item = context.Items.FirstOrDefault(i => i.ItemId == itemId);
//            if (item != null)
//            {
//                item.ItemCode = int.Parse(textBox2.Text.Trim());
//                item.ItemName = textBox3.Text.Trim();
//                context.Items.Update(item);
//                try
//                {
//                    context.SaveChanges();
//                    MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK,
//                        MessageBoxIcon.Information);


//                    RefreshGrid(context, EntityType.Item);

//                    textBox1.Text = textBox2.Text = textBox3.Text = "";
//                    textBox1.PlaceholderText = textBox2.PlaceholderText = textBox3.PlaceholderText = "";
//                }
//                catch (ValidationException vex)
//                {
//                    MessageBox.Show(vex.Message, "Validation Error", MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("An error occurred while saving: " + ex.Message, "Error",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Item not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            break;
//        case "DeleteI":
//            context = new CompanyWarehouseContext();
//            if (!int.TryParse(textBox1.Text.Trim(), out deleteID))
//            {
//                MessageBox.Show("Please enter a valid id");
//                return;
//            }

//            var itemToDelete = context.Items.FirstOrDefault(i => i.ItemId == deleteID);
//            if (itemToDelete != null)
//            {
//                var result =
//                    MessageBox.Show(
//                        $"Are you sure you want to delete this item, where it's Name is {itemToDelete.ItemName} ?",
//                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//                if (result == DialogResult.Yes)
//                {
//                    context.Items.Remove(itemToDelete);
//                }
//                else
//                {
//                    return;
//                }

//                try
//                {
//                    context.SaveChanges();
//                    MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK,
//                        MessageBoxIcon.Information);

//                    RefreshGrid(context, EntityType.Item);

//                    textBox1.Text = "";
//                    textBox1.PlaceholderText = "";
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("An error occurred while deleting: " + ex.Message, "Error",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Item not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            break;
//        default:
//            MessageBox.Show("No Choice is chosen");
//            break;
//    }
//}
