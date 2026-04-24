# Product Management UI Integration Guide

## Quick Start for UI Forms Integration

This guide shows how to integrate the ProductService into your WinForms UI.

## Adding Product Form Example

```csharp
using System;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class AddProductForm : Form
    {
        private ProductService _productService;

        public AddProductForm()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // Initialize UI components
            // Populate category dropdown, etc.
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from form controls
                string productName = txtProductName.Text;
                string category = cmbCategory.SelectedItem?.ToString();
                int minStock = int.Parse(txtMinStock.Text);
                double importPrice = double.Parse(txtImportPrice.Text);
                double exportPrice = double.Parse(txtExportPrice.Text);

                // Validate inputs (basic validation shown here)
                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("Please enter product name", "Validation Error");
                    return;
                }

                if (string.IsNullOrWhiteSpace(category))
                {
                    MessageBox.Show("Please select category", "Validation Error");
                    return;
                }

                // Call service to add product
                string productId = _productService.AddProduct(
                    productName,
                    category,
                    minStock,
                    importPrice,
                    exportPrice
                );

                MessageBox.Show(
                    $"Product added successfully!\nProduct ID: {productId}",
                    "Success"
                );

                // Clear form
                ClearForm();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error");
            }
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
            txtMinStock.Clear();
            txtImportPrice.Clear();
            txtExportPrice.Clear();
        }
    }
}
```

