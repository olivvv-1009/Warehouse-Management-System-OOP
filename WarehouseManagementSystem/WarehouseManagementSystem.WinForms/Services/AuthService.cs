using System;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rules;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class AuthService : IAuthService
    {
        private AccountRepository repo = new AccountRepository();
        private AuthRule rule = new AuthRule();

        private const int MAX_FAILED = 5;

        public Account Login(string username, string password, out int remaining)
        {
            Account user = repo.GetByUsername(username);

            remaining = 0;

            if (!rule.CanLogin(user))
                return null;

            string hash = HashHelper.Hash(password);

            remaining = MAX_FAILED - user.FailedLoginAttempts;

            if (user.PasswordHash == hash)
            {
                user.FailedLoginAttempts = 0;
                user.IsLocked = false;

                repo.Update(user);

                remaining = MAX_FAILED;
                return user;
            }

            user.FailedLoginAttempts++;

            if (user.FailedLoginAttempts >= MAX_FAILED)
                user.IsLocked = true;

            repo.Update(user);

            remaining = MAX_FAILED - user.FailedLoginAttempts;

            return null;
        }

        public string GetQuestion(string username)
        {
            Account user = repo.GetByUsername(username);
            return user != null ? user.SecurityQuestion : null;
        }

        public bool VerifyAnswer(string username, string answer)
        {
            Account user = repo.GetByUsername(username);
            if (user == null) return false;

            string hash = HashHelper.Hash(answer.Trim());
            return user.SecurityAnswerHash == hash;
        }

        public bool ResetPassword(string username, string newPass)
        {
            Account user = repo.GetByUsername(username);

            if (!rule.CanResetPassword(user))
                return false;

            user.PasswordHash = HashHelper.Hash(newPass);
            user.IsLocked = false;
            user.FailedLoginAttempts = 0;

            repo.Update(user);
            return true;
        }

        public bool ChangePassword(string username, string oldPass, string newPass)
        {
            Account user = repo.GetByUsername(username);

            if (user == null) return false;

            string oldHash = HashHelper.Hash(oldPass);

            if (!rule.CanChangePassword(user, user.PasswordHash, oldHash))
                return false;

            user.PasswordHash = HashHelper.Hash(newPass);
            user.FailedLoginAttempts = 0;

            repo.Update(user);
            return true;
        }

        public bool AdminReset(string accountId, string newPass)
        {
            Account user = repo.GetById(accountId);

            if (user == null) return false;

            user.PasswordHash = HashHelper.Hash(newPass);
            user.IsLocked = false;
            user.FailedLoginAttempts = 0;

            repo.Update(user);
            return true;
        }
    }
}