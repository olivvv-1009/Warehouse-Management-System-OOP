using System;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Import;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.Utils;


namespace WarehouseManagementSystem.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadView(UserControl view)
        {
            panel1.Controls.Clear();
            view.Dock = DockStyle.Fill;
            panel1.Controls.Add(view);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var user = Session.CurrentUser;

            if (user != null)
            {
                lbName.Text = user.Username;
                lbRole.Text = user.Role;
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
    }
}
