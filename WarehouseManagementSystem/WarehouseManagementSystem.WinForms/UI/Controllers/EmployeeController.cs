using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Controllers
{
    public class EmployeeController
    {
        private EmployeeService service;

        public EmployeeController()
        {
            service = new EmployeeService();
        }

        public List<Employee> GetAll()
        {
            return service.GetAllFresh();
        }

        public Employee GetById(string id)
        {
            return service.GetById(id);
        }

        public List<Employee> Search(string keyword)
        {
            return service.Search(keyword);
        }

        public bool Add(Employee employee)
        {
            return service.Add(employee);
        }

        public bool Update(Employee employee)
        {
            return service.Update(employee);
        }

        public bool Delete(string id)
        {
            return service.Delete(id);
        }

        public bool ResetPassword(string employeeId)
        {
            return service.ResetPassword(employeeId);
        }

        public List<Employee> GetAllFresh()
        {
            return service.GetAllFresh();
        }
    }
}
