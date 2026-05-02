using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Controllers
{
    internal class AuthController
    {
        private AuthService service;

        public AuthController()
        {
            service = new AuthService();
        }

        public Account Login(string username, string password, out int remaining)
        {
            return service.Login(username, password, out remaining);
        }

        public string GetQuestion(string username)
        {
            return service.GetQuestion(username);
        }

        public bool Verify(string username, string answer)
        {
            return service.VerifyAnswer(username, answer);
        }

        public bool Reset(string username, string newPass)
        {
            return service.ResetPassword(username, newPass);
        }

        public bool AdminReset(string accountId, string newPass)
        {
            return service.AdminReset(accountId, newPass);
        }
    }
}