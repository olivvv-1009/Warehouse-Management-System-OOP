using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class ProductService
    {
        private readonly ProductRepository
            _productRepository;

        private readonly InventoryRepository
            _inventoryRepository;

        public ProductService()
        {
            _productRepository =
                new ProductRepository();

            _inventoryRepository =
                new InventoryRepository();
        }

        /// <summary>
        /// Add new product
        /// </summary>
        public Product AddProduct(
            string name,
            string category,
            int minimumStock)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Product name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException(
                    "Category cannot be empty");
            }

            if (minimumStock < 0)
            {
                throw new ArgumentException(
                    "Minimum stock cannot be negative");
            }

            var allProducts =
                _productRepository.GetAll();

            int nextNumber =
                IdGenerator.GetNextNumber(
                    allProducts
                    .Select(p => p.ProductID)
                    .ToList(),
                    "PR");

            string productId =
                IdGenerator.GenerateProductId(
                    nextNumber);

            var product = new Product(
                productId,
                name,
                category,
                minimumStock);

            _productRepository.Add(product);

            return product;
        }

        /// <summary>
        /// Update product
        /// </summary>
        public void UpdateProduct(
            string productId,
            string name,
            string category,
            int minimumStock)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException(
                    "Product ID cannot be empty");
            }

            Product product =
                _productRepository
                .GetById(productId);

            if (product == null)
            {
                throw new InvalidOperationException(
                    $"Product {productId} not found");
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                product.Name = name;
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                product.Category = category;
            }

            if (minimumStock >= 0)
            {
                product.MinStock =
                    minimumStock;
            }

            _productRepository.Update(product);
        }

        public void UpdateProduct(
            ProductDisplayModel model)
        {
            UpdateProduct(
                model.ProductID,
                model.Name,
                model.Category,
                model.MinStock);
        }

        /// <summary>
        /// Delete product
        /// Only if product has no inventory
        /// </summary>
        public void DeleteProduct(
            string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException(
                    "Product ID cannot be empty");
            }

            List<InventoryItem> inventoryItems = _inventoryRepository
        .GetByProductId(productId);

            if (inventoryItems.Count > 0)
            {
                throw new InvalidOperationException(
                    "Cannot delete product with inventory");
            }

            _productRepository.Delete(productId);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        public List<ProductDisplayModel>
            GetAllProducts()
        {
            var products =
                _productRepository.GetAll();

            return products.Select(p =>
                new ProductDisplayModel
                {
                    ProductID = p.ProductID,

                    Name = p.Name,

                    Category = p.Category,

                    MinStock = p.MinStock
                })
                .ToList();
        }

        /// <summary>
        /// Get single product
        /// </summary>
        public ProductDisplayModel
            GetProduct(string productId)
        {
            Product product =
                _productRepository
                .GetById(productId);

            if (product == null)
            {
                return null;
            }

            return new ProductDisplayModel
            {
                ProductID = product.ProductID,

                Name = product.Name,

                Category = product.Category,

                MinStock = product.MinStock
            };
        }

        public Product GetProductById(
            string productId)
        {
            return _productRepository
                .GetById(productId);
        }

        public bool ProductExists(
            string productId)
        {
            return _productRepository
                .Exists(productId);
        }

        public ProductDisplayModel
            GetProductDisplayById(
            string productId)
        {
            var all =
                GetAllProducts();

            return all.FirstOrDefault(
                p => p.ProductID == productId);
        }
    }
}