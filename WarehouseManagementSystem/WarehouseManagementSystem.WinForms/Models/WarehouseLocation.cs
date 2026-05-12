using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class WarehouseLocation
    {
        public string LocationCode { get; set; }

        public string Zone { get; set; }

        public string Rack { get; set; }

        public string Shelf { get; set; }

        public int Capacity { get; set; }

        public int UsedCapacity { get; set; }

        public int Priority { get; set; }

        public List<string> AdjacentLocations { get; set; }

        public bool IsAvailable
        {
            get
            {
                return UsedCapacity < Capacity;
            }
        }

        public WarehouseLocation()
        {
            LocationCode = string.Empty;

            Zone = string.Empty;
            Rack = string.Empty;
            Shelf = string.Empty;

            Capacity = 0;
            UsedCapacity = 0;

            Priority = 0;

            AdjacentLocations = new List<string>();
        }
    }
}