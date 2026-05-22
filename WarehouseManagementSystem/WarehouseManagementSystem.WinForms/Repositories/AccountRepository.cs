using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Files;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class AccountRepository
    {
        private string fileName = "accounts.json";

        public List<Account> GetAll()
        {
            List<Account> list = FileHelper.ReadJsonList<Account>(fileName);
            if (list == null)
                list = new List<Account>();
            return list;
        }

        public Account GetById(string accountId)
        {
            List<Account> list = GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountId == accountId)
                    return list[i];
            }

            return null;
        }

        public Account GetByUsername(string username)
        {
            List<Account> list = GetAll();

            foreach (Account acc in list)
            {
                if (acc.Username == username)
                    return acc;
            }

            return null;
        }

        public void Update(Account acc)
        {
            List<Account> list = GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountId == acc.AccountId)
                {
                    list[i] = acc;
                    break;
                }
            }

            FileHelper.WriteJsonList(fileName, list);
        }
    }
}