using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Forms;

namespace WarehouseManagementSystem.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            ApplicationConfiguration.Initialize();
            FileHelper.EnsureDirectoriesExist();
            // 🔥 TẠO FILE LẦN ĐẦU (QUAN TRỌNG)
            if (!File.Exists(FileHelper.GetFilePath("accounts.json")))
            {
                FileHelper.WriteJsonList("accounts.json", new List<Account>());
            }
            Application.Run(new LoginForm());
        }
    }
}