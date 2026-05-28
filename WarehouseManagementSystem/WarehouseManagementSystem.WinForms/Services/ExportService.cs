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
        private readonly BatchRepository
            _batchRepository;

        private readonly ExportRepository
            _exportRepository;

        private readonly TransactionRepository
            _transactionRepository;

        private readonly FifoRule
            _fifoRule;

        public ExportService()
        {
            _batchRepository =
                new BatchRepository();

            _exportRepository =
                new ExportRepository();

            _transactionRepository =
                new TransactionRepository();

            _fifoRule =
                new FifoRule();
        }

        public bool CreateExportInvoice(
            string employeeName,
            string destination,
            List<OrderDetail> details)
        {
            foreach (OrderDetail detail
                in details)
            {
                List<Batch> batches =
                    _batchRepository
                        .GetByProductId(
                            detail.ProductId
                        );

                bool success =
                    _fifoRule.Apply(
                        batches,
                        detail.Quantity,
                        out var deductions
                    );

                if (!success)
                {
                    return false;
                }

                foreach (var deduction
                    in deductions)
                {
                    Batch batch =
                        batches.First(
                            x => x.BatchId
                                == deduction.BatchId
                        );

                    batch.RemainingQuantity -=
                        deduction.QuantityToDeduct;

                    if (
                        batch.RemainingQuantity
                        <= 0
                    )
                    {
                        batch.RemainingQuantity =
                            0;

                        batch.Status =
                            "Out of Stock";
                    }
                }
            }

            _batchRepository
                .Update();

            List<ExportInvoice> invoices =
                _exportRepository
                    .GetAll();

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        invoices
                            .Select(
                                x => x.ExportId
                            )
                            .ToList(),
                        "EXP"
                    );

            ExportInvoice invoice =
                new ExportInvoice();

            invoice.ExportId =
                IdGenerator
                    .GenerateExportId(
                        nextNumber
                    );

            invoice.EmployeeName =
                employeeName;

            invoice.Destination =
                destination;

            invoice.ExportDate =
                DateTime.Now;

            invoice.OrderDetails =
                details;

            invoice.TotalAmount =
                details.Sum(
                    x => x.TotalPrice
                );

            _exportRepository
                .Add(invoice);

            foreach (OrderDetail detail
                in details)
            {
                CreateTransaction(
                    detail.ProductId,
                    detail.Quantity,
                    invoice.ExportId
                );
            }

            return true;
        }

        private void CreateTransaction(
            string productId,
            int quantity,
            string exportId)
        {
            List<Transaction> transactions =
                _transactionRepository
                    .GetAll();

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        transactions
                            .Select(
                                x => x.TransactionId
                            )
                            .ToList(),
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
                Transaction.Types.Export;

            transaction.ReferenceId =
                exportId;

            _transactionRepository
                .Add(transaction);
        }
    }
}