using System.Collections.Generic;

namespace WMS.Models.Inventory
{
    public class Zone : StorageUnit
    {
        public List<Shelf> Shelves { get; set; }

        public Zone()
        {
            Shelves = new List<Shelf>();
        }

        public void AddShelf(Shelf shelf)
        {
            Shelves.Add(shelf);
        }

        public List<InventoryItem> GetInventoryItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            foreach (var shelf in Shelves)
            {
                foreach (var batch in shelf.Batches)
                {
                    items.AddRange(batch.Items);
                }
            }

            return items;
        }
    }
}