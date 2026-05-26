using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Interfaces
{
    public interface IReportService
    {
        List<InventoryReport> GetInventoryReport();

        List<LowStockReport> GetLowStockReport();

        int GetTotalImport();

        int GetTotalExport();

        ImportExportSummary GetSummary();
    }
}