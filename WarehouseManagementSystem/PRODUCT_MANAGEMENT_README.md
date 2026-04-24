# Product Management Feature Implementation

## Overview
This document describes the implementation of the product management feature for the Warehouse Management System (WMS), including adding, editing, deleting, and displaying products.

## Architecture

The implementation follows a layered architecture:

```
┌─────────────────────────────────────────┐
│         UI Forms (WinForms)             │
├─────────────────────────────────────────┤
│         ProductService (Business Logic) │
├─────────────────────────────────────────┤
│  ProductRepository, InventoryRepository,│
│         BatchRepository (Data Access)   │
├─────────────────────────────────────────┤
│    JSON Files (Data Persistence)        │
│  - products.json                        │
│  - inventory.json                       │
│  - batches.json                         │
└─────────────────────────────────────────┘
```

## File Structure

```
WMS/
├── Models/
│   ├── Products/
│   │   ├── Product.cs          (Updated - now includes CreatedAt and Category)
│   │   ├── Category.cs
│   │   ├── ConsumableProduct.cs
│   │   ├── ElectronicProduct.cs
│   │   └── FoodProduct.cs
│   └── Inventory/
│       ├── InventoryItem.cs    (Unchanged - used for inventory tracking)
│       ├── Batch.cs
│       ├── IStockManageable.cs
│       └── ...
├── Repositories/              (New)
│   ├── ProductRepository.cs    (Handles products.json)
│   ├── InventoryRepository.cs  (Handles inventory.json)
│   └── BatchRepository.cs      (Handles batches.json)
├── Services/
│   ├── ProductService.cs       (New - Business logic for product operations)
│   └── InventoryService.cs     (Placeholder for inventory operations)
└── ...

Data/                           (Created at runtime)
├── products.json              (Stores all products)
├── inventory.json             (Stores inventory items with min stock)
└── batches.json               (Stores batch/import records)
```

## Product Model Update

### Product.cs
The Product class has been updated from abstract to concrete:

```csharp
public class Product
{
    public string ProductId { get; set; }      // Format: PR0001, PR0002, ...
    public string ProductName { get; set; }
    public string Category { get; set; }       // e.g., Electronics, Food, Consumable
    public double ImportPrice { get; set; }
    public double ExportPrice { get; set; }
    public DateTime CreatedAt { get; set; }    // Auto-set when product is created
}
```

## Features Implementation

### 1. Add Product (Thêm sản phẩm)

**Input:**
- Product Name (Tên sản phẩm)
- Category (Phân loại)
- Minimum Stock (Minimum stock)

**Process:**
1. Load products.json
2. Generate ProductID (PR0001, PR0002, ...)
3. Create Product object with CreatedAt = DateTime.Now
4. Add to products.json
5. Create InventoryItem with ProductID and MinStock
6. Add to inventory.json

**Usage:**
```csharp
var productService = new ProductService();
string productId = productService.AddProduct(
    productName: "Laptop",
    category: "Electronics",
    minStock: 5,
    importPrice: 15000000,
    exportPrice: 16000000
);
// Returns: "PR0001"
```

### 2. Edit Product (Sửa sản phẩm)

**Editable Fields:**
- Product Name
- Category
- Minimum Stock
- ~~ProductID~~ (Cannot be modified)

**Process:**
1. Load products.json
2. Find product by ProductID
3. Update Name and Category
4. Save to products.json
5. Load inventory.json
6. Update MinStock
7. Save to inventory.json

**Usage:**
```csharp
var productService = new ProductService();
productService.UpdateProduct(
    productId: "PR0001",
    productName: "Gaming Laptop",
    category: "Electronics",
    minStock: 10
);
```

### 3. Delete Product (Xóa sản phẩm)

**Restrictions:**
- Can only delete products that have never been imported (no batch history)

**Process:**
1. Load batches.json
2. Check if batches exist for the ProductID
3. If YES → Reject deletion (error message)
4. If NO:
   - Delete from products.json
   - Delete from inventory.json

**Usage:**
```csharp
var productService = new ProductService();
try
{
    productService.DeleteProduct("PR0001");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    // Output: "Cannot delete product PR0001. It has import history..."
}
```

### 4. Display Products (Hiển thị sản phẩm)

**Information Displayed:**
- Product ID
- Product Name
- Category
- Minimum Stock (MinStock)
- Total Stock (calculated from batches)
- Average Import Price (calculated from batch history)

**Calculations:**
- **Total Stock**: Sum of all batch quantities for the product
- **Average Import Price**: 
  ```
  AVG = (Sum of all batch prices * quantities) / (Sum of all quantities)
  ```
  This is recalculated each time based on batch data

**Usage:**
```csharp
var productService = new ProductService();

// Get all products with inventory info
List<ProductDisplayInfo> products = productService.GetAllProductsWithInventory();

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductId}");
    Console.WriteLine($"Name: {product.ProductName}");
    Console.WriteLine($"Category: {product.Category}");
    Console.WriteLine($"Min Stock: {product.MinStock}");
    Console.WriteLine($"Total Stock: {product.TotalStock}");
    Console.WriteLine($"Avg Import Price: {product.AvgImportPrice}");
    Console.WriteLine();
}
```

## JSON File Structures

### products.json
```json
[
  {
    "productId": "PR0001",
    "productName": "Laptop",
    "category": "Electronics",
    "importPrice": 15000000,
    "exportPrice": 16000000,
    "createdAt": "2026-04-24T20:30:45.123456"
  },
  {
    "productId": "PR0002",
    "productName": "Milk",
    "category": "Food",
    "importPrice": 25000,
    "exportPrice": 30000,
    "createdAt": "2026-04-24T20:35:10.654321"
  }
]
```

