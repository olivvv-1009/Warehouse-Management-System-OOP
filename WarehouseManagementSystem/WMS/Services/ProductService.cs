using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models.Products;
using WarehouseManagementSystem.WinForms.Repositories;
using WMS.Models.Inventory;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly BatchRepository _batchRepository;

        public ProductService(
            ProductRepository productRepository = null,
            InventoryRepository inventoryRepository = null,
            BatchRepository batchRepository = null)
        {
            _productRepository = productRepository ?? new ProductRepository();
            _inventoryRepository = inventoryRepository ?? new InventoryRepository();
            _batchRepository = batchRepository ?? new BatchRepository();
        }

        /// <summary>
        /// Adds a new product with the specified name, category, and minimum stock.
        /// Automatically generates ProductId and sets CreatedAt timestamp.
        /// </summary>
        public string AddProduct(string productName, string category, int minStock, double importPrice = 0, double exportPrice = 0)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Category cannot be empty.");
            }

            if (minStock < 0)
            {
                throw new ArgumentException("Minimum stock cannot be negative.");
            }

            // Step 1: Generate ProductID (PR0001, PR0002...)
            var productId = _productRepository.GenerateNextProductId();

            // Step 2: Create Product object and set CreatedAt
            var product = new Product
            {
                ProductId = productId,
                ProductName = productName,
                Category = category,
                ImportPrice = importPrice,
                ExportPrice = exportPrice,
                CreatedAt = DateTime.Now
            };

            // Step 3: Save to products.json
            _productRepository.AddProduct(product);

            // Step 4: Create and save InventoryItem
            var inventoryItem = new InventoryItem
            {
                ProductId = productId,
                MinStock = minStock,
                Quantity = 0
            };

            _inventoryRepository.AddInventoryItem(inventoryItem);

            return productId;
        }

        /// <summary>
        /// Updates an existing product. Can only modify Name, Category, and MinStock.
        /// Cannot modify ProductID.
        /// </summary>
        public void UpdateProduct(string productId, string productName, string category, int minStock)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Category cannot be empty.");
            }

            if (minStock < 0)
            {
                throw new ArgumentException("Minimum stock cannot be negative.");
            }

            // Load and verify product exists
            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} not found.");
            }

            // Update product information
            product.ProductName = productName;
            product.Category = category;

            _productRepository.UpdateProduct(product);

            // Update inventory minimum stock
            var inventoryItem = _inventoryRepository.GetInventoryItemByProductId(productId);
            if (inventoryItem != null)
            {
                inventoryItem.MinStock = minStock;
                _inventoryRepository.UpdateInventoryItem(inventoryItem);
            }
        }

        /// <summary>
        /// Deletes a product only if it hasn't been imported/stocked yet.
        /// Checks batches.json to ensure no batches exist for this product.
        /// </summary>
        public void DeleteProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID cannot be empty.");
            }

            // Check if product has any batches (imports)
            var batches = _batchRepository.GetBatchesByProductId(productId);
            if (batches.Count > 0)
            {
                throw new Exception($"Cannot delete product {productId}. It has import history ({batches.Count} batch(es)) and must be retained for audit purposes.");
            }

            // Delete from products.json
            _productRepository.DeleteProduct(productId);

            // Delete from inventory.json
            _inventoryRepository.DeleteInventoryItem(productId);
        }

        /// <summary>
        /// Gets all products with their inventory information including total stock and average import price.
        /// </summary>
        public List<ProductDisplayInfo> GetAllProductsWithInventory()
        {
            var products = _productRepository.LoadAllProducts();
            var inventoryItems = _inventoryRepository.LoadAllInventoryItems();
            var allBatches = _batchRepository.LoadAllBatches();

            var result = new List<ProductDisplayInfo>();

            foreach (var product in products)
            {
                var inventory = inventoryItems.FirstOrDefault(i => i.ProductId == product.ProductId);
                var productBatches = allBatches.Where(b => b.ProductId == product.ProductId).ToList();

                // Calculate total stock and average import price
                var totalQuantity = productBatches.Sum(b => b.Quantity);
                var avgImportPrice = CalculateAverageImportPrice(productBatches);

                var displayInfo = new ProductDisplayInfo
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Category = product.Category,
                    MinStock = inventory?.MinStock ?? 0,
                    TotalStock = totalQuantity,
                    AvgImportPrice = avgImportPrice,
                    ImportPrice = product.ImportPrice,
                    ExportPrice = product.ExportPrice,
                    CreatedAt = product.CreatedAt
                };

                result.Add(displayInfo);
            }

            return result;
        }

        /// <summary>
        /// Gets a specific product with its inventory information.
        /// </summary>
        public ProductDisplayInfo GetProductWithInventory(string productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} not found.");
            }

            var inventory = _inventoryRepository.GetInventoryItemByProductId(productId);
            var batches = _batchRepository.GetBatchesByProductId(productId);

            var totalQuantity = batches.Sum(b => b.Quantity);
            var avgImportPrice = CalculateAverageImportPrice(batches);

            return new ProductDisplayInfo
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Category = product.Category,
                MinStock = inventory?.MinStock ?? 0,
                TotalStock = totalQuantity,
                AvgImportPrice = avgImportPrice,
                ImportPrice = product.ImportPrice,
                ExportPrice = product.ExportPrice,
                CreatedAt = product.CreatedAt
            };
        }

        /// <summary>
        /// Gets all products (simple list without inventory details).
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _productRepository.LoadAllProducts();
        }

        /// <summary>
        /// Gets a single product by ID.
        /// </summary>
        public Product GetProductById(string productId)
        {
            return _productRepository.GetProductById(productId);
        }

        /// <summary>
        /// Calculates average import price from batch records.
        /// Average = Total Value / Total Quantity
        /// </summary>
        private double CalculateAverageImportPrice(List<WarehouseManagementSystem.WinForms.Repositories.BatchRecord> batches)
        {
            if (batches == null || batches.Count == 0)
            {
                return 0;
            }

            var totalValue = batches.Sum(b => b.Price * b.Quantity);
            var totalQuantity = batches.Sum(b => b.Quantity);

            if (totalQuantity == 0)
            {
                return 0;
            }

            return totalValue / totalQuantity;
        }
    }

    /// <summary>
    /// DTO for displaying product information with inventory details
    /// </summary>
    public class ProductDisplayInfo
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int MinStock { get; set; }
        public int TotalStock { get; set; }
        public double AvgImportPrice { get; set; }
        public double ImportPrice { get; set; }
        public double ExportPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
