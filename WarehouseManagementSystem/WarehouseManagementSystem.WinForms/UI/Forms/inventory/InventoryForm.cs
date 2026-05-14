using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Forms.inventory
{
    public partial class InventoryForm
        : UserControl
    {
        private readonly InventoryController
            _inventoryController;

        public InventoryForm()
        {
            InitializeComponent();

            _inventoryController =
                new InventoryController();

            SetupUI();

            LoadInventory();
        }

        private void SetupUI()
        {
            BackColor =
                Color.FromArgb(
                    245,
                    245,
                    245
                );

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
                    245
                );

            flowInventory.Resize +=
                FlowInventory_Resize;
        }

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

        private void LoadInventory()
        {
            flowInventory.Controls.Clear();

            List<InventoryItem>
                inventoryItems =
                    _inventoryController
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
                    new Padding(
                        0,
                        0,
                        0,
                        15
                    );

                card.SetData(item);

                flowInventory.Controls
                    .Add(card);
            }
        }
    }
}