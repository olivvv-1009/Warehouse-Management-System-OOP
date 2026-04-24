using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models.Products;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.Examples
{
    /// <summary>
    /// Example usage of the ProductService for managing products
    /// This file demonstrates how to use the product management features
    /// </summary>
    public class ProductManagementExample
    {
        public static void Main()
        {
            try
            {
                // Initialize the product service
                var productService = new ProductService();

                Console.WriteLine("=== Warehouse Management System - Product Management ===\n");

                // Example 1: Add Products
                Console.WriteLine("1. Adding Products...");
                AddProductsExample(productService);

                // Example 2: Display All Products
                Console.WriteLine("\n2. Displaying All Products...");
                DisplayAllProductsExample(productService);

                // Example 3: Get Single Product
                Console.WriteLine("\n3. Getting Specific Product...");
                GetSingleProductExample(productService);

                // Example 4: Update Product
                Console.WriteLine("\n4. Updating Product...");
                UpdateProductExample(productService);

                // Example 5: Display Updated Products
                Console.WriteLine("\n5. Displaying Products After Update...");
                DisplayAllProductsExample(productService);

                // Example 6: Delete Product (commented out to preserve data)
                // Console.WriteLine("\n6. Deleting Product...");
                // DeleteProductExample(productService);

                Console.WriteLine("\n=== Examples Complete ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void AddProductsExample(ProductService service)
        {
            try
            {
                // Add Product 1
                var productId1 = service.AddProduct(
                    productName: "Dell XPS 15",
                    category: "Electronics",
                    minStock: 5,
                    importPrice: 15000000,
                    exportPrice: 16000000
                );
                Console.WriteLine($"✓ Added product: {productId1}");

                // Add Product 2
                var productId2 = service.AddProduct(
                    productName: "Fresh Milk",
                    category: "Food",
                    minStock: 50,
                    importPrice: 25000,
                    exportPrice: 35000
                );
                Console.WriteLine($"✓ Added product: {productId2}");

                // Add Product 3
                var productId3 = service.AddProduct(
                    productName: "Paper A4",
                    category: "Consumable",
                    minStock: 100,
                    importPrice: 75000,
                    exportPrice: 85000
                );
                Console.WriteLine($"✓ Added product: {productId3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error adding products: {ex.Message}");
            }
        }

        private static void DisplayAllProductsExample(ProductService service)
        {
            try
            {
                var products = service.GetAllProductsWithInventory();

                if (products.Count == 0)
                {
                    Console.WriteLine("No products found.");
                    return;
                }

                Console.WriteLine($"Found {products.Count} product(s):\n");

                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}");
                    Console.WriteLine($"Name: {product.ProductName}");
                    Console.WriteLine($"Category: {product.Category}");
                    Console.WriteLine($"Min Stock: {product.MinStock}");
                    Console.WriteLine($"Total Stock: {product.TotalStock}");
                    Console.WriteLine($"Avg Import Price: {product.AvgImportPrice:N0}");
                    Console.WriteLine($"Import Price: {product.ImportPrice:N0}");
                    Console.WriteLine($"Export Price: {product.ExportPrice:N0}");
                    Console.WriteLine($"Created At: {product.CreatedAt:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine("---");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error displaying products: {ex.Message}");
            }
        }

        private static void GetSingleProductExample(ProductService service)
        {
            try
            {
                var product = service.GetProductWithInventory("PR0001");

                if (product != null)
                {
                    Console.WriteLine($"Found product: {product.ProductName}");
                    Console.WriteLine($"  - ID: {product.ProductId}");
                    Console.WriteLine($"  - Category: {product.Category}");
                    Console.WriteLine($"  - Min Stock: {product.MinStock}");
                    Console.WriteLine($"  - Total Stock: {product.TotalStock}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error: {ex.Message}");
            }
        }

        private static void UpdateProductExample(ProductService service)
        {
            try
            {
                // Update first product
                service.UpdateProduct(
                    productId: "PR0001",
                    productName: "Dell XPS 15 Pro",
                    category: "Premium Electronics",
                    minStock: 10
                );
                Console.WriteLine("✓ Product updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error updating product: {ex.Message}");
            }
        }

        private static void DeleteProductExample(ProductService service)
        {
            try
            {
                // Try to delete a product (will fail if it has import history)
                service.DeleteProduct("PR0003");
                Console.WriteLine("✓ Product deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Cannot delete product: {ex.Message}");
            }
        }
    }
}
