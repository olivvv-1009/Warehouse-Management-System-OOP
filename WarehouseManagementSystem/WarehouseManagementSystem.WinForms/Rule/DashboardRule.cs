using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rules
{
    public class DashboardRule
    {
        public bool IsLowStock(
            InventoryItem item
        )
        {
            if (item == null)
            {
                return false;
            }

            return item.StockStatus
                == "Low Stock";
        }

        public decimal CalculateInventoryValue(
            int quantity,
            decimal price
        )
        {
            return quantity * price;
        }
    }
}