using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models.Users
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }

        public Employee() { }

        public Employee(string id, string name, string role)
        {
            EmployeeId = id;
            FullName = name;
            Role = role;
        }

        public bool CheckPermission(string action)
        {
            if (Role == "Admin") return true;
            if (Role == "Staff" && action == "View") return true;
            return false;
        }
    }
}
