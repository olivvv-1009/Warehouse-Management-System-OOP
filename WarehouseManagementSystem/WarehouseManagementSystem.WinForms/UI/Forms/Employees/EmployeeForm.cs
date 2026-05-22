using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Employees
{
    public partial class EmployeeForm : UserControl
    {
        private EmployeeController controller;

        public EmployeeForm()
        {
            InitializeComponent();
            controller = new EmployeeController();

            dgvEmployee.AutoGenerateColumns = false;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "Search by name, phone or email...";
            txtSearch.ForeColor = Color.Gray;

            SetupGrid();
            LoadData();
        }

        // ================= GRID STYLE =================
        private void SetupGrid()
        {
            dgvEmployee.EnableHeadersVisualStyles = false;

            dgvEmployee.DefaultCellStyle.Font =
                new Font("Times New Roman", 12);

            dgvEmployee.ColumnHeadersDefaultCellStyle.Font =
                new Font("Times New Roman", 12, FontStyle.Bold);

            dgvEmployee.RowTemplate.Height = 100;

            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvEmployee.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvEmployee.ScrollBars = ScrollBars.Both;

            // SAFE CHECK TRÁNH NULL
            if (dgvEmployee.Columns["EmployeeId"] != null)
                dgvEmployee.Columns["EmployeeId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvEmployee.Columns["Gender"] != null)
                dgvEmployee.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvEmployee.Columns["Edit"] != null)
                dgvEmployee.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvEmployee.Columns["Delete"] != null)
                dgvEmployee.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvEmployee.Columns["Reset"] != null)
                dgvEmployee.Columns["Reset"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvEmployee.Columns["Email"] != null)
            {
                dgvEmployee.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEmployee.Columns["Email"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        // ================= LOAD DATA =================
        private void LoadData()
        {
            List<Employee> list = controller.GetAll(); // hoặc GetAllFresh()

            dgvEmployee.Rows.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                dgvEmployee.Rows.Add(
                    list[i].EmployeeId,
                    list[i].FullName,
                    list[i].DateOfBirth,
                    list[i].Gender,
                    list[i].PhoneNumber,
                    list[i].Email,
                    list[i].Address,
                    list[i].Role
                );
            }

            dgvEmployee.Refresh(); // thêm dòng này
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditEmployeeForm form =
                new AddEditEmployeeForm();

            form.ShowDialog();

            LoadData();
        }

        // ================= GRID CLICK =================
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= dgvEmployee.Rows.Count)
                return;

            object cellValue = dgvEmployee.Rows[e.RowIndex].Cells[0].Value;

            if (cellValue == null)
                return;

            string employeeId = cellValue.ToString();

            string column = dgvEmployee.Columns[e.ColumnIndex].Name;

            if (column == "Edit")
            {
                AddEditEmployeeForm form =
                    new AddEditEmployeeForm(employeeId);

                form.ShowDialog();
                LoadData();
            }
            else if (column == "Delete")
            {
                DialogResult r =
                    MessageBox.Show(
                        "Delete employee?",
                        "Confirm",
                        MessageBoxButtons.YesNo
                    );

                if (r == DialogResult.Yes)
                {
                    controller.Delete(employeeId);
                    LoadData();
                }
            }
            else if (column == "Reset")
            {
                DialogResult r =
                    MessageBox.Show(
                        "Reset password to phone number?",
                        "Confirm",
                        MessageBoxButtons.YesNo
                    );

                if (r == DialogResult.Yes)
                {
                    controller.ResetPassword(employeeId);
                    MessageBox.Show("Reset success!");
                }
            }
        }

        // ================= SEARCH =================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by name, phone or email...")
                return;

            List<Employee> list =
                controller.Search(txtSearch.Text.Trim());

            dgvEmployee.Rows.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                dgvEmployee.Rows.Add(
                    list[i].EmployeeId,
                    list[i].FullName,
                    list[i].DateOfBirth,
                    list[i].Gender,
                    list[i].PhoneNumber,
                    list[i].Email,
                    list[i].Address,
                    list[i].Role
                );
            }
        }

        // ================= PLACEHOLDER =================
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Contains("Search"))
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                txtSearch.Text = "Search by name, phone or email...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // ================= ENTER TO SEARCH =================
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData(); // trigger search already via TextChanged
                e.SuppressKeyPress = true;
            }
        }
    }
}
