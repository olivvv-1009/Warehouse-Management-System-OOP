using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    internal class Account
    {
        private string accountId = "";
        private string username = "";
        private string passwordHash = "";
        private string role = "";
        private string securityQuestion = "";
        private string securityAnswerHash = "";

        private bool isActive;
        private int failedLoginAttempts;
        private bool isLocked;

        public string AccountId { get { return accountId; } set { accountId = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string PasswordHash { get { return passwordHash; } set { passwordHash = value; } }
        public string Role { get { return role; } set { role = value; } }

        public string SecurityQuestion { get { return securityQuestion; } set { securityQuestion = value; } }
        public string SecurityAnswerHash { get { return securityAnswerHash; } set { securityAnswerHash = value; } }

        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public int FailedLoginAttempts { get { return failedLoginAttempts; } set { failedLoginAttempts = value; } }
        public bool IsLocked { get { return isLocked; } set { isLocked = value; } }
    }
}
