using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.Forms.inventory
{
    public partial class InventoryCardControl
        : UserControl
    {
        private bool _isExpanded = false;

        public InventoryCardControl()
        {
            InitializeComponent();

            SetupUI();

            panelHeader.Click +=
                Header_Click;

            foreach (Control control
                in tableLayoutPanel1.Controls)
            {
                control.Click +=
                    Header_Click;
            }
        }

        // =====================================
        // Setup UI
        // =====================================

        private void SetupUI()
        {
            // =========================
            // Card
            // =========================

            this.BackColor =
                Color.White;

            this.Margin =
                new Padding(0, 0, 0, 15);

            this.Padding =
                new Padding(0);

            this.Height =
                70;

            this.BorderStyle =
                BorderStyle.FixedSingle;

            // =========================
            // Header
            // =========================

            panelHeader.Height =
                70;

            panelHeader.BackColor =
                Color.White;

            panelHeader.Cursor =
                Cursors.Hand;

            // =========================
            // Batch Panel
            // =========================

            panelBatch.Visible =
                false;

            panelBatch.Height =
                180;

            panelBatch.Padding =
                new Padding(10);

            panelBatch.BackColor =
                Color.WhiteSmoke;

            // =========================
            // DataGridView
            // =========================

            dgvBatch.Dock =
                DockStyle.Fill;

            dgvBatch.BorderStyle =
                BorderStyle.None;

            dgvBatch.BackgroundColor =
                Color.White;

            dgvBatch.RowHeadersVisible =
                false;

            dgvBatch.AllowUserToAddRows =
                false;

            dgvBatch.AllowUserToDeleteRows =
                false;

            dgvBatch.AllowUserToResizeRows =
                false;

            dgvBatch.ReadOnly =
                true;

            dgvBatch.MultiSelect =
                false;

            dgvBatch.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBatch.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBatch.RowTemplate.Height =
                36;

            dgvBatch.EnableHeadersVisualStyles =
                false;

            dgvBatch.GridColor =
                Color.Gainsboro;

            // Header Style

            dgvBatch.ColumnHeadersHeight =
                40;

            dgvBatch.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvBatch.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(33, 150, 243);

            dgvBatch.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvBatch.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            // Row Style

            dgvBatch.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvBatch.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 240, 255);

            dgvBatch.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvBatch.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 248, 248);

            SetupBatchColumns();
        }

        // =====================================
        // Setup Batch Columns
        // =====================================

        private void SetupBatchColumns()
        {
            dgvBatch.Columns.Clear();

            dgvBatch.Columns.Add(
                "colBatchId",
                "Product ID");

            dgvBatch.Columns.Add(
                "colProductName",
                "Product Name");

            dgvBatch.Columns.Add(
                "colQuantity",
                "Quantity");

            dgvBatch.Columns.Add(
                "colImportDate",
                "Import Date");

            dgvBatch.Columns.Add(
                "colImportPrice",
                "Import Price");

            dgvBatch.Columns.Add(
                "colZone",
                "Zone");

            dgvBatch.Columns.Add(
                "colRack",
                "Rack");

            dgvBatch.Columns.Add(
                "colShelf",
                "Shelf");

            dgvBatch.Columns.Add(
                "colStatus",
                "Status");

            dgvBatch.Columns.Add(
                "colAction",
                "Action");
        }

        // =====================================
        // Set Main Data
        // =====================================

        public void SetData(
            InventoryItem item)
        {
            lblProductId.Text =
                item.ProductId;

            lblProductName.Text =
                item.ProductName;

            lblQuantity.Text =
                item.Quantity.ToString();

            lblMinStock.Text =
                item.ImportDate
                    .ToString("yyyy-MM-dd");

            lblStatus.Text =
                item.StockStatus;

            // Status Color

            if (item.StockStatus == "In Stock")
            {
                lblStatus.BackColor =
                    Color.FromArgb(76, 175, 80);

                lblStatus.ForeColor =
                    Color.White;
            }
            else if (item.StockStatus == "Low Stock")
            {
                lblStatus.BackColor =
                    Color.FromArgb(255, 193, 7);

                lblStatus.ForeColor =
                    Color.Black;
            }
            else
            {
                lblStatus.BackColor =
                    Color.FromArgb(244, 67, 54);

                lblStatus.ForeColor =
                    Color.White;
            }
        }

        // =====================================
        // Load Batch Data
        // =====================================

        public void LoadBatchData(
            List<InventoryItem> batches)
        {
            dgvBatch.Rows.Clear();

            foreach (InventoryItem item
                in batches)
            {
                dgvBatch.Rows.Add(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.ImportDate
                        .ToString("yyyy-MM-dd"),
                    "$1200",
                    "Z1",
                    "R1",
                    item.LocationCode,
                    item.StockStatus,
                    "Re-arrange"
                );
            }
        }

        // =====================================
        // Expand / Collapse
        // =====================================

        private void Header_Click(
    object sender,
    EventArgs e)
        {
            _isExpanded =
                !_isExpanded;

            panelBatch.Visible =
                _isExpanded;

            this.Height =
                _isExpanded
                ? 260
                : 70;
        }
    }
}