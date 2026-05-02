using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
	public class ProductAddedEventArgs : EventArgs
	{
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string Category { get; set; }
		public int MinimumStock { get; set; }
		public string Status { get; set; }
	}

	public partial class ProductForm : UserControl
	{
		public event EventHandler<ProductAddedEventArgs> ProductAdded;

		public ProductForm()
		{
			InitializeComponent();
			if (!DesignMode)
			{
				LoadSampleData();
				btnAddProduct.Click += btnAddProduct_Click;
			}
		}

		private void ProductForm_Load(object sender, EventArgs e)
		{
			// Optionally reload data or refresh UI
		}

		private void LoadSampleData()
		{
			dgvProducts.Rows.Clear();
			dgvProducts.Rows.Add("PRD0001", "Laptop Dell XPS 13", "Electronics", "$1200.00", 10, "Active");
			dgvProducts.Rows.Add("PRD0002", "iPhone 15 Pro", "Electronics", "$1000.00", 15, "Active");
			dgvProducts.Rows.Add("PRD0003", "Samsung Galaxy S24", "Electronics", "$800.00", 20, "Active");
			dgvProducts.Rows.Add("PRD0004", "Sony Headphones WH-1000XM5", "Electronics", "$300.00", 25, "Active");
			dgvProducts.Rows.Add("PRD0005", "Apple Watch Series 9", "Electronics", "$350.00", 15, "Active");
		}

		private void btnAddProduct_Click(object sender, EventArgs e)
		{
			using (var addForm = new AddProductForm())
			{
				if (addForm.ShowDialog(this) == DialogResult.OK)
				{
					var code = "PRD" + (dgvProducts.Rows.Count + 1).ToString("D4");
					dgvProducts.Rows.Add(
						code,
						addForm.ProductName,
						addForm.Category,
						"$0.00", // Avg Import Price is calculated elsewhere
						addForm.MinimumStock,
						"Active"
					);
					ProductAdded?.Invoke(this, new ProductAddedEventArgs
					{
						ProductCode = code,
						ProductName = addForm.ProductName,
						Category = addForm.Category,
						MinimumStock = addForm.MinimumStock,
						Status = "Active"
					});
				}
			}
		}
	}
}
