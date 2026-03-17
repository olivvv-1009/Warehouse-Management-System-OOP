using System.Collections.Generic;

namespace WMS.Models.Inventory
{
    public class Shelf : StorageUnit
    {
        public List<InventoryItem> InventoryItems { get; private set; } = new List<InventoryItem>();

        public void AddItem(InventoryItem item)
        {
            if (item != null)
                InventoryItems.Add(item);
        }
    }
}