using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.UI.Controllers;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.SettingsForms
{
    public partial class Settings : UserControl
    {
        private ProfileService profileService;
        private AuthController authController;
        public Settings()
        {
            InitializeComponent();
            profileService = new ProfileService();
            authController = new AuthController();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            cboGender.Items.Clear();
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");

            cboRole.Items.Clear();
            cboRole.Items.Add("Admin");
            cboRole.Items.Add("Staff");

            cbQuestion.Items.Clear();
            cbQuestion.Items.Add("Tên thú cưng?");
            cbQuestion.Items.Add("Màu yêu thích?");
            cbQuestion.Items.Add("Tên trường cấp 3?");
            cbQuestion.Items.Add("Món ăn yêu thích?");
            cbQuestion.SelectedIndex = 0;

            if (Session.CurrentUser == null)
            {
                MessageBox.Show("User not logged in");
                return;
            }

            Profile p = new ProfileService()
                .GetByAccountId(Session.CurrentUser.AccountId);

            if (p == null)
            {
                MessageBox.Show("Profile not found");
                return;
            }

            Session.CurrentProfile = p;

            // ===== TEXT =====
            txtFullName.Text = p.FullName;
            txtPhone.Text = p.PhoneNumber;
            txtEmail.Text = p.Email;
            txtAddress.Text = p.Address;

            // ===== DATE FIX =====
            if (DateTime.TryParse(p.DateOfBirth, out DateTime dob))
                dtBirth.Value = dob;

            // ===== COMBO FIX =====
            cboGender.SelectedItem = p.Gender;
            cboRole.SelectedItem = p.Role;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            Profile p = Session.CurrentProfile;

            p.FullName = txtFullName.Text.Trim();
            p.PhoneNumber = txtPhone.Text.Trim();
            p.Email = txtEmail.Text.Trim();
            p.Address = txtAddress.Text.Trim();

            // FIX FORMAT
            p.DateOfBirth = dtBirth.Value.ToString("yyyy-MM-dd");

            bool ok = profileService.UpdateProfile(p);

            if (ok)
            {
                // ================= SYNC EMPLOYEE =================

                EmployeeRepository employeeRepo =
                    new EmployeeRepository();

                Employee emp =
                    employeeRepo.GetById(p.EmployeeId);

                if (emp != null)
                {
                    emp.FullName = p.FullName;
                    emp.PhoneNumber = p.PhoneNumber;
                    emp.Email = p.Email;
                    emp.Address = p.Address;
                    emp.DateOfBirth = p.DateOfBirth;

                    employeeRepo.Update(emp);
                }

                MessageBox.Show("Update successful!");
            }
            else
            {
                MessageBox.Show("Invalid information!");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Confirm password incorrect!");
                return;
            }

            bool ok = authController.ChangePassword(
                Session.CurrentUser.Username,
                txtOldPassword.Text,
                txtNewPassword.Text
            );

            if (ok)
            {
                MessageBox.Show("Password changed!");
            }
            else
            {
                MessageBox.Show("Old password incorrect!");
            }
        }

        private void btnSaveSecurity_Click(object sender, EventArgs e)
        {
            bool ok = authController.UpdateSecurity(
            Session.CurrentUser.Username,
            cbQuestion.Text,
            txtAnswer.Text
             );

            if (ok)
            {
                MessageBox.Show("Security question updated!");
            }
        }
    }
}
