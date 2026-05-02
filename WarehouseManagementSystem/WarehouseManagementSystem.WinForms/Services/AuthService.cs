using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class AuthService
    {
        private AccountRepository repo = new AccountRepository();
        private const int MAX_FAILED = 5;

        public Account Login(string username, string password, out int remaining)
        {
            Account user = repo.GetByUsername(username);

            if (user == null || !user.IsActive)
            {
                remaining = 0;
                return null;
            }

            if (user.IsLocked)
                throw new Exception("Account is locked!");

            string hash = HashHelper.Hash(password);

            // luôn tính remaining trước
            remaining = MAX_FAILED - user.FailedLoginAttempts;

            if (user.PasswordHash.ToUpper() == hash.ToUpper())
            {
                user.FailedLoginAttempts = 0;
                user.IsLocked = false;

                repo.Update(user);

                remaining = MAX_FAILED; // reset về 5

                return user;
            }
            else
            {
                user.FailedLoginAttempts++;

                remaining = MAX_FAILED - user.FailedLoginAttempts;

                if (user.FailedLoginAttempts >= MAX_FAILED)
                {
                    user.IsLocked = true;
                    repo.Update(user);
                    throw new Exception("Account is locked!");
                }

                repo.Update(user);
                return null;
            }
        }

        //FORGOT PASSWORD, CHANGE PASSWORD, SECURITY QUESTION/ANSWER, ETC. CAN BE ADDED HERE
        public string GetQuestion(string username)
        {
            Account user = repo.GetByUsername(username);
            if (user == null) return null;
            return user.SecurityQuestion;
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
            if (user == null) return false;

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

            if (user.PasswordHash != HashHelper.Hash(oldPass))
                return false;

            user.PasswordHash = HashHelper.Hash(newPass);
            user.FailedLoginAttempts = 0;
            repo.Update(user);
            return true;
        }

        //ADMIN RESET USER PASSWORD
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