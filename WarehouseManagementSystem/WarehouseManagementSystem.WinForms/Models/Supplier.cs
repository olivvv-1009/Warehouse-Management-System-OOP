using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Supplier
    {
        public string SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }


        public Supplier()
        {
            SupplierId = string.Empty;
            SupplierName = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
        }
    }
}
