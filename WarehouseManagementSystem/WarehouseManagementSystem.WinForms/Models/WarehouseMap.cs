using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class WarehouseMap
    {
        public string LocationCode
        {
            get;
            set;
        }

        public string Zone
        {
            get;
            set;
        }

        public string Rack
        {
            get;
            set;
        }

        public string Shelf
        {
            get;
            set;
        }

        public List<string> AdjacentLocations
        {
            get;
            set;
        }

        public int Priority
        {
            get;
            set;
        }

        public WarehouseMap()
        {
            LocationCode = string.Empty;

            Zone = string.Empty;

            Rack = string.Empty;

            Shelf = string.Empty;

            AdjacentLocations =
                new List<string>();

            Priority = 0;
        }
    }
}