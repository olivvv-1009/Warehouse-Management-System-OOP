using System.Collections.Generic;
using System.Linq;

namespace WMS.Models.Inventory
{
    public class Warehouse : StorageUnit
    {
        public List<Zone> Zones { get; private set; } = new List<Zone>();

        public void AddZone(Zone zone)
        {
            if (zone != null)
                Zones.Add(zone);
        }

        public List<InventoryItem> GetAllInventory()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            foreach (var zone in Zones)
            {
                items.AddRange(zone.GetInventoryItems());
            }

            return items.Distinct().ToList(); 
        }
    }
}