using System;

namespace WMS.Models.Transactions
{
    public class Transaction
    {
        public string Type { get; set; } = "";
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}