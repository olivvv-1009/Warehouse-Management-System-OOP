using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Reports
{
    public class InventoryReport : Report
    {
        public int TotalItems { get; set; }

        public InventoryReport(int total) : base("Inventory Report")
        {
            TotalItems = total;
        }

        public override string Generate()
        {
            return $"[Inventory Report] Total Items: {TotalItems}";
        }
    }
}
