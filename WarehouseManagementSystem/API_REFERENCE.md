# Product Management API Reference

## ProductService

Complete API reference for the ProductService class.

### Constructor

```csharp
// Default constructor - creates new repositories
public ProductService()

// Constructor with custom repositories (for testing/custom paths)
public ProductService(
    ProductRepository productRepository = null,
    InventoryRepository inventoryRepository = null,
    BatchRepository batchRepository = null)
```

### Methods

#### AddProduct

Adds a new product to the system.

```csharp
public string AddProduct(
    string productName,
    string category,
    int minStock,
    double importPrice = 0,
    double exportPrice = 0)
```

**Parameters:**
- `productName` (string): Name of the product. Must not be empty. Max 255 characters.
- `category` (string): Product category. Must not be empty. Max 100 characters.
- `minStock` (int): Minimum stock level. Must be >= 0.
- `importPrice` (double, optional): Import price. Default 0. Must be >= 0.
- `exportPrice` (double, optional): Export price. Default 0. Must be >= 0.

**Returns:**
- (string): Generated ProductID in format "PR####" (e.g., "PR0001")

**Throws:**
- `ArgumentException`: If productName is empty, category is empty, or minStock is negative
- `Exception`: If product already exists (should not happen with auto-generation)

**Example:**
```csharp
var service = new ProductService();
try
{
    string productId = service.AddProduct(
        "Dell XPS 15",
        "Electronics",
        5,
        15000000,
        16000000
    );
    Console.WriteLine($"Product added: {productId}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation error: {ex.Message}");
}
```

**Side Effects:**
1. Creates new Product in products.json
2. Creates new InventoryItem in inventory.json
3. Sets CreatedAt = DateTime.Now
4. Generates unique ProductID

---

#### UpdateProduct

Updates an existing product. Cannot modify ProductID.

```csharp
public void UpdateProduct(
    string productId,
    string productName,
    string category,
    int minStock)
```

**Parameters:**
- `productId` (string): The ProductID to update. Format "PR####".
- `productName` (string): New product name. Must not be empty.
- `category` (string): New category. Must not be empty.
- `minStock` (int): New minimum stock level. Must be >= 0.

**Returns:**
- (void)

**Throws:**
- `ArgumentException`: If productId is empty, productName is empty, category is empty, or minStock is negative
- `Exception`: If product with productId not found

**Example:**
```csharp
var service = new ProductService();
try
{
    service.UpdateProduct(
        "PR0001",
        "Dell XPS 15 Pro",
        "Premium Electronics",
        10
    );
    Console.WriteLine("Product updated");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

**Side Effects:**
1. Updates Product in products.json
2. Updates MinStock in inventory.json
3. Does NOT change CreatedAt timestamp
4. Does NOT change ProductID

---

#### DeleteProduct

Deletes a product. Only works if product has no import history.

```csharp
public void DeleteProduct(string productId)
```

**Parameters:**
- `productId` (string): The ProductID to delete. Format "PR####".

**Returns:**
- (void)

**Throws:**
- `ArgumentException`: If productId is empty
- `Exception`: If product has batches (import history) or not found

**Example:**
```csharp
var service = new ProductService();
try
{
    service.DeleteProduct("PR0001");
    Console.WriteLine("Product deleted");
}
catch (Exception ex)
{
    Console.WriteLine($"Cannot delete: {ex.Message}");
    // Example: "Cannot delete product PR0001. It has import history (2 batch(es))..."
}
```

**Side Effects:**
1. Removes Product from products.json
2. Removes InventoryItem from inventory.json
3. Does NOT remove batches (checked before deletion)

**Audit Trail:**
- Fails if ANY batches exist for the product
- This preserves the audit trail of imports

---

#### GetAllProductsWithInventory

Gets all products with complete inventory information.

```csharp
public List<ProductDisplayInfo> GetAllProductsWithInventory()
```

**Parameters:**
- (none)

**Returns:**
- List<ProductDisplayInfo>: All products with inventory and pricing info

**Throws:**
- `Exception`: If unable to load from files

**Properties of each ProductDisplayInfo:**
- `ProductId` (string): "PR####"
- `ProductName` (string): Product name
- `Category` (string): Product category
- `MinStock` (int): Minimum stock level
- `TotalStock` (int): Current total stock (sum of batches)
- `AvgImportPrice` (double): Average import price (Σ(price×qty)/Σ(qty))
- `ImportPrice` (double): Standard import price
- `ExportPrice` (double): Standard export price
- `CreatedAt` (DateTime): Creation timestamp

**Example:**
```csharp
var service = new ProductService();
var products = service.GetAllProductsWithInventory();

