using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Import;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.Utils;
namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class MainForm_Staff : Form
    {
        private ProductForm _productForm;
        public MainForm_Staff()
        {
            InitializeComponent();
            _productForm = new ProductForm();

        }
        private void MainForm_Staff_Load(object sender, EventArgs e)
        {
            var user = Session.CurrentUser;

            if (user != null)
            {
                lbName.Text = user.Username;
                lbRole.Text = user.Role;
            }
        }
        private void LoadView(UserControl view)
        {
            mainpanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(view);
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
