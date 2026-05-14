using System;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Controllers
{
    internal class InventoryController
    {
        private readonly InventoryService
        _inventoryService;

        public InventoryController()
        {
            _inventoryService =
                new InventoryService();
        }

        public List<InventoryItem>
            GetAllInventory()
        {
            return _inventoryService
                .GetAllInventory();
        }

        public List<InventoryItem>
            GetLowStockItems()
        {
            return _inventoryService
                .GetLowStockItems();
        }
    }
}
