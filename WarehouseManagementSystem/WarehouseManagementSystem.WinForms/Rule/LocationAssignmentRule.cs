using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
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
    int quantity,
    List<string> usedRacks
)
        {
            int i;

            string oldZone = "";

            string oldRack = "";

            WarehouseLocation bestLocation =
                null;

            int maxRemaining = -1;

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
                )
                {
                    oldZone =
                        locations[i].Zone;

                    oldRack =
                        locations[i].Rack;

                    if (
                        remainingCapacity >= quantity
                        &&
                        remainingCapacity >
                        maxRemaining
                    )
                    {
                        maxRemaining =
                            remainingCapacity;

                        bestLocation =
                            locations[i];
                    }
                }
            }

            if (bestLocation != null)
            {
                return bestLocation;
            }

            // =================
            // RULE 2
            // SAME RACK
            // =================

            maxRemaining = -1;

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
                    remainingCapacity >= quantity
                )
                {
                    if (
                        remainingCapacity >
                        maxRemaining
                    )
                    {
                        maxRemaining =
                            remainingCapacity;

                        bestLocation =
                            locations[i];
                    }
                }
            }

            if (bestLocation != null)
            {
                return bestLocation;
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

            maxRemaining = -1;

            for (
                i = 0;
                i < locations.Count;
                i++
            )
            {
                int remainingCapacity =
                    locations[i].Capacity -
                    locations[i].UsedCapacity;

                string rackKey =
    locations[i].Zone
    + "-"
    + locations[i].Rack;

                if (
    !usedRacks.Contains(
        rackKey
    )
    &&
    string.IsNullOrWhiteSpace(
        locations[i].ProductId
    )
    &&
    locations[i].Zone
        == targetZone
    &&
    remainingCapacity >= quantity
)
                {
                    if (
                        remainingCapacity >
                        maxRemaining
                    )
                    {
                        maxRemaining =
                            remainingCapacity;

                        bestLocation =
                            locations[i];
                    }
                }
            }

            return bestLocation;
        }

    }
}