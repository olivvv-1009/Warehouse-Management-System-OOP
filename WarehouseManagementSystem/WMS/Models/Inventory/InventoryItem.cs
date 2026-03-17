using System;

namespace WMS.Models.Inventory
{
    public class InventoryItem : IStockManageable
    {
        public int InventoryItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; private set; }

        public int MinStock { get; set; }

        public void AddStock(int amount)
        {
            Quantity += amount;
        }

        public void RemoveStock(int amount)
        {
            if (Quantity < amount)
                throw new Exception("Not enough stock");

            Quantity -= amount;
        }

        public bool IsLowStock()
        {
            return Quantity <= MinStock;
        }
    }
}