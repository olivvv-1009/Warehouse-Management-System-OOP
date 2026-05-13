using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class ImportOrderDetails : Form
    {
        private readonly ImportInvoice
            _invoice;

        private readonly SupplierRepository
            _supplierRepository;

        public ImportOrderDetails(
            ImportInvoice invoice)
        {
            InitializeComponent();

            _invoice = invoice;

            _supplierRepository =
                new SupplierRepository();

            SetupDataGridView();

            LoadInvoiceData();
        }

        private void SetupDataGridView()
        {
            dgvProduct.Columns.Clear();

            dgvProduct.AutoGenerateColumns =
                false;

            dgvProduct.AllowUserToAddRows =
                false;

            dgvProduct.AllowUserToResizeRows =
                false;

            dgvProduct.AllowUserToResizeColumns =
                false;

            dgvProduct.RowHeadersVisible =
                false;

            dgvProduct.ReadOnly =
                true;

            dgvProduct.MultiSelect =
                false;

            dgvProduct.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProduct.BackgroundColor =
                Color.White;

            dgvProduct.BorderStyle =
                BorderStyle.None;

            dgvProduct.GridColor =
                Color.LightGray;

            dgvProduct.RowTemplate.Height =
                50;

            dgvProduct.ColumnHeadersHeight =
                45;

            dgvProduct.EnableHeadersVisualStyles =
                false;

            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 73, 94);

            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvProduct.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgvProduct.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Regular
                );

            dgvProduct.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            dgvProduct.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvProduct.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProduct.ScrollBars =
                ScrollBars.Vertical;

            dgvProduct.Columns.Add(
                "ProductId",
                "Product"
            );

            dgvProduct.Columns.Add(
                "Quantity",
                "Quantity"
            );

            dgvProduct.Columns.Add(
                "Price",
                "Unit Price"
            );

            dgvProduct.Columns.Add(
                "Total",
                "Total Price"
            );

            dgvProduct.Columns.Add(
                "Location",
                "Location"
            );

            dgvProduct.Columns["ProductId"]
                .FillWeight = 220;

            dgvProduct.Columns["Quantity"]
                .FillWeight = 90;

            dgvProduct.Columns["Price"]
                .FillWeight = 120;

            dgvProduct.Columns["Total"]
                .FillWeight = 140;

            dgvProduct.Columns["Location"]
                .FillWeight = 160;
        }

        private void LoadInvoiceData()
        {
            string supplierName =
                _invoice.SupplierId;

            List<Supplier> suppliers =
                _supplierRepository.GetAll();

            for (int i = 0;
                i < suppliers.Count;
                i++)
            {
                if (suppliers[i].SupplierId
                    == _invoice.SupplierId)
                {
                    supplierName =
                        suppliers[i].SupplierName;

                    break;
                }
            }

            lblSupplier.Text =
                supplierName;

            lblDate.Text =
                _invoice.ImportDate.ToString(
                    "yyyy-MM-dd"
                );

            lblStatus.Text =
                "Completed";

            lblCreatedBy.Text =
                _invoice.EmployeeName;

            dgvProduct.Rows.Clear();

            for (int i = 0;
                i < _invoice.OrderDetails.Count;
                i++)
            {
                OrderDetail detail =
                    _invoice.OrderDetails[i];

                dgvProduct.Rows.Add(
                    detail.ProductId,
                    detail.Quantity,
                    detail.UnitPrice.ToString("N0"),
                    detail.TotalPrice.ToString("N0"),
                    detail.LocationCode
                );
            }
        }

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}