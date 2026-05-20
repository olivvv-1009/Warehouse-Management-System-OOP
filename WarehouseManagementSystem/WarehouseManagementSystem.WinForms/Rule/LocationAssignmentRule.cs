using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class LocationAssignmentRule
    {
        public WarehouseLocation
            FindAvailableLocation(
                List<WarehouseLocation> locations,
                string productId,
                int quantity)
        {
            int i;

            string oldZone = "";

            string oldRack = "";



            for (
                i = 0;
                i < locations.Count;
                i++
            )
            {
                int remainingCapacity =
                    locations[i].Capacity -
                    locations[i].UsedCapacity;

                if (
                    locations[i].ProductId
                        == productId
                    &&
                    remainingCapacity
                        >= quantity
                )
                {
                    return locations[i];
                }

                if (
                    locations[i].ProductId
                        == productId
                )
                {
                    oldZone =
                        locations[i].Zone;

                    oldRack =
                        locations[i].Rack;
                }
            }



            for (
                i = 0;
                i < locations.Count;
                i++
            )
            {
                int remainingCapacity =
                    locations[i].Capacity -
                    locations[i].UsedCapacity;

                if (
                    locations[i].ProductId
                        == null
                    &&
                    locations[i].Zone
                        == oldZone
                    &&
                    locations[i].Rack
                        == oldRack
                    &&
                    remainingCapacity
                        >= quantity
                )
                {
                    return locations[i];
                }
            }



            for (
                i = 0;
                i < locations.Count;
                i++
            )
            {
                int remainingCapacity =
                    locations[i].Capacity -
                    locations[i].UsedCapacity;

                if (
                    remainingCapacity
                        >= quantity
                )
                {
                    return locations[i];
                }
            }

            return null;
        }
    }
}