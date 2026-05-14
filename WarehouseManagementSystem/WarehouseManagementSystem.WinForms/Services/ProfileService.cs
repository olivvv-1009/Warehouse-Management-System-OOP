using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ProfileService : IProfileService
    {
        private ProfileRepository repo = new ProfileRepository();

        public Profile GetByAccountId(string accountId)
        {
            return repo.GetByAccountId(accountId);
        }

        public string GetFullName(string accountId)
        {
            Profile p = repo.GetByAccountId(accountId);
            return p != null ? p.FullName : "";
        }

        public bool UpdateProfile(Profile profile)
        {
            if (profile == null) return false;

            repo.Update(profile);
            return true;
        }
    }
}