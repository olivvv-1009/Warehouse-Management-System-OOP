namespace WarehouseManagementSystem.WinForms.Models
{
    public abstract class Report
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ReportName { get; set; }
    }
}