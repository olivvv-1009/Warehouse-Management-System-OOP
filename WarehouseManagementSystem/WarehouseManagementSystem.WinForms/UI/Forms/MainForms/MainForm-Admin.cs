using System;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Forms.Import;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.UI.Forms.SettingsForms;
using WarehouseManagementSystem.WinForms.UI.Suppliers;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadView(UserControl view)
        {
            panel1.Controls.Clear();
            view.Dock = DockStyle.Fill;
            panel1.Controls.Add(view);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Account user = Session.CurrentUser;

            if (user != null)
            {
                lbRole.Text = user.Role;

                // lấy full name từ profile (không dùng var)
                Profile profile = Session.CurrentProfile;

                if (profile != null)
                {
                    lbName.Text = profile.FullName;
                }
                else
                {
                    lbName.Text = user.Username;
                }
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadView(new ProductForm());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadView(new InventoryForm());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            LoadView(new ImportForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadView(new Settings());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            LoadView(new SupplierForm());
        }
    }
}