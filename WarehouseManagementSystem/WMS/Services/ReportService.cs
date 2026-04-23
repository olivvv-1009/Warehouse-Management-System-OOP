using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Reports;

namespace WMS.Services
{
    public class ReportService
    {
        // Dependency: dùng abstract class
        public string GenerateReport(Report report)
        {
            return report.Generate();
        }
    }
}
