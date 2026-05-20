using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class ExportService
    {
        private readonly BatchRepository _batchRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly ExportRepository _exportRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly FifoRule _fifoRule;

        public ExportService()
        {
            _batchRepository = new BatchRepository();
            _inventoryRepository = new InventoryRepository();
            _exportRepository = new ExportRepository();
            _transactionRepository = new TransactionRepository();
            _fifoRule = new FifoRule();
        }

        public bool ExportProduct(
            string productId,
            int quantity,
            string employeeName,
            decimal unitPrice)
        {
            List<Batch> batches =
                _batchRepository.GetByProductId(productId);

            bool success =
                _fifoRule.Apply(
                    batches,
                    quantity,
                    out var deductions);

            if (!success)
            {
                return false;
            }

            foreach (var deduction in deductions)
            {
                Batch batch =
                    batches.First(
                        x => x.BatchId ==
                        deduction.BatchId);

                batch.Quantity -=
                    deduction.QuantityToDeduct;
            }

            _batchRepository.Update();

            InventoryItem inventory = _inventoryRepository.GetByProductId(productId).FirstOrDefault();

            if (inventory != null)
            {
                inventory.Quantity -= quantity;

                _inventoryRepository.Update();
            }

            ExportInvoice invoice =
                CreateInvoice(
                    productId,
                    quantity,
                    employeeName,
                    unitPrice);

            _exportRepository.Add(invoice);

            CreateTransaction(
                productId,
                quantity,
                invoice.ExportId);

            return true;
        }

        private ExportInvoice CreateInvoice(
            string productId,
            int quantity,
            string employeeName,
            decimal unitPrice)
        {
            List<ExportInvoice> invoices =
                _exportRepository.GetAll();

            int nextNumber =
                IdGenerator.GetNextNumber(
                    invoices
                        .Select(x => x.ExportId)
                        .ToList(),
                    "EXP");

            ExportInvoice invoice =
                new ExportInvoice();

            invoice.ExportId =
                IdGenerator.GenerateExportId(
                    nextNumber);

            invoice.EmployeeName =
                employeeName;

            invoice.ExportDate =
                DateTime.Now;

            OrderDetail detail =
                new OrderDetail();

            detail.ProductId =
                productId;

            detail.Quantity =
                quantity;

            detail.UnitPrice =
                unitPrice;

            detail.TotalPrice =
                quantity * unitPrice;

            invoice.OrderDetails.Add(detail);

            invoice.TotalAmount =
                detail.TotalPrice;

            return invoice;
        }

        private void CreateTransaction(
            string productId,
            int quantity,
            string exportId)
        {
            List<Transaction> transactions =
                _transactionRepository.GetAll();

            int nextNumber =
                IdGenerator.GetNextNumber(
                    transactions
                        .Select(
                            x => x.TransactionId)
                        .ToList(),
                    "TRN");

            Transaction transaction =
                new Transaction();

            transaction.TransactionId =
                IdGenerator.GenerateTransactionId(
                    nextNumber);

            transaction.ProductId =
                productId;

            transaction.Quantity =
                quantity;

            transaction.TransactionType =
                Transaction.Types.Export;

            transaction.ReferenceId =
                exportId;

            _transactionRepository
                .Add(transaction);
        }
    }
}