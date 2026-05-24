using WarehouseManagementSystem.WinForms.UI.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Import;
using WarehouseManagementSystem.WinForms.UI.Forms.inventory;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.UI.Forms.SettingsForms;
using WarehouseManagementSystem.WinForms.UI.Forms.Dashboard;
using WarehouseManagementSystem.WinForms.UI.Suppliers;
using WarehouseManagementSystem.WinForms.Utils;
namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class MainForm_Staff : Form
    {
        private ProductForm _productForm;
        public MainForm_Staff()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadView(new Settings());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            LoadView(new SupplierForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
             "Do you want to logout?",
             "Confirm Logout",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                Session.CurrentUser = null;
                Session.CurrentProfile = null;

                LoginForm login = new LoginForm();

                login.Show();

                this.Hide();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadView(new DashboardForm());
        }
    }
}
