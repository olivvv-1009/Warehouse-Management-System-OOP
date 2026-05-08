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
    internal class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly BatchRepository _batchRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
            _inventoryRepository = new InventoryRepository();
            _batchRepository = new BatchRepository();
        }

        /// <summary>
        /// Add a new product
        /// Step 1: Input product name, category, minimum stock
        /// Step 2: System processes - Load products.json, generate ProductID, create Product object,
        ///         set CreatedAt = DateTime.Now, add to list, save file
        /// Step 3: Create InventoryItem - Load inventory.json, create InventoryItem with ProductID and MinStock, save file
        /// </summary>
        public Product AddProduct(string name, string category, int minimumStock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty");

            if (minimumStock < 0)
                throw new ArgumentException("Minimum stock cannot be negative");

            // Step 2: Generate ProductID and create Product
            var allProducts = _productRepository.GetAll();
            int nextNumber = IdGenerator.GetNextNumber(allProducts.Select(p => p.ProductID).ToList(), "PR");
            string productId = IdGenerator.GenerateProductId(nextNumber);

            var product = new Product(productId, name, category)
            {
                CreatedAt = DateTime.Now
            };

            // Add to repository and save
            _productRepository.Add(product);

            // Step 3: Create InventoryItem
            var inventoryItem = new InventoryItem(productId, minimumStock);
            _inventoryRepository.Add(inventoryItem);

            return product;
        }

        /// <summary>
        /// Update an existing product
        /// Can only update: Name, Category, MinimumStock (not ID)
        /// Flow: Load products.json → Find product by ID → Update Name, Category → Save
        ///       Load inventory.json → Update MinStock → Save
        /// </summary>
        public void UpdateProduct(string productId, string name, string category, int minimumStock)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("Product ID cannot be empty");

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new InvalidOperationException($"Product with ID {productId} not found");

            if (!string.IsNullOrWhiteSpace(name))
                product.Name = name;

            if (!string.IsNullOrWhiteSpace(category))
                product.Category = category;

            // Update products.json
            _productRepository.Update(product);

            // Update inventory.json with new MinStock
            if (minimumStock >= 0)
            {
                var inventoryItem = _inventoryRepository.GetByProductId(productId);
                if (inventoryItem != null)
                {
                    inventoryItem.MinStock = minimumStock;
                    _inventoryRepository.Update(inventoryItem);
                }
            }
        }

        public void UpdateProduct(ProductDisplayModel model)
        {
            UpdateProduct(model.ProductID, model.Name, model.Category, model.MinStock);
        }

        /// <summary>
        /// Delete a product
        /// Only delete products that have never had imports
        /// Flow: Load batches.json → Check if batch exists with ProductID
        ///       If found, CANNOT delete
        ///       If valid: Delete from products.json and inventory.json
        /// </summary>
        public void DeleteProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("Product ID cannot be empty");

            // Check if product has any imports
            if (_batchRepository.ProductHasImports(productId))
                throw new InvalidOperationException($"Cannot delete product {productId}. Product has import history.");

            // Delete from products
            _productRepository.Delete(productId);

            // Delete from inventory
            _inventoryRepository.Delete(productId);
        }

        /// <summary>
        /// Get all products with their inventory and calculated average import price
        /// Flow: Load products.json → Load inventory.json → Load batch.json
        ///       For each product, calculate AVG import price:
        ///       - Load batches by ProductID
        ///       - Loop: totalValue += price * quantity, totalQty += quantity
        ///       - avg = totalValue / totalQty
        /// </summary>
        public List<ProductDisplayModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            var inventory = _inventoryRepository.GetAll();
            // If you have price info, fetch it here. For now, set AvgImportPrice = null.
            var result = products.Select(p =>
            {
                var inv = inventory.FirstOrDefault(i => i.ProductID == p.ProductID);
                return new ProductDisplayModel
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Category = p.Category,
                    MinStock = inv?.MinStock ?? 0,
                    AvgImportPrice = null // TODO: Set actual price if available
                };
            }).ToList();
            return result;
        }

        /// <summary>
        /// Get a single product with its inventory details
        /// </summary>
        public ProductDisplayModel GetProduct(string productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                return null;

            var inventoryItem = _inventoryRepository.GetByProductId(productId);
            decimal avgImportPrice = _batchRepository.GetAverageImportPrice(productId);

            return new ProductDisplayModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Category = product.Category,
                MinStock = inventoryItem?.MinStock ?? 0,
                
            };
        }

        public Product GetProductById(string productId)
        {
            return _productRepository.GetById(productId);
        }

        public bool ProductExists(string productId)
        {
            return _productRepository.Exists(productId);
        }

        public ProductDisplayModel GetProductDisplayById(string productId)
        {
            var all = GetAllProducts();
            return all.FirstOrDefault(p => p.ProductID == productId);
        }
    }
}
