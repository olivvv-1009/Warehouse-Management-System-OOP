using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class WarehouseLocation
    {
        public string LocationId { get; set; }

        public string Zone { get; set; }

        public string Shelf { get; set; }

        public string Bin { get; set; }

        public int Capacity { get; set; }

        public int UsedCapacity { get; set; }

        public bool IsAvailable { get; set; }

        public WarehouseLocation()
        {
            LocationId = string.Empty;
            Zone = string.Empty;
            Shelf = string.Empty;
            Bin = string.Empty;

            Capacity = 0;
            UsedCapacity = 0;

            IsAvailable = true;
        }
    }
}
