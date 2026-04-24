using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using WarehouseManagementSystem.WinForms.Models.Products;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ProductRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductRepository(string filePath = "Data/products.json")
        {
            _filePath = filePath;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public List<Product> LoadAllProducts()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Product>();
                }

                var json = File.ReadAllText(_filePath);
                var products = JsonSerializer.Deserialize<List<Product>>(json, _jsonOptions);
                return products ?? new List<Product>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading products from file: {ex.Message}", ex);
            }
        }

        public void SaveAllProducts(List<Product> products)
        {
            try
            {
                EnsureDirectoryExists();
                var json = JsonSerializer.Serialize(products, _jsonOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving products to file: {ex.Message}", ex);
            }
        }

        public Product GetProductById(string productId)
        {
            var products = LoadAllProducts();
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void AddProduct(Product product)
        {
            var products = LoadAllProducts();
            if (products.Any(p => p.ProductId == product.ProductId))
            {
                throw new Exception($"Product with ID {product.ProductId} already exists.");
            }
            products.Add(product);
            SaveAllProducts(products);
        }

        public void UpdateProduct(Product product)
        {
            var products = LoadAllProducts();
            var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
            {
                throw new Exception($"Product with ID {product.ProductId} not found.");
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.ImportPrice = product.ImportPrice;
            existingProduct.ExportPrice = product.ExportPrice;

            SaveAllProducts(products);
        }

        public void DeleteProduct(string productId)
        {
            var products = LoadAllProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} not found.");
            }

            products.Remove(product);
            SaveAllProducts(products);
        }

        public string GenerateNextProductId()
        {
            var products = LoadAllProducts();
            if (products.Count == 0)
            {
                return "PR0001";
            }

            // Extract numeric part from ProductId and find the maximum
            var maxNumber = products
                .Where(p => p.ProductId.StartsWith("PR"))
                .Select(p =>
                {
                    if (int.TryParse(p.ProductId.Substring(2), out int num))
                    {
                        return num;
                    }
                    return 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return $"PR{(maxNumber + 1):D4}";
        }
    }
}
