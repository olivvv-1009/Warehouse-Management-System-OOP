#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    public partial class CreateExportInvoice : Form
    {
        private readonly ExportService _exportService;
        private readonly ProductService _productService;
        private readonly BatchRepository _batchRepository;
        private readonly FifoRule _fifoRule;
        private readonly BranchRepository _branchRepository;

        private Dictionary<string, (string Name, int Available)> _productMap = new();

        public CreateExportInvoice()
        {
            InitializeComponent();

            _exportService = new ExportService();
            _productService = new ProductService();
            _batchRepository = new BatchRepository();
            _fifoRule = new FifoRule();
            _branchRepository = new BranchRepository();

            LoadDestinations();
            LoadProductMap();
            SetupDropdown();
            SetupEvents();

            lblEmployeeValue.Text = Session.CurrentProfile?.FullName ?? "";
            dtpDate.Value = DateTime.Now;
        }

        private void LoadDestinations()
        {
            var branches = _branchRepository.GetAll();
            txtDestination.DataSource = branches;
            txtDestination.DisplayMember = "BranchName";
            txtDestination.ValueMember = "BranchId";
            txtDestination.SelectedIndex = -1;
        }

        private void LoadProductMap()
        {
            _productMap.Clear();
            var products = _productService.GetAllProducts();
            foreach (var p in products)
            {
                var batches = _batchRepository.GetByProductId(p.ProductID);
                int available = _fifoRule.GetAvailableQuantity(batches);
                _productMap[p.ProductID] = (p.Name, available);
            }
        }

        private void SetupDropdown()
        {
            var displayList = _productMap
                .Select(kv => new
                {
                    Id = kv.Key,
                    Display = $"{kv.Value.Name} (Available: {kv.Value.Available})"
                })
                .OrderBy(x => x.Display)
                .ToList<object>();

            colProduct.DataSource = displayList;
            colProduct.DisplayMember = "Display";
            colProduct.ValueMember = "Id";
        }

        private void SetupEvents()
        {
            btnAddProduct.Click += (s, e) => AddProductRow();
            btnComplete.Click += (s, e) => BtnComplete_Click();
            btnSaveDraft.Click += (s, e) => BtnSaveDraft_Click();
            btnCancel.Click += (s, e) => BtnCancel_Click();

            dgvProducts.CellValueChanged += DgvProducts_CellValueChanged;
            dgvProducts.CellClick += DgvProducts_CellClick;

            dgvProducts.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvProducts.IsCurrentCellDirty &&
                    dgvProducts.CurrentCell is DataGridViewComboBoxCell)
                    dgvProducts.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            dgvProducts.DataError += (s, e) => e.Cancel = true;
        }

        private void AddProductRow()
        {
            int idx = dgvProducts.Rows.Add();
            var row = dgvProducts.Rows[idx];
            row.Cells["colQuantity"].Value = 1;
            row.Cells["colAvailable"].Value = "-";
            row.Cells["colFifo"].Value = "-";
        }

        private void RemoveRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvProducts.Rows.Count)
                dgvProducts.Rows.RemoveAt(rowIndex);
        }

        private void DgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProducts.Columns[e.ColumnIndex].Name == "colRemove")
                RemoveRow(e.RowIndex);
        }

        private void DgvProducts_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvProducts.Columns[e.ColumnIndex].Name;
            if (col == "colProduct" || col == "colQuantity")
                UpdateRowInfo(e.RowIndex);
        }

        private void UpdateRowInfo(int rowIndex)
        {
            var row = dgvProducts.Rows[rowIndex];
            var productId = row.Cells["colProduct"].Value?.ToString();
            if (string.IsNullOrEmpty(productId)) return;

            if (!int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty) || qty <= 0)
                qty = 1;

            var batches = _batchRepository.GetByProductId(productId);
            int available = _fifoRule.GetAvailableQuantity(batches);

            row.Cells["colAvailable"].Value = available.ToString();
            row.Cells["colAvailable"].Style.ForeColor =
                available > 0 ? Color.FromArgb(21, 128, 61) : Color.FromArgb(185, 28, 28);
            row.Cells["colAvailable"].Style.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            bool canExport = _fifoRule.Apply(batches, qty, out var deductions);
            if (canExport && deductions != null && deductions.Count > 0)
            {
                var first = deductions[0];
                var batch = batches.FirstOrDefault(b => b.BatchId == first.BatchId);
                string date = batch?.ImportDate.ToString("yyyy-MM-dd") ?? "";
                string fifo = deductions.Count == 1
                    ? $"{first.BatchId}: {first.QuantityToDeduct} units ({date})"
                    : string.Join(", ", deductions.Select(d =>
                    {
                        var b = batches.FirstOrDefault(x => x.BatchId == d.BatchId);
                        return $"{d.BatchId}: {d.QuantityToDeduct}u ({b?.ImportDate:yyyy-MM-dd})";
                    }));

                row.Cells["colFifo"].Value = fifo;
                row.Cells["colFifo"].Style.ForeColor = Color.FromArgb(37, 99, 235);
            }
            else
            {
                row.Cells["colFifo"].Value = "Not enough stock";
                row.Cells["colFifo"].Style.ForeColor = Color.FromArgb(185, 28, 28);
            }
        }

        private bool CollectExportItems(
            out List<(string ProductId, int Quantity, decimal UnitPrice)> items)
        {
            items = new List<(string, int, decimal)>();

            if (txtDestination.SelectedItem == null)
            {
                MessageBox.Show("Please select a destination.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one product.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                var productId = row.Cells["colProduct"].Value?.ToString();
                if (string.IsNullOrEmpty(productId))
                {
                    MessageBox.Show("Please select a product for all rows.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty) || qty <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity (> 0) for all rows.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var batches = _batchRepository.GetByProductId(productId);
                if (!_fifoRule.Apply(batches, qty, out _))
                {
                    string name = row.Cells["colProduct"].FormattedValue?.ToString() ?? productId;
                    MessageBox.Show($"Not enough stock for \"{name}\".",
                        "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                items.Add((productId, qty, 0m));
            }

            return true;
        }

        private void BtnComplete_Click()
        {
            if (!CollectExportItems(out var items)) return;

            string employee = Session.CurrentProfile?.FullName ?? "";
            string destination = (txtDestination.SelectedItem as BranchInfo)?.BranchName ?? "";

            var orderDetails = items.Select(item => new OrderDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.Quantity * item.UnitPrice
            }).ToList();

            bool success = _exportService.CreateExportInvoice(employee, destination, orderDetails);

            if (success)
            {
                MessageBox.Show("Export invoice created successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to create export invoice. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveDraft_Click()
        {
            if (txtDestination.SelectedItem == null)
            {
                MessageBox.Show("Please select a destination before saving draft.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one product.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var items = new List<(string ProductId, int Quantity, decimal UnitPrice)>();
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                var productId = row.Cells["colProduct"].Value?.ToString();
                if (string.IsNullOrEmpty(productId)) continue;
                int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty);
                if (qty <= 0) qty = 1;
                items.Add((productId, qty, 0m));
            }

            string employee = Session.CurrentProfile?.FullName ?? "";
            string destination = (txtDestination.SelectedItem as BranchInfo)?.BranchName ?? "";

            _exportService.SaveDraft(items, employee, destination);
            Close();
        }

        private void BtnCancel_Click()
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to cancel? All changes will be lost.",
                "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) Close();
        }
    }
}