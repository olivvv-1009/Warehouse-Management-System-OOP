using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rules;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ReportService : IReportService
    {
        private ReportRepository repo;
        private ReportRule rule;

        public ReportService()
        {
            repo = new ReportRepository();
            rule = new ReportRule();
        }

        public List<InventoryReport> GetInventoryReport()
        {
            List<Product> products = repo.GetProducts();
            List<Batch> inventory = repo.GetInventory();

            List<InventoryReport> result =
                new List<InventoryReport>();

            for (int i = 0; i < products.Count; i++)
            {
                Product p = products[i];

                int currentStock = 0;

                for (int j = 0; j < inventory.Count; j++)
                {
                    if (inventory[j].ProductId == p.ProductID)
                    {
                        currentStock =
                            currentStock + inventory[j].AvailableQuantity;
                    }
                }

                InventoryReport model =
                    new InventoryReport();

                model.Product = p.Name;
                model.CurrentStock = currentStock;
                model.MinStock = p.MinStock;

                if (currentStock < p.MinStock)
                {
                    model.Status = "Low";
                }
                else
                {
                    model.Status = "Normal";
                }

                result.Add(model);
            }

            return result;
        }

        public List<LowStockReport> GetLowStockReport()
        {
            List<InventoryReport> inventory =
                GetInventoryReport();

            List<LowStockReport> result =
                new List<LowStockReport>();

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].CurrentStock < inventory[i].MinStock)
                {
                    LowStockReport model =
                        new LowStockReport();

                    model.Product = inventory[i].Product;
                    model.CurrentStock = inventory[i].CurrentStock;
                    model.MinStock = inventory[i].MinStock;
                    model.Shortage =
                        inventory[i].MinStock - inventory[i].CurrentStock;

                    result.Add(model);
                }
            }

            return result;
        }

        public int GetTotalImport()
        {
            return repo.GetTotalImport();
        }

        public int GetTotalExport()
        {
            return repo.GetTotalExport();
        }

        public ImportExportSummary GetSummary()
        {
            int importTotal = GetTotalImport();
            int exportTotal = GetTotalExport();

            ImportExportSummary model =
                new ImportExportSummary();

            model.TotalImport = importTotal;
            model.TotalExport = exportTotal;
            model.NetChange = importTotal - exportTotal;

            return model;
        }
    }
}