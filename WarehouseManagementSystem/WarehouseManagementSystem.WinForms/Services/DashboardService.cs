using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Rules;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ProductRepository
            _productRepository;

        private readonly InventoryRepository
            _inventoryRepository;

        private readonly TransactionRepository
            _transactionRepository;
        private LookupService _lookupService;
        private DashboardRule _dashboardRule;
        private readonly ImportRepository _importRepository;
        private readonly BatchRepository _batchRepository;


        public DashboardService()
        {
            _productRepository =
                new ProductRepository();

            _inventoryRepository =
                new InventoryRepository();

            _transactionRepository =
                new TransactionRepository();

            _importRepository =
                new ImportRepository();

            _batchRepository =
                new BatchRepository();

            _dashboardRule =
                new DashboardRule();

            _lookupService =
                new LookupService(
                    ConvertProducts(),
                    new List<Supplier>(),
                    _batchRepository.GetAll(),
                    _inventoryRepository.GetAll(),
                    new List<Account>(),
                    new List<Profile>()
                );
        }
        public List<Transaction>
    GetAllTransactions()
        {
            return _transactionRepository
                .GetAll();
        }

        public DashboardStatistic
    GetStatistics()
        {
            List<Product>
                products =
                    _productRepository.GetAll();

            List<InventoryItem>
                inventories =
                    _inventoryRepository.GetAll();

            DashboardStatistic
                statistic =
                    new DashboardStatistic();

            statistic.TotalProducts =
                products.Count;

            int totalInventory = 0;

            int lowStockCount = 0;

            decimal inventoryValue = 0;

            int i;

            for (
                i = 0;
                i < inventories.Count;
                i++
            )
            {
                InventoryItem item =
                    inventories[i];

                totalInventory +=
                    item.Quantity;

                if (
                    _dashboardRule
                        .IsLowStock(item)
                )
                {
                    lowStockCount++;
                }

                decimal importPrice =
                    GetImportPrice(
                        item.ProductId
                    );

                inventoryValue +=
                    _dashboardRule
                        .CalculateInventoryValue(
                            item.Quantity,
                            importPrice
                        );
            }

            statistic.TotalInventory =
                totalInventory;

            statistic.LowStockItems =
                lowStockCount;

            statistic.InventoryValue =
                inventoryValue;

            return statistic;
        }

        private decimal GetImportPrice(
    string productId
)
        {
            List<ImportInvoice>
                imports =
                    _importRepository.GetAll();

            decimal price = 0;

            DateTime latestDate =
                DateTime.MinValue;

            int i;

            for (
                i = 0;
                i < imports.Count;
                i++
            )
            {
                ImportInvoice import =
                    imports[i];

                int j;

                for (
                    j = 0;
                    j < import.OrderDetails.Count;
                    j++
                )
                {
                    OrderDetail detail =
                        import.OrderDetails[j];

                    if (
                        detail.ProductId
                        ==
                        productId
                    )
                    {
                        if (
                            import.ImportDate
                            >
                            latestDate
                        )
                        {
                            latestDate =
                                import.ImportDate;

                            price =
                                detail.UnitPrice;
                        }
                    }
                }
            }

            return price;
        }

        public List<Transaction>
            GetRecentTransactions()
        {
            List<Transaction>
                transactions =
                    _transactionRepository
                        .GetAll();

            transactions.Sort(
                delegate (
                    Transaction a,
                    Transaction b
                )
                {
                    return b.Date.CompareTo(
                        a.Date
                    );
                });

            List<Transaction>
                result =
                    new List<Transaction>();

            int count = 10;

            if (
                transactions.Count
                < count
            )
            {
                count =
                    transactions.Count;
            }

            int i;

            for (
                i = 0;
                i < count;
                i++
            )
            {
                result.Add(
                    transactions[i]
                );
            }

            return result;
        }

        public List<InventoryItem>
    GetLowStockItems()
        {
            List<InventoryItem>
                inventories =
                    _inventoryRepository
                        .GetAll();

            List<InventoryItem>
                result =
                    new List<InventoryItem>();

            int i;

            for (
                i = 0;
                i < inventories.Count;
                i++
            )
            {
                if (
                    inventories[i]
                        .StockStatus
                    ==
                    "Low Stock"
                )
                {
                    result.Add(
                        inventories[i]
                    );
                }
            }

            return result;
        }

        public Dictionary<string, int>
    GetCategoryDistribution()
        {
            List<Product>
                products =
                    _productRepository.GetAll();

            Dictionary<string, int>
                result =
                    new Dictionary<string, int>();

            int i;

            for (
                i = 0;
                i < products.Count;
                i++
            )
            {
                string category = _lookupService.GetProductCategory(products[i].ProductID);

                if (
                    result.ContainsKey(
                        category
                    )
                )
                {
                    result[category]++;
                }
                else
                {
                    result.Add(
                        category,
                        1
                    );
                }
            }

            return result;
        }

        public Dictionary<string, int>
            GetImportExportChart()
        {
            List<Transaction>
                transactions =
                    _transactionRepository
                        .GetAll();

            Dictionary<string, int>
                result =
                    new Dictionary<string, int>();

            DateTime today =
                DateTime.Today;

            int i;

            for (
                i = 6;
                i >= 0;
                i--
            )
            {
                DateTime date =
                    today.AddDays(-i);

                string key =
                    date.ToString("dd/MM");

                result.Add(
                    key,
                    0
                );
            }

            for (
                i = 0;
                i < transactions.Count;
                i++
            )
            {
                Transaction transaction =
                    transactions[i];

                string key =
                    transaction.Date
                        .ToString("dd/MM");

                if (
                    result.ContainsKey(
                        key
                    )
                )
                {
                    result[key] +=
                        transaction.Quantity;
                }
            }

            return result;
        }
        private List<ProductDisplayModel>
    ConvertProducts()
        {
            List<Product>
                products =
                    _productRepository.GetAll();

            List<ProductDisplayModel>
                result =
                    new List<ProductDisplayModel>();

            int i;

            for (
                i = 0;
                i < products.Count;
                i++
            )
            {
                ProductDisplayModel model =
                    new ProductDisplayModel();

                model.ProductID =
                    products[i].ProductID;

                model.Name =
                    products[i].Name;

                model.Category =
                    products[i].Category;

                model.MinStock =
                    products[i].MinStock;

                result.Add(
                    model
                );
            }

            return result;
        }

        public string GetProductCategory(
    string productId
)
        {
            List<Product>
                products =
                    _productRepository.GetAll();

            int i;

            for (
                i = 0;
                i < products.Count;
                i++
            )
            {
                if (
                    products[i].ProductID
                    ==
                    productId
                )
                {
                    return
                        products[i].Category;
                }
            }

            return "Unknown";
        }
    }
}