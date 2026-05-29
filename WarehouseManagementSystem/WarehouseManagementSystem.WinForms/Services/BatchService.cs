using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class BatchService
    {
        private readonly BatchRepository
            _batchRepository;
        private readonly SupplierRepository _supplierRepository;

        public BatchService()
        {
            _batchRepository =
                new BatchRepository();
            _supplierRepository =
        new SupplierRepository();
        }

        public List<Batch> GetAllBatches()
        {
            return _batchRepository.GetAll();
        }

        public void AddBatch(Batch batch)
        {
            _batchRepository.Add(batch);
        }

        public Batch FindBatchById(
            string batchId)
        {
            return _batchRepository
                .FindById(batchId);
        }

        public string GetSupplierIdByBatch(
            string batchId)
        {
            return _batchRepository
                .GetSupplierIdByBatch(
                    batchId
                );
        }

        public string GetSupplierNameByBatch(
    string batchId)
        {
            List<Batch> batches =
                _batchRepository.GetAll();

            Batch foundBatch = null;

            foreach (Batch batch in batches)
            {
                if (batch.BatchId == batchId)
                {
                    foundBatch = batch;
                    break;
                }
            }

            if (foundBatch == null)
            {
                return "Unknown";
            }

            List<Supplier> suppliers =
                _supplierRepository.GetAll();

            foreach (Supplier supplier in suppliers)
            {
                if (supplier.SupplierId
                    == foundBatch.SupplierId)
                {
                    return supplier.SupplierName;
                }
            }

            return "Unknown";
        }
    }
}