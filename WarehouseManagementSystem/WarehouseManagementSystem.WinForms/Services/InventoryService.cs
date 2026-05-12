using System;
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

        public InventoryService()
        {
            _inventoryRepository =
                new InventoryRepository();

            _productRepository =
                new ProductRepository();
        }

        public List<InventoryItem>
            GetAllInventory()
        {
            List<InventoryItem> inventoryItems =
                _inventoryRepository.GetAll();

            List<Product> products =
                _productRepository.GetAll();

            foreach (InventoryItem item
                in inventoryItems)
            {
                foreach (Product product
                    in products)
                {
                    if (product.ProductID
                        == item.ProductId)
                    {
                        item.ProductName =
                            product.Name;

                        break;
                    }
                }
            }

            return inventoryItems;
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
                .GetTotalQuantity(productId);
        }

        public List<InventoryItem>
            GetLowStockItems()
        {
            List<InventoryItem> lowStockItems =
                new List<InventoryItem>();

            List<InventoryItem> inventoryItems =
                GetAllInventory();

            foreach (InventoryItem item
                in inventoryItems)
            {
                if (item.Quantity
                    <= item.MinStock)
                {
                    lowStockItems.Add(item);
                }
            }

            return lowStockItems;
        }
    }
}