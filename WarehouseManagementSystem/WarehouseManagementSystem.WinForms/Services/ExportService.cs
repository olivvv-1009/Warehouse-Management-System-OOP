using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ExportService
    {
        private readonly BatchRepository _batchRepository;
        private readonly ExportRepository _exportRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly FifoRule _fifoRule;

        public ExportService()
        {
            _batchRepository = new BatchRepository();
            _exportRepository = new ExportRepository();
            _transactionRepository = new TransactionRepository();
            _fifoRule = new FifoRule();
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

        // ─── ExportProduct (Complete ngay) ───────────────────────
        public bool ExportProduct(
            string productId, int quantity,
            string employeeName, decimal unitPrice,
            string destination = "")
        {
            var batches = _batchRepository.GetByProductId(productId);
            bool ok = _fifoRule.Apply(batches, quantity, out var deductions);
            if (!ok) return false;

            foreach (var d in deductions)
            {
                var batch = batches.First(x => x.BatchId == d.BatchId);
                batch.Quantity -= d.QuantityToDeduct;
            }
            _batchRepository.Update();

            var invoices = _exportRepository.GetAll();
            int nextNumber = IdGenerator.GetNextNumber(invoices.Select(x => x.ExportId).ToList(), "EXP");
            var invoice = new ExportInvoice
            {
                ExportId = IdGenerator.GenerateExportId(nextNumber),
                EmployeeName = employeeName,
                Destination = destination,
                ExportDate = DateTime.Now,
                Status = "Completed"
            };
            invoice.OrderDetails.Add(new OrderDetail
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalPrice = quantity * unitPrice
            });
            invoice.TotalAmount = invoice.OrderDetails.Sum(x => x.TotalPrice);
            _exportRepository.Add(invoice);
            CreateTransaction(productId, quantity, invoice.ExportId);
            return true;
        }

        // ─── SaveDraft ────────────────────────────────────────────
        public string SaveDraft(
            List<(string ProductId, int Quantity, decimal UnitPrice)> items,
            string employeeName, string destination)
        {
            var invoices = _exportRepository.GetAll();
            int nextNumber = IdGenerator.GetNextNumber(invoices.Select(x => x.ExportId).ToList(), "EXP");
            var invoice = new ExportInvoice
            {
                ExportId = IdGenerator.GenerateExportId(nextNumber),
                EmployeeName = employeeName,
                Destination = destination,
                ExportDate = DateTime.Now,
                Status = "Draft"
            };
            foreach (var item in items)
                invoice.OrderDetails.Add(new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quantity * item.UnitPrice
                });
            invoice.TotalAmount = invoice.OrderDetails.Sum(x => x.TotalPrice);
            _exportRepository.Add(invoice);
            return invoice.ExportId;
        }

        // ─── CompleteDraft ────────────────────────────────────────
        public bool CompleteDraft(string exportId)
        {
            var invoice = _exportRepository.GetAll().FirstOrDefault(x => x.ExportId == exportId);
            if (invoice == null || invoice.Status == "Completed") return false;

            foreach (var detail in invoice.OrderDetails)
            {
                var batches = _batchRepository.GetByProductId(detail.ProductId);
                bool ok = _fifoRule.Apply(batches, detail.Quantity, out var deductions);
                if (!ok) return false;

                foreach (var d in deductions)
                {
                    var batch = batches.First(x => x.BatchId == d.BatchId);
                    batch.Quantity -= d.QuantityToDeduct;
                }
                _batchRepository.Update();

                CreateTransaction(detail.ProductId, detail.Quantity, exportId);
            }
            invoice.Status = "Completed";
            _exportRepository.Update(invoice);
            return true;
        }

    }
}