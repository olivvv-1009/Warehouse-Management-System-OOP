using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rules;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ProfileService : IProfileService
    {
        private ProfileRepository repo = new ProfileRepository();
        private ProfileRule rule = new ProfileRule();

        public Profile GetByAccountId(string accountId)
        {
            return repo.GetByAccountId(accountId);
        }

        public string GetFullName(string accountId)
        {
            Profile p = repo.GetByAccountId(accountId);

            if (p == null)
                return "";

            return p.FullName;
        }

        public bool UpdateProfile(Profile profile)
        {
            if (!rule.IsValidName(profile.FullName))
                return false;

            if (!rule.IsValidPhone(profile.Phone))
                return false;

            if (!rule.IsValidEmail(profile.Email))
                return false;

            repo.Update(profile);

            return true;
        }
    }
}