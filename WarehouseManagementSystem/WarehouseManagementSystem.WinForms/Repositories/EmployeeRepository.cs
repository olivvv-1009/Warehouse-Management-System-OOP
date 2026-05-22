using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class EmployeeRepository
    {
        private const string FilePath =
            "profile.json";

        private List<Employee> employees;

        public EmployeeRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            employees =
                FileHelper.ReadJsonList<Employee>(
                    FilePath
                );

            if (employees == null)
            {
                employees =
                    new List<Employee>();
            }
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                employees
            );
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetById(string id)
        {
            int i;

            for (i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    return employees[i];
                }
            }

            return null;
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);

            SaveData();
        }

        public void Update(Employee employee)
        {
            int i;

            for (i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmployeeId
                    == employee.EmployeeId)
                {
                    employees[i] = employee;
                    break;
                }
            }

            SaveData();
        }

        public void Delete(string id)
        {
            int i;

            for (i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    employees.RemoveAt(i);
                    break;
                }
            }

            SaveData();
        }

        public void Reload()
        {
            LoadData();
        }
    }
}
