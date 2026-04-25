using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Files;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class InventoryRepository
    {
        private const string FileName = "inventory.json";
        private List<InventoryItem> _inventory;

        public InventoryRepository()
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            try
            {
                _inventory = FileHelper.ReadJsonList<InventoryItem>(FileName);
                if (_inventory == null)
                {
                    _inventory = new List<InventoryItem>();
                }
            }
            catch
            {
                _inventory = new List<InventoryItem>();
            }
        }

        public List<InventoryItem> GetAll()
        {
            return new List<InventoryItem>(_inventory);
        }

        public InventoryItem GetByProductId(string productId)
        {
            return _inventory.FirstOrDefault(i => i.ProductID == productId);
        }

        public void Add(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_inventory.Any(i => i.ProductID == item.ProductID))
                throw new InvalidOperationException($"Inventory item for product {item.ProductID} already exists");

            _inventory.Add(item);
            Save();
        }

        public void Update(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var existingItem = GetByProductId(item.ProductID);
            if (existingItem == null)
                throw new InvalidOperationException($"Inventory item for product {item.ProductID} not found");

            existingItem.MinStock = item.MinStock;
            existingItem.TotalStock = item.TotalStock;
            Save();
        }

        public void Delete(string productId)
        {
            var item = GetByProductId(productId);
            if (item != null)
            {
                _inventory.Remove(item);
                Save();
            }
        }

        public void UpdateTotalStock(string productId, int quantity)
        {
            var item = GetByProductId(productId);
            if (item != null)
            {
                item.TotalStock += quantity;
                Save();
            }
        }

        public void Save()
        {
            try
            {
                FileHelper.WriteJsonList(FileName, _inventory);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error saving inventory: {ex.Message}", ex);
            }
        }

        public bool Exists(string productId)
        {
            return _inventory.Any(i => i.ProductID == productId);
        }
    }
}
