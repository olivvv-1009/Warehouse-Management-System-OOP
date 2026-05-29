using System;
using System.Collections.Generic;
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

        // Generate Batch ID: BAT-PR0001-01, BAT-PR0001-02, ...
        public static string GenerateBatchId(string productId, int batchNumber)
        {
            return $"BAT-{productId}-{batchNumber:D2}";
        }

        // Generate Supplier ID: SP0001, SP0002, ...
        public static string GenerateSupplierId(int nextNumber)
        {
            return $"SP{nextNumber:D4}";
        }

        // Generate Import Order ID
        // IMP0001, IMP0002, ...
        public static string GenerateImportId(
            int nextNumber)
        {
            return $"IMP{nextNumber:D4}";
        }

        // Generate Return Order ID
        // RT0001, RT0002, ...
        public static string GenerateReturnId(
            int nextNumber)
        {
            return
                $"RT{nextNumber:D4}";
        }

        // Generate Export Order ID
        // EXP0001, EXP0002, ...
        public static string GenerateExportId(
            int nextNumber)
        {
            return $"EXP{nextNumber:D4}";
        }
        // Generate Transaction ID
        // TRN0001, TRN0002, ...

        public static string GenerateTransactionId(
            int nextNumber)
        {
            return
                $"TRN{nextNumber:D4}";
        }

        public static string GenerateEmployeeId(int nextNumber)
        {
            return $"EMP{nextNumber:D4}";
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


