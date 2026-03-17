using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models.Products;

namespace WMS.Models.Inventory
{
    public class InventoryItem : IStockManageable
    {
        public int InventoryItemId { get; set; }

        public int ProductId { get; set; }

        // 👉 thêm navigation (nếu module khác cần)
        public Product Product { get; set; }

        public int Quantity { get; private set; }

        public int MinStock { get; set; }

        public List<Batch> Batches { get; private set; } = new List<Batch>();

        // ✅ Constructor mới (an toàn)
        public InventoryItem(Product product)
        {
            Product = product;
            ProductId = product?.ProductId ?? 0;
        }

        public InventoryItem() { }

        // ✅ Method cũ (giữ)
        public void AddBatch(Batch batch)
        {
            if (batch == null) return;

            Batches.Add(batch);
            Quantity += batch.Quantity;
        }

        // ✅ SỬA AddStock để hợp với Batch
        public void AddStock(int quantity)
        {
            if (quantity <= 0) return;

            var batch = new Batch
            {
                Quantity = quantity,
                ImportDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(6) // hoặc truyền từ ngoài
            };

            AddBatch(batch);
        }

        public void RemoveStock(int amount)
        {
            if (Quantity < amount)
                throw new Exception("Not enough stock");

            int remaining = amount;

            Batches = Batches.OrderBy(b => b.ExpiryDate).ToList();

            foreach (var batch in Batches)
            {
                if (remaining <= 0) break;

                if (batch.Quantity <= remaining)
                {
                    remaining -= batch.Quantity;
                    batch.Quantity = 0;
                }
                else
                {
                    batch.Quantity -= remaining;
                    remaining = 0;
                }
            }

            Batches.RemoveAll(b => b.Quantity == 0);
            Quantity -= amount;
        }

        // ✅ Method mới (OK)
        public int GetTotalQuantity()
        {
            return Batches.Sum(b => b.Quantity);
        }

        public bool IsLowStock()
        {
            return Quantity <= MinStock;
        }
    }
}