using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models.Products
{
    public abstract class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double ImportPrice { get; set; }
        public double ExportPrice { get; set; }
        public virtual string GetCategory()
        {
            return null;
        }
    }
}
