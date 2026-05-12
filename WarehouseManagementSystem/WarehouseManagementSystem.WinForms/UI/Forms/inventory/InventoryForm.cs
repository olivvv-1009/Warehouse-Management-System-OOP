using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.ConsoleUI;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms.inventory
{
    public partial class InventoryForm : UserControl
    {
        private readonly InventoryService _inventoryService;
        public InventoryForm()
        {
            InitializeComponent();

            _inventoryService = new InventoryService();

            SetupDataGridView();

            LoadInventoryData();
        }
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns =
                false;

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(
                "colProductId",
                "Product Code");

            dataGridView1.Columns.Add(
                "colProductName",
                "Product Name");

            dataGridView1.Columns.Add(
                "colQuantity",
                "Quantity");

            dataGridView1.Columns.Add(
                "colMinStock",
                "Min Stock");

            dataGridView1.Columns.Add(
                "colStatus",
                "Status");

            dataGridView1.RowTemplate.Height =
                40;

            dataGridView1.AllowUserToAddRows =
                false;

            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dataGridView1.BorderStyle =
                BorderStyle.None;

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);
        }

        private void LoadInventoryData()
        {
            dataGridView1.Rows.Clear();

            List<InventoryItem> inventoryItems =
                _inventoryService
                .GetAllInventory();

            foreach (InventoryItem item
                in inventoryItems)
            {
                dataGridView1.Rows.Add(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.MinStock,
                    item.StockStatus
                );
            }
        }
    }
}
