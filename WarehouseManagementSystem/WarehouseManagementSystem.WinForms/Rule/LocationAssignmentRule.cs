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
                string category,
                int quantity)
        {
            int i;

            string oldZone = "";

            string oldRack = "";

            // =================
            // RULE 1
            // SAME PRODUCT
            // =================

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

            // =================
            // RULE 2
            // SAME RACK
            // =================

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
                    string.IsNullOrWhiteSpace(
                        locations[i].ProductId
                    )
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

            // =================
            // RULE 3
            // CATEGORY ZONE
            // =================

            string targetZone = "";

            if (
                category == "Laptop"
            )
            {
                targetZone = "A";
            }
            else if (
                category == "Smartphone"
            )
            {
                targetZone = "B";
            }
            else if (
                category == "Accessory"
            )
            {
                targetZone = "C";
            }
            else if (
                category == "Tablet"
            )
            {
                targetZone = "D";
            }
            else if (
                category == "Monitor"
            )
            {
                targetZone = "E";
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
                    string.IsNullOrWhiteSpace(
                        locations[i].ProductId
                    )
                    &&
                    locations[i].Zone
                        == targetZone
                    &&
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