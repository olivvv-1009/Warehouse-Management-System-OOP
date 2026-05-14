using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ImportRepository
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

            if (_invoices == null)
            {
                _invoices =
                    new List<ImportInvoice>();
            }
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

        public void Update(
            List<ImportInvoice> invoices)
        {
            _invoices = invoices;

            SaveData();
        }

        public bool AddImportInvoice(
    ImportInvoice invoice)
        {
            List<ImportInvoice> invoices =
                FileHelper
                    .ReadJsonList<ImportInvoice>(
                        "import.json"
                    );

            invoices.Add(invoice);

            FileHelper.WriteJsonList(
                "import.json",
                invoices
            );

            return true;
        }
    }
}