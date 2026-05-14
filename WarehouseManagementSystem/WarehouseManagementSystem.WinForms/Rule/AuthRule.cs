using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rules
{
    public class AuthRule
    {
        public bool CanLogin(Account user)
        {
            if (user == null) return false;
            if (!user.IsActive) return false;
            if (user.IsLocked) return false;

            return true;
        }

        public bool CanResetPassword(Account user)
        {
            if (user == null) return false;
            if (!user.IsActive) return false;
            if (user.IsLocked) return false;

            return true;
        }

        public bool CanChangePassword(Account user, string oldHash, string inputHash)
        {
            if (user == null) return false;
            return oldHash == inputHash;
        }
    }
}