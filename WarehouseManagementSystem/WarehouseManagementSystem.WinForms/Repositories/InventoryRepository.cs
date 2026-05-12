using System;
using System.Collections.Generic;
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
            foreach (var i in _inventory)
            {
                if (i.ProductId == productId)
                    return i;
            }
            return null;
        }

        public void Add(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));


       foreach (var i in _inventory)
            {
                if (i.ProductId == item.ProductId)
                    throw new InvalidOperationException($"Inventory item for product {item.ProductId} already exists");
            }

            _inventory.Add(item);
            Save();
        }

        public void Update(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var existingItem = GetByProductId(item.ProductId);
            if (existingItem == null)
                throw new InvalidOperationException($"Inventory item for product {item.ProductId} not found");

            existingItem.MinStock = item.MinStock;
            existingItem.TotalQuantity = item.TotalQuantity;
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
                item.TotalQuantity += quantity;
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
            return _inventory.Any(i => i.ProductId == productId);
        }
    }
}
