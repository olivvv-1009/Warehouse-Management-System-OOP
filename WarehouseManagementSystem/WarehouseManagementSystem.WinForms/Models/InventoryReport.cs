namespace WarehouseManagementSystem.WinForms.Models;
public class InventoryReport : Report
{
    public string Product { get; set; }
    public string Category { get; set; }
    public int CurrentStock { get; set; }
    public int MinStock { get; set; }
    public string Status { get; set; }
}