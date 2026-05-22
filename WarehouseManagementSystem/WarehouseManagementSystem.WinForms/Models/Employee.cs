namespace WarehouseManagementSystem.WinForms.Models
{
    public class Employee
    {
        private string employeeId;
        private string fullName;
        private string dateOfBirth;
        private string gender;
        private string phoneNumber;
        private string email;
        private string address;
        private string role;
        private bool isActive;
        private string accountId;

        public string AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Employee()
        {
            employeeId = "";
            fullName = "";
            dateOfBirth = "";
            gender = "";
            phoneNumber = "";
            email = "";
            address = "";
            role = "";
            isActive = true;
        }
    }
}