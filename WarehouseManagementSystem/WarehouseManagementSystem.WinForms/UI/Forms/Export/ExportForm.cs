using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    public partial class ExportForm : UserControl
    {
        private readonly ExportRepository _exportRepository;

        public ExportForm()
        {
            InitializeComponent();
            _exportRepository = new ExportRepository();
            SetupDataGridView();
            LoadExportOrders();
        }

        // ─── Setup giống hệt ImportForm ──────────────────────────

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

            // Background & border
            dgvExportOrders.BackgroundColor = Color.White;
            dgvExportOrders.BorderStyle = BorderStyle.None;
            dgvExportOrders.GridColor = Color.FromArgb(230, 230, 230);
            dgvExportOrders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExportOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Row & header height
            dgvExportOrders.RowTemplate.Height = 48;
            dgvExportOrders.ColumnHeadersHeight = 55;
            dgvExportOrders.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Header style
            dgvExportOrders.EnableHeadersVisualStyles = false;
            dgvExportOrders.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);
            dgvExportOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvExportOrders.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvExportOrders.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Cell style
            dgvExportOrders.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvExportOrders.DefaultCellStyle.Padding = new Padding(8);
            dgvExportOrders.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dgvExportOrders.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);
            dgvExportOrders.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Alternating row
            dgvExportOrders.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            // Fill & scroll
            dgvExportOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExportOrders.ScrollBars = ScrollBars.Vertical;
            dgvExportOrders.Dock = DockStyle.Fill;

            AddColumns();

            // Column widths
            dgvExportOrders.Columns["InvoiceId"].FillWeight = 90;
            dgvExportOrders.Columns["Destination"].FillWeight = 160;
            dgvExportOrders.Columns["Date"].FillWeight = 90;
            dgvExportOrders.Columns["Items"].FillWeight = 60;
            dgvExportOrders.Columns["Status"].FillWeight = 100;
            dgvExportOrders.Columns["CreatedBy"].FillWeight = 150;
            dgvExportOrders.Columns["Action"].FillWeight = 60;

            dgvExportOrders.CellFormatting += dgvExportOrders_CellFormatting;
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

            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Action";
            actionColumn.HeaderText = "Actions";
            actionColumn.Text = "👁";
            actionColumn.UseColumnTextForButtonValue = true;
            dgvExportOrders.Columns.Add(actionColumn);
        }

        // ─── Load data ────────────────────────────────────────────

        private void LoadExportOrders()
        {
            dgvExportOrders.Rows.Clear();

            List<ExportInvoice> exports = _exportRepository.GetAll();

            foreach (ExportInvoice invoice in exports)
            {
                int row = dgvExportOrders.Rows.Add(
                    invoice.ExportId,
                    "",                                          // Destination (chưa lưu)
                    invoice.ExportDate.ToString("yyyy-MM-dd"),
                    invoice.OrderDetails.Count,
                    "Completed",
                    invoice.EmployeeName,
                    "👁"
                );

                // Tô màu ô Status giống Import
                dgvExportOrders.Rows[row].Cells["Status"].Style.BackColor =
                    Color.FromArgb(220, 252, 231);
                dgvExportOrders.Rows[row].Cells["Status"].Style.ForeColor =
                    Color.SeaGreen;
                dgvExportOrders.Rows[row].Cells["Status"].Style.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        // ─── Cell click: nút 👁 ───────────────────────────────────

        private void dgvExportOrders_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvExportOrders.Columns[e.ColumnIndex].Name != "Action") return;

            string exportId =
                dgvExportOrders.Rows[e.RowIndex]
                .Cells["InvoiceId"].Value?.ToString() ?? "";

            ExportInvoice? invoice =
                _exportRepository.GetAll()
                .Find(x => x.ExportId == exportId);

            if (invoice != null)
            {
                ExportOrderDetails form = new ExportOrderDetails(invoice);
                form.ShowDialog();
            }
        }

        // ─── CellFormatting ───────────────────────────────────────

        private void dgvExportOrders_CellFormatting(
            object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Đã set màu trực tiếp trong LoadExportOrders, không cần làm gì thêm
        }

        // ─── Buttons ──────────────────────────────────────────────

        private void btnCreateExport_Click(object sender, EventArgs e)
        {
            CreateExportInvoice form = new CreateExportInvoice();
            form.ShowDialog();
            LoadExportOrders();
        }
    }
}
