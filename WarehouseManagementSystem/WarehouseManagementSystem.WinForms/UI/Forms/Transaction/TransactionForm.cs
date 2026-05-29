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
        private readonly ReturnRepository _returnRepo;

        private List<Models.Transaction> _allTransactions;

        public TransactionForm()
        {
            InitializeComponent();

            _transactionRepo = new TransactionRepository();
            _productService = new ProductService();
            _returnRepo = new ReturnRepository();
            _allTransactions = new List<Models.Transaction>();

            // Setup UI trước
            SetupDataGridView();
            SetupFilters();

            // Events
            panelTitle.Resize += PanelTitle_Resize;
            chkStart.CheckedChanged += ChkStart_CheckedChanged;
            chkEnd.CheckedChanged += ChkEnd_CheckedChanged;
            panelCards.Resize += PanelCards_Resize;
            panelCards.VisibleChanged += PanelCards_VisibleChanged;

            // Build cards
            BuildCard(
                cardTotalTx,
                lblTotalTxLabel,
                "TOTAL TRANSACTIONS",
                lblTotalTx,
                "0",
                Color.FromArgb(100, 116, 139));

            BuildCard(
                cardImport,
                lblImportLabel,
                "TOTAL IMPORTED",
                lblTotalImport,
                "0",
                Color.FromArgb(21, 128, 61));

            BuildCard(
                cardExport,
                lblExportLabel,
                "TOTAL EXPORTED",
                lblTotalExport,
                "0",
                Color.FromArgb(185, 28, 28));

            LayoutCards();

            // Load data cuối cùng
            LoadData();
        }

        private void PanelTitle_Resize(object sender, EventArgs e)
        {
            lblAutoGen.Location = new Point(panelTitle.Width - 340, 8);
        }

        private void ChkStart_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = chkStart.Checked;
            ApplyFilter();
        }

        private void ChkEnd_CheckedChanged(object sender, EventArgs e)
        {
            dtpEnd.Enabled = chkEnd.Checked;
            ApplyFilter();
        }

        private void PanelCards_Resize(object sender, EventArgs e)
        {
            LayoutCards();
        }

        private void PanelCards_VisibleChanged(object sender, EventArgs e)
        {
            LayoutCards();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
                LoadData();
        }

        private void BuildCard(
    Panel card,
    Label lblLabel,
    string labelText,
    Label lblValue,
    string defaultVal,
    Color valueColor)
        {
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            lblLabel.Text = labelText;
            lblLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblLabel.ForeColor = Color.FromArgb(120, 120, 120);
            lblLabel.AutoSize = false;
            lblLabel.Location = new Point(16, 14);
            lblLabel.Size = new Size(card.Width - 32, 20);
            lblLabel.TextAlign = ContentAlignment.MiddleLeft;

            lblValue.Text = defaultVal;
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue.ForeColor = valueColor;
            lblValue.AutoSize = false;
            lblValue.Location = new Point(16, 38);
            lblValue.Size = new Size(card.Width - 32, 44);
            lblValue.TextAlign = ContentAlignment.MiddleLeft;

            card.Controls.Add(lblLabel);
            card.Controls.Add(lblValue);
        }

        private void LayoutCards()
        {
            int w = panelCards.ClientSize.Width;
            int h = panelCards.ClientSize.Height;
            int gap = 12;
            int cardW = (w - gap * 2) / 3;

            if (cardW < 80) return;

            cardTotalTx.SetBounds(0, 0, cardW, h);
            cardImport.SetBounds(cardW + gap, 0, cardW, h);
            cardExport.SetBounds((cardW + gap) * 2, 0, cardW, h);

            foreach (var card in new[] { cardTotalTx, cardImport, cardExport })
            {
                foreach (Control c in card.Controls)
                {
                    c.Width = cardW - 32;
                }
            }
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

            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 80, 80);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);

            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ScrollBars = ScrollBars.Vertical;
            dgvTransactions.Dock = DockStyle.Fill;

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "ColId";
            colId.HeaderText = "Transaction ID";
            colId.FillWeight = 110;
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colId.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            colId.DefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            dgvTransactions.Columns.Add(colId);

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "ColDate";
            colDate.HeaderText = "Date";
            colDate.FillWeight = 90;
            dgvTransactions.Columns.Add(colDate);

            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn();
            colType.Name = "ColType";
            colType.HeaderText = "Type";
            colType.FillWeight = 80;
            colType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.Columns.Add(colType);

            DataGridViewTextBoxColumn colProduct = new DataGridViewTextBoxColumn();
            colProduct.Name = "ColProduct";
            colProduct.HeaderText = "Product";
            colProduct.FillWeight = 200;
            colProduct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTransactions.Columns.Add(colProduct);

            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.Name = "ColQty";
            colQty.HeaderText = "Quantity";
            colQty.FillWeight = 80;
            colQty.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.Columns.Add(colQty);

            DataGridViewTextBoxColumn colEmployee = new DataGridViewTextBoxColumn();
            colEmployee.Name = "ColEmployee";
            colEmployee.HeaderText = "Employee";
            colEmployee.FillWeight = 130;
            dgvTransactions.Columns.Add(colEmployee);

            DataGridViewTextBoxColumn colOrderId = new DataGridViewTextBoxColumn();
            colOrderId.Name = "ColOrderId";
            colOrderId.HeaderText = "Order ID";
            colOrderId.FillWeight = 100;
            colOrderId.DefaultCellStyle.ForeColor = Color.FromArgb(120, 120, 120);
            colOrderId.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            dgvTransactions.Columns.Add(colOrderId);

            dgvTransactions.CellFormatting += Dgv_CellFormatting;
        }

        // ─── Setup filters ────────────────────────────────────────

        private void SetupFilters()
        {
            cmbType.Items.Clear();
            cmbType.Items.AddRange(new object[] { "All Types", "IMPORT", "EXPORT", "RETURN" });
            cmbType.SelectedIndex = 0;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProduct.Items.Clear();
            cmbProduct.Items.Add("All Products");
            List<ProductDisplayModel> products = _productService.GetAllProducts();
            foreach (ProductDisplayModel p in products)
                cmbProduct.Items.Add(p.Name);
            cmbProduct.SelectedIndex = 0;
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbType.SelectedIndexChanged += CmbType_SelectedIndexChanged;
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
            dtpStart.ValueChanged += DtpStart_ValueChanged;
            dtpEnd.ValueChanged += DtpEnd_ValueChanged;
        }

        // ─── Event handlers thay thế lambda ──────────────────────

        private void CmbType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void CmbProduct_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void DtpStart_ValueChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void DtpEnd_ValueChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        // ─── Load all data ────────────────────────────────────────

        private void LoadData()
        {
            _allTransactions = _transactionRepo.GetAll();
            _allTransactions.Sort(CompareByDateDescending);

            UpdateSummaryCards(_allTransactions);
            PopulateGrid(_allTransactions);
        }

        // ─── Comparer thay thế lambda sort ───────────────────────

        private int CompareByDateDescending(Models.Transaction a, Models.Transaction b)
        {
            return b.Date.CompareTo(a.Date);
        }

        // ─── Apply filter ─────────────────────────────────────────

        private void ApplyFilter()
        {
            List<Models.Transaction> filtered = new List<Models.Transaction>();

            string typeFilter = "All Types";
            if (cmbType.SelectedItem != null)
                typeFilter = cmbType.SelectedItem.ToString() ?? "All Types";

            string productFilter = "All Products";
            if (cmbProduct.SelectedItem != null)
                productFilter = cmbProduct.SelectedItem.ToString() ?? "All Products";

            DateTime startDate = chkStart.Checked ? dtpStart.Value.Date : DateTime.MinValue;
            DateTime endDate = chkEnd.Checked ? dtpEnd.Value.Date : DateTime.MaxValue;

            foreach (Models.Transaction t in _allTransactions)
            {
                bool matchType = typeFilter == "All Types" || t.TransactionType == typeFilter;

                bool matchProduct = true;
                if (productFilter != "All Products")
                {
                    Product product = _productService.GetProductById(t.ProductId);
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
            int totalImport = 0;
            int totalExport = 0;

            foreach (Models.Transaction t in list)
            {
                if (t.TransactionType == "IMPORT")
                    totalImport += t.Quantity;
                else if (t.TransactionType == "EXPORT")
                    totalExport += t.Quantity;
            }

            lblTotalTx.Text = list.Count.ToString();
            lblTotalImport.Text = totalImport.ToString();
            lblTotalExport.Text = totalExport.ToString();
        }

        // ─── Fill grid ────────────────────────────────────────────

        private void PopulateGrid(List<Models.Transaction> list)
        {
            dgvTransactions.Rows.Clear();

            foreach (Models.Transaction t in list)
            {
                string productName = t.ProductId;
                Product product = _productService.GetProductById(t.ProductId);
                if (product != null)
                    productName = product.Name;

                string employee = GetEmployeeFromReference(t.ReferenceId, t.TransactionType);

                string qtyText;
                if (t.TransactionType == "EXPORT" || t.TransactionType == "RETURN")
                    qtyText = "-" + t.Quantity.ToString();
                else
                    qtyText = "+" + t.Quantity.ToString();

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
            if (string.IsNullOrEmpty(refId))
                return "";

            try
            {
                if (type == "IMPORT")
                {
                    ImportRepository importRepo = new ImportRepository();
                    List<ImportInvoice> invoices = importRepo.GetAll();
                    foreach (ImportInvoice inv in invoices)
                    {
                        if (inv.InvoiceId == refId)
                            return inv.EmployeeName;
                    }
                }
                else if (type == "EXPORT")
                {
                    ExportRepository exportRepo = new ExportRepository();
                    List<ExportInvoice> invoices = exportRepo.GetAll();
                    foreach (ExportInvoice inv in invoices)
                    {
                        if (inv.InvoiceId == refId)
                            return inv.EmployeeName;
                    }
                }
                else if (type == "RETURN")
                {
                    List<ReturnOrder> returns = _returnRepo.GetAll();
                    foreach (ReturnOrder r in returns)
                    {
                        if (r.InvoiceId == refId)
                        {
                            if (string.IsNullOrEmpty(r.EmployeeId))
                                return "";

                            ProfileRepository profileRepo = new ProfileRepository();
                            List<Profile> profiles = profileRepo.GetAll();

                            foreach (Profile p in profiles)
                            {
                                if (p.EmployeeId == r.EmployeeId)
                                    return p.FullName;
                            }

                            foreach (Profile p in profiles)
                            {
                                if (p.AccountId == r.EmployeeId)
                                    return p.FullName;
                            }

                            return r.EmployeeId;
                        }
                    }
                }
            }
            catch { }

            return "";
        }

        // ─── Cell formatting: màu Type + Quantity ────────────────

        private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string col = dgvTransactions.Columns[e.ColumnIndex].Name;

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
                else if (type == "RETURN")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 237, 213);
                    e.CellStyle.ForeColor = Color.FromArgb(154, 52, 18);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }

            if (col == "ColQty" && e.Value != null && e.CellStyle != null)
            {
                string qtyStr = e.Value.ToString() ?? string.Empty;
                if (qtyStr.StartsWith("-"))
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                else
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
            }
        }
    }
}