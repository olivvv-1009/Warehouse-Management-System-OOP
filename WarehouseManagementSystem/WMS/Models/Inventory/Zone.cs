using System.Collections.Generic;

namespace WMS.Models.Inventory
{
    public class Zone : StorageUnit
    {
        public List<Shelf> Shelves { get; set; } = new List<Shelf>();

        public void AddShelf(Shelf shelf)
        {
            if (shelf != null)
                Shelves.Add(shelf);
        }

        public List<InventoryItem> GetInventoryItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            foreach (var shelf in Shelves)
            {
                items.AddRange(shelf.InventoryItems);
            }

            return items;
        }
    }
}