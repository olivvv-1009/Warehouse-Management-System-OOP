using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Invoice
    {
        public string InvoiceId
        {
            get;
            set;
        }

        public decimal TotalAmount
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public Invoice()
        {
            InvoiceId =
                string.Empty;

            TotalAmount =
                0;

            CreatedDate =
                DateTime.Now;

            Status =
                "Pending";
        }
    }
}