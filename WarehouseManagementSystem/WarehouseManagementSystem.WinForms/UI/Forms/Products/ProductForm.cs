using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.UI.Forms.Products;
using WarehouseManagementSystem.WinForms.Services;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Products
{
public partial class ProductForm : UserControl
{
	private readonly ProductService _productService = new ProductService();
	private List<ProductDisplayModel> _allProducts = new List<ProductDisplayModel>();

public ProductForm()
{
	InitializeComponent();
    SetupDataGridView();
            Load += ProductForm_Load;
	addproductBtn.Click += addproductBtn_Click;
	searchBtn.Click += searchBtn_Click;
	categoryCB.SelectedIndexChanged += categoryCB_SelectedIndexChanged;
	dataGridView1.CellContentClick += dataGridView1_CellContentClick;
}
        private void SetupDataGridView()
        {
            dataGridView1.BorderStyle =
                BorderStyle.None;

            dataGridView1.BackgroundColor =
                Color.White;

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(30, 41, 59);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersHeight = 45;

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(226, 232, 240);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dataGridView1.RowTemplate.Height = 40;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(230, 230, 230);
        }

        private void ProductForm_Load(object sender, EventArgs e)
	{
		LoadProducts();
	}

        private void LoadProducts()
        {
            _allProducts =
                _productService.GetAllProducts();

            dataGridView1.DataSource =
                BuildProductTable(_allProducts);

            AddActionColumn();

            StyleStatusColumn();

            LoadCategories();
        }

        private void StyleStatusColumn()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Status"].Value?.ToString()
                    == "Active")
                {
                    row.Cells["Status"].Style.BackColor =
                        Color.FromArgb(220, 252, 231);

                    row.Cells["Status"].Style.ForeColor =
                        Color.FromArgb(22, 101, 52);

                    row.Cells["Status"].Style.Font =
                        new Font(
                            "Segoe UI",
                            9,
                            FontStyle.Bold);
                }
            }
        }

        private void LoadCategories()
        {
            List<string> categories =
                new List<string>();

            foreach (var p in _allProducts)
            {
                if (!categories.Contains(p.Category))
                {
                    categories.Add(p.Category);
                }
            }

            categoryCB.Items.Clear();

            categoryCB.Items.Add(
                "All Categories");

            foreach (var cat in categories)
            {
                categoryCB.Items.Add(cat);
            }

            categoryCB.SelectedIndex = 0;
        }

        private void addproductBtn_Click(object sender, EventArgs e)
	{
		using (var f = new AddProductForm())
		{
			if (f.ShowDialog() == DialogResult.OK)
			{
				try
				{
					_productService.AddProduct(f.ProductName, f.Category, f.MinimumStock);
					LoadProducts();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Failed to add product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}

	private void searchBtn_Click(object sender, EventArgs e)
	{
		ApplyFilters();
	}

	private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
	{
		ApplyFilters();
	}

        private void ApplyFilters()
        {
            string search =
                searchTB.Text.Trim().ToLower();

            string category =
                categoryCB.SelectedItem?.ToString();

            List<ProductDisplayModel> filtered =
                new List<ProductDisplayModel>();

            foreach (var p in _allProducts)
            {
                bool matches = true;

                if (!string.IsNullOrEmpty(search))
                {
                    bool containsName =
                        p.Name != null &&
                        p.Name.ToLower().Contains(search);

                    bool containsId =
                        p.ProductID != null &&
                        p.ProductID.ToLower().Contains(search);

                    if (!containsName && !containsId)
                    {
                        matches = false;
                    }
                }

                if (!string.IsNullOrEmpty(category)
                    && category != "All Categories")
                {
                    if (p.Category != category)
                    {
                        matches = false;
                    }
                }

                if (matches)
                {
                    filtered.Add(p);
                }
            }

            dataGridView1.DataSource =
                BuildProductTable(filtered);

            AddActionColumn();

            StyleStatusColumn();
        }

        // Handle Actions column click
        private void dataGridView1_CellContentClick(
         object sender,
         DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string columnName =
                dataGridView1.Columns[e.ColumnIndex].Name;

            string productCode =
                dataGridView1.Rows[e.RowIndex]
                .Cells["Product Code"]
                .Value.ToString();

            // ================= EDIT =================
            if (columnName == "Edit")
            {
                ProductDisplayModel product = null;

                foreach (var p in _allProducts)
                {
                    if (p.ProductID == productCode)
                    {
                        product = p;
                        break;
                    }
                }

                if (product != null)
                {
                    using (var f = new AddProductForm())
                    {
                        f.Controls["txtProductName"].Text =
                            product.Name;

                        f.Controls["txtCategory"].Text =
                            product.Category;

                        f.Controls["txtMinStock"].Text =
                            product.MinStock.ToString();

                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            product.Name =
                                f.ProductName;

                            product.Category =
                                f.Category;

                            product.MinStock =
                                f.MinimumStock;

                            _productService
                                .UpdateProduct(product);

                            LoadProducts();
                        }
                    }
                }
            }

            // ================= DELETE =================
            else if (columnName == "Delete")
            {
                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this product?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _productService
                            .DeleteProduct(productCode);

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "Delete Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private DataTable BuildProductTable(
    List<ProductDisplayModel> products)
        {
            var dt = new DataTable();

            dt.Columns.Add("Product Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Category");
            dt.Columns.Add("Avg Import Price");
            dt.Columns.Add("Min Stock");
            dt.Columns.Add("Status");

            foreach (var p in products)
            {
                dt.Rows.Add(
                    p.ProductID,
                    p.Name,
                    p.Category,
                    p.AvgImportPrice?.ToString("C") ?? "$0.00",
                    p.MinStock,
                    "Active");
            }

            return dt;
        }

        private void AddActionColumn()
        {
            if (!dataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn =
                    new DataGridViewButtonColumn();

                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 70;

                dataGridView1.Columns.Add(editBtn);
            }

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn =
                    new DataGridViewButtonColumn();

                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 80;

                dataGridView1.Columns.Add(deleteBtn);
            }

            dataGridView1.Columns["Edit"].DefaultCellStyle.BackColor =
                Color.FromArgb(59, 130, 246);

            dataGridView1.Columns["Edit"].DefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.Columns["Delete"].DefaultCellStyle.BackColor =
                Color.FromArgb(239, 68, 68);

            dataGridView1.Columns["Delete"].DefaultCellStyle.ForeColor =
                Color.White;
        }
    }
}
