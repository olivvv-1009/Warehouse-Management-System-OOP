using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Utils
{
    internal static class Session
    {
        public static Account? CurrentUser { get; set; }
        public static Profile? CurrentProfile { get; set; }
    }
}