using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
	Load += ProductForm_Load;
	addproductBtn.Click += addproductBtn_Click;
	searchBtn.Click += searchBtn_Click;
	categoryCB.SelectedIndexChanged += categoryCB_SelectedIndexChanged;
	dataGridView1.CellContentClick += dataGridView1_CellContentClick;
}

	private void ProductForm_Load(object sender, EventArgs e)
	{
		LoadProducts();
	}

    private void LoadProducts()
	{
		_allProducts = _productService.GetAllProducts();
		dataGridView1.DataSource = null;
		// Build DataTable for custom columns
		var dt = new DataTable();
		dt.Columns.Add("Product Code");
		dt.Columns.Add("Name");
		dt.Columns.Add("Category");
		dt.Columns.Add("Avg Import Price");
		dt.Columns.Add("Min Stock");
		dt.Columns.Add("Status");
		foreach (var p in _allProducts)
		{
			dt.Rows.Add(p.ProductID, p.Name, p.Category, p.AvgImportPrice?.ToString("C") ?? "$0.00", p.MinStock, "Active");
		}
		dataGridView1.DataSource = dt;
		// Add Actions column if not present
		if (!dataGridView1.Columns.Contains("Actions"))
		{
			var actionsCol = new DataGridViewButtonColumn();
			actionsCol.Name = "Actions";
			actionsCol.HeaderText = "Actions";
			actionsCol.Text = "✏️ / 🗑️";
			actionsCol.UseColumnTextForButtonValue = true;
			actionsCol.Width = 90;
			dataGridView1.Columns.Add(actionsCol);
		}
		// Style Status column
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			if (row.Cells["Status"].Value?.ToString() == "Active")
			{
				row.Cells["Status"].Style.BackColor = Color.FromArgb(212, 237, 218);
				row.Cells["Status"].Style.ForeColor = Color.FromArgb(40, 167, 69);
				row.Cells["Status"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			}
		}
     // Populate category filter without LINQ
		List<string> categories = new List<string>();
		foreach (var p in _allProducts)
		{
			if (!categories.Contains(p.Category))
			{
				categories.Add(p.Category);
			}
		}
		categoryCB.Items.Clear();
		categoryCB.Items.Add("All Categories");
		if (categories.Count > 0)
		{
			foreach (var cat in categories)
			{
				categoryCB.Items.Add(cat);
			}
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
     string search = searchTB.Text.Trim().ToLower();
		string category = categoryCB.SelectedItem?.ToString();
		List<ProductDisplayModel> filtered = new List<ProductDisplayModel>();
		foreach (var p in _allProducts)
		{
			bool matches = true;
			if (!string.IsNullOrEmpty(search))
			{
				if (!(p.Name != null && p.Name.ToLower().Contains(search)) && !(p.ProductID != null && p.ProductID.ToLower().Contains(search)))
				{
					matches = false;
				}
			}
			if (!string.IsNullOrEmpty(category) && category != "All Categories")
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
		// Rebuild DataTable for filtered results
		var dt = new DataTable();
		dt.Columns.Add("Product Code");
		dt.Columns.Add("Name");
		dt.Columns.Add("Category");
		dt.Columns.Add("Avg Import Price");
		dt.Columns.Add("Min Stock");
		dt.Columns.Add("Status");
		foreach (var p in filtered)
		{
			dt.Rows.Add(p.ProductID, p.Name, p.Category, p.AvgImportPrice?.ToString("C") ?? "$0.00", p.MinStock, "Active");
		}
		dataGridView1.DataSource = dt;
		if (!dataGridView1.Columns.Contains("Actions"))
		{
			var actionsCol = new DataGridViewButtonColumn();
			actionsCol.Name = "Actions";
			actionsCol.HeaderText = "Actions";
			actionsCol.Text = "✏️ / 🗑️";
			actionsCol.UseColumnTextForButtonValue = true;
			actionsCol.Width = 90;
			dataGridView1.Columns.Add(actionsCol);
		}
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			if (row.Cells["Status"].Value?.ToString() == "Active")
			{
				row.Cells["Status"].Style.BackColor = Color.FromArgb(212, 237, 218);
				row.Cells["Status"].Style.ForeColor = Color.FromArgb(40, 167, 69);
				row.Cells["Status"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			}
		}
	}
    // Handle Actions column click
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Actions")
        {
            var productCode = dataGridView1.Rows[e.RowIndex].Cells["Product Code"].Value.ToString();
            var result = MessageBox.Show("Choose an action:\nYes = Edit, No = Delete", "Edit/Delete Product", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Edit
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
					// Pre-fill fields (assume AddProductForm allows this)
					f.Controls["txtProductName"].Text = product.Name;
					f.Controls["txtCategory"].Text = product.Category;
					f.Controls["txtMinStock"].Text = product.MinStock.ToString();
					if (f.ShowDialog() == DialogResult.OK)
					{
						product.Name = f.ProductName;
						product.Category = f.Category;
						product.MinStock = f.MinimumStock;
						_productService.UpdateProduct(product);
						LoadProducts();
					}
				}
			}
            }
            else if (result == DialogResult.No)
            {
                // Delete
                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _productService.DeleteProduct(productCode);
                    LoadProducts();
                }
            }
        }
    }
}
}
