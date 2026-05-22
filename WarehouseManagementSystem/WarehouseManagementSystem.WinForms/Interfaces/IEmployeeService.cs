using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();

        Employee GetById(string id);

        List<Employee> Search(string keyword);

        bool Add(Employee employee);

        bool Update(Employee employee);

        bool Delete(string id);

        bool ResetPassword(string employeeId);

    }
}
