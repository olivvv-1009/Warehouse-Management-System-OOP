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
    }
}