## Display Products Grid Example

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class ProductListForm : Form
    {
        private ProductService _productService;

        public ProductListForm()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                // Get all products with inventory information
                var products = _productService.GetAllProductsWithInventory();

                // Bind to DataGridView
                dataGridViewProducts.DataSource = products;

                // Configure columns
                ConfigureColumns();

                lblTotal.Text = $"Total Products: {products.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error");
            }
        }

        private void ConfigureColumns()
        {
            // Set column widths and formats
            dataGridViewProducts.Columns["ProductId"].Width = 80;
            dataGridViewProducts.Columns["ProductName"].Width = 150;
            dataGridViewProducts.Columns["Category"].Width = 100;
            dataGridViewProducts.Columns["MinStock"].Width = 80;
            dataGridViewProducts.Columns["TotalStock"].Width = 80;
            dataGridViewProducts.Columns["AvgImportPrice"].Width = 120;
            dataGridViewProducts.Columns["CreatedAt"].Width = 150;

            // Format price columns
            dataGridViewProducts.Columns["AvgImportPrice"].DefaultCellStyle.Format = "N0";
            dataGridViewProducts.Columns["ImportPrice"].DefaultCellStyle.Format = "N0";
            dataGridViewProducts.Columns["ExportPrice"].DefaultCellStyle.Format = "N0";

            // Format date columns
            dataGridViewProducts.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewProducts.Rows[e.RowIndex];
                string productId = row.Cells["ProductId"].Value.ToString();

                // Open edit form
                EditProductForm editForm = new EditProductForm(productId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(); // Refresh after edit
                }
            }
        }
    }
}
```

## Edit Product Form Example

```csharp
using System;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    public partial class EditProductForm : Form
    {
        private ProductService _productService;
        private string _productId;

        public EditProductForm(string productId)
        {
            InitializeComponent();
            _productService = new ProductService();
            _productId = productId;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void LoadProductData()
        {
            try
            {
                var product = _productService.GetProductWithInventory(_productId);

                if (product == null)
                {
                    MessageBox.Show("Product not found", "Error");
                    this.Close();
                    return;
                }

                // Populate form fields
                lblProductId.Text = product.ProductId;
                txtProductName.Text = product.ProductName;
                cmbCategory.SelectedItem = product.Category;
                txtMinStock.Text = product.MinStock.ToString();
                txtImportPrice.Text = product.ImportPrice.ToString("N0");
                txtExportPrice.Text = product.ExportPrice.ToString("N0");
                lblCreatedAt.Text = product.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");

                // Disable ProductId field (read-only)
                lblProductId.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product data: {ex.Message}", "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = txtProductName.Text;
                string category = cmbCategory.SelectedItem?.ToString();
                int minStock = int.Parse(txtMinStock.Text);

                // Call service to update product
                _productService.UpdateProduct(_productId, productName, category, minStock);

                MessageBox.Show("Product updated successfully", "Success");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
```

## Delete Product with Confirmation

```csharp
private void DeleteProduct(string productId)
{
    try
    {
        DialogResult result = MessageBox.Show(
            $"Are you sure you want to delete product {productId}?\n\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Yes)
        {
            _productService.DeleteProduct(productId);
            MessageBox.Show("Product deleted successfully", "Success");
            LoadProducts(); // Refresh the list
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Cannot delete product: {ex.Message}", "Error");
    }
}
```

## Service Initialization Best Practices

```csharp
// Option 1: Create new instance in each form (Simple)
private ProductService _productService = new ProductService();

// Option 2: Use dependency injection (Recommended for larger apps)
public class ProductForm
{
    private readonly ProductService _productService;

    public ProductForm(ProductService productService)
    {
        _productService = productService ?? new ProductService();
    }
}

// Option 3: Singleton pattern (if sharing service across forms)
public static class ServiceManager
{
    private static readonly ProductService _productService = new ProductService();

    public static ProductService ProductService => _productService;
}

// Usage:
var products = ServiceManager.ProductService.GetAllProductsWithInventory();
```

## Common UI Binding Examples

```csharp
// Binding to ComboBox for filtering by category
private void LoadCategoryFilter()
{
    var products = _productService.GetAllProducts();
    var categories = products
        .Select(p => p.Category)
        .Distinct()
        .OrderBy(c => c)
        .ToList();

    cmbCategory.DataSource = categories;
}

// Binding to ListBox
private void LoadProductList()
{
    var products = _productService.GetAllProducts();
    lstProducts.DataSource = products.Select(p => 
        $"{p.ProductId} - {p.ProductName} ({p.Category})"
    ).ToList();
}

// Binding to DataGridView with custom columns
private void BindDataGrid()
{
    var products = _productService.GetAllProductsWithInventory();

    dataGridView1.DataSource = products;

    // Add status column
    var statusColumn = new DataGridViewTextBoxColumn();
    statusColumn.Name = "Status";
    statusColumn.HeaderText = "Stock Status";
    dataGridView1.Columns.Add(statusColumn);

    // Populate status column
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        var minStock = (int)row.Cells["MinStock"].Value;
        var totalStock = (int)row.Cells["TotalStock"].Value;

        if (totalStock <= minStock)
            row.Cells["Status"].Value = "LOW ⚠️";
        else
            row.Cells["Status"].Value = "OK ✓";
    }
}
```

## Error Handling Pattern

```csharp
private void SafeProductOperation(Action operation, string successMessage)
{
    try
    {
        operation?.Invoke();
        MessageBox.Show(successMessage, "Success");
    }
    catch (ArgumentException ex)
    {
        MessageBox.Show($"Invalid input: {ex.Message}", "Validation Error");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Operation failed: {ex.Message}", "Error");
    }
}

// Usage:
SafeProductOperation(
    () => _productService.AddProduct(name, category, minStock, price1, price2),
    "Product added successfully"
);
```

## File Paths Consideration

The ProductService automatically creates the `Data/` folder in the application's working directory. For deployed applications, you can customize the paths:

```csharp
// Custom paths for different environments
var productRepo = new ProductRepository("C:/AppData/products.json");
var inventoryRepo = new InventoryRepository("C:/AppData/inventory.json");
var batchRepo = new BatchRepository("C:/AppData/batches.json");

var productService = new ProductService(productRepo, inventoryRepo, batchRepo);
```

## Tips for UI Development

1. **Always wrap calls in try-catch** to handle business logic errors
2. **Use async/await** for long operations:
   ```csharp
   Task.Run(() => _productService.GetAllProductsWithInventory());
   ```
3. **Show loading indicators** during database operations
4. **Cache data** to improve UI responsiveness
5. **Validate input** before calling service methods
6. **Provide clear error messages** to end users
7. **Test with sample data** using the ProductManagementExample class
