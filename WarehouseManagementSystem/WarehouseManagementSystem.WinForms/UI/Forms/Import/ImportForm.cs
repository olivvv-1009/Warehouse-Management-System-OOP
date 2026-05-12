using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.UI.Controllers;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class ImportForm : UserControl
    {
        public ImportForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateImportOrder form = new CreateImportOrder();

            form.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnSupplier form = new ReturnSupplier();
            form.ShowDialog();
        }
    }
}
