using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
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

            SetupUI();

            LoadInventory();
        }

        // =====================================
        // Setup UI
        // =====================================

        private void SetupUI()
        {
            // Form Background

            this.BackColor =
                Color.FromArgb(
                    245,
                    245,
                    245);

            // FlowLayoutPanel

            flowInventory.Dock =
                DockStyle.Fill;

            flowInventory.FlowDirection =
                FlowDirection.TopDown;

            flowInventory.WrapContents =
                false;

            flowInventory.AutoScroll =
                true;

            flowInventory.Padding =
                new Padding(15);

            flowInventory.BackColor =
                Color.FromArgb(
                    245,
                    245,
                    245);

            flowInventory.Resize +=
                FlowInventory_Resize;
        }

        // =====================================
        // Resize Cards
        // =====================================

        private void FlowInventory_Resize(
            object sender,
            EventArgs e)
        {
            foreach (Control control
                in flowInventory.Controls)
            {
                control.Width =
                    flowInventory.ClientSize.Width
                    - 35;
            }
        }

        // =====================================
        // Load Inventory
        // =====================================

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
            flowInventory.ClientSize.Width
            - 35;

        card.Margin =
            new Padding(0, 0, 0, 15);

        // Header

        card.SetData(item);

        // Batch Table

        List<InventoryItem> batches =
            inventoryItems
            .Where(x =>
                x.ProductId
                == item.ProductId)
            .ToList();

        card.LoadBatchData(
            batches);

        flowInventory.Controls
            .Add(card);
    }
}
    }
}