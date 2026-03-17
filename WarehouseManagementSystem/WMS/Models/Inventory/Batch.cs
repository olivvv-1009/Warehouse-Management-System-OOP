using System;

namespace WMS.Models.Inventory
{
    public class Batch
    {
        public int BatchId { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
    }
}