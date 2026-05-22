using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Rules;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository repo;
        private EmployeeRule rule;
        private AccountRepository accountRepo;

        public EmployeeService()
        {
            repo = new EmployeeRepository();

            rule = new EmployeeRule();

            accountRepo = new AccountRepository();
        }

        public List<Employee> GetAll()
        {
            return repo.GetAll();
        }

        public Employee GetById(string id)
        {
            return repo.GetById(id);
        }

        public List<Employee> Search(string keyword)
        {
            List<Employee> result =
                new List<Employee>();

            List<Employee> list =
                repo.GetAll();

            if (keyword == null)
                keyword = "";

            keyword =
                keyword.ToLower();

            int i;

            for (i = 0; i < list.Count; i++)
            {
                string name =
                    list[i].FullName.ToLower();

                string phone =
                    list[i].PhoneNumber.ToLower();

                string email =
                    list[i].Email.ToLower();

                string role =
                    list[i].Role.ToLower();

                if (name.Contains(keyword)
                    || phone.Contains(keyword)
                    || email.Contains(keyword)
                    || role.Contains(keyword))
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }

        public bool Add(Employee employee)
        {
            if (!rule.IsValid(employee))
                return false;

            List<Employee> employees = repo.GetAll();
            List<string> ids = new List<string>();

            for (int i = 0; i < employees.Count; i++)
                ids.Add(employees[i].EmployeeId);

            int next = IdGenerator.GetNextNumber(ids, "EMP");

            employee.EmployeeId = IdGenerator.GenerateEmployeeId(next);
            employee.IsActive = true;

            // ================= ACCOUNT =================
            List<Account> accounts = accountRepo.GetAll();
            List<string> accIds = new List<string>();

            for (int i = 0; i < accounts.Count; i++)
                accIds.Add(accounts[i].AccountId);

            int nextAcc = IdGenerator.GetNextNumber(accIds, "ACC");

            Account account = new Account
            {
                AccountId = "ACC" + nextAcc.ToString("D3"),
                Username = employee.FullName.Replace(" ", ""),
                PasswordHash = HashHelper.Hash(employee.PhoneNumber),
                Role = employee.Role,
                IsActive = true,
                IsLocked = false,
                FailedLoginAttempts = 0,
                SecurityQuestion = "",
                SecurityAnswerHash = ""
            };

            accountRepo.Add(account);

            // ================= PROFILE (FIX QUAN TRỌNG) =================
            ProfileRepository profileRepo = new ProfileRepository();

            Profile profile = new Profile
            {
                ProfileId = "PRF" + nextAcc.ToString("D4"),
                AccountId = account.AccountId,
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Address = employee.Address,
                Role = employee.Role
            };

            profileRepo.Add(profile);

            return true;
        }

        public bool Update(Employee employee)
        {
            if (!rule.IsValid(employee))
                return false;

            repo.Update(employee);

            return true;
        }

        public bool Delete(string id)
        {
            Employee employee = repo.GetById(id);

            if (employee == null)
                return false;

            // XÓA EMPLOYEE/PROFILE
            repo.Delete(id);

            // XÓA ACCOUNT
            accountRepo.Delete(employee.AccountId);

            return true;
        }

        public bool ResetPassword(string employeeId)
        {
            Employee employee =
                repo.GetById(employeeId);

            if (employee == null)
                return false;

            Account account =
                accountRepo.GetByUsername(
                    employee.FullName.Replace(" ", "")
                );

            if (account == null)
                return false;

            account.PasswordHash =
                HashHelper.Hash(
                    employee.PhoneNumber
                );

            account.SecurityQuestion = "";

            account.SecurityAnswerHash = "";

            accountRepo.Update(account);

            return true;
        }

        public List<Employee> GetAllFresh()
        {
            repo = new EmployeeRepository(); // reload lại file
            return repo.GetAll();
        }
    }
}
