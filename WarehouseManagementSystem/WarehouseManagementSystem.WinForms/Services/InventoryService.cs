using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class InventoryService
    {
        private readonly InventoryRepository
            _inventoryRepository;

        private readonly ProductRepository
            _productRepository;

        private readonly BatchRepository
            _batchRepository;

        private readonly LocationService
            _locationService;

        public InventoryService()
        {
            _inventoryRepository =
                new InventoryRepository();

            _productRepository =
                new ProductRepository();

            _batchRepository =
                new BatchRepository();

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
                InventoryItem item =
                    new InventoryItem();

                item.ProductId =
                    product.ProductID;

                item.ProductName =
                    product.Name;

                item.MinStock =
                    product.MinStock;

                item.Quantity =
                    _inventoryRepository
                        .GetTotalQuantity(
                            product.ProductID
                        );

                result.Add(item);
            }

            return result;
        }

        public void AddInventoryItem(
            InventoryItem item)
        {
            _inventoryRepository.Add(item);
        }

        public int GetTotalQuantity(
            string productId)
        {
            return _inventoryRepository
                .GetTotalQuantity(
                    productId
                );
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
    }
}