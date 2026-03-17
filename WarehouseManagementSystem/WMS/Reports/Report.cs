using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Reports
{
    public abstract class Report
    {
        public string ReportName { get; set; }

        public Report(string name)
        {
            ReportName = name;
        }

        public abstract string Generate();
    }
}
