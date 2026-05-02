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

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class MainForm_Staff : Form
    {
        private ProductForm _productForm;
        public MainForm_Staff()
        {
            InitializeComponent();
            _productForm = new ProductForm();
            _productForm.ProductAdded += ProductForm_ProductAdded;
        }
        private void LoadView(UserControl view)
        {
            mainpanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(view);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadView(_productForm);
        }
        private void ProductForm_ProductAdded(object sender, ProductAddedEventArgs e)
        {
            // For now, just show a notification. In future, update other UI parts if needed.
            MessageBox.Show($"Product '{e.ProductName}' added!", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
