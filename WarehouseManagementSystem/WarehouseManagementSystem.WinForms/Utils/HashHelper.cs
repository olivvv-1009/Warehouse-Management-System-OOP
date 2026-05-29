using System.Security.Cryptography;
using System.Text;

namespace WarehouseManagementSystem.WinForms.Utils
{
    public static class HashHelper
    {
        public static string Hash(string input)
        {
            SHA256 sha = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2")); // lowercase
            }

            return sb.ToString();
        }
    }
}