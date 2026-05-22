using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class EmployeeRule
    {
        public bool IsValid(Employee employee)
        {
            if (employee.FullName.Trim() == "")
                return false;

            if (employee.PhoneNumber.Trim() == "")
                return false;

            if (employee.Email.Trim() == "")
                return false;

            return true;
        }
    }
}
