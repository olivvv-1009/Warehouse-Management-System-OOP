using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
public class Product
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
        }

        public Product(string productId, string name, string category)
        {
            ProductID = productId;
            Name = name;
            Category = category;
            CreatedAt = DateTime.Now;
        }
    }
}
