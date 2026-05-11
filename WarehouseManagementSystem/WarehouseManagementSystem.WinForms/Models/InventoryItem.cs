using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    internal class InventoryItem
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int TotalQuantity { get; set; }

        public int MinStock { get; set; }

        public string StockStatus { get; set; }

        public InventoryItem()
        {
            ProductId = string.Empty;
            ProductName = string.Empty;

            TotalQuantity = 0;
            MinStock = 0;

            StockStatus = "OK";
        }
    }
}
