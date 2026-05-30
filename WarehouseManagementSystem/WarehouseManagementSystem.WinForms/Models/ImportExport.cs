namespace WarehouseManagementSystem.WinForms.Models
{
    public class ImportExport : Report
    {
        public DateTime Date { get; set; }
        public int ImportQty { get; set; }
        public int ExportQty { get; set; }
    }
}
