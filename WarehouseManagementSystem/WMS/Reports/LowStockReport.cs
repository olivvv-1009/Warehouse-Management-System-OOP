using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Reports
{
    public class LowStockReport : Report
    {
        public int LowStockCount { get; set; }

        public LowStockReport(int count) : base("Low Stock Report")
        {
            LowStockCount = count;
        }

        public override string Generate()
        {
            return $"[Low Stock] Items below threshold: {LowStockCount}";
        }
    }
}
