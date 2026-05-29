using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ExportRepository
    {
        private readonly string _path =
            FileHelper.GetFilePath(
                "export.json"
            );

        public List<ExportInvoice>
            GetAll()
        {
            if (!File.Exists(_path))
            {
                return
                    new List<ExportInvoice>();
            }

            string json =
                File.ReadAllText(
                    _path
                );

            return JsonSerializer
                .Deserialize<
                    List<ExportInvoice>
                >(json)
                ??
                new List<ExportInvoice>();
        }

        public void Add(
            ExportInvoice invoice)
        {
            List<ExportInvoice>
                invoices =
                    GetAll();

            invoices.Add(
                invoice
            );

            Save(invoices);
        }

        public void Update(
    ExportInvoice invoice)
        {
            List<ExportInvoice>
                invoices =
                    GetAll();

            int index = -1;

            int i;

            for (
                i = 0;
                i < invoices.Count;
                i++
            )
            {
                if (
                    invoices[i]
                        .InvoiceId
                    ==
                    invoice.InvoiceId
                )
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                invoices[index] =
                    invoice;

                Save(invoices);
            }
        }

        private void Save(
            List<ExportInvoice>
                invoices)
        {
            string json =
                JsonSerializer
                    .Serialize(
                        invoices,
                        new JsonSerializerOptions
                        {
                            WriteIndented =
                                true
                        });

            File.WriteAllText(
                _path,
                json
            );
        }
    }
}