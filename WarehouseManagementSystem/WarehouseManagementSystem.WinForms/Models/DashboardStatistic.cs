namespace WarehouseManagementSystem.WinForms.Models
{
    public class DashboardStatistic
    {
        public int TotalProducts { get; set; }

        public int TotalInventory { get; set; }

        public int LowStockItems { get; set; }

        public decimal InventoryValue { get; set; }
    }
}