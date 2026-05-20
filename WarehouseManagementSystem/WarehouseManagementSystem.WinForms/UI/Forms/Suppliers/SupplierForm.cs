using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Suppliers
{
    public partial class SupplierForm : UserControl
    {
        private SupplierController controller;

        public SupplierForm()
        {
            InitializeComponent();
            controller = new SupplierController();
            dgvSupplier.AutoGenerateColumns = false;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "Search by name or phone...";
            txtSearch.ForeColor = Color.Gray;

            SetGridStyle();
            LoadData();
        }

        // ================= GRID STYLE =================
        private void SetGridStyle()
        {
            dgvSupplier.EnableHeadersVisualStyles = false;

            dgvSupplier.DefaultCellStyle.Font =
                new Font("Times New Roman", 12);

            dgvSupplier.ColumnHeadersDefaultCellStyle.Font =
                new Font("Times New Roman", 12, FontStyle.Bold);

            dgvSupplier.RowTemplate.Height = 60;

            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplier.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSupplier.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvSupplier.ScrollBars = ScrollBars.Both;

            if (dgvSupplier.Columns.Contains("Edit"))
                dgvSupplier.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvSupplier.Columns.Contains("Delete"))
                dgvSupplier.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvSupplier.Columns.Contains("SupplierId"))
                dgvSupplier.Columns["SupplierId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvSupplier.Columns.Contains("PhoneNumber"))
                dgvSupplier.Columns["PhoneNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // ================= LOAD DATA =================
        private void LoadData()
        {
            List<Supplier> list = controller.GetAll();

            if (list == null)
                list = new List<Supplier>();

            RenderData(list);
        }

        // ================= RENDER =================
        private void RenderData(List<Supplier> list)
        {
            dgvSupplier.Rows.Clear();

            int i;
            for (i = 0; i < list.Count; i++)
            {
                dgvSupplier.Rows.Add(
                    list[i].SupplierId,
                    list[i].SupplierName,
                    list[i].PhoneNumber,
                    list[i].Email,
                    list[i].Address
                );
            }
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditSupplierForm form = new AddEditSupplierForm();
            form.ShowDialog();

            ReloadAfterChange();
        }

        // ================= EDIT/DELETE =================
        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            object value = dgvSupplier.Rows[e.RowIndex].Cells[0].Value;
            if (value == null)
                return;

            string supplierId = value.ToString();
            string columnName = dgvSupplier.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                AddEditSupplierForm form = new AddEditSupplierForm(supplierId);
                form.ShowDialog();

                ReloadAfterChange();
            }
            else if (columnName == "Delete")
            {
                DialogResult result = MessageBox.Show(
                    "Delete supplier?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    controller.Delete(supplierId);
                    ReloadAfterChange();
                }
            }
        }

        // ================= SEARCH =================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (keyword == "" || keyword == "Search by name or phone...")
            {
                LoadData();
                return;
            }

            List<Supplier> list = controller.Search(keyword);

            if (list == null)
                list = new List<Supplier>();

            RenderData(list);
        }

        // ================= FIX REFRESH POINT =================
        private void ReloadAfterChange()
        {
            txtSearch.Text = "Search by name or phone...";
            txtSearch.ForeColor = Color.Gray;

            LoadData();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by name or phone...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                txtSearch.Text = "Search by name or phone...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // tránh beep

                string keyword = txtSearch.Text.Trim();

                List<Supplier> list = controller.Search(keyword);

                RenderData(list);
            }
        }
    }
}