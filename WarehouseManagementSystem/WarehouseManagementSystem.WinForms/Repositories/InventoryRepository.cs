using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class InventoryRepository
    {
        private const string FilePath =
            "inventory.json";

        private List<InventoryItem> _inventoryItems;

        public InventoryRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            _inventoryItems =
                FileHelper.ReadJsonList<InventoryItem>(
                    FilePath
                );
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                _inventoryItems
            );
        }

        public List<InventoryItem> GetAll()
        {
            return _inventoryItems;
        }

        public void Add(InventoryItem item)
        {
            _inventoryItems.Add(item);

            SaveData();
        }

        public void Update()
        {
            SaveData();
        }

        public InventoryItem Find(
            string productId,
            string batchId,
            string locationCode)
        {
            int i;

            for (i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].ProductId
                    == productId
                    && _inventoryItems[i].BatchId
                    == batchId
                    && _inventoryItems[i].LocationCode
                    == locationCode)
                {
                    return _inventoryItems[i];
                }
            }

            return null;
        }

        public int GetTotalQuantity(
            string productId)
        {
            int total = 0;

            int i;

            for (i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].ProductId
                    == productId)
                {
                    total +=
                        _inventoryItems[i].Quantity;
                }
            }

            return total;
        }

        public InventoryItem GetByProductId(string productId)
        {
            foreach (InventoryItem item
                in _inventoryItems)
            {
                if (item.ProductId == productId)
                {
                    return item;
                }
            }

            return null;
        }
    }
}