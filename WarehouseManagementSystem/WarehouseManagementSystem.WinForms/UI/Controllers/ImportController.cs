using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.Controllers
{
    internal class ImportController
    {
        private readonly ImportService
            _importService;

        private readonly LocationService
            _locationService;

        private readonly ProductService
            _productService;

        public ImportController()
        {
            _importService =
                new ImportService();

            _locationService =
                new LocationService();

            _productService =
                new ProductService();
        }

        public List<Supplier>
            GetAllSuppliers()
        {
            return _importService
                .GetAllSuppliers();
        }

        public List<ProductDisplayModel>
    GetAllProducts()
        {
            return _productService
                .GetAllProducts();
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

        public WarehouseLocation
            AutoAssignLocation(
                string productId,
                int quantity)
        {
            WarehouseLocation location =
                _locationService
                    .FindBestLocation(
                        productId,
                        quantity
                    );

            return location;
        }

        public bool ValidateImportOrder(
            List<OrderDetail> items)
        {
            int i;

            for (
                i = 0;
                i < items.Count;
                i++
            )
            {
                if (
                    items[i].Quantity <= 0
                )
                {
                    return false;
                }

                if (
                    items[i].UnitPrice <= 0
                )
                {
                    return false;
                }
            }

            return true;
        }

        public bool CreateImportOrder(
    string supplierId,
    string employeeName,
    List<OrderDetail> items)
        {
            return _importService
                .CreateImportOrder(
                    supplierId,
                    employeeName,
                    items
                );
        }
    }
}