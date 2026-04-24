using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using WMS.Models.Inventory;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class BatchRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public BatchRepository(string filePath = "Data/batches.json")
        {
            _filePath = filePath;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public List<BatchRecord> LoadAllBatches()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<BatchRecord>();
                }

                var json = File.ReadAllText(_filePath);
                var batches = JsonSerializer.Deserialize<List<BatchRecord>>(json, _jsonOptions);
                return batches ?? new List<BatchRecord>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading batches from file: {ex.Message}", ex);
            }
        }

        public void SaveAllBatches(List<BatchRecord> batches)
        {
            try
            {
                EnsureDirectoryExists();
                var json = JsonSerializer.Serialize(batches, _jsonOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving batches to file: {ex.Message}", ex);
            }
        }

        public List<BatchRecord> GetBatchesByProductId(string productId)
        {
            var batches = LoadAllBatches();
            return batches.Where(b => b.ProductId == productId).ToList();
        }

        public void AddBatch(BatchRecord batch)
        {
            var batches = LoadAllBatches();
            batches.Add(batch);
            SaveAllBatches(batches);
        }

        public void DeleteBatchesByProductId(string productId)
        {
            var batches = LoadAllBatches();
            var batchesToKeep = batches.Where(b => b.ProductId != productId).ToList();
            SaveAllBatches(batchesToKeep);
        }
    }

    /// <summary>
    /// Represents a batch record in the system for tracking product imports
    /// </summary>
    public class BatchRecord
    {
        public int BatchId { get; set; }
        public string ProductId { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
