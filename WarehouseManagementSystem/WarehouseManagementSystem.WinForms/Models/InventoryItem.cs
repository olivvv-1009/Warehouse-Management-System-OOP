using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    internal class InventoryItem
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string BatchId { get; set; }

        public string LocationCode { get; set; }

        public int Quantity { get; set; }

        public int MinStock { get; set; }

        public DateTime ImportDate { get; set; }

        public DateTime LastUpdated { get; set; }

        public string StockStatus
        {
            get
            {
                if (Quantity <= 0)
                {
                    return "Out Of Stock";
                }

                if (Quantity <= MinStock)
                {
                    return "Low Stock";
                }

                return "In Stock";
            }
        }

        public InventoryItem()
        {
            ProductId = string.Empty;

            ProductName = string.Empty;

            BatchId = string.Empty;

            LocationCode = string.Empty;

            Quantity = 0;

            MinStock = 0;

            ImportDate = DateTime.Now;

            LastUpdated = DateTime.Now;
        }
    }
}