using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Files;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ProfileRepository
    {
        private string fileName = "profile.json";

        public List<Profile> GetAll()
        {
            List<Profile> list = FileHelper.ReadJsonList<Profile>(fileName);
            if (list == null)
                list = new List<Profile>();
            return list;
        }

        public Profile GetByAccountId(string accountId)
        {
            List<Profile> list = GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountId == accountId)
                    return list[i];
            }

            return null;
        }

        public void Update(Profile profile)
        {
            List<Profile> list = GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountId == profile.AccountId)
                {
                    list[i] = profile;
                    break;
                }
            }

            FileHelper.WriteJsonList(fileName, list);
        }
    }
}