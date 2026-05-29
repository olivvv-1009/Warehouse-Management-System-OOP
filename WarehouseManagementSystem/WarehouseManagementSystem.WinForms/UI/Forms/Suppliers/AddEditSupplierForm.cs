using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Suppliers
{
    public partial class AddEditSupplierForm : Form
    {
        private SupplierController controller;
        private string supplierId;
        public AddEditSupplierForm()
        {
            InitializeComponent();
            controller = new SupplierController();

            supplierId = "";
        }

        public AddEditSupplierForm(string supplierId)
        {
            InitializeComponent();

            controller = new SupplierController();

            this.supplierId = supplierId;
        }

        private void AddEditSupplierForm_Load(object sender, EventArgs e)
        {
            if (supplierId != "")
            {
                Supplier supplier = controller.GetById(supplierId);

                if (supplier != null)
                {
                    txtName.Text = supplier.SupplierName;
                    txtPhone.Text = supplier.PhoneNumber;
                    txtEmail.Text = supplier.Email;
                    txtAddress.Text = supplier.Address;

                    this.Text = "Edit Supplier";
                }
            }
            else
            {
                this.Text = "Add Supplier";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Supplier name is required!");
                return;
            }

            Supplier supplier = new Supplier();
            supplier.SupplierName = txtName.Text.Trim();
            supplier.PhoneNumber = txtPhone.Text.Trim();
            supplier.Email = txtEmail.Text.Trim();
            supplier.Address = txtAddress.Text.Trim();

            // EDIT
            if (supplierId != "")
            {
                supplier.SupplierId = supplierId;
                controller.Update(supplier);

                MessageBox.Show("Update success!");
            }
            // ADD
            else
            {
                controller.Add(supplier);
                MessageBox.Show("Add success!");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
