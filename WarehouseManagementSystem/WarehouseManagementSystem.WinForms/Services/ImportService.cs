using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class ImportService
    {
        private readonly BatchRepository
            _batchRepository;

        private readonly LocationRepository
            _locationRepository;

        private readonly ImportRepository
            _importRepository;

        private readonly SupplierService
            _supplierService;

        private readonly ProductRepository
            _productRepository;

        private readonly LocationAssignmentRule
            _locationRule;

        public ImportService()
        {
            _batchRepository =
                new BatchRepository();

            _locationRepository =
                new LocationRepository();

            _importRepository =
                new ImportRepository();

            _supplierService =
                new SupplierService();

            _productRepository =
                new ProductRepository();

            _locationRule =
                new LocationAssignmentRule();
        }

        public bool CreateImportOrder(
            string supplierId,
            string employeeName,
            List<OrderDetail> items)
        {
            List<WarehouseLocation> locations =
                _locationRepository
                    .GetAll();

            List<Product> products =
                _productRepository
                    .GetAll();

            int i;

            for (
                i = 0;
                i < items.Count;
                i++
            )
            {
                OrderDetail item =
                    items[i];

                Product product =
                    null;

                int j;

                for (
                    j = 0;
                    j < products.Count;
                    j++
                )
                {
                    if (
                        products[j].ProductID
                        == item.ProductId
                    )
                    {
                        product =
                            products[j];

                        break;
                    }
                }

                if (product == null)
                {
                    return false;
                }

                WarehouseLocation location =
                    _locationRule
                        .FindAvailableLocation(
                            locations,
                            item.ProductId,
                            product.Category,
                            item.Quantity
                        );

                if (location == null)
                {
                    return false;
                }

                location.ProductId =
                    item.ProductId;

                location.UsedCapacity +=
                    item.Quantity;

                List<Batch> oldBatches =
                    _batchRepository
                        .GetByProductId(
                            item.ProductId
                        );

                int batchNumber =
                    oldBatches.Count + 1;

                Batch batch =
                    new Batch();

                batch.BatchId =
                    "BAT-"
                    + item.ProductId
                    + "-"
                    + batchNumber
                        .ToString("D2");

                batch.ProductId =
                    item.ProductId;

                batch.SupplierId =
                    supplierId;

                batch.LocationCode =
                    location.LocationCode;

                batch.Quantity =
                    item.Quantity;

                batch.RemainingQuantity =
                    item.Quantity;

                batch.ImportPrice =
                    item.UnitPrice;

                batch.ImportDate =
                    DateTime.Now;

                batch.Status =
                    "Stored";

                _batchRepository
                    .Add(batch);

                item.BatchId =
                    batch.BatchId;

                item.LocationCode =
                    location.LocationCode;

                item.Zone =
                    location.Zone;

                item.Rack =
                    location.Rack;

                item.Shelf =
                    location.Shelf;
            }

            _locationRepository
                .Update();

            List<ImportInvoice> invoices =
                _importRepository
                    .GetAll();

            List<string> ids =
                new List<string>();

            int k;

            for (
                k = 0;
                k < invoices.Count;
                k++
            )
            {
                ids.Add(
                    invoices[k]
                        .ImportId
                );
            }

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        ids,
                        "IMP"
                    );

            ImportInvoice invoice =
                new ImportInvoice();

            invoice.ImportId =
                IdGenerator
                    .GenerateImportId(
                        nextNumber
                    );

            invoice.SupplierId =
                supplierId;

            invoice.EmployeeName =
                employeeName;

            invoice.ImportDate =
                DateTime.Now;

            invoice.OrderDetails =
                items;

            decimal totalAmount = 0;

            for (
                k = 0;
                k < items.Count;
                k++
            )
            {
                totalAmount +=
                    items[k]
                        .TotalPrice;
            }

            invoice.TotalAmount =
                totalAmount;

            _importRepository
                .Add(invoice);

            return true;
        }
    }
}