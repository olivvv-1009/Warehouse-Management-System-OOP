using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.Controllers
{
    public class ReportController
    {
        private ReportService service;

        public ReportController()
        {
            service = new ReportService();
        }

        public List<InventoryReport> Inventory()
        {
            return service.GetInventoryReport();
        }

        public List<LowStockReport> LowStock()
        {
            return service.GetLowStockReport();
        }

        public ImportExportSummary Summary()
        {
            return service.GetSummary();
        }
    }
}