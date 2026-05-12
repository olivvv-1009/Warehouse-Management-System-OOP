using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.ConsoleUI
{
    internal class ProductController
    {
        private readonly ProductService
            _productService;

        public ProductController()
        {
            _productService =
                new ProductService();
        }

        /// <summary>
        /// Add product
        /// </summary>
        public bool AddProduct(
            string name,
            string category,
            int minimumStock)
        {
            try
            {
                _productService.AddProduct(
                    name,
                    category,
                    minimumStock);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error adding product: {ex.Message}");

                return false;
            }
        }

        /// <summary>
        /// Update product
        /// </summary>
        public bool UpdateProduct(
            string productId,
            string name,
            string category,
            int minimumStock)
        {
            try
            {
                _productService.UpdateProduct(
                    productId,
                    name,
                    category,
                    minimumStock);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error updating product: {ex.Message}");

                return false;
            }
        }

        /// <summary>
        /// Delete product
        /// </summary>
        public bool DeleteProduct(
            string productId)
        {
            try
            {
                _productService.DeleteProduct(
                    productId);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error deleting product: {ex.Message}");

                return false;
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        public List<ProductDisplayModel>
            GetAllProducts()
        {
            try
            {
                return _productService
                    .GetAllProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error retrieving products: {ex.Message}");

                return new List<ProductDisplayModel>();
            }
        }

        /// <summary>
        /// Get single product
        /// </summary>
        public ProductDisplayModel
            GetProduct(string productId)
        {
            try
            {
                return _productService
                    .GetProduct(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error retrieving product: {ex.Message}");

                return null;
            }
        }
    }
}