using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models.Users
{
    public class Supplier
    {
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }

        public List<string> SupplyHistory { get; set; }

        public Supplier()
        {
            SupplyHistory = new List<string>();
        }

        public Supplier(string id, string name, string phone)
        {
            SupplierId = id;
            SupplierName = name;
            Phone = phone;
            SupplyHistory = new List<string>();
        }

        public void AddSupply(string record)
        {
            SupplyHistory.Add(record);
        }
    }
}

