using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ImportInvoice
    {
        public string ImportId { get; set; }

        public string SupplierId { get; set; }

        public DateTime ImportDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string EmployeeName { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public ImportInvoice()
        {
            ImportId = string.Empty;
            SupplierId = string.Empty;

            ImportDate = DateTime.Now;

            TotalAmount = 0;

            EmployeeName = string.Empty;

            OrderDetails = new List<OrderDetail>();
        }
    }
}
