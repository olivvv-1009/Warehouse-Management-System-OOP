using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Auth_Login
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
            txtNewPassword.Enabled = false;
            btnReset.Enabled = false;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            AuthController controller = new AuthController();

            string question = controller.GetQuestion(txtUsername.Text);

            if (question != null)
            {
                lblQuestion.Text = question;
            }
            else
            {
                MessageBox.Show("Không tìm thấy user!");
            }
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            AuthController controller = new AuthController();

            bool ok = controller.Verify(txtUsername.Text, txtAnswer.Text);

            if (ok)
            {
                MessageBox.Show("Đúng!");
                txtNewPassword.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                MessageBox.Show("Sai câu trả lời!");
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            AuthController controller = new AuthController();

            bool ok = controller.Reset(txtUsername.Text, txtNewPassword.Text);

            if (ok)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
        }
    }
}
