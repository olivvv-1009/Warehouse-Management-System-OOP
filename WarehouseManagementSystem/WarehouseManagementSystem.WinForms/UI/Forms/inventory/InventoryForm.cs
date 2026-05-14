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

            cbFilter.Items.Add("All");

            cbFilter.Items.Add("In Stock");

            cbFilter.Items.Add("Low Stock");

            cbFilter.Items.Add("Out Of Stock");

            cbFilter.SelectedIndex = 0;

            txtSearch.TextChanged +=
                FilterChanged;

            cbFilter.SelectedIndexChanged +=
                FilterChanged;
        }

        private void FilterChanged(
    object sender,
    EventArgs e)
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            flowInventory.Controls.Clear();

            List<InventoryItem>
                inventoryItems =
                    _inventoryController
                        .GetAllInventory();

            string keyword =
                txtSearch.Text
                    .Trim()
                    .ToLower();

            string filter =
                cbFilter.SelectedItem
                    .ToString();

            foreach (InventoryItem item
                in inventoryItems)
            {
                bool matchSearch =
                    item.ProductName
                        .ToLower()
                        .Contains(keyword)
                    ||
                    item.ProductId
                        .ToLower()
                        .Contains(keyword);

                string stockStatus =
                    "In Stock";

                if (item.Quantity
                    <= 0)
                {
                    stockStatus =
                        "Out Of Stock";
                }
                else if (item.Quantity
                    <= item.MinStock)
                {
                    stockStatus =
                        "Low Stock";
                }

                bool matchFilter =
                    filter == "All"
                    ||
                    stockStatus == filter;

                if (matchSearch
                    && matchFilter)
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

                    List<Batch> batches =
                        _inventoryController
                            .GetBatchesByProductId(
                                item.ProductId
                            );

                    card.LoadBatchData(
                        batches,
                        _inventoryController
                    );

                    flowInventory.Controls
                        .Add(card);
                }
            }
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

    }
}