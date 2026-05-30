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

        private readonly TransactionRepository
            _transactionRepository;

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

            _transactionRepository =
                new TransactionRepository();
        }

        // ================= SUPPLIER =================

        public List<Supplier>
            GetAllSuppliers()
        {
            return _supplierService.GetAll();
        }

        // ================= IMPORT =================

        public bool ImportProduct(
            InventoryItem item,
            string locationCode)
        {
            return true;
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

                Product? product =
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

                List<string> usedRacks =
    new List<string>();

                WarehouseLocation location =
                    _locationRule
                        .FindAvailableLocation(
                            locations,
                            item.ProductId,
                            product.Category,
                            item.Quantity,
                            usedRacks
                        );
                if (location == null)
                {
                    return false;
                }

                if (location == null)
                {
                    return false;
                }

                if (
                    string.IsNullOrWhiteSpace(
                        location.ProductId
                    )
                )
                {
                    location.ProductId =
                        item.ProductId;
                }

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

                batch.CreatedDate =
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
    .UpdateLocations(
        locations
    );

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
                        .InvoiceId
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

            invoice.InvoiceId =
                IdGenerator
                    .GenerateImportId(
                        nextNumber
                    );

            invoice.SupplierId =
                supplierId;

            invoice.EmployeeName =
                employeeName;

            invoice.CreatedDate =
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

            // Ghi transaction cho từng sản phẩm
            int t;
            for (
                t = 0;
                t < items.Count;
                t++
            )
            {
                CreateTransaction(
                    items[t].ProductId,
                    items[t].Quantity,
                    invoice.InvoiceId,
                    employeeName
                );
            }

            return true;
        }

        private void CreateTransaction(
            string productId,
            int quantity,
            string InvoiceId,
            string employeeName)
        {
            List<Transaction> transactions =
                _transactionRepository
                    .GetAll();

            List<string> txIds =
                new List<string>();

            int i;
            for (
                i = 0;
                i < transactions.Count;
                i++
            )
            {
                txIds.Add(
                    transactions[i]
                        .TransactionId
                );
            }

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        txIds,
                        "TRN"
                    );

            Transaction transaction =
                new Transaction();

            transaction.TransactionId =
                IdGenerator
                    .GenerateTransactionId(
                        nextNumber
                    );

            transaction.ProductId =
                productId;

            transaction.Quantity =
                quantity;

            transaction.TransactionType =
                Transaction.Types.Import;

            transaction.ReferenceId =
                InvoiceId;

            transaction.Date =
                DateTime.Now;

            _transactionRepository
                .Add(transaction);
        }

        // ================= GET ALL =================

        public List<ImportInvoice>
            GetAll()
        {
            return _importRepository
                .GetAll();
        }

        // ================= FIND =================

        public ImportInvoice?
            FindById(
                string importInvoiceId)
        {
            List<ImportInvoice>
                invoices =
                    _importRepository
                        .GetAll();

            int i;

            for (
                i = 0;
                i < invoices.Count;
                i++
            )
            {
                if (
                    invoices[i].InvoiceId
                    == importInvoiceId
                )
                {
                    return invoices[i];
                }
            }

            return null;
        }
    }
}