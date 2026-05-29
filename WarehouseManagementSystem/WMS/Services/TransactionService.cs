using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Models.Inventory;

namespace WMS.Services
{
    internal class TransactionService
    {
        // Dependency: nhận InventoryItem từ ngoài
        public void ExportStock(InventoryItem item, int quantity)
        {
            foreach (var batch in item.Batches)
            {
                if (quantity <= 0) break;

                int take = Math.Min(batch.Quantity, quantity);
                batch.Quantity -= take;
                quantity -= take;
            }
        }
    }
}
