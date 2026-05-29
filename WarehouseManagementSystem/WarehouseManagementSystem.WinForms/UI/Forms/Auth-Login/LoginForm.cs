using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.UI.Controllers;
using WarehouseManagementSystem.WinForms.UI.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Auth_Login;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            AuthController controller = new AuthController();
            ProfileService profileService = new ProfileService();

            int remaining = 0;

            try
            {
                Account user = controller.Login(username, password, out remaining);

                if (user != null)
                {
                    Session.CurrentUser = user;
                    Session.CurrentProfile = profileService.GetByAccountId(user.AccountId);

                    MessageBox.Show("Login successful!");

                    if (user.Role == "Admin")
                    {
                        Form1 admin = new Form1();
                        admin.Show();
                    }
                    else
                    {
                        MainForm_Staff staff = new MainForm_Staff();
                        staff.Show();
                    }

                    this.Hide();
                }
                else
                {
                    lblAttempts.Text = "Còn " + remaining.ToString() + " lần thử";
                    MessageBox.Show("Sai mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblAttempts.Text = "";
            }
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm f = new ForgotPasswordForm();
            f.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblAttempts.Text = "Còn 5 lần thử";
        }
    }
}
