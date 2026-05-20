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
                FileHelper.ReadJsonList<
                    InventoryItem
                >(FilePath);

            if (_inventoryItems == null)
            {
                _inventoryItems =
                    new List<InventoryItem>();
            }
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
            return new List<InventoryItem>( _inventoryItems);
        }

        public void Add(InventoryItem item)
        {
            _inventoryItems.Add(item);

            SaveData();
        }

        public int GetMinStock(
     string productId)
        {
            List<Product> products =
                FileHelper.ReadJsonList<Product>(
                    "products.json"
                );

            if (products == null)
            {
                return 0;
            }

            foreach (Product product
                in products)
            {
                if (product.ProductID
                    == productId)
                {
                    return product.MinStock;
                }
            }

            return 0;
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


        public List<InventoryItem>
            GetByProductId(
                string productId)
        {
            List<InventoryItem> result =
                new List<InventoryItem>();

            foreach (InventoryItem item
                in _inventoryItems)
            {
                if (item.ProductId
                    == productId)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public int GetTotalQuantity(
    string productId)
        {
            int total = 0;

            List<Batch> batches =
                FileHelper.ReadJsonList<Batch>(
                    "batch.json"
                );

            if (batches == null)
            {
                return 0;
            }

            foreach (Batch batch
                in batches)
            {
                if (batch.ProductId
                    == productId)
                {
                    total +=
                        batch.RemainingQuantity;
                }
            }

            return total;
        }
    }
}