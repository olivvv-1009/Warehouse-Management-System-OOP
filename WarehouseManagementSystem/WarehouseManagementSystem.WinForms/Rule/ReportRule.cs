namespace WarehouseManagementSystem.WinForms.Rules
{
    public class ReportRule
    {
        public bool IsValidDateRange(System.DateTime start, System.DateTime end)
        {
            if (start == null || end == null)
            {
                return false;
            }

            if (start > end)
            {
                return false;
            }

            return true;
        }

        public bool IsValidCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return true; // All category allowed
            }

            return true;
        }
    }
}