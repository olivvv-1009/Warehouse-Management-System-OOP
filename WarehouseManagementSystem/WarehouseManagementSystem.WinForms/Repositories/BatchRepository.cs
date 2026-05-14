using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class BatchRepository
    {
        private const string FilePath =
            "batch.json";
        private List<Batch> _batches;
        private const string ImportFilePath =
            "import.json";
        private List<ImportInvoice> _imports;
        private const string SupplierFilePath =
           "supplier.json";
        private List<Supplier> _suppliers;

        public BatchRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            _batches =
                FileHelper.ReadJsonList<Batch>(
                    FilePath
                );

            if (_batches == null)
            {
                _batches =
                    new List<Batch>();
            }

            _imports =
                FileHelper.ReadJsonList
                    <ImportInvoice>(
                        ImportFilePath
                    );

            if (_imports == null)
            {
                _imports =
                    new List<ImportInvoice>();
            }

            _suppliers =
              FileHelper.ReadJsonList<Supplier>(
        SupplierFilePath
    );

            if (_suppliers == null)
            {
                _suppliers =
                    new List<Supplier>();
            }
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                _batches
            );
        }

        public List<Batch> GetAll()
        {
            return new List<Batch>(
                _batches
            );
        }

        public void Add(Batch batch)
        {
            _batches.Add(batch);

            SaveData();
        }

        public void Update()
        {
            SaveData();
        }

        public Batch FindById(
            string batchId)
        {
            foreach (Batch batch
                in _batches)
            {
                if (batch.BatchId
                    == batchId)
                {
                    return batch;
                }
            }

            return null;
        }

        public List<Batch>
            GetByProductId(
                string productId)
        {
            List<Batch> result =
                new List<Batch>();

            foreach (Batch batch
                in _batches)
            {
                if (batch.ProductId
                    == productId)
                {
                    result.Add(batch);
                }
            }

            return result;
        }

        public string GetSupplierIdByBatch(
    string batchId)
        {
            Batch batch =
                FindById(batchId);

            if (batch == null)
            {
                return string.Empty;
            }

            foreach (ImportInvoice invoice
                in _imports)
            {
                foreach (OrderDetail detail
                    in invoice.OrderDetails)
                {
                    if (detail.ProductId
                        == batch.ProductId)
                    {
                        return invoice
                            .SupplierId;
                    }
                }
            }

            return string.Empty;
        }

        public string GetSupplierNameByBatch(
            string batchId)
        {
            string supplierId =
                GetSupplierIdByBatch(
                    batchId
                );

            if (supplierId == string.Empty)
            {
                return string.Empty;
            }

            foreach (Supplier supplier
                in _suppliers)
            {
                if (supplier.SupplierId
                    == supplierId)
                {
                    return supplier
                        .SupplierName;
                }
            }

            return string.Empty;
        }
    }
}