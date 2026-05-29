using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class OrderDetail
    {
        public string ProductId { get; set; }

        public string BatchId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public string LocationCode { get; set; }

        public string Zone { get; set; }

        public string Rack { get; set; }

        public string Shelf { get; set; }

        public OrderDetail()
        {
            ProductId = string.Empty;

            BatchId = string.Empty;

            Quantity = 0;

            UnitPrice = 0;

            TotalPrice = 0;

            LocationCode = string.Empty;

            Zone = string.Empty;

            Rack = string.Empty;

            Shelf = string.Empty;
        }
    }
}