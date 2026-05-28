namespace WarehouseManagementSystem.WinForms.Models
{
    public class Destination
    {
        public string DestinationId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
