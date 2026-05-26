using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ReportRepository
    {
        public List<Product> GetProducts()
        {
            List<Product> list =
                FileHelper.ReadJsonList<Product>("products.json");

            if (list == null)
                list = new List<Product>();

            return list;
        }

        public List<InventoryItem> GetInventory()
        {
            List<InventoryItem> list =
                FileHelper.ReadJsonList<InventoryItem>("inventory.json");

            if (list == null)
                list = new List<InventoryItem>();

            return list;
        }

        public int GetTotalImport()
        {
            List<ImportInvoice> imports =
                FileHelper.ReadJsonList<ImportInvoice>("import.json");

            if (imports == null)
                imports = new List<ImportInvoice>();
            int total = 0;

            for (int i = 0; i < imports.Count; i++)
            {
                for (int j = 0; j < imports[i].OrderDetails.Count; j++)
                {
                    total += imports[i].OrderDetails[j].Quantity;
                }
            }

            return total;
        }

        public int GetTotalExport()
        {
            List<ExportInvoice> exports =
                FileHelper.ReadJsonList<ExportInvoice>("export.json");

            if (exports == null)
                exports = new List<ExportInvoice>();
            int total = 0;

            for (int i = 0; i < exports.Count; i++)
            {
                for (int j = 0; j < exports[i].OrderDetails.Count; j++)
                {
                    total += exports[i].OrderDetails[j].Quantity;
                }
            }

            return total;
        }
    }
}