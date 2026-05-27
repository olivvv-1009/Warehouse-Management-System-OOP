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
        private readonly ExportRepository
            _exportRepository;

        public ExportForm()
        {
            InitializeComponent();

            _exportRepository =
                new ExportRepository();

            SetupDataGrid();

            SetupUI();

            LoadExportOrders();
        }

        private void SetupUI()
        {
            dgvExportOrders.CellFormatting +=
    dgvExportOrders_CellFormatting;
            dgvExportOrders
                .EnableHeadersVisualStyles =
                false;

            dgvExportOrders
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                Color.FromArgb(
                    0,
                    122,
                    204);

            dgvExportOrders
                .ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dgvExportOrders
                .RowsDefaultCellStyle
                .BackColor =
                Color.White;

            dgvExportOrders
                .AlternatingRowsDefaultCellStyle
                .BackColor =
                Color.FromArgb(
                    240,
                    248,
                    255);

            dgvExportOrders
                .DefaultCellStyle
                .SelectionBackColor =
                Color.LightBlue;

            dgvExportOrders
                .DefaultCellStyle
                .SelectionForeColor =
                Color.Black;
        }

        private void SetupDataGrid()
        {
            dgvExportOrders
                .AutoGenerateColumns =
                false;

            dgvExportOrders
                .AllowUserToAddRows =
                false;

            dgvExportOrders
                .ReadOnly =
                true;

            dgvExportOrders
                .RowHeadersVisible =
                false;
        }

        private void LoadExportOrders()
        {
            dgvExportOrders.Rows.Clear();

            List<ExportInvoice>
                exports =
                _exportRepository
                .GetAll();

            foreach (
                ExportInvoice invoice
                in exports
            )
            {
                dgvExportOrders.Rows.Add(
                    invoice.ExportId,
                    "Warehouse",
                    invoice.ExportDate
                        .ToString("yyyy-MM-dd"),
                    invoice.OrderDetails.Count,
                    "Completed",
                    invoice.EmployeeName,
                    "👁"
                );
            }
        }
        private void dgvExportOrders_CellFormatting(
           object? sender,
           DataGridViewCellFormattingEventArgs e)
        {
            if (
                dgvExportOrders.Columns[e.ColumnIndex]
                .Name
                ==
                "Status"
            )
            {
                if (
                    e.Value?.ToString()
                    ==
                    "Completed"
                )
                {
                    e.CellStyle.BackColor =
                        Color.FromArgb(
                            212,
                            237,
                            218
                        );

                    e.CellStyle.ForeColor =
                        Color.FromArgb(
                            40,
                            167,
                            69
                        );

                    e.CellStyle.SelectionBackColor =
                        Color.FromArgb(
                            212,
                            237,
                            218
                        );

                    e.CellStyle.SelectionForeColor =
                        Color.FromArgb(
                            40,
                            167,
                            69
                        );

                    e.CellStyle.Font =
                        new Font(
                            dgvExportOrders.Font,
                            FontStyle.Bold
                        );
                }
            }
        }

        private void btnCreateExportInvoice_Click(
    object sender,
    EventArgs e)
        {
            CreateExportInvoice form =
                new CreateExportInvoice();

            form.ShowDialog();
        }
        
    }
}