using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Files;

namespace WarehouseManagementSystem.WinForms.Utils
{
    public class WarehouseMapSeeder
    {
        private const string FileName =
            "warehouse_map.json";

        public static void Seed()
        {
            List<WarehouseMap> maps =
                new List<WarehouseMap>();

            int priority = 1;

            for (int z = 1; z <= 4; z++)
            {
                for (int r = 1; r <= 5; r++)
                {
                    for (int s = 1; s <= 5; s++)
                    {
                        WarehouseMap map =
                            new WarehouseMap();

                        map.Zone = $"Z{z}";

                        map.Rack = $"R{r:D2}";

                        map.Shelf = $"S{s:D2}";

                        map.LocationCode =
                            $"Z{z}-R{r:D2}-S{s:D2}";

                        map.Priority = priority++;

                        map.AdjacentLocations =
                            GenerateAdjacentLocations(
                                z, r, s);

                        maps.Add(map);
                    }
                }
            }

            FileHelper.WriteJsonList(
                FileName,
                maps
            );
        }

        private static List<string>
            GenerateAdjacentLocations(
                int zone,
                int rack,
                int shelf)
        {
            List<string> adjacent =
                new List<string>();

            if (shelf > 1)
            {
                adjacent.Add(
                    $"Z{zone}-R{rack:D2}-S{(shelf - 1):D2}");
            }

            if (shelf < 5)
            {
                adjacent.Add(
                    $"Z{zone}-R{rack:D2}-S{(shelf + 1):D2}");
            }

            if (rack < 5)
            {
                adjacent.Add(
                    $"Z{zone}-R{(rack + 1):D2}-S{shelf:D2}");
            }

            return adjacent;
        }
    }
}