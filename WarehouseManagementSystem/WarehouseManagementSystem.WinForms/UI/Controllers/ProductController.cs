using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.ConsoleUI
{
    internal class ProductController
    {
        private readonly ProductService _productService;
        private readonly InventoryService _inventoryService;

        public ProductController()
        {
            _productService = new ProductService();
            _inventoryService = new InventoryService();
        }

        /// <summary>
        /// Handle add product request
        /// </summary>
        public bool AddProduct(string name, string category, int minimumStock)
        {
            try
            {
                var product = _productService.AddProduct(name, category, minimumStock);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Handle update product request
        /// </summary>
        public bool UpdateProduct(string productId, string name, string category, int minimumStock)
        {
            try
            {
                _productService.UpdateProduct(productId, name, category, minimumStock);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Handle delete product request
        /// </summary>
        public bool DeleteProduct(string productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Get all products for display
        /// </summary>
        public List<ProductDisplayModel> GetAllProducts()
        {
            try
            {
                return _productService.GetAllProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving products: {ex.Message}");
                return new List<ProductDisplayModel>();
            }
        }

        /// <summary>
        /// Get a specific product
        /// </summary>
        public ProductDisplayModel GetProduct(string productId)
        {
            try
            {
                return _productService.GetProduct(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving product: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Add batch/import
        /// </summary>
        public bool AddBatch(string productId, int quantity, decimal price)
        {
            try
            {
                _inventoryService.AddBatch(productId, quantity, price);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding batch: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Get low stock products
        /// </summary>
        public List<InventoryItem> GetLowStockProducts()
        {
            try
            {
                return _inventoryService.GetLowStockProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving low stock products: {ex.Message}");
                return new List<InventoryItem>();
            }
        }
    }
}
