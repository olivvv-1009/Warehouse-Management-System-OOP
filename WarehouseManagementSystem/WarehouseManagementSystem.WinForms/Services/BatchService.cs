using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class BatchService
    {
        private readonly BatchRepository
            _batchRepository;

        public BatchService()
        {
            _batchRepository =
                new BatchRepository();
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
            return _batchRepository
                .GetSupplierNameByBatch(
                    batchId
                );
        }
    }
}