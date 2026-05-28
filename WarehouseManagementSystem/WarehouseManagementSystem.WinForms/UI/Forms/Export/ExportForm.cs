#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    public partial class ExportForm : UserControl
    {
        private readonly ExportRepository _exportRepository;
        private readonly ExportService _exportService;

        public ExportForm()
        {
            InitializeComponent();
            _exportRepository = new ExportRepository();
            _exportService = new ExportService();
            SetupDataGridView();
            LoadExportOrders();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible) LoadExportOrders();
        }

        // ─── Setup ───────────────────────────────────────────────

        private void SetupDataGridView()
        {
            dgvExportOrders.Columns.Clear();
            dgvExportOrders.AutoGenerateColumns = false;
            dgvExportOrders.RowHeadersVisible = false;
            dgvExportOrders.AllowUserToAddRows = false;
            dgvExportOrders.AllowUserToDeleteRows = false;
            dgvExportOrders.AllowUserToResizeRows = false;
            dgvExportOrders.AllowUserToResizeColumns = false;
            dgvExportOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExportOrders.MultiSelect = false;
            dgvExportOrders.ReadOnly = true;

            dgvExportOrders.BackgroundColor = Color.White;
            dgvExportOrders.BorderStyle = BorderStyle.None;
            dgvExportOrders.GridColor = Color.FromArgb(230, 230, 230);
            dgvExportOrders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExportOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgvExportOrders.RowTemplate.Height = 48;
            dgvExportOrders.ColumnHeadersHeight = 55;
            dgvExportOrders.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvExportOrders.EnableHeadersVisualStyles = false;
            dgvExportOrders.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);
            dgvExportOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvExportOrders.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvExportOrders.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvExportOrders.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvExportOrders.DefaultCellStyle.Padding = new Padding(8);
            dgvExportOrders.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dgvExportOrders.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);
            dgvExportOrders.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvExportOrders.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            dgvExportOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExportOrders.ScrollBars = ScrollBars.Vertical;
            dgvExportOrders.Dock = DockStyle.Fill;

            AddColumns();

            dgvExportOrders.Columns["InvoiceId"].FillWeight = 90;
            dgvExportOrders.Columns["Destination"].FillWeight = 160;
            dgvExportOrders.Columns["Date"].FillWeight = 90;
            dgvExportOrders.Columns["Items"].FillWeight = 60;
            dgvExportOrders.Columns["Status"].FillWeight = 100;
            dgvExportOrders.Columns["CreatedBy"].FillWeight = 150;
            dgvExportOrders.Columns["ActionView"].FillWeight = 45;
            dgvExportOrders.Columns["ActionComplete"].FillWeight = 45;

            dgvExportOrders.CellClick += dgvExportOrders_CellClick;
        }

        private void AddColumns()
        {
            dgvExportOrders.Columns.Add("InvoiceId", "Invoice ID");
            dgvExportOrders.Columns.Add("Destination", "Destination");
            dgvExportOrders.Columns.Add("Date", "Date");
            dgvExportOrders.Columns.Add("Items", "Items");
            dgvExportOrders.Columns.Add("Status", "Status");
            dgvExportOrders.Columns.Add("CreatedBy", "Created By");

            // Nút 👁 — xem chi tiết (luôn hiện)
            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "ActionView";
            btnView.HeaderText = "Actions";
            btnView.Text = "👁";
            btnView.UseColumnTextForButtonValue = true;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.DefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            btnView.DefaultCellStyle.BackColor = Color.White;
            btnView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExportOrders.Columns.Add(btnView);

            // Nút ✓ — complete draft (chỉ hiện khi Draft)
            var btnComplete = new DataGridViewButtonColumn();
            btnComplete.Name = "ActionComplete";
            btnComplete.HeaderText = "";
            btnComplete.Text = "✓";
            btnComplete.UseColumnTextForButtonValue = true;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61);
            btnComplete.DefaultCellStyle.BackColor = Color.White;
            btnComplete.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnComplete.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvExportOrders.Columns.Add(btnComplete);
        }

        // ─── Load data ────────────────────────────────────────────

        private void LoadExportOrders()
        {
            dgvExportOrders.Rows.Clear();

            List<ExportInvoice> exports = _exportRepository.GetAll();

            foreach (ExportInvoice invoice in exports)
            {
                string status = string.IsNullOrEmpty(invoice.Status)
                    ? "Completed" : invoice.Status;

                int rowIdx = dgvExportOrders.Rows.Add(
                    invoice.ExportId,
                    invoice.Destination,
                    invoice.ExportDate.ToString("yyyy-MM-dd"),
                    invoice.OrderDetails.Count,
                    status,
                    invoice.EmployeeName
                );

                var row = dgvExportOrders.Rows[rowIdx];

                // Màu Status
                if (status == "Draft")
                {
                    row.Cells["Status"].Style.BackColor = Color.FromArgb(254, 249, 195);
                    row.Cells["Status"].Style.ForeColor = Color.FromArgb(133, 77, 14);
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Hiện nút ✓
                    row.Cells["ActionComplete"].Value = "✓";
                    row.Cells["ActionComplete"].Style.ForeColor = Color.FromArgb(21, 128, 61);
                }
                else
                {
                    row.Cells["Status"].Style.BackColor = Color.FromArgb(220, 252, 231);
                    row.Cells["Status"].Style.ForeColor = Color.SeaGreen;
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Ẩn hẳn nút ✓ cho Completed
                    var cell = row.Cells["ActionComplete"];
                    cell.Value = "";
                    cell.ReadOnly = true;
                    cell.Style.ForeColor = Color.White;
                    cell.Style.BackColor = Color.White;
                    cell.Style.SelectionForeColor = Color.White;
                    cell.Style.SelectionBackColor = Color.White;
                }
            }
        }

        // ─── Cell click ──────────────────────────────────────────

        private void dgvExportOrders_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvExportOrders.Columns[e.ColumnIndex].Name;
            string exportId = dgvExportOrders.Rows[e.RowIndex]
                .Cells["InvoiceId"].Value?.ToString() ?? "";

            if (colName == "ActionView")
            {
                ExportInvoice? invoice = _exportRepository.GetAll()
                    .Find(x => x.ExportId == exportId);
                if (invoice != null)
                {
                    ExportOrderDetails form = new ExportOrderDetails(invoice);
                    form.ShowDialog();
                }
            }
            else if (colName == "ActionComplete")
            {
                string status = dgvExportOrders.Rows[e.RowIndex]
                    .Cells["Status"].Value?.ToString() ?? "";
                if (status != "Draft") return;

                var confirm = MessageBox.Show(
                    $"Complete invoice {exportId}? Stock will be deducted.",
                    "Confirm Complete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                bool ok = _exportService.CompleteDraft(exportId);
                if (ok)
                {
                    MessageBox.Show("Invoice completed successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadExportOrders();
                }
                else
                {
                    MessageBox.Show("Failed to complete. Please check stock availability.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ─── Create button ────────────────────────────────────────

        private void btnCreateExport_Click(object sender, EventArgs e)
        {
            CreateExportInvoice form = new CreateExportInvoice();
            form.ShowDialog();
            LoadExportOrders();
        }
    }
}
