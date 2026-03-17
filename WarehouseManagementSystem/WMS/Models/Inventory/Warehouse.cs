using System.Collections.Generic;

namespace WMS.Models.Inventory
{
    public class Warehouse : StorageUnit
    {
        public List<Zone> Zones { get; set; }

        public Warehouse()
        {
            Zones = new List<Zone>();
        }

        public void AddZone(Zone zone)
        {
            Zones.Add(zone);
        }

        public List<InventoryItem> GetAllInventory()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            foreach (var zone in Zones)
            {
                items.AddRange(zone.GetInventoryItems());
            }

            return items;
        }
    }
}