using System;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Employees
{
    public partial class AddEditEmployeeForm : Form
    {
        private EmployeeController controller;
        private string employeeId;

        public AddEditEmployeeForm()
        {
            InitializeComponent();
            controller = new EmployeeController();
            employeeId = "";
        }

        public AddEditEmployeeForm(string id)
        {
            InitializeComponent();
            controller = new EmployeeController();
            employeeId = id;
        }

        private void AddEditEmployeeForm_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");

            cboRole.Items.Add("Admin");
            cboRole.Items.Add("Staff");

            if (!string.IsNullOrEmpty(employeeId))
            {
                Employee emp = controller.GetById(employeeId);

                if (emp != null)
                {
                    txtFullName.Text = emp.FullName;
                    DateTime dob;

                    if (DateTime.TryParse(emp.DateOfBirth, out dob))
                    {
                        dtpDOB.Value = dob;
                    }
                    cboGender.Text = emp.Gender;
                    txtPhone.Text = emp.PhoneNumber;
                    txtEmail.Text = emp.Email;
                    txtAddress.Text = emp.Address;
                    cboRole.Text = emp.Role;
                }
            }
        }

        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            emp.EmployeeId = employeeId; // empty nếu add

            emp.FullName = txtFullName.Text.Trim();
            emp.DateOfBirth = dtpDOB.Value.ToString("yyyy-MM-dd");
            emp.Gender = cboGender.Text;
            emp.PhoneNumber = txtPhone.Text.Trim();
            emp.Email = txtEmail.Text.Trim();
            emp.Address = txtAddress.Text.Trim();
            emp.Role = cboRole.Text;

            bool success;

            if (string.IsNullOrEmpty(employeeId))
            {
                success = controller.Add(emp);
            }
            else
            {
                emp.EmployeeId = employeeId;
                success = controller.Update(emp);
            }

            if (success)
            {
                MessageBox.Show("Save success!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Save failed!");
            }
        }

        // ================= CANCEL =================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
