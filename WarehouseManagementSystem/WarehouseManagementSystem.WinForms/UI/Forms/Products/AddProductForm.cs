using System;
using System.Windows.Forms;

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class AddProductForm : Form
    {
        public string ProductName => txtProductName.Text.Trim();
        public string Category => txtCategory.Text.Trim();
        public int MinimumStock => int.TryParse(txtMinStock.Text, out var val) ? val : 0;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductName) || string.IsNullOrWhiteSpace(Category) || MinimumStock < 0)
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnAdd.Click += btnAdd_Click;
            txtProductName.Focus();
        }
    }
}
