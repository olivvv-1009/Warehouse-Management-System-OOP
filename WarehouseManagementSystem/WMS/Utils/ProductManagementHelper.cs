using System;

namespace WarehouseManagementSystem.WinForms.Utils
{
    /// <summary>
    /// Helper utilities for product management operations
    /// Provides common functionality and constants
    /// </summary>
    public static class ProductManagementHelper
    {
        // Default data directories
        public const string DATA_DIRECTORY = "Data";
        public const string PRODUCTS_FILE = "Data/products.json";
        public const string INVENTORY_FILE = "Data/inventory.json";
        public const string BATCHES_FILE = "Data/batches.json";

        // Product ID format constants
        public const string PRODUCT_ID_PREFIX = "PR";
        public const int PRODUCT_ID_FORMAT_LENGTH = 4; // e.g., "0001"

        /// <summary>
        /// Validates if a product ID follows the correct format (PR####)
        /// </summary>
        public static bool IsValidProductId(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                return false;

            if (!productId.StartsWith(PRODUCT_ID_PREFIX))
                return false;

            var numericPart = productId.Substring(PRODUCT_ID_PREFIX.Length);
            return int.TryParse(numericPart, out _);
        }

        /// <summary>
        /// Validates product name
        /// </summary>
        public static bool IsValidProductName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 1 && name.Length <= 255;
        }

        /// <summary>
        /// Validates category name
        /// </summary>
        public static bool IsValidCategory(string category)
        {
            return !string.IsNullOrWhiteSpace(category) && category.Length >= 1 && category.Length <= 100;
        }

        /// <summary>
        /// Validates minimum stock value
        /// </summary>
        public static bool IsValidMinStock(int minStock)
        {
            return minStock >= 0 && minStock <= 999999;
        }

        /// <summary>
        /// Validates price value
        /// </summary>
        public static bool IsValidPrice(double price)
        {
            return price >= 0 && price <= 999999999;
        }

        /// <summary>
        /// Formats a price for display
        /// </summary>
        public static string FormatPrice(double price)
        {
            return price.ToString("N0");
        }

        /// <summary>
        /// Formats a timestamp for display
        /// </summary>
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Gets a user-friendly status message for low stock
        /// </summary>
        public static string GetStockStatus(int currentStock, int minStock)
        {
            if (currentStock <= minStock)
                return "LOW STOCK ⚠️";
            else if (currentStock > minStock * 2)
                return "ADEQUATE ✓";
            else
                return "NORMAL";
        }
    }
}
