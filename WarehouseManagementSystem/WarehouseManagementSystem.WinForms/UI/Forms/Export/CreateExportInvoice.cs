using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    public partial class CreateExportInvoice : Form
    {
        private readonly ExportService _exportService;
        private readonly ProductService _productService;
        private readonly BatchRepository _batchRepository;
        private readonly FifoRule _fifoRule;

        private readonly List<Panel> _productRows;
        private Panel? _rowContainer;

        public CreateExportInvoice()
        {
            InitializeComponent();

            _exportService = new ExportService();
            _productService = new ProductService();
            _batchRepository = new BatchRepository();
            _fifoRule = new FifoRule();
            _productRows = new List<Panel>();
            _rowContainer = null;

            SetupGrid();
            SetupEvents();

            lblEmployeeValue.Text =
                Session.CurrentProfile?.FullName ?? "";

            dtpDate.Value = DateTime.Now;
        }

        // ─── Setup ───────────────────────────────────────────────

        private void SetupGrid()
        {
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersHeight = 45;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(80, 80, 80);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProducts.RowTemplate.Height = 40;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
        }

        private void SetupEvents()
        {
            btnAddProduct.Click += (object? s, EventArgs e) => AddProductRow();
            btnComplete.Click += (object? s, EventArgs e) => btnComplete_Click();
            btnSaveDraft.Click += (object? s, EventArgs e) => btnSaveDraft_Click();
            btnCancel.Click += (object? s, EventArgs e) => btnCancel_Click();
        }

        // ─── Load products vào ComboBox ───────────────────────────

        private void LoadProducts(ComboBox cb)
        {
            List<ProductDisplayModel> products =
                _productService.GetAllProducts();

            cb.DataSource = products;
            cb.DisplayMember = "Name";
            cb.ValueMember = "ProductID";
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndex = -1;
        }

        // ─── Row container ────────────────────────────────────────

        private void EnsureRowContainer()
        {
            if (_rowContainer != null) return;

            _rowContainer = new Panel();
            _rowContainer.AutoSize = true;
            _rowContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _rowContainer.Location = new Point(
                dgvProducts.Left,
                dgvProducts.Bottom + 5);
            _rowContainer.Width = dgvProducts.Width;
            _rowContainer.BackColor = Color.White;

            panelMain.Controls.Add(_rowContainer);
            dgvProducts.Visible = false;
        }

        // ─── Thêm row sản phẩm ───────────────────────────────────

        private void AddProductRow()
        {
            Panel row = new Panel();
            row.Height = 50;
            row.BackColor = Color.White;
            row.BorderStyle = BorderStyle.FixedSingle;

            ComboBox cbProduct = new ComboBox();
            cbProduct.Name = "cbProduct";
            cbProduct.Location = new Point(5, 10);
            cbProduct.Width = 200;
            LoadProducts(cbProduct);

            Label lblAvailable = new Label();
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Location = new Point(215, 14);
            lblAvailable.Size = new Size(90, 25);
            lblAvailable.Text = "-";
            lblAvailable.TextAlign = ContentAlignment.MiddleCenter;
            lblAvailable.BackColor = Color.FromArgb(230, 245, 255);

            NumericUpDown numQty = new NumericUpDown();
            numQty.Name = "numQty";
            numQty.Location = new Point(315, 12);
            numQty.Width = 80;
            numQty.Minimum = 1;
            numQty.Maximum = 99999;
            numQty.Value = 1;

            Label lblFifo = new Label();
            lblFifo.Name = "lblFifo";
            lblFifo.Location = new Point(405, 14);
            lblFifo.Size = new Size(170, 25);
            lblFifo.Text = "-";
            lblFifo.TextAlign = ContentAlignment.MiddleLeft;
            lblFifo.ForeColor = Color.RoyalBlue;

            Button btnRemove = new Button();
            btnRemove.Text = "x";
            btnRemove.Location = new Point(585, 12);
            btnRemove.Size = new Size(30, 26);
            btnRemove.ForeColor = Color.Red;

            cbProduct.SelectionChangeCommitted +=
                (object? s, EventArgs e) => UpdateRowInfo(row);
            numQty.ValueChanged +=
                (object? s, EventArgs e) => UpdateRowInfo(row);
            btnRemove.Click +=
                (object? s, EventArgs e) => RemoveProductRow(row);

            row.Controls.Add(cbProduct);
            row.Controls.Add(lblAvailable);
            row.Controls.Add(numQty);
            row.Controls.Add(lblFifo);
            row.Controls.Add(btnRemove);

            EnsureRowContainer();

            int yOffset = _productRows.Count * 55;
            row.Location = new Point(0, yOffset);
            row.Width = _rowContainer!.Width;

            _rowContainer.Controls.Add(row);
            _productRows.Add(row);
        }

        private void RemoveProductRow(Panel row)
        {
            _productRows.Remove(row);
            _rowContainer?.Controls.Remove(row);

            for (int i = 0; i < _productRows.Count; i++)
            {
                _productRows[i].Location = new Point(0, i * 55);
            }

            RefreshFifoPreview();
        }

        // ─── Cập nhật Available & FIFO preview ───────────────────

        private void UpdateRowInfo(Panel row)
        {
            ComboBox? cbProduct =
                row.Controls["cbProduct"] as ComboBox;
            Label? lblAvailable =
                row.Controls["lblAvailable"] as Label;
            Label? lblFifo =
                row.Controls["lblFifo"] as Label;
            NumericUpDown? numQty =
                row.Controls["numQty"] as NumericUpDown;

            if (cbProduct == null || lblAvailable == null ||
                lblFifo == null || numQty == null) return;

            if (cbProduct.SelectedValue == null) return;

            string productId =
                cbProduct.SelectedValue.ToString() ?? "";

            if (string.IsNullOrEmpty(productId)) return;

            List<Batch> batches =
                _batchRepository.GetByProductId(productId);

            int available =
                _fifoRule.GetAvailableQuantity(batches);

            lblAvailable.Text = available.ToString();
            lblAvailable.ForeColor =
                available > 0 ? Color.DarkGreen : Color.Red;

            numQty.Maximum = available > 0 ? available : 1;

            int qty = (int)numQty.Value;

            bool canExport = _fifoRule.Apply(
                batches, qty, out var deductions);

            if (canExport && deductions != null)
            {
                lblFifo.Text = $"{deductions.Count} batch(es)";
                lblFifo.ForeColor = Color.SeaGreen;
            }
            else
            {
                lblFifo.Text = "Not enough stock";
                lblFifo.ForeColor = Color.Red;
            }
        }

        private void RefreshFifoPreview()
        {
            foreach (Panel row in _productRows)
                UpdateRowInfo(row);
        }

        // ─── Thu thập dữ liệu ────────────────────────────────────

        private bool CollectExportItems(
            out List<(string ProductId, int Quantity, decimal UnitPrice)> items)
        {
            items = new List<(string, int, decimal)>();

            if (_productRows.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one product.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                MessageBox.Show(
                    "Please enter a destination.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            foreach (Panel row in _productRows)
            {
                ComboBox? cbProduct =
                    row.Controls["cbProduct"] as ComboBox;
                NumericUpDown? numQty =
                    row.Controls["numQty"] as NumericUpDown;

                if (cbProduct == null || numQty == null) continue;

                if (cbProduct.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Please select a product for all rows.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                string productId =
                    cbProduct.SelectedValue.ToString() ?? "";
                int qty = (int)numQty.Value;

                List<Batch> batches =
                    _batchRepository.GetByProductId(productId);

                bool ok = _fifoRule.Apply(batches, qty, out _);

                if (!ok)
                {
                    MessageBox.Show(
                        $"Not enough stock for \"{cbProduct.Text}\".",
                        "Insufficient Stock",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                items.Add((productId, qty, 0m));
            }

            return true;
        }

        // ─── Button handlers ──────────────────────────────────────

        private void btnComplete_Click()
        {
            if (!CollectExportItems(out var items)) return;

            string employeeName =
                Session.CurrentProfile?.FullName ?? "";

            string destination = txtDestination.Text.Trim();

            bool allSuccess = true;

            foreach (var item in items)
            {
                bool success = _exportService.ExportProduct(
                    item.ProductId,
                    item.Quantity,
                    employeeName,
                    item.UnitPrice,
                    destination);

                if (!success) { allSuccess = false; break; }
            }

            if (allSuccess)
            {
                MessageBox.Show(
                    "Export invoice created successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Failed to create export invoice. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSaveDraft_Click()
        {
            if (string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                MessageBox.Show(
                    "Please enter a destination before saving draft.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Draft saved. Note: stock has NOT been deducted yet.",
                "Draft Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCancel_Click()
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel? All changes will be lost.",
                "Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
                this.Close();
        }

        // ─── Stubs từ Designer ────────────────────────────────────

        private void label3_Click(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}

