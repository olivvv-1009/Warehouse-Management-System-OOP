using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ImportRepository : IRepository<ImportInvoice>
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
            LoadData();
            return _invoices;
        }

        public void Add(ImportInvoice invoice)
        {
            _invoices.Add(invoice);

            SaveData();
        }

        public void Save(List<ImportInvoice> items)
        {
            _invoices = items;
            SaveData();
        }

        public ImportInvoice FindById(
    string InvoiceId)
        {
            int i;

            for (
                i = 0;
                i < _invoices.Count;
                i++
            )
            {
                if (
                    _invoices[i]
                        .InvoiceId
                    == InvoiceId
                )
                {
                    return _invoices[i];
                }
            }

            return null;
        }
    }


}