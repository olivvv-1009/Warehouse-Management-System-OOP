using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class LocationAssignmentRule
    {
        public WarehouseLocation FindAvailableLocation(
            List<WarehouseLocation> locations,
            int quantity)
        {
            for (int i = 0; i < locations.Count; i++)
            {
                int remainingCapacity =
                    locations[i].Capacity -
                    locations[i].UsedCapacity;

                if (remainingCapacity >= quantity)
                {
                    return locations[i];
                }
            }

            return null;
        }
    }
}