using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.Controllers
{
    internal class ImportController
    {
        private readonly ImportService
            _importService;

        public ImportController()
        {
            _importService =
                new ImportService();
        }

        public bool ImportProduct(
            string productId,
            string productName,
            int quantity,
            int minStock,
            string locationCode)
        {
            InventoryItem item =
                new InventoryItem();

            item.ProductId =
                productId;

            item.ProductName =
                productName;

            item.Quantity =
                quantity;

            item.MinStock =
                minStock;

            return _importService
                .ImportProduct(
                    item,
                    locationCode
                );
        }
    }
}