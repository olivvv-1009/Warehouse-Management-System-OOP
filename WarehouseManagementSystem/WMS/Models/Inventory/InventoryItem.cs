using System;
using System.Collections.Generic;
using System.Linq;

namespace WMS.Models.Inventory
{
    public class InventoryItem : IStockManageable
    {
        public int InventoryItemId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; private set; }
        public int MinStock { get; set; }

        public List<Batch> Batches { get; private set; } = new List<Batch>();

        public void AddBatch(Batch batch)
        {
            if (batch == null) return;

            Batches.Add(batch);
            Quantity += batch.Quantity;
        }

        public void AddStock(int amount)
        {
            Quantity += amount;
        }

        public void RemoveStock(int amount)
        {
            if (Quantity < amount)
                throw new Exception("Not enough stock");

            int remaining = amount;

            // FIFO theo hạn sử dụng
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

        public bool IsLowStock()
        {
            return Quantity <= MinStock;
        }
    }
}