using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Interfaces
{
    public interface IProfileService
    {
        Profile GetByAccountId(string accountId);
        string GetFullName(string accountId);
        bool UpdateProfile(Profile profile);
    }
}