### inventory.json
```json
[
  {
    "inventoryItemId": 0,
    "productId": "PR0001",
    "product": null,
    "quantity": 0,
    "minStock": 5,
    "batches": []
  },
  {
    "inventoryItemId": 0,
    "productId": "PR0002",
    "product": null,
    "quantity": 0,
    "minStock": 50,
    "batches": []
  }
]
```

### batches.json
```json
[
  {
    "batchId": 1,
    "productId": "PR0001",
    "importDate": "2026-04-24T21:00:00",
    "expiryDate": "2028-04-24T21:00:00",
    "quantity": 10,
    "price": 15000000
  },
  {
    "batchId": 2,
    "productId": "PR0001",
    "importDate": "2026-04-24T22:00:00",
    "expiryDate": "2028-04-24T22:00:00",
    "quantity": 5,
    "price": 15500000
  }
]
```

## Classes Reference

### ProductService
Main business logic service for product operations.

**Methods:**
- `string AddProduct(string productName, string category, int minStock, double importPrice = 0, double exportPrice = 0)`
- `void UpdateProduct(string productId, string productName, string category, int minStock)`
- `void DeleteProduct(string productId)`
- `List<ProductDisplayInfo> GetAllProductsWithInventory()`
- `ProductDisplayInfo GetProductWithInventory(string productId)`
- `List<Product> GetAllProducts()`
- `Product GetProductById(string productId)`

### ProductRepository
Data access layer for products.json

**Methods:**
- `List<Product> LoadAllProducts()`
- `void SaveAllProducts(List<Product> products)`
- `Product GetProductById(string productId)`
- `void AddProduct(Product product)`
- `void UpdateProduct(Product product)`
- `void DeleteProduct(string productId)`
- `string GenerateNextProductId()`

### InventoryRepository
Data access layer for inventory.json

**Methods:**
- `List<InventoryItem> LoadAllInventoryItems()`
- `void SaveAllInventoryItems(List<InventoryItem> items)`
- `InventoryItem GetInventoryItemByProductId(string productId)`
- `void AddInventoryItem(InventoryItem item)`
- `void UpdateInventoryItem(InventoryItem item)`
- `void DeleteInventoryItem(string productId)`

### BatchRepository
Data access layer for batches.json

**Methods:**
- `List<BatchRecord> LoadAllBatches()`
- `void SaveAllBatches(List<BatchRecord> batches)`
- `List<BatchRecord> GetBatchesByProductId(string productId)`
- `void AddBatch(BatchRecord batch)`
- `void DeleteBatchesByProductId(string productId)`

## Error Handling

All methods include validation and throw exceptions with descriptive messages:

```csharp
ArgumentException     // Invalid input parameters
Exception             // Business logic violations (e.g., duplicate ID, not found)
```

**Example Error Messages:**
- "Product name cannot be empty."
- "Category cannot be empty."
- "Minimum stock cannot be negative."
- "Product with ID PR0001 already exists."
- "Product with ID PR9999 not found."
- "Cannot delete product PR0001. It has import history..."

## Cross-Platform Compatibility

The implementation uses:
- **System.Text.Json** for JSON serialization (built-in to .NET, works on all platforms)
- **Standard file I/O** (Path.GetDirectoryName, File.ReadAllText, etc.) that works on Windows, Linux, and macOS
- **Environment-agnostic paths** using Path.Combine and relative paths
- **DateTime** for timestamp handling (cross-platform compatible)

All paths use relative path structure (e.g., "Data/products.json") which works on all operating systems.

## Integration with Existing System

The implementation integrates with:
1. **Product Model** - Updated to include CreatedAt and Category
2. **InventoryItem Model** - Used for tracking minimum stock levels
3. **Batch Model** - Extended with ProductId and Price for import tracking
4. **Existing folder structure** - Maintains the separation of Models, Repositories, and Services

## Usage Example

```csharp
// Initialize service
var productService = new ProductService();

// Add new product
try
{
    string productId = productService.AddProduct(
        productName: "Dell XPS 15",
        category: "Electronics",
        minStock: 5,
        importPrice: 15000000,
        exportPrice: 16000000
    );
    Console.WriteLine($"Product added with ID: {productId}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Display all products
var allProducts = productService.GetAllProductsWithInventory();
foreach (var product in allProducts)
{
    Console.WriteLine($"{product.ProductId}: {product.ProductName} ({product.Category})");
    Console.WriteLine($"  Stock: {product.TotalStock}/{product.MinStock}");
    Console.WriteLine($"  Avg Import Price: {product.AvgImportPrice}");
}

// Update product
productService.UpdateProduct(productId, "Dell XPS 15 Pro", "Electronics", 10);

// Delete product (only if no imports)
try
{
    productService.DeleteProduct(productId);
}
catch (Exception ex)
{
    Console.WriteLine($"Cannot delete: {ex.Message}");
}
```

## Notes

- ProductID is auto-generated in format PR0001, PR0002, etc.
- CreatedAt is automatically set to DateTime.Now when a product is created
- Average import price is recalculated each time (not stored) based on batch data
- Products with import history cannot be deleted (audit trail requirement)
- Only Name, Category, and MinStock can be updated; ProductID is immutable
- All JSON files are created in Data/ directory with proper indentation for readability
