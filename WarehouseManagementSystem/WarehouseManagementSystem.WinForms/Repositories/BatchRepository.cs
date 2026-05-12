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
            return _batches;
        }

        public void Add(Batch batch)
        {
            _batches.Add(batch);

            SaveData();
        }

        public Batch FindById(string batchId)
        {
            int i;

            for (i = 0; i < _batches.Count; i++)
            {
                if (_batches[i].BatchId == batchId)
                {
                    return _batches[i];
                }
            }

            return null;
        }
    }
}