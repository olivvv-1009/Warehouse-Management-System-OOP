using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ExportInvoice
    {
        public string ExportId { get; set; }

        public string EmployeeName { get; set; }

        public string Destination { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime ExportDate { get; set; }

        public string Status { get; set; }

        public List<OrderDetail> OrderDetails
        {
            get;
            set;
        }

        public ExportInvoice()
        {
            ExportId = string.Empty;
            EmployeeName = string.Empty;
            Destination = string.Empty;
            TotalAmount = 0;
            ExportDate = DateTime.Now;
            Status = "Completed";
            OrderDetails = new List<OrderDetail>();
        }
    }
}