using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly BatchRepository _batchRepository;
        private readonly ProductRepository _productRepository;

        public InventoryService()
        {
            _inventoryRepository = new InventoryRepository();
            _batchRepository = new BatchRepository();
            _productRepository = new ProductRepository();
        }

        /// <summary>
        /// Add a batch (import) to the system
        /// Updates inventory total stock accordingly
        /// </summary>
        public Batch AddBatch(string productId, int quantity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("Product ID cannot be empty");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            // Check if product exists
            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new InvalidOperationException($"Product with ID {productId} not found");

            // Generate Batch ID
            var allBatches = _batchRepository.GetAll();
            int nextNumber = IdGenerator.GetNextNumber(allBatches.Select(b => b.BatchId).ToList(), "BA");
            string batchId = IdGenerator.GenerateBatchId(nextNumber);

            // Create batch
            var batch = new Batch(batchId, productId, quantity, price)
            {
                ImportDate = DateTime.Now
            };

            // Add batch to repository
            _batchRepository.Add(batch);

            // Update inventory total stock
            _inventoryRepository.UpdateTotalStock(productId, quantity);

            return batch;
        }

        /// <summary>
        /// Get inventory details for a specific product
        /// </summary>
        public InventoryItem GetInventory(string productId)
        {
            return _inventoryRepository.GetByProductId(productId);
        }

        /// <summary>
        /// Get all inventory items
        /// </summary>
        public List<InventoryItem> GetAllInventory()
        {
            return _inventoryRepository.GetAll();
        }

        /// <summary>
        /// Get all batches for a specific product
        /// </summary>
        public List<Batch> GetBatchesByProduct(string productId)
        {
            return _batchRepository.GetByProductId(productId);
        }

        /// <summary>
        /// Get all batches
        /// </summary>
        public List<Batch> GetAllBatches()
        {
            return _batchRepository.GetAll();
        }

        /// <summary>
        /// Calculate average import price for a product
        /// Recalculated each run based on batch data:
        /// - Load batches.json
        /// - Filter by ProductID
        /// - Loop: totalValue += price * quantity, totalQty += quantity
        /// - avg = totalValue / totalQty
        /// </summary>
        public decimal CalculateAverageImportPrice(string productId)
        {
            return _batchRepository.GetAverageImportPrice(productId);
        }

        /// <summary>
        /// Check if inventory is below minimum stock
        /// </summary>
        public bool IsLowStock(string productId)
        {
            var inventory = GetInventory(productId);
            if (inventory == null)
                return false;

            return inventory.TotalQuantity < inventory.MinStock;
        }

        /// <summary>
        /// Get all products with low stock
        /// </summary>
        public List<InventoryItem> GetLowStockProducts()
        {
            var allInventory = GetAllInventory();
            return allInventory.Where(i => i.TotalQuantity < i.MinStock).ToList();
        }
    }
}
