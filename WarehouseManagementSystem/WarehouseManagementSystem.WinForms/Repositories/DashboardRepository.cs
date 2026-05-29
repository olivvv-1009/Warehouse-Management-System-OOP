using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class DashboardRepository
    {
        public ProductRepository ProductRepository
            = new ProductRepository();

        public InventoryRepository InventoryRepository
            = new InventoryRepository();

        public TransactionRepository TransactionRepository
            = new TransactionRepository();

        public ExportRepository ExportRepository
            = new ExportRepository();

        public ImportRepository ImportRepository
            = new ImportRepository();
    }
}