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
        private readonly InventoryService
           _inventoryService;

        public InventoryForm()
        {
            InitializeComponent();

            _inventoryService =
                new InventoryService();

            LoadInventory();
        }

        private void LoadInventory()
        {
            flowInventory.Controls.Clear();

            List<InventoryItem> inventoryItems =
                _inventoryService
                .GetAllInventory();

            foreach (InventoryItem item
                in inventoryItems)
            {
                InventoryCardControl card =
                    new InventoryCardControl();

                card.Width =
                    flowInventory.Width - 30;

                // Main Row
                card.SetData(item);

                // Batch Table
                List<InventoryItem> batches =
                    inventoryItems
                    .Where(x =>
                        x.ProductId
                        == item.ProductId)
                    .ToList();

                card.LoadBatchData(batches);

                flowInventory.Controls.Add(card);
            }
        }
    }
}
