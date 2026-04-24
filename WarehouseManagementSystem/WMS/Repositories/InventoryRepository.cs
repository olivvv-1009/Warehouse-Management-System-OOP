using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using WMS.Models.Inventory;
using WarehouseManagementSystem.WinForms.Models.Products;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class InventoryRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public InventoryRepository(string filePath = "Data/inventory.json")
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

        public List<InventoryItem> LoadAllInventoryItems()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<InventoryItem>();
                }

                var json = File.ReadAllText(_filePath);
                var items = JsonSerializer.Deserialize<List<InventoryItem>>(json, _jsonOptions);
                return items ?? new List<InventoryItem>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading inventory from file: {ex.Message}", ex);
            }
        }

        public void SaveAllInventoryItems(List<InventoryItem> items)
        {
            try
            {
                EnsureDirectoryExists();
                var json = JsonSerializer.Serialize(items, _jsonOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving inventory to file: {ex.Message}", ex);
            }
        }

        public InventoryItem GetInventoryItemByProductId(string productId)
        {
            var items = LoadAllInventoryItems();
            return items.FirstOrDefault(i => i.ProductId == productId);
        }

        public void AddInventoryItem(InventoryItem item)
        {
            var items = LoadAllInventoryItems();
            if (items.Any(i => i.ProductId == item.ProductId))
            {
                throw new Exception($"Inventory item for product {item.ProductId} already exists.");
            }
            items.Add(item);
            SaveAllInventoryItems(items);
        }

        public void UpdateInventoryItem(InventoryItem item)
        {
            var items = LoadAllInventoryItems();
            var existingItem = items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem == null)
            {
                throw new Exception($"Inventory item for product {item.ProductId} not found.");
            }

            existingItem.MinStock = item.MinStock;
            SaveAllInventoryItems(items);
        }

        public void DeleteInventoryItem(string productId)
        {
            var items = LoadAllInventoryItems();
            var item = items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                throw new Exception($"Inventory item for product {productId} not found.");
            }

            items.Remove(item);
            SaveAllInventoryItems(items);
        }
    }
}
