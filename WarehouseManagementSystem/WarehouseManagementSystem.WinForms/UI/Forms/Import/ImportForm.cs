using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class ImportForm : UserControl
    {
        private readonly ImportRepository
            _importRepository;

        private readonly SupplierRepository
            _supplierRepository;

        public ImportForm()
        {
            InitializeComponent();

            _importRepository =
                new ImportRepository();

            _supplierRepository =
                new SupplierRepository();

            SetupDataGridView();

            LoadImportInvoices();

            dataGridView1.CellClick +=
                dataGridView1_CellClick;
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.AutoGenerateColumns =
                false;

            dataGridView1.RowHeadersVisible =
                false;

            dataGridView1.AllowUserToAddRows =
                false;

            dataGridView1.AllowUserToResizeRows =
                false;

            dataGridView1.AllowUserToResizeColumns =
                false;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect =
                false;

            dataGridView1.ReadOnly =
                true;

            dataGridView1.BackgroundColor =
                Color.White;

            dataGridView1.BorderStyle =
                BorderStyle.None;

            dataGridView1.GridColor =
                Color.LightGray;

            dataGridView1.RowTemplate.Height =
                60;

            dataGridView1.ColumnHeadersHeight =
                50;

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 73, 94);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dataGridView1.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Regular
                );

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ScrollBars =
                ScrollBars.Vertical;

            AddColumns();

            dataGridView1.Columns["ImportId"]
                .FillWeight = 150;

            dataGridView1.Columns["Supplier"]
                .FillWeight = 260;

            dataGridView1.Columns["Date"]
                .FillWeight = 130;

            dataGridView1.Columns["Items"]
                .FillWeight = 70;

            dataGridView1.Columns["Status"]
                .FillWeight = 120;

            dataGridView1.Columns["ReturnStatus"]
                .FillWeight = 140;

            dataGridView1.Columns["CreatedBy"]
                .FillWeight = 170;

            dataGridView1.Columns["Action"]
                .FillWeight = 90;
        }

        private void AddColumns()
        {
            dataGridView1.Columns.Add(
                "ImportId",
                "Invoice ID"
            );

            dataGridView1.Columns.Add(
                "Supplier",
                "Supplier"
            );

            dataGridView1.Columns.Add(
                "Date",
                "Date"
            );

            dataGridView1.Columns.Add(
                "Items",
                "Items"
            );

            dataGridView1.Columns.Add(
                "Status",
                "Status"
            );

            dataGridView1.Columns.Add(
                "ReturnStatus",
                "Return Status"
            );

            dataGridView1.Columns.Add(
                "CreatedBy",
                "Created By"
            );

            DataGridViewButtonColumn actionColumn =
                new DataGridViewButtonColumn();

            actionColumn.Name =
                "Action";

            actionColumn.HeaderText =
                "Actions";

            actionColumn.Text =
                "View";

            actionColumn.UseColumnTextForButtonValue =
                true;

            dataGridView1.Columns.Add(
                actionColumn
            );
        }

        private void LoadImportInvoices()
        {
            dataGridView1.Rows.Clear();

            List<ImportInvoice> invoices =
                _importRepository.GetAll();

            List<Supplier> suppliers =
                _supplierRepository.GetAll();

            for (int i = 0; i < invoices.Count; i++)
            {
                ImportInvoice invoice =
                    invoices[i];

                string supplierName =
                    invoice.SupplierId;

                for (int j = 0;
                    j < suppliers.Count;
                    j++)
                {
                    if (suppliers[j].SupplierId
                        == invoice.SupplierId)
                    {
                        supplierName =
                            suppliers[j].SupplierName;

                        break;
                    }
                }

                int totalItems =
                    invoice.OrderDetails.Count;

                dataGridView1.Rows.Add(
                    invoice.ImportId,
                    supplierName,
                    invoice.ImportDate.ToString(
                        "yyyy-MM-dd"
                    ),
                    totalItems,
                    "Completed",
                    "No Return",
                    invoice.EmployeeName,
                    "View"
                );
            }
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name
                == "Action")
            {
                string importId =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["ImportId"]
                    .Value
                    .ToString();

                List<ImportInvoice> invoices =
                    _importRepository.GetAll();

                ImportInvoice selectedInvoice =
                    null;

                for (int i = 0;
                    i < invoices.Count;
                    i++)
                {
                    if (invoices[i].ImportId
                        == importId)
                    {
                        selectedInvoice =
                            invoices[i];

                        break;
                    }
                }

                if (selectedInvoice != null)
                {
                    ImportOrderDetails form =
                        new ImportOrderDetails(
                            selectedInvoice
                        );

                    form.ShowDialog();
                }
            }
        }

        private void btnCreate_Click(
            object sender,
            EventArgs e)
        {
            CreateImportOrder form =
        new CreateImportOrder();

            form.ShowDialog();

            LoadImportInvoices();
        }

        private void btnReturn_Click(
            object sender,
            EventArgs e)
        {
            ReturnSupplier form =
                new ReturnSupplier();

            form.ShowDialog();
        }
    }
}