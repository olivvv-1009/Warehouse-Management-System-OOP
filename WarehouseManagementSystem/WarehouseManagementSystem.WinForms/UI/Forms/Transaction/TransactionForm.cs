using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Transaction
{
    public partial class TransactionForm : UserControl
    {
        private readonly TransactionRepository _transactionRepo;
        private readonly ProductService _productService;

        // Dữ liệu gốc để filter
        private List<Models.Transaction> _allTransactions;

        public TransactionForm()
        {
            InitializeComponent();
            _transactionRepo = new TransactionRepository();
            _productService = new ProductService();
            _allTransactions = new List<Models.Transaction>();

            SetupDataGridView();
            SetupFilters();
            LoadData();
        }

        // Reload mỗi khi được hiển thị lại (sau khi tạo export/import mới)
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
                LoadData();
        }

        // ─── Setup DataGridView ───────────────────────────────────

        private void SetupDataGridView()
        {
            dgvTransactions.Columns.Clear();
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.ColumnHeadersVisible = true;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.AllowUserToResizeColumns = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.GridColor = Color.FromArgb(230, 230, 230);
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTransactions.RowTemplate.Height = 52;
            dgvTransactions.ColumnHeadersHeight = 50;
            dgvTransactions.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Header style
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 80, 80);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell style
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);

            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ScrollBars = ScrollBars.Vertical;
            dgvTransactions.Dock = DockStyle.Fill;

            // ── Columns ──
            var colId = new DataGridViewTextBoxColumn
            { Name = "ColId", HeaderText = "Transaction ID", FillWeight = 110 };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colId.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            colId.DefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            dgvTransactions.Columns.Add(colId);

            var colDate = new DataGridViewTextBoxColumn
            { Name = "ColDate", HeaderText = "Date", FillWeight = 90 };
            dgvTransactions.Columns.Add(colDate);

            // Type column — sẽ tô màu trong CellFormatting
            var colType = new DataGridViewTextBoxColumn
            { Name = "ColType", HeaderText = "Type", FillWeight = 80 };
            colType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.Columns.Add(colType);

            var colProduct = new DataGridViewTextBoxColumn
            { Name = "ColProduct", HeaderText = "Product", FillWeight = 200 };
            colProduct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTransactions.Columns.Add(colProduct);

            // Quantity — màu xanh/đỏ
            var colQty = new DataGridViewTextBoxColumn
            { Name = "ColQty", HeaderText = "Quantity", FillWeight = 80 };
            colQty.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.Columns.Add(colQty);

            var colEmployee = new DataGridViewTextBoxColumn
            { Name = "ColEmployee", HeaderText = "Employee", FillWeight = 130 };
            dgvTransactions.Columns.Add(colEmployee);

            var colOrderId = new DataGridViewTextBoxColumn
            { Name = "ColOrderId", HeaderText = "Order ID", FillWeight = 100 };
            colOrderId.DefaultCellStyle.ForeColor = Color.FromArgb(120, 120, 120);
            colOrderId.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            dgvTransactions.Columns.Add(colOrderId);

            dgvTransactions.CellFormatting += Dgv_CellFormatting;
        }

        // ─── Setup filters ────────────────────────────────────────

        private void SetupFilters()
        {
            cmbType.Items.Clear();
            cmbType.Items.AddRange(new object[] { "All Types", "IMPORT", "EXPORT" });
            cmbType.SelectedIndex = 0;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;

            // Product combo: load tất cả products
            cmbProduct.Items.Clear();
            cmbProduct.Items.Add("All Products");
            var products = _productService.GetAllProducts();
            foreach (var p in products)
                cmbProduct.Items.Add(p.Name);
            cmbProduct.SelectedIndex = 0;
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbType.SelectedIndexChanged += (s, e) => ApplyFilter();
            cmbProduct.SelectedIndexChanged += (s, e) => ApplyFilter();
            dtpStart.ValueChanged += (s, e) => ApplyFilter();
            dtpEnd.ValueChanged += (s, e) => ApplyFilter();
        }

        // ─── Load all data ────────────────────────────────────────

        private void LoadData()
        {
            _allTransactions = _transactionRepo.GetAll();
            // Sort mới nhất lên trên
            _allTransactions.Sort((a, b) => b.Date.CompareTo(a.Date));

            UpdateSummaryCards(_allTransactions);
            PopulateGrid(_allTransactions);
        }

        // ─── Apply filter ─────────────────────────────────────────

        private void ApplyFilter()
        {
            var filtered = new List<Models.Transaction>();

            string typeFilter = cmbType.SelectedItem?.ToString() ?? "All Types";
            string productFilter = cmbProduct.SelectedItem?.ToString() ?? "All Products";
            DateTime startDate = chkStart.Checked ? dtpStart.Value.Date : DateTime.MinValue;
            DateTime endDate = chkEnd.Checked ? dtpEnd.Value.Date : DateTime.MaxValue;

            foreach (var t in _allTransactions)
            {
                bool matchType = typeFilter == "All Types" || t.TransactionType == typeFilter;

                bool matchProduct = true;
                if (productFilter != "All Products")
                {
                    var product = _productService.GetProductById(t.ProductId);
                    matchProduct = product != null && product.Name == productFilter;
                }

                bool matchDate = t.Date.Date >= startDate && t.Date.Date <= endDate;

                if (matchType && matchProduct && matchDate)
                    filtered.Add(t);
            }

            UpdateSummaryCards(filtered);
            PopulateGrid(filtered);
        }

        // ─── Summary cards ────────────────────────────────────────

        private void UpdateSummaryCards(List<Models.Transaction> list)
        {
            int totalImport = 0, totalExport = 0;

            foreach (var t in list)
            {
                if (t.TransactionType == "IMPORT") totalImport += t.Quantity;
                else if (t.TransactionType == "EXPORT") totalExport += t.Quantity;
            }

            lblTotalTx.Text = list.Count.ToString();
            lblTotalImport.Text = totalImport.ToString();
            lblTotalExport.Text = totalExport.ToString();
        }

        // ─── Fill grid ────────────────────────────────────────────

        private void PopulateGrid(List<Models.Transaction> list)
        {
            dgvTransactions.Rows.Clear();

            foreach (var t in list)
            {
                string productName = t.ProductId;
                var product = _productService.GetProductById(t.ProductId);
                if (product != null) productName = product.Name;

                // Employee: lấy từ EmployeeName trong invoice nếu có
                string employee = GetEmployeeFromReference(t.ReferenceId, t.TransactionType);

                // Qty display: +x hoặc -x
                string qtyText = t.TransactionType == "EXPORT"
                    ? $"-{t.Quantity}"
                    : $"+{t.Quantity}";

                dgvTransactions.Rows.Add(
                    t.TransactionId,
                    t.Date.ToString("yyyy-MM-dd"),
                    t.TransactionType,
                    productName,
                    qtyText,
                    employee,
                    t.ReferenceId
                );
            }
        }

        // ─── Lookup employee name from invoice ───────────────────

        private string GetEmployeeFromReference(string refId, string type)
        {
            if (string.IsNullOrEmpty(refId)) return "";

            try
            {
                if (type == "IMPORT")
                {
                    var importRepo = new ImportRepository();
                    var invoices = importRepo.GetAll();
                    foreach (var inv in invoices)
                        if (inv.ImportId == refId)
                            return inv.EmployeeName;
                }
                else if (type == "EXPORT")
                {
                    var exportRepo = new ExportRepository();
                    var invoices = exportRepo.GetAll();
                    foreach (var inv in invoices)
                        if (inv.ExportId == refId)
                            return inv.EmployeeName;
                }
            }
            catch { }

            return "";
        }

        // ─── Cell formatting: màu Type + Quantity ────────────────

        private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvTransactions.Columns[e.ColumnIndex].Name;

            // Type badge
            if (col == "ColType" && e.Value != null && e.CellStyle != null)
            {
                string type = e.Value.ToString() ?? string.Empty;
                if (type == "IMPORT")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (type == "EXPORT")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }

            // Quantity màu
            if (col == "ColQty" && e.Value != null && e.CellStyle != null)
            {
                string qtyStr = e.Value.ToString() ?? string.Empty;
                e.CellStyle.ForeColor = qtyStr.StartsWith("-")
                    ? Color.FromArgb(185, 28, 28)
                    : Color.FromArgb(21, 128, 61);
            }
        }
    }
}
