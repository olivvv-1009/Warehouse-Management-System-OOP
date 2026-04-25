using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    internal class InventoryItem
    {
        public string ProductID { get; set; }
        public int MinStock { get; set; }
        public int TotalStock { get; set; }

        public InventoryItem()
        {
            TotalStock = 0;
        }

        public InventoryItem(string productId, int minStock)
        {
            ProductID = productId;
            MinStock = minStock;
            TotalStock = 0;
        }
    }
}
