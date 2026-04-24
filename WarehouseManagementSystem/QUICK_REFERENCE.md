# Product Management - Quick Reference

## Core Classes

### ProductService
Main service for all product operations.

```csharp
var service = new ProductService();

// Add
string id = service.AddProduct("Name", "Category", minStock, importPrice, exportPrice);

// Update  
service.UpdateProduct(id, "NewName", "NewCategory", newMinStock);

// Delete
service.DeleteProduct(id);

// Get All
var products = service.GetAllProductsWithInventory();

// Get One
var product = service.GetProductWithInventory(id);
```

### ProductRepository
Data access for products.json

```csharp
var repo = new ProductRepository();

repo.LoadAllProducts();           // List<Product>
repo.AddProduct(product);
repo.UpdateProduct(product);
repo.DeleteProduct(id);
repo.GetProductById(id);
repo.GenerateNextProductId();    // Returns "PR0001", "PR0002", etc.
repo.SaveAllProducts(list);
```

### InventoryRepository
Data access for inventory.json

```csharp
var repo = new InventoryRepository();

repo.LoadAllInventoryItems();
repo.AddInventoryItem(item);
repo.UpdateInventoryItem(item);
repo.DeleteInventoryItem(id);
repo.GetInventoryItemByProductId(id);
repo.SaveAllInventoryItems(list);
```

### BatchRepository
Data access for batches.json

```csharp
var repo = new BatchRepository();

repo.LoadAllBatches();
repo.AddBatch(batchRecord);
repo.DeleteBatchesByProductId(id);
repo.GetBatchesByProductId(id);
repo.SaveAllBatches(list);
```

## Data Models

### Product
```csharp
public class Product
{
    public string ProductId { get; set; }      // "PR0001"
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double ImportPrice { get; set; }
    public double ExportPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

### InventoryItem
```csharp
public class InventoryItem
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int MinStock { get; set; }
    public List<Batch> Batches { get; set; }
}
```

### BatchRecord
```csharp
public class BatchRecord
{
    public int BatchId { get; set; }
    public string ProductId { get; set; }
    public DateTime ImportDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}
```

### ProductDisplayInfo (DTO)
```csharp
public class ProductDisplayInfo
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public int MinStock { get; set; }
    public int TotalStock { get; set; }      // Σ batch quantities
    public double AvgImportPrice { get; set; } // Σ(price×qty) / Σ(qty)
    public double ImportPrice { get; set; }
    public double ExportPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

## File Locations

```
Data/
├── products.json       (Product list)
├── inventory.json      (Stock levels)
└── batches.json        (Import history)
```

## Common Workflows

### Add Product
```csharp
var service = new ProductService();
try
{
    var id = service.AddProduct("Laptop", "Electronics", 5, 15000000, 16000000);
    Console.WriteLine($"Added: {id}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Display All Products
```csharp
var products = service.GetAllProductsWithInventory();
foreach (var p in products)
{
    Console.WriteLine($"{p.ProductId}: {p.ProductName}");
    Console.WriteLine($"  Category: {p.Category}");
    Console.WriteLine($"  Stock: {p.TotalStock}/{p.MinStock}");
    Console.WriteLine($"  Avg Price: {p.AvgImportPrice:N0}");
}
```

### Update Product
```csharp
try
{
    service.UpdateProduct("PR0001", "New Name", "New Category", 10);
}
catch (Exception ex)
{
    Console.WriteLine($"Update failed: {ex.Message}");
}
```

### Delete Product
```csharp
try
{
    service.DeleteProduct("PR0001");
}
catch (Exception ex)
{
    // Product has import history - cannot delete
    Console.WriteLine($"Cannot delete: {ex.Message}");
}
```

## Validation Helpers

```csharp
// Validate product ID format
bool valid = ProductManagementHelper.IsValidProductId("PR0001");

// Format price for display
string formatted = ProductManagementHelper.FormatPrice(15000000);  // "15,000,000"

// Format datetime for display
string date = ProductManagementHelper.FormatDateTime(DateTime.Now); // "2026-04-24 20:30:45"

// Get stock status
string status = ProductManagementHelper.GetStockStatus(5, 10); // "LOW STOCK ⚠️"

// Validate fields
bool validName = ProductManagementHelper.IsValidProductName("Laptop");
bool validCategory = ProductManagementHelper.IsValidCategory("Electronics");
bool validMinStock = ProductManagementHelper.IsValidMinStock(5);
bool validPrice = ProductManagementHelper.IsValidPrice(15000000);
```

## Exception Handling

```csharp
try
{
    service.AddProduct(name, category, minStock);
}
catch (ArgumentException ex)
{
    // Input validation failed
    // Ex: "Product name cannot be empty."
    Console.WriteLine($"Invalid input: {ex.Message}");
}
catch (Exception ex)
{
    // Business logic error
    // Ex: "Product with ID PR0001 already exists."
    Console.WriteLine($"Operation failed: {ex.Message}");
}
```

## UI DataGridView Binding

```csharp
// Bind to DataGridView
var products = service.GetAllProductsWithInventory();
dataGridView.DataSource = products;

// Format columns
dataGridView.Columns["AvgImportPrice"].DefaultCellStyle.Format = "N0";
dataGridView.Columns["TotalStock"].HeaderText = "Current Stock";
dataGridView.Columns["MinStock"].HeaderText = "Min Stock";
```

## Key Points to Remember

1. **ProductID is auto-generated** - Do not provide it when adding
2. **CreatedAt is immutable** - Set once at creation
3. **Cannot edit ProductID** - Only Name, Category, MinStock
4. **Cannot delete with history** - Check batches first
5. **AvgImportPrice is calculated** - Not stored in database
6. **TotalStock is calculated** - Sum of batch quantities
7. **All files are JSON** - Human-readable, easy to debug
8. **Paths are relative** - Works on any platform/device

## Troubleshooting

### "Data/products.json" not found
- Normal on first run - will be created automatically

### "Product ID already exists"
- ProductID is auto-generated and guaranteed to be unique

### "Cannot delete - has import history"
- Product must be retained for audit trail when batches exist

### "Product not found"
- Check ProductID format (PR0001, not PR1, not pr0001)

### Average Import Price is 0
- No batches have been added for the product yet
- It's calculated as: Σ(batch.price × batch.quantity) / Σ(batch.quantity)

## Performance Notes

- All operations load/save entire JSON files
- For large datasets (10,000+ products), consider implementing:
  - Caching layer
  - Pagination for display
  - Database instead of JSON
  - Async operations

## Future Enhancements

Consider adding:
- Database layer (SQL, NoSQL)
- Async/await for I/O operations
- Caching mechanism
- Search/filter capabilities
- Batch import/export
- Product image storage
- Multi-warehouse support
- User audit logging
