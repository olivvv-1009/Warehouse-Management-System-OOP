using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ImportInvoice
    {
        public string ImportId { get; set; }

        public string ProductId { get; set; }

        public string BatchId { get; set; }

        public string LocationCode { get; set; }

        public string SupplierId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

        public string EmployeeName { get; set; }

        public DateTime ImportDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public ImportInvoice()
        {
            ImportId = string.Empty;

            ProductId = string.Empty;

            BatchId = string.Empty;

            LocationCode = string.Empty;

            SupplierId = string.Empty;

            Quantity = 0;

            TotalAmount = 0;

            EmployeeName = string.Empty;

            ImportDate = DateTime.Now;

            OrderDetails = new List<OrderDetail>();
        }
    }
}