using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Controllers;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    public partial class CreateImportOrder
        : Form
    {
        private readonly ImportController
            _importController;

        public CreateImportOrder()
        {
            InitializeComponent();

            _importController =
                new ImportController();
        }

        private void CreateImportOrder_Load(
            object sender,
            EventArgs e)
        {
            if (Session.CurrentProfile != null)
            {
                lbCreateby.Text =
                    Session.CurrentProfile
                        .FullName;
            }

            flowProducts.AutoScroll = true;

            flowProducts.WrapContents = false;

            flowProducts.FlowDirection =
                FlowDirection.TopDown;

            flowProducts.HorizontalScroll.Enabled = true;

            flowProducts.HorizontalScroll.Visible = true;



            CreateHeader();

            LoadSuppliers();

            AddProductRowUI();
        }

        private void CreateHeader()
        {
            Panel header =
                new Panel();

            header.Height = 55;

            header.Width = 1000;

            header.BackColor =
                Color.FromArgb(245, 245, 245);

            header.BorderStyle =
                BorderStyle.FixedSingle;



            Label lbProduct =
                new Label();

            lbProduct.Text =
                "Product";

            lbProduct.Location =
                new Point(20, 18);

            lbProduct.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );



            Label lbQty =
                new Label();

            lbQty.Text =
                "Quantity";

            lbQty.Location =
                new Point(230, 18);

            lbQty.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );



            Label lbPrice =
                new Label();

            lbPrice.Text =
                "Price";

            lbPrice.Location =
                new Point(360, 18);

            lbPrice.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );



            Label lbLocation =
                new Label();

            lbLocation.Text =
                "Warehouse";

            lbLocation.Location =
                new Point(500, 18);

            lbLocation.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );



            header.Controls.Add(lbProduct);

            header.Controls.Add(lbQty);

            header.Controls.Add(lbPrice);

            header.Controls.Add(lbLocation);



            flowProducts.Controls.Add(header);
        }

        private void LoadSuppliers()
        {
            List<Supplier> suppliers =
                _importController
                    .GetAllSuppliers();

            cbSupplier.DataSource =
                suppliers;

            cbSupplier.DisplayMember =
                "SupplierName";

            cbSupplier.ValueMember =
                "SupplierId";
        }

        void AddProductRowUI()
        {
            Panel row =
                new Panel();

            row.Height = 70;

            row.Width = 1000;

            row.BackColor =
                Color.White;

            row.BorderStyle =
                BorderStyle.FixedSingle;



            ComboBox cbProduct =
                new ComboBox();

            cbProduct.Name =
                "cbProduct";

            cbProduct.Location =
                new Point(20, 18);

            cbProduct.Width = 160;

            cbProduct.DropDownStyle =
                ComboBoxStyle.DropDownList;



            NumericUpDown numQuantity =
                new NumericUpDown();

            numQuantity.Name =
                "numQuantity";

            numQuantity.Location =
                new Point(230, 18);

            numQuantity.Width = 80;

            numQuantity.Minimum = 1;



            TextBox txtPrice =
                new TextBox();

            txtPrice.Name =
                "txtPrice";

            txtPrice.Location =
                new Point(360, 18);

            txtPrice.Width = 100;



            Label lbZone =
                new Label();

            lbZone.Name =
                "lbZone";

            lbZone.Location =
                new Point(500, 18);

            lbZone.Size =
                new Size(50, 28);

            lbZone.BackColor =
                Color.FromArgb(220, 230, 255);

            lbZone.TextAlign =
                ContentAlignment.MiddleCenter;



            Label lbRack =
                new Label();

            lbRack.Name =
                "lbRack";

            lbRack.Location =
                new Point(560, 18);

            lbRack.Size =
                new Size(65, 28);

            lbRack.BackColor =
                Color.FromArgb(220, 255, 220);

            lbRack.TextAlign =
                ContentAlignment.MiddleCenter;



            Label lbShelf =
                new Label();

            lbShelf.Name =
                "lbShelf";

            lbShelf.Location =
                new Point(635, 18);

            lbShelf.Size =
                new Size(75, 28);

            lbShelf.BackColor =
                Color.FromArgb(245, 220, 255);

            lbShelf.TextAlign =
                ContentAlignment.MiddleCenter;



            Label lbCapacity =
                new Label();

            lbCapacity.Name =
                "lbCapacity";

            lbCapacity.Location =
                new Point(730, 24);

            lbCapacity.AutoSize = true;

            lbCapacity.Text =
                "Capacity: -";



            Button btnRemove =
                new Button();

            btnRemove.Text = "×";

            btnRemove.Location =
                new Point(920, 16);

            btnRemove.Width = 40;

            btnRemove.Height = 30;



            LoadProducts(cbProduct);



            cbProduct.SelectedIndex = -1;

            lbZone.Text = "";

            lbRack.Text = "";

            lbShelf.Text = "";



            cbProduct.SelectionChangeCommitted +=
                ProductChanged;

            numQuantity.ValueChanged +=
                QuantityChanged;

            btnRemove.Click +=
                RemoveRow;



            row.Controls.Add(cbProduct);

            row.Controls.Add(numQuantity);

            row.Controls.Add(txtPrice);

            row.Controls.Add(lbZone);

            row.Controls.Add(lbRack);

            row.Controls.Add(lbShelf);

            row.Controls.Add(lbCapacity);

            row.Controls.Add(btnRemove);



            flowProducts.Controls.Add(row);
        }

        private void LoadProducts(
            ComboBox cbProduct)
        {
            List<ProductDisplayModel> products =
                _importController
                    .GetAllProducts();

            cbProduct.DataSource =
                products;

            cbProduct.DisplayMember =
                "Name";

            cbProduct.ValueMember =
                "ProductID";

            cbProduct.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void ProductChanged(
            object sender,
            EventArgs e)
        {
            ComboBox cbProduct =
                (ComboBox)sender;

            Panel row =
                (Panel)cbProduct.Parent;

            UpdateLocation(row);
        }

        private void QuantityChanged(
            object sender,
            EventArgs e)
        {
            NumericUpDown numQuantity =
                (NumericUpDown)sender;

            Panel row =
                (Panel)numQuantity.Parent;

            UpdateLocation(row);
        }

        private void UpdateLocation(
            Panel row)
        {
            ComboBox cbProduct =
                (ComboBox)row.Controls["cbProduct"];

            NumericUpDown numQuantity =
                (NumericUpDown)row.Controls["numQuantity"];

            Label lbZone =
                (Label)row.Controls["lbZone"];

            Label lbRack =
                (Label)row.Controls["lbRack"];

            Label lbShelf =
                (Label)row.Controls["lbShelf"];

            Label lbCapacity =
                (Label)row.Controls["lbCapacity"];

            if (cbProduct.SelectedValue == null)
            {
                return;
            }

            string productId =
                cbProduct.SelectedValue
                    .ToString();

            int quantity =
                (int)numQuantity.Value;

            WarehouseLocation location =
                _importController
                    .AutoAssignLocation(
                        productId,
                        quantity
                    );

            if (location == null)
            {
                lbZone.Text = "";

                lbRack.Text = "";

                lbShelf.Text = "";

                lbCapacity.Text =
                    "No Space";

                return;
            }

            lbZone.Text =
                location.Zone;

            lbRack.Text =
                location.Rack;

            lbShelf.Text =
                location.Shelf;

            lbCapacity.Text =
                "Capacity: "
                + location.UsedCapacity
                + "/"
                + location.Capacity;
        }

        private void RemoveRow(
            object sender,
            EventArgs e)
        {
            Button btn =
                (Button)sender;

            Panel row =
                (Panel)btn.Parent;

            flowProducts.Controls
                .Remove(row);
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            AddProductRowUI();
        }

        private void btnAddProduct_Click(
            object sender,
            EventArgs e)
        {
            AddProductRowUI();
        }

        private void button5_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                List<OrderDetail> items =
                    new List<OrderDetail>();

                foreach (Control control in flowProducts.Controls)
                {
                    if (!(control is Panel row))
                    {
                        continue;
                    }

                    if (row.Controls["cbProduct"] == null)
                    {
                        continue;
                    }

                    ComboBox cbProduct =
                        (ComboBox)row.Controls["cbProduct"];

                    NumericUpDown numQuantity =
                        (NumericUpDown)row.Controls["numQuantity"];

                    TextBox txtPrice =
                        (TextBox)row.Controls["txtPrice"];

                    Label lbZone =
                        (Label)row.Controls["lbZone"];

                    Label lbRack =
                        (Label)row.Controls["lbRack"];

                    Label lbShelf =
                        (Label)row.Controls["lbShelf"];

                    if (cbProduct.SelectedValue == null)
                    {
                        MessageBox.Show(
                            "Please select product!"
                        );

                        return;
                    }

                    if (!decimal.TryParse(
                            txtPrice.Text,
                            out decimal price))
                    {
                        MessageBox.Show(
                            "Invalid price!"
                        );

                        return;
                    }

                    OrderDetail item =
                        new OrderDetail()
                        {
                            ProductId =
                                cbProduct
                                    .SelectedValue
                                    .ToString(),

                            Quantity =
                                (int)numQuantity.Value,

                            UnitPrice =
                                price,

                            TotalPrice =
                                price *
                                (int)numQuantity.Value,

                            Zone =
                                lbZone.Text,

                            Rack =
                                lbRack.Text,

                            Shelf =
                                lbShelf.Text,

                            LocationCode =
                                lbZone.Text + "-"
                                + lbRack.Text + "-"
                                + lbShelf.Text
                        };

                    items.Add(item);
                }

                bool result =
                    _importController
                        .CreateImportOrder(
                            cbSupplier
                                .SelectedValue
                                .ToString(),

                            Session
                                .CurrentProfile
                                .FullName,

                            items
                        );

                if (result)
                {
                    MessageBox.Show(
                        "Create import order successfully!"
                    );

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Create import order failed!"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}