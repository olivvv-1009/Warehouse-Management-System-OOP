using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ImportInvoice : Invoice
    {
        public string SupplierId
        {
            get;
            set;
        }

        public string EmployeeName
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

        public ImportInvoice()
        {
            SupplierId =
                string.Empty;

            EmployeeName =
                string.Empty;

            OrderDetails =
                new List<OrderDetail>();
        }
    }
}