using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
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
            Profile p = Session.CurrentProfile;

            if (p == null)
            {
                MessageBox.Show("Profile not found!");
                return;
            }

            txtFullName.Text = p.FullName;
            txtPhone.Text = p.Phone;
            txtEmail.Text = p.Email;
            txtAddress.Text = p.Address;
            txtPosition.Text = p.Position;

            dtBirth.Text = p.DateOfBirth;

            cbQuestion.Items.Add("Tên thú cưng?");
            cbQuestion.Items.Add("Màu yêu thích?");
            cbQuestion.Items.Add("Tên trường cấp 3?");
            cbQuestion.Items.Add("Món ăn yêu thích?");

            cbQuestion.SelectedIndex = 0;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            Profile p = Session.CurrentProfile;

            p.FullName = txtFullName.Text;
            p.Phone = txtPhone.Text;
            p.Email = txtEmail.Text;
            p.Address = txtAddress.Text;
            p.Position = txtPosition.Text;
            p.DateOfBirth = dtBirth.Text;

            bool ok = profileService.UpdateProfile(p);

            if (ok)
            {
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
