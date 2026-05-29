namespace WarehouseManagementSystem.WinForms.Models
{
    public class LowStockReport
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public int CurrentStock { get; set; }
        public int MinStock { get; set; }
        public int Shortage { get; set; }
    }
}
