using System;
using System.Collections.Generic;

namespace WMS.Models.Inventory
{
    public class Batch
    {
        public int BatchId { get; set; }

        public DateTime ImportDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public List<InventoryItem> Items { get; set; }

        public Batch()
        {
            Items = new List<InventoryItem>();
        }

        public void AddItem(InventoryItem item)
        {
            Items.Add(item);
        }
    }
}