using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Interfaces
{
    public interface IDashboardService
    {
        DashboardStatistic
            GetStatistics();

        List<Transaction>
            GetRecentTransactions();

        List<InventoryItem>
            GetLowStockItems();

        Dictionary<string, int>
            GetCategoryDistribution();

        Dictionary<string, int>
            GetImportExportChart();
    }
}