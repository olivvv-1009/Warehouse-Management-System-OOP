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
	}

	private void ProductForm_Load(object sender, EventArgs e)
	{
		LoadProducts();
	}

	private void LoadProducts()
	{
		_allProducts = _productService.GetAllProducts();
		dataGridView1.DataSource = null;
		dataGridView1.DataSource = _allProducts;
		dataGridView1.AutoGenerateColumns = true;
		// Populate category filter
        var categories = _allProducts.Select(p => p.Category).Distinct().ToList();
		categoryCB.Items.Clear();
		categoryCB.Items.Add("All");
		if (categories.Count > 0)
			categoryCB.Items.AddRange(categories.Cast<object>().ToArray());
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
		var filtered = _allProducts.AsEnumerable();
		if (!string.IsNullOrEmpty(search))
		{
			filtered = filtered.Where(p => p.Name.ToLower().Contains(search) || p.ProductID.ToLower().Contains(search));
		}
		if (!string.IsNullOrEmpty(category) && category != "All")
		{
			filtered = filtered.Where(p => p.Category == category);
		}
		dataGridView1.DataSource = null;
		dataGridView1.DataSource = filtered.ToList();
	}
}
}
