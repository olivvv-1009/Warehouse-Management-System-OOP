using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class ReturnSupplier : Form
    {
        public ReturnSupplier()
        {
            InitializeComponent();
        }

        private void ReturnSupplier_Load(object sender, EventArgs e)
        {
            if (Session.CurrentProfile != null)
            {
                lbCreatedby.Text = Session.CurrentProfile.FullName;
            }
        }
    }
}
