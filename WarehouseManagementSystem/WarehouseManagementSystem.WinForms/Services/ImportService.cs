using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class ImportService
    {
        private readonly InventoryRepository
            _inventoryRepository;

        private readonly BatchRepository
            _batchRepository;

        private readonly LocationRepository
            _locationRepository;

        private readonly ImportRepository
            _importRepository;

        private readonly SupplierService
            _supplierService;

        public ImportService()
        {
            _inventoryRepository =
                new InventoryRepository();

            _batchRepository =
                new BatchRepository();

            _locationRepository =
                new LocationRepository();

            _importRepository =
                new ImportRepository();

            _supplierService =
                new SupplierService();
        }

        public List<Supplier>
            GetAllSuppliers()
        {
            return _supplierService
                .GetAllSuppliers();
        }

        public bool ImportProduct(
    InventoryItem item,
    string locationCode)
        {
            WarehouseLocation location =
                _locationRepository
                    .FindByCode(locationCode);

            if (location == null)
            {
                return false;
            }

            if (
                location.UsedCapacity
                + item.Quantity
                > location.Capacity
            )
            {
                return false;
            }

            Batch batch =
                new Batch();

            batch.BatchId =
                Guid.NewGuid()
                    .ToString();

            batch.ProductId =
                item.ProductId;

            batch.LocationCode =
                locationCode;

            batch.Quantity =
                item.Quantity;

            batch.ImportDate =
                DateTime.Now;

            item.BatchId =
                batch.BatchId;

            item.LocationCode =
                locationCode;

            _batchRepository
                .Add(batch);

            _inventoryRepository
                .Add(item);

            location.UsedCapacity +=
                item.Quantity;

            _locationRepository
                .Update();

            ImportInvoice invoice =
                new ImportInvoice();

            invoice.ImportId =
                Guid.NewGuid()
                    .ToString();

            invoice.SupplierId =
                string.Empty;

            invoice.EmployeeName =
                string.Empty;

            invoice.ImportDate =
                DateTime.Now;

            OrderDetail detail =
                new OrderDetail();

            detail.ProductId =
                item.ProductId;

            detail.BatchId =
                batch.BatchId;

            detail.Quantity =
                item.Quantity;

            detail.UnitPrice =
                0;

            detail.TotalPrice =
                0;

            detail.LocationCode =
                locationCode;

            invoice.OrderDetails
                .Add(detail);

            _importRepository
                .Add(invoice);

            return true;
        }

        public bool CreateImportOrder(
    string supplierId,
    string employeeName,
    List<OrderDetail> items)
        {
            List<ImportInvoice> invoices =
                _importRepository.GetAll();

            List<string> ids =
                invoices
                    .Select(x => x.ImportId)
                    .ToList();

            int nextNumber =
                IdGenerator.GetNextNumber(
                    ids,
                    "IMP"
                );

            ImportInvoice invoice =
                new ImportInvoice();

            invoice.ImportId =
                IdGenerator.GenerateImportId(
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

            invoice.TotalAmount =
                items.Sum(
                    x => x.TotalPrice
                );

            _importRepository
                .Add(invoice);

            return true;
        }
    }
}