using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Batch
    {
        public string BatchId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime ImportDate { get; set; }

        public Batch()
        {
            BatchId = string.Empty;
            ProductId = string.Empty;

            Quantity = 0;

            ImportDate = DateTime.Now;
        }
    }
}