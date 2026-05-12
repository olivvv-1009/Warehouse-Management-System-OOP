using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class ImportRepository
    {
        private const string FilePath =
            "import.json";

        private List<ImportInvoice> _invoices;

        public ImportRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            _invoices =
                FileHelper.ReadJsonList<ImportInvoice>(
                    FilePath
                );
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                _invoices
            );
        }

        public List<ImportInvoice> GetAll()
        {
            return _invoices;
        }

        public void Add(ImportInvoice invoice)
        {
            _invoices.Add(invoice);

            SaveData();
        }
    }
}