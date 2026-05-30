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
        private readonly ImportRepository _importRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly ReturnRepository _returnRepository;

        public ImportForm()
        {
            InitializeComponent();

            _importRepository = new ImportRepository();
            _supplierRepository = new SupplierRepository();
            _returnRepository = new ReturnRepository();

            SetupDataGridView();
            LoadImportInvoices();

            dgvImportOrders.CellClick += dgvImportOrders_CellClick;
            dgvImportOrders.CellDoubleClick += dgvImportOrders_CellDoubleClick;
        }

        // ─── Setup DataGridView ───────────────────────────────────

        private void SetupDataGridView()
        {
            dgvImportOrders.Columns.Clear();
            dgvImportOrders.AutoGenerateColumns = false;
            dgvImportOrders.RowHeadersVisible = false;
            dgvImportOrders.AllowUserToAddRows = false;
            dgvImportOrders.AllowUserToDeleteRows = false;
            dgvImportOrders.AllowUserToResizeRows = false;
            dgvImportOrders.AllowUserToResizeColumns = false;
            dgvImportOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportOrders.MultiSelect = false;
            dgvImportOrders.ReadOnly = true;
            dgvImportOrders.BackgroundColor = Color.White;
            dgvImportOrders.BorderStyle = BorderStyle.None;
            dgvImportOrders.GridColor = Color.FromArgb(230, 230, 230);
            dgvImportOrders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvImportOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvImportOrders.RowTemplate.Height = 48;
            dgvImportOrders.ColumnHeadersHeight = 55;
            dgvImportOrders.EnableHeadersVisualStyles = false;
            dgvImportOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvImportOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvImportOrders.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvImportOrders.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvImportOrders.DefaultCellStyle.Padding = new Padding(8);
            dgvImportOrders.DefaultCellStyle.SelectionBackColor =Color.FromArgb(219, 234, 254);
            dgvImportOrders.DefaultCellStyle.SelectionForeColor =Color.Black;
            dgvImportOrders.ClearSelection();
            dgvImportOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportOrders.ScrollBars = ScrollBars.Vertical;

            AddColumns();

            dgvImportOrders.Columns["InvoiceId"].FillWeight = 80;
            dgvImportOrders.Columns["Supplier"].FillWeight = 180;
            dgvImportOrders.Columns["Date"].FillWeight = 90;
            dgvImportOrders.Columns["Items"].FillWeight = 60;
            dgvImportOrders.Columns["Status"].FillWeight = 90;
            dgvImportOrders.Columns["ReturnStatus"].FillWeight = 110;
            dgvImportOrders.Columns["CreatedBy"].FillWeight = 120;
            dgvImportOrders.Columns["Action"].FillWeight = 60;
        }

        private void AddColumns()
        {
            dgvImportOrders.Columns.Add("InvoiceId", "Invoice ID");
            dgvImportOrders.Columns.Add("Supplier", "Supplier");
            dgvImportOrders.Columns.Add("Date", "Date");
            dgvImportOrders.Columns.Add("Items", "Items");
            dgvImportOrders.Columns.Add("Status", "Status");

            DataGridViewButtonColumn returnColumn = new DataGridViewButtonColumn();
            returnColumn.Name = "ReturnStatus";
            returnColumn.HeaderText = "Return Status";
            dgvImportOrders.Columns.Add(returnColumn);

            dgvImportOrders.Columns.Add("CreatedBy", "Created By");

            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Action";
            actionColumn.HeaderText = "Actions";
            actionColumn.Text = "👁";
            actionColumn.UseColumnTextForButtonValue = true;
            dgvImportOrders.Columns.Add(actionColumn);
        }

        // ─── Load data ────────────────────────────────────────────

        private void LoadImportInvoices()
        {
            dgvImportOrders.Rows.Clear();

            List<ImportInvoice> invoices = _importRepository.GetAll();
            List<Supplier> suppliers = _supplierRepository.GetAll();
            List<ReturnOrder> returns = _returnRepository.GetAll();

            foreach (ImportInvoice invoice in invoices)
            {
                string supplierName = invoice.SupplierId;

                foreach (Supplier supplier in suppliers)
                {
                    if (supplier.SupplierId == invoice.SupplierId)
                    {
                        supplierName = supplier.SupplierName;
                        break;
                    }
                }

                string returnText = "No Return";
                string returnId = "";

                foreach (ReturnOrder order in returns)
                {
                    if (order.ImportInvoiceId == invoice.InvoiceId)
                    {
                        returnText = "Returned";
                        returnId = order.InvoiceId;
                        break;
                    }
                }

                int row = dgvImportOrders.Rows.Add(
                    invoice.InvoiceId,
                    supplierName,
                    invoice.CreatedDate.ToString("yyyy-MM-dd"),
                    invoice.OrderDetails.Count,
                    "Completed",
                    returnText,
                    invoice.EmployeeName,
                    "👁"
                );

                dgvImportOrders.Rows[row].Cells["ReturnStatus"].Tag = returnId;

                dgvImportOrders.Rows[row].Cells["Status"].Style.ForeColor =Color.SeaGreen;

                dgvImportOrders.Rows[row].Cells["Status"].Style.Font =new Font("Segoe UI", 10, FontStyle.Bold);

                if (returnText == "Returned")
                {
                    dgvImportOrders.Rows[row].Cells["ReturnStatus"].Style.BackColor =
                        Color.SeaGreen;
                    dgvImportOrders.Rows[row].Cells["ReturnStatus"].Style.ForeColor =
                        Color.White;
                }
                else
                {
                    dgvImportOrders.Rows[row].Cells["ReturnStatus"].Style.BackColor =
                        Color.FromArgb(243, 244, 246);
                    dgvImportOrders.Rows[row].Cells["ReturnStatus"].Style.ForeColor =
                        Color.Black;
                }
            }
        }

        // ─── Cell click ───────────────────────────────────────────

        private void dgvImportOrders_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName =
                dgvImportOrders.Columns[e.ColumnIndex].Name;

            if (columnName == "Action")
            {
                string InvoiceId =
                    dgvImportOrders.Rows[e.RowIndex]
                    .Cells["InvoiceId"].Value?.ToString() ?? "";

                ImportInvoice? invoice =
                    _importRepository.GetAll()
                    .Find(x => x.InvoiceId == InvoiceId);

                if (invoice != null)
                {
                    ImportOrderDetails form = new ImportOrderDetails(invoice);
                    form.ShowDialog();
                    LoadImportInvoices();
                }
            }

            if (columnName == "ReturnStatus")
            {
                string status =
                    dgvImportOrders.Rows[e.RowIndex]
                    .Cells["ReturnStatus"].Value?.ToString() ?? "";

                if (status != "Returned") return;

                string returnId =
                    dgvImportOrders.Rows[e.RowIndex]
                    .Cells["ReturnStatus"].Tag?.ToString() ?? "";

                ReturnOrder? order = _returnRepository.FindById(returnId);

                if (order != null)
                {
                    ReturnSupplier form = new ReturnSupplier(order);
                    form.ShowDialog();
                    LoadImportInvoices();
                }
            }
        }

        // ─── Cell double click ────────────────────────────────────

        private void dgvImportOrders_CellDoubleClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string InvoiceId =
                dgvImportOrders.Rows[e.RowIndex]
                .Cells["InvoiceId"].Value?.ToString() ?? "";

            ImportInvoice invoice =
    _importRepository.FindById(
        InvoiceId
    );

            if (invoice != null)
            {
                ImportOrderDetails form = new ImportOrderDetails(invoice);
                form.ShowDialog();
                LoadImportInvoices();
            }
        }

        private void dgvImportOrders_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        { }

        // ─── Buttons ──────────────────────────────────────────────

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateImportOrder form = new CreateImportOrder();

            form.ImportCreated += Form_ImportCreated;

            form.ShowDialog();
        }
        private void Form_ImportCreated(object sender, EventArgs e)
        {
            LoadImportInvoices();
        }


        private void btnReturn_Click(
    object sender,
    EventArgs e)
        {
            ReturnSupplier form =
                new ReturnSupplier();

            form.ReturnCreated +=
                Form_ReturnCreated;

            form.ShowDialog();
        }

        private void Form_ReturnCreated(
            object sender,
            EventArgs e)
        {
            LoadImportInvoices();
        }

        // ─── Stubs required by Designer ───────────────────────────

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
    }
}
