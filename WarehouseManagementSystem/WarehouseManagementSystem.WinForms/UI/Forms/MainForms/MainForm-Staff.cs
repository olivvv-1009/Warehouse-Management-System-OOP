using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using WarehouseManagementSystem.WinForms.UI.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;
using WarehouseManagementSystem.WinForms.UI.Forms.Import;
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
