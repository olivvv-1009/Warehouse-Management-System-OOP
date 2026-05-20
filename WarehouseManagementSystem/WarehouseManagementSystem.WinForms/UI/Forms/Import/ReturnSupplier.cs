using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Controllers;
using WarehouseManagementSystem.WinForms.Models;
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

        private ProductController
            _productController;

        public ReturnSupplier()
        {
            InitializeComponent();

            _returnController =
                new ReturnController();

            _importController =
                new ImportController();

            _productController =
                new ProductController();

            LoadImportInvoices();

            dtpReturnDate.Value =
                DateTime.Now;
        }

        private void ReturnSupplier_Load(
            object sender,
            EventArgs e)
        {
            if (
                Session.CurrentProfile !=
                null
            )
            {
                lbCreatedby.Text =
                    Session
                        .CurrentProfile
                        .FullName;
            }

            SetupDataGridView();
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

            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                    .Fill;

            dgvProducts.RowTemplate.Height =
                35;

            dgvProducts.AllowUserToAddRows =
                false;

            dgvProducts.MultiSelect =
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

            dgvProducts.Columns[0]
                .FillWeight = 20;

            dgvProducts.Columns[1]
                .FillWeight = 40;

            dgvProducts.Columns[2]
                .FillWeight = 20;

            dgvProducts.Columns[3]
                .FillWeight = 20;

            dgvProducts.ColumnHeadersHeight =
                40;

            dgvProducts.EnableHeadersVisualStyles =
                false;

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
            string importInvoiceId =
                cboImportInvoice.Text;

            ImportInvoice invoice =
                _importController
                    .FindById(
                        importInvoiceId
                    );

            if (invoice == null)
            {
                return;
            }

            txtSupplier.Text =
                invoice.SupplierId;

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

                ProductDisplayModel
                    product =
                        _productController
                            .GetProduct(
                                detail
                                    .ProductId
                            );

                string productName =
                    "";

                if (product != null)
                {
                    productName =
                        product.Name;
                }

                dgvProducts.Rows.Add(
                    detail.ProductId,
                    productName,
                    detail.Quantity,
                    0
                );
            }
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

                txtReason.Focus();

                return;
            }

            ReturnOrder returnOrder =
                new ReturnOrder();

            returnOrder.ReturnOrderId =
                Guid.NewGuid()
                    .ToString();

            returnOrder.ImportInvoiceId =
                cboImportInvoice.Text;

            returnOrder.SupplierId =
                txtSupplier.Text;

            returnOrder.ReturnDate =
                dtpReturnDate.Value;

            returnOrder.Status =
                "Pending";

            int i;

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

                int quantityToReturn =
                    Convert.ToInt32(
                        dgvProducts
                            .Rows[i]
                            .Cells[3]
                            .Value
                    );

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

                ReturnOrderDetail
                    detail =
                        new ReturnOrderDetail();

                detail.ProductId =
                    dgvProducts
                        .Rows[i]
                        .Cells[0]
                        .Value
                        .ToString();

                detail.Quantity =
                    quantityToReturn;

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
    }
}