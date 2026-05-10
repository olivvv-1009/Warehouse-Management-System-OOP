using System;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;


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

        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadView(new ProductForm());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadView(new InventoryForm());
        }
    }
}
