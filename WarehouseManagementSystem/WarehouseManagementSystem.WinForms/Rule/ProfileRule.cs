namespace WarehouseManagementSystem.WinForms.Rules
{
    public class ProfileRule
    {
        public bool IsValidPhone(string phone)
        {
            if (phone.Length < 10)
                return false;

            return true;
        }

        public bool IsValidEmail(string email)
        {
            if (!email.Contains("@"))
                return false;

            return true;
        }

        public bool IsValidName(string name)
        {
            if (name.Trim() == "")
                return false;

            return true;
        }
    }
}