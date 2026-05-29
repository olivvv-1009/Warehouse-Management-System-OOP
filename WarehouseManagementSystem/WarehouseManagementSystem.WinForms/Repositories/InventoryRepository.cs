using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class InventoryRepository
    {
        private const string ProductFile =
            "products.json";

        private const string BatchFile =
            "batch.json";

        public List<InventoryItem>
            GetAll()
        {
            List<InventoryItem> result =
                new List<InventoryItem>();

            List<Product> products =
                FileHelper.ReadJsonList<Product>(
                    ProductFile
                );

            List<Batch> batches =
                FileHelper.ReadJsonList<Batch>(
                    BatchFile
                );

            if (products == null)
            {
                return result;
            }

            if (batches == null)
            {
                batches =
                    new List<Batch>();
            }

            foreach (Product product
                in products)
            {
                int totalQuantity = 0;

                foreach (Batch batch
                    in batches)
                {
                    if (batch.ProductId
                        == product.ProductID)
                    {
                        totalQuantity +=
                            batch.AvailableQuantity;
                    }
                }

                InventoryItem item =
                    new InventoryItem();

                item.ProductId =
                    product.ProductID;

                item.ProductName =
                    product.Name;

                item.MinStock =
                    product.MinStock;

                item.Quantity =
                    totalQuantity;

                result.Add(item);
            }

            return result;
        }

        public InventoryItem Find(
            string productId)
        {
            List<InventoryItem>
                inventoryItems =
                    GetAll();

            foreach (InventoryItem item
                in inventoryItems)
            {
                if (item.ProductId
                    == productId)
                {
                    return item;
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

            List<InventoryItem>
                inventoryItems =
                    GetAll();

            foreach (InventoryItem item
                in inventoryItems)
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
                    BatchFile
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
                        batch.AvailableQuantity;
                }
            }

            return total;
        }

        public int GetMinStock(
            string productId)
        {
            List<Product> products =
                FileHelper.ReadJsonList<Product>(
                    ProductFile
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

        public bool IsLowStock(
            string productId)
        {
            int totalQuantity =
                GetTotalQuantity(
                    productId
                );

            int minStock =
                GetMinStock(
                    productId
                );

            return totalQuantity
                <= minStock;
        }
    }
}