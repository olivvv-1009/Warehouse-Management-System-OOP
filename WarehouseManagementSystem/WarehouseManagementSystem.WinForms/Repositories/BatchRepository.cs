using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Files;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class BatchRepository
    {
        private const string FileName = "batch.json";
        private List<Batch> _batches;

        public BatchRepository()
        {
            LoadBatches();
        }

        private void LoadBatches()
        {
            try
            {
                _batches = FileHelper.ReadJsonList<Batch>(FileName);
                if (_batches == null)
                {
                    _batches = new List<Batch>();
                }
            }
            catch
            {
                _batches = new List<Batch>();
            }
        }

        public List<Batch> GetAll()
        {
            return new List<Batch>(_batches);
        }

        public List<Batch> GetByProductId(string productId)
        {
            return _batches.Where(b => b.ProductID == productId).ToList();
        }

        public Batch GetById(string batchId)
        {
            return _batches.FirstOrDefault(b => b.BatchID == batchId);
        }

        public void Add(Batch batch)
        {
            if (batch == null)
                throw new ArgumentNullException(nameof(batch));

            if (_batches.Any(b => b.BatchID == batch.BatchID))
                throw new InvalidOperationException($"Batch with ID {batch.BatchID} already exists");

            _batches.Add(batch);
            Save();
        }

        public void Delete(string batchId)
        {
            var batch = GetById(batchId);
            if (batch != null)
            {
                _batches.Remove(batch);
                Save();
            }
        }

        public void Save()
        {
            try
            {
                FileHelper.WriteJsonList(FileName, _batches);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error saving batches: {ex.Message}", ex);
            }
        }

        public bool ProductHasImports(string productId)
        {
            return _batches.Any(b => b.ProductID == productId);
        }

        public decimal GetAverageImportPrice(string productId)
        {
            var batches = GetByProductId(productId);
            if (batches.Count == 0)
                return 0;

            decimal totalValue = 0;
            int totalQty = 0;

            foreach (var batch in batches)
            {
                totalValue += batch.Price * batch.Quantity;
                totalQty += batch.Quantity;
            }

            return totalQty > 0 ? totalValue / totalQty : 0;
        }
    }
}
