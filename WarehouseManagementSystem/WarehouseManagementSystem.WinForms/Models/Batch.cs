using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Batch
    {
        public string BatchId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public int RemainingQuantity { get; set; }

        public decimal ImportPrice { get; set; }

        public DateTime ImportDate { get; set; }

        public string Zone { get; set; }

        public string Shelf { get; set; }

        public string Bin { get; set; }

        public string Status { get; set; }

        public Batch()
        {
            BatchId = string.Empty;
            ProductId = string.Empty;

            Quantity = 0;
            RemainingQuantity = 0;

            ImportPrice = 0;

            ImportDate = DateTime.Now;

            Zone = string.Empty;
            Shelf = string.Empty;
            Bin = string.Empty;

            Status = "Stored";
        }
    }
}
