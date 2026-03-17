using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMS.Models.Inventory;
using WMS.Models.Products;

namespace WMS.Services
{
    public class InventoryService
    {
        // Dependency: nhận InventoryItem từ ngoài
        public void AddStock(InventoryItem item, int quantity)
        {
            item.AddStock(quantity);
        }

    }
}
