using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    /// <summary>
    /// Display model for showing product information with inventory details
    /// </summary>
    public class ProductDisplayModel
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int MinStock { get; set; }
        public decimal? AvgImportPrice { get; set; } 
    }
}
