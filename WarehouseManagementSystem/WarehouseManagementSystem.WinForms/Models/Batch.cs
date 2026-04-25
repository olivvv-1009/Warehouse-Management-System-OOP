using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    internal class Batch
    {
        public string BatchID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ImportDate { get; set; }

        public Batch()
        {
            ImportDate = DateTime.Now;
        }

        public Batch(string batchId, string productId, int quantity, decimal price)
        {
            BatchID = batchId;
            ProductID = productId;
            Quantity = quantity;
            Price = price;
            ImportDate = DateTime.Now;
        }
    }
}
