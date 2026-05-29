using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class SupplierRule
    {
        public bool IsValid(Supplier supplier)
        {
            if (supplier.SupplierName.Trim() == "")
                return false;

            if (supplier.PhoneNumber.Trim() == "")
                return false;

            if (supplier.Email.Trim() == "")
                return false;

            return true;
        }
    }
}