foreach (var p in products)
{
    Console.WriteLine($"{p.ProductId}: {p.ProductName}");
    Console.WriteLine($"  Category: {p.Category}");
    Console.WriteLine($"  Stock: {p.TotalStock}/{p.MinStock}");
    Console.WriteLine($"  Avg Price: {p.AvgImportPrice:N0}");
    Console.WriteLine($"  Created: {p.CreatedAt:yyyy-MM-dd}");
}
```

**Performance Note:**
- Loads all products, inventory items, and batches
- Calculates totals and averages
- O(n) complexity where n = number of products

---

#### GetProductWithInventory

Gets a single product with complete inventory information.

```csharp
public ProductDisplayInfo GetProductWithInventory(string productId)
```

**Parameters:**
- `productId` (string): The ProductID to retrieve. Format "PR####".

**Returns:**
- ProductDisplayInfo: Product with inventory details

**Throws:**
- `Exception`: If product not found

**Example:**
```csharp
var service = new ProductService();
try
{
    var product = service.GetProductWithInventory("PR0001");
    Console.WriteLine($"Name: {product.ProductName}");
    Console.WriteLine($"Stock: {product.TotalStock}/{product.MinStock}");
}
catch (Exception ex)
{
    Console.WriteLine($"Not found: {ex.Message}");
}
```

---

#### GetAllProducts

Gets all products (simple list without inventory details).

```csharp
public List<Product> GetAllProducts()
```

**Parameters:**
- (none)

**Returns:**
- List<Product>: All products

**Throws:**
- `Exception`: If unable to load from file

**Example:**
```csharp
var service = new ProductService();
var products = service.GetAllProducts();
Console.WriteLine($"Total products: {products.Count}");
```

---

#### GetProductById

Gets a single product by ID (without inventory details).

```csharp
public Product GetProductById(string productId)
```

**Parameters:**
- `productId` (string): The ProductID to retrieve. Format "PR####".

**Returns:**
- Product: Product object, or null if not found

**Throws:**
- (none)

**Example:**
```csharp
var service = new ProductService();
var product = service.GetProductById("PR0001");
if (product != null)
{
    Console.WriteLine($"Found: {product.ProductName}");
}
else
{
    Console.WriteLine("Not found");
}
```

---

## ProductRepository

Data access layer for products.json

### Constructor

```csharp
public ProductRepository(string filePath = "Data/products.json")
```

### Methods

#### LoadAllProducts
```csharp
public List<Product> LoadAllProducts()
```
Loads all products from products.json.

#### SaveAllProducts
```csharp
public void SaveAllProducts(List<Product> products)
```
Saves products to products.json.

#### GetProductById
```csharp
public Product GetProductById(string productId)
```
Gets single product by ID.

#### AddProduct
```csharp
public void AddProduct(Product product)
```
Adds new product to file.

#### UpdateProduct
```csharp
public void UpdateProduct(Product product)
```
Updates existing product.

#### DeleteProduct
```csharp
public void DeleteProduct(string productId)
```
Deletes product by ID.

#### GenerateNextProductId
```csharp
public string GenerateNextProductId()
```
Generates next ProductID in sequence (PR0001, PR0002, ...).

Returns format: "PR####" (e.g., "PR0042")

---

## InventoryRepository

Data access layer for inventory.json

### Constructor

```csharp
public InventoryRepository(string filePath = "Data/inventory.json")
```

### Methods

#### LoadAllInventoryItems
```csharp
public List<InventoryItem> LoadAllInventoryItems()
```

#### SaveAllInventoryItems
```csharp
public void SaveAllInventoryItems(List<InventoryItem> items)
```

#### GetInventoryItemByProductId
```csharp
public InventoryItem GetInventoryItemByProductId(string productId)
```

#### AddInventoryItem
```csharp
public void AddInventoryItem(InventoryItem item)
```

#### UpdateInventoryItem
```csharp
public void UpdateInventoryItem(InventoryItem item)
```

#### DeleteInventoryItem
```csharp
public void DeleteInventoryItem(string productId)
```

---

## BatchRepository

Data access layer for batches.json

### Constructor

```csharp
public BatchRepository(string filePath = "Data/batches.json")
```

### Methods

#### LoadAllBatches
```csharp
public List<BatchRecord> LoadAllBatches()
```

#### SaveAllBatches
```csharp
public void SaveAllBatches(List<BatchRecord> batches)
```

#### GetBatchesByProductId
```csharp
public List<BatchRecord> GetBatchesByProductId(string productId)
```

#### AddBatch
```csharp
public void AddBatch(BatchRecord batch)
```

#### DeleteBatchesByProductId
```csharp
public void DeleteBatchesByProductId(string productId)
```

---

## DTOs (Data Transfer Objects)

### ProductDisplayInfo

```csharp
public class ProductDisplayInfo
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public int MinStock { get; set; }
    public int TotalStock { get; set; }
    public double AvgImportPrice { get; set; }
    public double ImportPrice { get; set; }
    public double ExportPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

Used for displaying product information with calculated fields.

---

## Error Codes/Messages

### ArgumentException Messages
- "Product name cannot be empty."
- "Category cannot be empty."
- "Minimum stock cannot be negative."
- "Product ID cannot be empty."

### Exception Messages
- "Product with ID {id} already exists."
- "Product with ID {id} not found."
- "Cannot delete product {id}. It has import history ({count} batch(es))..."
- "Error loading products from file: {details}"
- "Error saving products to file: {details}"

---

## Constants (ProductManagementHelper)

```csharp
public const string DATA_DIRECTORY = "Data";
public const string PRODUCTS_FILE = "Data/products.json";
public const string INVENTORY_FILE = "Data/inventory.json";
public const string BATCHES_FILE = "Data/batches.json";
public const string PRODUCT_ID_PREFIX = "PR";
public const int PRODUCT_ID_FORMAT_LENGTH = 4;
```

---

## Threading Considerations

Current implementation is **not thread-safe**. For multi-threaded scenarios:
1. Add lock statements in repositories
2. Use database instead of JSON files
3. Implement async/await patterns

---

## Memory Usage

- Each ProductService instance loads ALL products/inventory/batches into memory
- No pagination currently implemented
- For 10,000+ products, consider implementing:
  - Pagination
  - Filtering before loading
  - Caching layer
  - Database backend

---

## Backward Compatibility

- The service is forward-compatible (can add new fields to JSON)
- Old JSON files will work with new code
- Consider versioning strategy if making breaking changes
