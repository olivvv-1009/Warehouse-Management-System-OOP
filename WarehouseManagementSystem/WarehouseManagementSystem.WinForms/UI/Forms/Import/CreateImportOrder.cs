using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WarehouseManagementSystem.WinForms.Controllers;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class CreateImportOrder : Form
    {
        private readonly ImportController _importController;
        public event EventHandler ImportCreated;
        private InventoryForm inventoryForm;


        public CreateImportOrder()
        {
            InitializeComponent();
            _importController = new ImportController();
        }

        // ─── Load ─────────────────────────────────────────────────

        private void CreateImportOrder_Load(object sender, EventArgs e)
        {
            if (Session.CurrentProfile != null)
            {
                lbCreateby.Text =
                    Session.CurrentProfile.FullName;
            }

            flowProducts.AutoScroll = true;
            flowProducts.WrapContents = false;
            flowProducts.FlowDirection = FlowDirection.TopDown;
            flowProducts.HorizontalScroll.Enabled = true;
            flowProducts.HorizontalScroll.Visible = true;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;

            CreateHeader();
            LoadSuppliers();
            AddProductRowUI();
        }

        // ─── Header row ───────────────────────────────────────────

        private void CreateHeader()
        {
            Panel header = new Panel();
            header.Height = 55;
            header.Width = 1000;
            header.BackColor = Color.FromArgb(245, 245, 245);
            header.BorderStyle = BorderStyle.FixedSingle;

            Label lbProduct = new Label();
            lbProduct.Text = "Product";
            lbProduct.Location = new Point(20, 18);
            lbProduct.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Label lbQty = new Label();
            lbQty.Text = "Quantity";
            lbQty.Location = new Point(230, 18);
            lbQty.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Label lbPrice = new Label();
            lbPrice.Text = "Price";
            lbPrice.Location = new Point(360, 18);
            lbPrice.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Label lbLocation = new Label();
            lbLocation.Text = "Warehouse";
            lbLocation.Location = new Point(500, 18);
            lbLocation.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            header.Controls.Add(lbProduct);
            header.Controls.Add(lbQty);
            header.Controls.Add(lbPrice);
            header.Controls.Add(lbLocation);

            flowProducts.Controls.Add(header);
        }

        // ─── Load suppliers ───────────────────────────────────────

        private void LoadSuppliers()
        {
            List<Supplier> suppliers =
                _importController.GetAllSuppliers();

            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierId";
        }

        // ─── Load products vào ComboBox ───────────────────────────

        private void LoadProducts(ComboBox cbProduct)
        {
            List<ProductDisplayModel> products =
                _importController.GetAllProducts();

            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "ProductID";
            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ─── Thêm row sản phẩm ───────────────────────────────────

        private void AddProductRowUI()
        {
            Panel row = new Panel();
            row.Height = 70;
            row.Width = 1000;
            row.BackColor = Color.White;
            row.BorderStyle = BorderStyle.FixedSingle;

            ComboBox cbProduct = new ComboBox();
            cbProduct.Name = "cbProduct";
            cbProduct.Location = new Point(20, 18);
            cbProduct.Width = 160;
            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            NumericUpDown numQuantity = new NumericUpDown();
            numQuantity.Name = "numQuantity";
            numQuantity.Location = new Point(230, 18);
            numQuantity.Width = 80;
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 10000;

            TextBox txtPrice = new TextBox();
            txtPrice.Name = "txtPrice";
            txtPrice.Location = new Point(360, 18);
            txtPrice.Width = 100;

            Label lbZone = new Label();
            lbZone.Name = "lbZone";
            lbZone.Location = new Point(500, 18);
            lbZone.Size = new Size(50, 28);
            lbZone.BackColor = Color.FromArgb(220, 230, 255);
            lbZone.TextAlign = ContentAlignment.MiddleCenter;
            lbZone.Text = "";

            Label lbRack = new Label();
            lbRack.Name = "lbRack";
            lbRack.Location = new Point(560, 18);
            lbRack.Size = new Size(65, 28);
            lbRack.BackColor = Color.FromArgb(220, 255, 220);
            lbRack.TextAlign = ContentAlignment.MiddleCenter;
            lbRack.Text = "";

            Label lbShelf = new Label();
            lbShelf.Name = "lbShelf";
            lbShelf.Location = new Point(635, 18);
            lbShelf.Size = new Size(75, 28);
            lbShelf.BackColor = Color.FromArgb(245, 220, 255);
            lbShelf.TextAlign = ContentAlignment.MiddleCenter;
            lbShelf.Text = "";

            Label lbCapacity = new Label();
            lbCapacity.Name = "lbCapacity";
            lbCapacity.Location = new Point(730, 24);
            lbCapacity.AutoSize = true;
            lbCapacity.Text = "Capacity: -";

            Button btnRemove = new Button();
            btnRemove.Text = "x";
            btnRemove.Location = new Point(920, 16);
            btnRemove.Width = 40;
            btnRemove.Height = 30;

            LoadProducts(cbProduct);
            cbProduct.SelectedIndex = -1;

            cbProduct.SelectionChangeCommitted += ProductChanged;
            numQuantity.ValueChanged += QuantityChanged;
            btnRemove.Click += RemoveRow;

            row.Controls.Add(cbProduct);
            row.Controls.Add(numQuantity);
            row.Controls.Add(txtPrice);
            row.Controls.Add(lbZone);
            row.Controls.Add(lbRack);
            row.Controls.Add(lbShelf);
            row.Controls.Add(lbCapacity);
            row.Controls.Add(btnRemove);

            flowProducts.Controls.Add(row);
        }

        // ─── Event: product / quantity thay đổi ──────────────────

        private void ProductChanged(object? sender, EventArgs e)
        {
            if (sender is not ComboBox cbProduct) return;
            if (cbProduct.Parent is not Panel row) return;
            UpdateLocation(row);
        }

        private void QuantityChanged(object? sender, EventArgs e)
        {
            if (sender is not NumericUpDown numQuantity) return;
            if (numQuantity.Parent is not Panel row) return;
            UpdateLocation(row);
        }

        // ─── Cập nhật vị trí kho tự động ─────────────────────────

        private void UpdateLocation(Panel row)
        {
            ComboBox? cbProduct =
                row.Controls["cbProduct"] as ComboBox;
            NumericUpDown? numQuantity =
                row.Controls["numQuantity"] as NumericUpDown;
            Label? lbZone =
                row.Controls["lbZone"] as Label;
            Label? lbRack =
                row.Controls["lbRack"] as Label;
            Label? lbShelf =
                row.Controls["lbShelf"] as Label;
            Label? lbCapacity =
                row.Controls["lbCapacity"] as Label;

            if (cbProduct == null || numQuantity == null ||
                lbZone == null || lbRack == null ||
                lbShelf == null || lbCapacity == null) return;

            if (cbProduct.SelectedValue == null) return;

            string productId =
                cbProduct.SelectedValue.ToString() ?? "";

            if (string.IsNullOrEmpty(productId)) return;

            int quantity = (int)numQuantity.Value;

            foreach (Control control in flowProducts.Controls)
            {
                if (control is not Panel otherRow)
                    continue;

                if (otherRow == row)
                    continue;

                ComboBox? otherProduct =
                    otherRow.Controls["cbProduct"]
                    as ComboBox;

                Label? otherZone =
                    otherRow.Controls["lbZone"]
                    as Label;

                Label? otherRack =
                    otherRow.Controls["lbRack"]
                    as Label;

                if (
                    otherProduct == null ||
                    otherZone == null ||
                    otherRack == null
                )
                {
                    continue;
                }

                if (
                    otherProduct.SelectedValue == null
                )
                {
                    continue;
                }

                string otherProductId =
                    otherProduct.SelectedValue
                        .ToString() ?? "";
            }

            List<string> usedRacks =
    new List<string>();

            foreach (Control control in flowProducts.Controls)
            {
                if (control is not Panel otherRow)
                    continue;

                if (otherRow == row)
                    continue;

                ComboBox? otherProduct =
                    otherRow.Controls["cbProduct"]
                    as ComboBox;

                Label? otherZone =
                    otherRow.Controls["lbZone"]
                    as Label;

                Label? otherRack =
                    otherRow.Controls["lbRack"]
                    as Label;

                if (
                    otherProduct == null ||
                    otherZone == null ||
                    otherRack == null
                )
                {
                    continue;
                }

                if (
                    otherProduct.SelectedValue == null
                )
                {
                    continue;
                }

                string otherProductId =
                    otherProduct.SelectedValue
                        .ToString() ?? "";

                if (
                    otherProductId != productId &&
                    !string.IsNullOrWhiteSpace(
                        otherRack.Text
                    )
                )
                {
                    usedRacks.Add(
                        otherZone.Text +
                        "-" +
                        otherRack.Text
                    );
                }
            }

            WarehouseLocation? location =
    _importController.AutoAssignLocation(
        productId,
        quantity,
        usedRacks
    );

            if (location != null)
            {
                string rackKey =
                    location.Zone +
                    "-" +
                    location.Rack;
            }

            if (location == null)
            {
                lbZone.Text = "";
                lbRack.Text = "";
                lbShelf.Text = "";
                lbCapacity.Text = "No Space";
                return;
            }

            lbZone.Text = location.Zone;
            lbRack.Text = location.Rack;
            lbShelf.Text = location.Shelf;
            int available =
    location.Capacity -
    location.UsedCapacity;

            lbCapacity.Text =
                "Available: "
                + available
                + "/"
                + location.Capacity;
        }

        // ─── Xóa row ──────────────────────────────────────────────

        private void RemoveRow(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            if (btn.Parent is not Panel row) return;
            flowProducts.Controls.Remove(row);
        }

        // ─── Button: Add Product ──────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProductRowUI();
        }

        // ─── Button: Complete ─────────────────────────────────────

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate supplier
                if (cbSupplier.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Please select a supplier!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                List<OrderDetail> items = new List<OrderDetail>();

                foreach (Control control in flowProducts.Controls)
                {
                    if (control is not Panel row) continue;

                    // Bỏ qua header row (không có cbProduct)
                    if (row.Controls["cbProduct"] == null) continue;

                    ComboBox? cbProduct =
                        row.Controls["cbProduct"] as ComboBox;
                    NumericUpDown? numQuantity =
                        row.Controls["numQuantity"] as NumericUpDown;
                    TextBox? txtPrice =
                        row.Controls["txtPrice"] as TextBox;
                    Label? lbZone =
                        row.Controls["lbZone"] as Label;
                    Label? lbRack =
                        row.Controls["lbRack"] as Label;
                    Label? lbShelf =
                        row.Controls["lbShelf"] as Label;

                    if (cbProduct == null || numQuantity == null ||
                        txtPrice == null || lbZone == null ||
                        lbRack == null || lbShelf == null) continue;

                    if (cbProduct.SelectedValue == null)
                    {
                        MessageBox.Show(
                            "Please select a product for all rows!",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(
                            txtPrice.Text, out decimal price)
                        || price <= 0)
                    {
                        MessageBox.Show(
                            "Please enter a valid price (greater than 0)!",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    string productId =
                        cbProduct.SelectedValue.ToString() ?? "";

                    int qty = (int)numQuantity.Value;

                    OrderDetail item = new OrderDetail()
                    {
                        ProductId = productId,
                        Quantity = qty,
                        UnitPrice = price,
                        TotalPrice = price * qty,
                        Zone = lbZone.Text,
                        Rack = lbRack.Text,
                        Shelf = lbShelf.Text,
                        LocationCode =
                            lbZone.Text + "-"
                            + lbRack.Text + "-"
                            + lbShelf.Text
                    };

                    items.Add(item);
                }

                if (items.Count == 0)
                {
                    MessageBox.Show(
                        "Please add at least one product!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string supplierId =
                    cbSupplier.SelectedValue?.ToString() ?? "";

                string employeeName =
                    Session.CurrentProfile?.FullName ?? "";

                bool result = _importController.CreateImportOrder(
                    supplierId, employeeName, items);

                if (result)
                {
                    MessageBox.Show(
                        "Import order created successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    if (ImportCreated != null)
                    {
                        ImportCreated(this, EventArgs.Empty);
                    }

                    if (inventoryForm != null)
                    {
                        inventoryForm.ReloadData();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to create import order. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public CreateImportOrder(InventoryForm form)
        {
            InitializeComponent();

            _importController =
                new ImportController();

            inventoryForm = form;
        }

        // ─── Button: Cancel ───────────────────────────────────────

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel?",
                "Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
                this.Close();
        }
    }
}