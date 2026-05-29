using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ExportInvoice : Invoice
    {
        public string EmployeeName
        {
            get;
            set;
        }

        public string Destination
        {
            get;
            set;
        }

        public List<OrderDetail>
            OrderDetails
        {
            get;
            set;
        }

        public ExportInvoice()
        {
            EmployeeName =
                string.Empty;

            Destination =
                string.Empty;

            OrderDetails =
                new List<OrderDetail>();
        }
    }
}