using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class OrderDetail
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public string Zone { get; set; }

        public string Shelf { get; set; }

        public string Bin { get; set; }

        public OrderDetail()
        {
            ProductId = string.Empty;

            Quantity = 0;

            UnitPrice = 0;
            TotalPrice = 0;

            Zone = string.Empty;
            Shelf = string.Empty;
            Bin = string.Empty;
        }
    }
}
