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

namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    public partial class CreateExportInvoice : Form
    {
        public CreateExportInvoice()
        {
            InitializeComponent();
            dgvProducts.EnableHeadersVisualStyles =
    false;

            dgvProducts.ColumnHeadersHeight =
                45;

            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor =
                Color.White;

            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(
                    80,
                    80,
                    80
                );

            dgvProducts.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgvProducts.RowTemplate.Height =
                40;
            lblEmployeeValue.Text =
                    Session.CurrentProfile
                        .FullName;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
