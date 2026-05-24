using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.Controllers
{
    public class DashboardController
    {
        private DashboardService service;

        public DashboardController()
        {
            service =
                new DashboardService();
        }

        public DashboardStatistic
            GetStatistics()
        {
            return service.GetStatistics();
        }

        public List<Transaction>
            GetRecentTransactions()
        {
            return service
                .GetRecentTransactions();
        }

        public List<InventoryItem>
            GetLowStockItems()
        {
            return service
                .GetLowStockItems();
        }

        public Dictionary<string, int>
            GetCategoryDistribution()
        {
            return service
                .GetCategoryDistribution();
        }

        public Dictionary<string, int>
            GetImportExportChart()
        {
            return service
                .GetImportExportChart();
        }

        public List<Transaction>
    GetAllTransactions()
        {
            return service
                .GetAllTransactions();
        }

        public string GetProductCategory(
            string productId
        )
        {
            return service
                .GetProductCategory(
                    productId
                );
        }
    }
}