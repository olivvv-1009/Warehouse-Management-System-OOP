using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Batch
    {
        public string BatchId { get; set; }

        public string ProductId { get; set; }

        public string LocationCode { get; set; }

        public int Quantity { get; set; }

        public int RemainingQuantity { get; set; }

        public decimal ImportPrice { get; set; }

        public DateTime ImportDate { get; set; }

        public string Status { get; set; }

        public Batch()
        {
            BatchId = string.Empty;

            ProductId = string.Empty;

            LocationCode = string.Empty;

            Quantity = 0;

            RemainingQuantity = 0;

            ImportPrice = 0;

            ImportDate = DateTime.Now;

            Status = "Stored";
        }
    }
}