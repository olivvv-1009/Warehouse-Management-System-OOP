using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class InventoryService
    {
        private readonly ProductRepository
            _productRepository;

        private readonly BatchRepository
            _batchRepository;

        private readonly BatchService
            _batchService;

        private readonly LocationService
            _locationService;

        public InventoryService()
        {
            _productRepository =
                new ProductRepository();

            _batchRepository =
                new BatchRepository();

            _batchService =
                new BatchService();

            _locationService =
                new LocationService();
        }

        public List<InventoryItem>
            GetAllInventory()
        {
            List<InventoryItem> result =
                new List<InventoryItem>();

            List<Product> products =
                _productRepository.GetAll();

            foreach (Product product
                in products)
            {
                int totalQuantity = 0;

                List<Batch> productBatches =
                    _batchRepository.GetByProductId(
                        product.ProductID
                    );

                foreach (Batch batch
                    in productBatches)
                {
                    totalQuantity +=
                        batch.RemainingQuantity;
                }

                InventoryItem item =
                    new InventoryItem();

                item.ProductId =
                    product.ProductID;

                item.ProductName =
                    product.Name;

                item.MinStock =
                    product.MinStock;

                int totalQuantity = 0;

                List<Batch> productBatches =
                    _batchRepository.GetByProductId(
                        product.ProductID
                    );

                foreach (Batch batch
    in productBatches)
                {
                    totalQuantity +=
                        batch.RemainingQuantity;
                }

                item.Quantity =
                    totalQuantity;

                result.Add(item);
            }

            return result;
        }

        public int GetTotalQuantity(
    string productId)
        {
            int total = 0;

            List<Batch> batches =
                _batchRepository.GetByProductId(
                    productId
                );

            foreach (Batch batch
                in batches)
            {
                total +=
                    batch.RemainingQuantity;
            }

            return total;
        }

        public List<InventoryItem>
            GetLowStockItems()
        {
            List<InventoryItem> result =
                new List<InventoryItem>();

            List<InventoryItem>
                inventoryItems =
                    GetAllInventory();

            foreach (InventoryItem item
                in inventoryItems)
            {
                if (item.Quantity
                    <= item.MinStock)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public InventoryItem FindInventoryByProductId(
            string productId)
        {
            List<InventoryItem>
                inventoryItems =
                    GetAllInventory();

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

        public List<Batch>
            GetBatchesByProductId(
                string productId)
        {
            return _batchRepository
                .GetByProductId(
                    productId
                );
        }

        public WarehouseLocation
            GetLocationByCode(
                string locationCode)
        {
            return _locationService
                .FindLocationByCode(
                    locationCode
                );
        }

        public string GetSupplierNameByBatch(
            string batchId)
        {
            return _batchService
                .GetSupplierNameByBatch(
                    batchId
                );
        }

        public bool IsLowStock(
            string productId)
        {
            InventoryItem item =
                FindInventoryByProductId(
                    productId
                );

            if (item == null)
            {
                return false;
            }

            return item.Quantity
                <= item.MinStock;
        }
    }
}
