using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Services
{
    public interface IAuthService
    {
        Account Login(string username, string password, out int remaining);

        string GetQuestion(string username);

        bool VerifyAnswer(string username, string answer);

        bool ResetPassword(string username, string newPass);

        bool ChangePassword(string username, string oldPass, string newPass);

        bool AdminReset(string accountId, string newPass);
    }
}