using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Supplier
    {
        private string supplierId;
        private string supplierName;
        private string phoneNumber;
        private string address;
        private string email;
        private bool isActive;

        public string SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Supplier()
        {
            supplierId = "";
            supplierName = "";
            phoneNumber = "";
            address = "";
            email = "";
            isActive = true;
        }
    }
}