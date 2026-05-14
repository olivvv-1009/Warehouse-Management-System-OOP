using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Controllers
{
    public class InventoryController
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

        public List<Batch>
            GetBatchesByProductId(
                string productId)
        {
            return _inventoryService
                .GetBatchesByProductId(
                    productId
                );
        }

        public WarehouseLocation
    GetLocationByCode(
        string locationCode)
        {
            return _inventoryService
                .GetLocationByCode(
                    locationCode
                );
        }

        public string GetSupplierNameByBatch(
    string batchId)
        {
            return _inventoryService
                .GetSupplierNameByBatch(
                    batchId
                );
        }
    }
}