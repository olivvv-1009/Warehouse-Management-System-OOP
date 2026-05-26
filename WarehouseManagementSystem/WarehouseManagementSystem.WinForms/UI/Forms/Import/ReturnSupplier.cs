using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Controllers;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.UI.ConsoleUI;
using WarehouseManagementSystem.WinForms.UI.Controllers;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class ReturnSupplier : Form
    {
        private ReturnController
            _returnController;

        private ImportController
            _importController;

        private LookupService
            _lookupService;

        private BatchRepository
            _batchRepository;
        private bool
    _isViewMode;

        private ReturnOrder
            _returnOrder;

        public ReturnSupplier()
        {
            InitializeComponent();

            _isViewMode =
                false;

            // ===== EVENT =====

            dgvProducts.CellEndEdit +=
                dgvProducts_CellEndEdit;

            // ===== CONTROLLER =====

            _returnController =
                new ReturnController();

            _importController =
                new ImportController();

            _batchRepository =
                new BatchRepository();

            // ===== LOOKUP =====

            ProductController
                productController =
                    new ProductController();

            SupplierController
                supplierController =
                    new SupplierController();

            _lookupService =
                new LookupService(
                    productController
                        .GetAllProducts(),

                    supplierController
                        .GetAll(),

                    new List<Batch>(),

                    new List<InventoryItem>(),

                    new List<Account>(),

                    new List<Profile>()
                );

            LoadImportInvoices();

            dtpReturnDate.Value =
                DateTime.Now;
        }

        public ReturnSupplier(
    ReturnOrder returnOrder)
        {
            InitializeComponent();

            _isViewMode =
                true;

            _returnOrder =
                returnOrder;

            dgvProducts.CellEndEdit +=
                dgvProducts_CellEndEdit;

            _returnController =
                new ReturnController();

            _importController =
                new ImportController();

            _batchRepository =
                new BatchRepository();

            ProductController
                productController =
                    new ProductController();

            SupplierController
                supplierController =
                    new SupplierController();

            _lookupService =
                new LookupService(
                    productController
                        .GetAllProducts(),

                    supplierController
                        .GetAll(),

                    new List<Batch>(),

                    new List<InventoryItem>(),

                    new List<Account>(),

                    new List<Profile>()
                );

            SetupDataGridView();

            LoadReturnOrderData();
        }

        private void ReturnSupplier_Load(
            object sender,
            EventArgs e)
        {
            dtpReturnDate.Format =
                DateTimePickerFormat
                    .Custom;

            dtpReturnDate.CustomFormat =
                "dd/MM/yyyy";

            if (
                Session.CurrentProfile
                != null
            )
            {
                lbCreatedby.Text =
                    Session
                        .CurrentProfile
                        .FullName;
            }

            if (!_isViewMode)
            {
                SetupDataGridView();
            }
        }

        private void SetupDataGridView()
        {
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(
                "ProductId",
                "Product ID"
            );

            dgvProducts.Columns.Add(
                "ProductName",
                "Product Name"
            );

            dgvProducts.Columns.Add(
                "ImportedQuantity",
                "Imported Quantity"
            );

            dgvProducts.Columns.Add(
                "ReturnQuantity",
                "Quantity To Return"
            );

            dgvProducts.Columns.Add(
                "TotalValue",
                "Total Value"
            );

            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                    .Fill;

            dgvProducts.AllowUserToAddRows =
                false;

            dgvProducts.SelectionMode =
                DataGridViewSelectionMode
                    .FullRowSelect;

            dgvProducts.Columns[0]
                .ReadOnly = true;

            dgvProducts.Columns[1]
                .ReadOnly = true;

            dgvProducts.Columns[2]
                .ReadOnly = true;

            dgvProducts.Columns[4]
                .ReadOnly = true;

            dgvProducts.ColumnHeadersDefaultCellStyle
                .Font =
                    new Font(
                        "Times New Roman",
                        12,
                        FontStyle.Bold
                    );

            dgvProducts.DefaultCellStyle
                .Font =
                    new Font(
                        "Times New Roman",
                        12
                    );
        }

        private void LoadImportInvoices()
        {
            cboImportInvoice.Items.Clear();

            List<ImportInvoice>
                invoices =
                    _importController
                        .GetAll();

            int i;

            for (
                i = 0;
                i < invoices.Count;
                i++
            )
            {
                cboImportInvoice.Items.Add(
                    invoices[i]
                        .ImportId
                );
            }
        }

        private void
            cboImportInvoice_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ImportInvoice invoice =
                _importController
                    .FindById(
                        cboImportInvoice.Text
                    );

            if (invoice == null)
            {
                return;
            }

            txtSupplier.Text =
                _lookupService
                    .GetSupplierName(
                        invoice.SupplierId
                    );

            dgvProducts.Rows.Clear();

            int i;

            for (
                i = 0;
                i <
                invoice.OrderDetails.Count;
                i++
            )
            {
                OrderDetail detail =
                    invoice
                        .OrderDetails[i];

                string productName =
                    _lookupService
                        .GetProductName(
                            detail.ProductId
                        );

                dgvProducts.Rows.Add(
                    detail.ProductId,
                    productName,
                    detail.Quantity,
                    0,
                    0
                );
            }
        }

        // ===== AUTO UPDATE TOTAL VALUE =====

        private void dgvProducts_CellEndEdit(
    object sender,
    DataGridViewCellEventArgs e)
        {
            // ===== QUANTITY COLUMN =====

            if (e.ColumnIndex != 3)
            {
                return;
            }

            DataGridViewRow row =
                dgvProducts.Rows[e.RowIndex];

            if (
                row.Cells[3].Value
                == null
            )
            {
                return;
            }

            int quantity = 0;

            bool isNumber =
                int.TryParse(
                    row.Cells[3]
                        .Value
                        .ToString(),
                    out quantity
                );

            if (!isNumber)
            {
                row.Cells[4].Value =
                    0;

                return;
            }

            string productId =
                row.Cells[0]
                    .Value
                    .ToString();

            decimal importPrice =
                0;

            List<Batch> batches =
                _batchRepository
                    .GetByProductId(
                        productId
                    );

            if (
                batches.Count > 0
            )
            {
                importPrice =
                    batches[0]
                        .ImportPrice;
            }

            decimal totalValue =
                quantity
                * importPrice;

            // ===== KHÔNG FORMAT STRING =====

            row.Cells[4].Value =
                totalValue;
        }

        private void btnSubmit_Click(
            object sender,
            EventArgs e)
        {
            if (
                cboImportInvoice.Text
                == ""
            )
            {
                MessageBox.Show(
                    "Please select import invoice."
                );

                return;
            }

            if (
                txtReason.Text.Trim()
                == ""
            )
            {
                MessageBox.Show(
                    "Reason is required."
                );

                return;
            }

            ImportInvoice invoice =
                _importController
                    .FindById(
                        cboImportInvoice.Text
                    );

            if (invoice == null)
            {
                return;
            }

            List<ReturnOrder> orders =
                _returnController
                    .GetAll();

            List<string> ids =
                new List<string>();

            int i;

            for (
                i = 0;
                i < orders.Count;
                i++
            )
            {
                ids.Add(
                    orders[i]
                        .ReturnOrderId
                );
            }

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        ids,
                        "RT"
                    );

            ReturnOrder returnOrder =
                new ReturnOrder();

            returnOrder.ReturnOrderId =
                IdGenerator
                    .GenerateReturnId(
                        nextNumber
                    );

            returnOrder.ImportInvoiceId =
                invoice.ImportId;

            returnOrder.SupplierId =
                invoice.SupplierId;

            returnOrder.ReturnDate =
                dtpReturnDate.Value;

            returnOrder.Status =
                "Pending";

            for (
                i = 0;
                i <
                dgvProducts.Rows.Count;
                i++
            )
            {
                if (
                    dgvProducts
                        .Rows[i]
                        .Cells[3]
                        .Value == null
                )
                {
                    continue;
                }

                int quantityToReturn = 0;

                bool isValid =
                    int.TryParse(
                        dgvProducts
                            .Rows[i]
                            .Cells[3]
                            .Value
                            .ToString(),
                        out quantityToReturn
                    );

                if (!isValid)
                {
                    MessageBox.Show(
                        "Invalid quantity."
                    );

                    return;
                }

                if (
                    quantityToReturn <= 0
                )
                {
                    continue;
                }

                int importedQuantity =
                    Convert.ToInt32(
                        dgvProducts
                            .Rows[i]
                            .Cells[2]
                            .Value
                    );

                if (
                    quantityToReturn >
                    importedQuantity
                )
                {
                    MessageBox.Show(
                        "Return quantity cannot exceed imported quantity."
                    );

                    return;
                }

                string productId =
                    dgvProducts
                        .Rows[i]
                        .Cells[0]
                        .Value
                        .ToString();

                decimal importPrice =
                    0;

                List<Batch> batches =
                    _batchRepository
                        .GetByProductId(
                            productId
                        );

                if (
                    batches.Count > 0
                )
                {
                    importPrice =
                        batches[0]
                            .ImportPrice;
                }

                ReturnOrderDetail
                    detail =
                        new ReturnOrderDetail();

                detail.ProductId =
                    productId;

                detail.Quantity =
                    quantityToReturn;

                detail.UnitPrice =
                    importPrice;

                detail.ReturnReason =
                    txtReason.Text;

                returnOrder
                    .Details
                    .Add(detail);
            }

            if (
                returnOrder
                    .Details.Count == 0
            )
            {
                MessageBox.Show(
                    "Please enter return quantity."
                );

                return;
            }

            bool result =
                _returnController
                    .CreateReturnOrder(
                        returnOrder
                    );

            if (result)
            {
                MessageBox.Show(
                    "Return order created successfully."
                );

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Failed to create return order."
                );
            }
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        private void LoadReturnOrderData()
        {
            cboImportInvoice.Text =
                _returnOrder
                    .ImportInvoiceId;

            txtSupplier.Text =
                _lookupService
                    .GetSupplierName(
                        _returnOrder
                            .SupplierId
                    );

            dtpReturnDate.Value =
                _returnOrder
                    .ReturnDate;

            txtReason.Text =
                "";

            dgvProducts.Rows.Clear();

            int i;

            for (
                i = 0;
                i <
                _returnOrder
                    .Details.Count;
                i++
            )
            {
                WarehouseManagementSystem
                    .WinForms
                    .Models
                    .ReturnOrderDetail detail =
                        _returnOrder
                            .Details[i];

                string productName =
                    _lookupService
                        .GetProductName(
                            detail
                                .ProductId
                        );

                dgvProducts.Rows.Add(
                    detail.ProductId,
                    productName,
                    detail.Quantity,
                    detail.Quantity,
                    detail.TotalPrice
                );

                if (
                    txtReason.Text
                    == ""
                )
                {
                    txtReason.Text =
                        detail
                            .ReturnReason;
                }
            }

            // ===== VIEW ONLY =====

            cboImportInvoice.Enabled =
                false;

            txtReason.ReadOnly =
                true;

            dgvProducts.ReadOnly =
                true;

            dtpReturnDate.Enabled =
                false;

            btnSubmit.Visible =
                false;

            btnCancel.Text =
                "Close";

            // ===== CREATED BY =====

            lbCreatedby.Text =
                _returnOrder
                    .EmployeeId;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}