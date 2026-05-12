using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Product
    {
        public string ProductID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int MinStock { get; set; }

        public DateTime CreatedAt { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
        }

        // Constructor cũ
        public Product(
            string productId,
            string name,
            string category)
        {
            ProductID = productId;

            Name = name;

            Category = category;

            CreatedAt = DateTime.Now;
        }

        // Constructor mới
        public Product(
            string productId,
            string name,
            string category,
            int minStock)
        {
            ProductID = productId;

            Name = name;

            Category = category;

            MinStock = minStock;

            CreatedAt = DateTime.Now;
        }
    }
}