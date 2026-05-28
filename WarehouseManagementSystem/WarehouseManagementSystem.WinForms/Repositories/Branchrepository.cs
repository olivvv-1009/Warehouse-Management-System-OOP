using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class BranchRepository
    {
        private const string FilePath = "branches.json";

        public List<BranchInfo> GetAll()
        {
            var branches = FileHelper.ReadJsonList<BranchInfo>(FilePath);
            return branches ?? new List<BranchInfo>();
        }
    }
}