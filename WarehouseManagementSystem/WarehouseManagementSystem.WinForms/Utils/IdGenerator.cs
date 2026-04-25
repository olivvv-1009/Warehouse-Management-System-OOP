using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Utils
{
    internal class IdGenerator
    {
        // Generate Product ID: PR0001, PR0002, ...
        public static string GenerateProductId(int nextNumber)
        {
            return $"PR{nextNumber:D4}";
        }

        // Generate Batch ID: BA0001, BA0002, ...
        public static string GenerateBatchId(int nextNumber)
        {
            return $"BA{nextNumber:D4}";
        }

        // Get the next number from a list of IDs
        public static int GetNextNumber(List<string> existingIds, string prefix)
        {
            if (existingIds == null || existingIds.Count == 0)
                return 1;

            int maxNumber = 0;
            foreach (var id in existingIds)
            {
                if (id.StartsWith(prefix) && int.TryParse(id.Substring(prefix.Length), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }
            return maxNumber + 1;
        }
    }
}
