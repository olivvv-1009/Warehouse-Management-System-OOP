using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ReturnOrder : Invoice
    {
        public string EmployeeId
        {
            get;
            set;
        }

        public string ImportInvoiceId
        {
            get;
            set;
        }

        public string SupplierId
        {
            get;
            set;
        }

        public List<ReturnOrderDetail>
            Details
        {
            get;
            set;
        }

        public ReturnOrder()
        {
            EmployeeId =
                string.Empty;

            ImportInvoiceId =
                string.Empty;

            SupplierId =
                string.Empty;

            Details =
                new List<ReturnOrderDetail>();
        }
    }
}