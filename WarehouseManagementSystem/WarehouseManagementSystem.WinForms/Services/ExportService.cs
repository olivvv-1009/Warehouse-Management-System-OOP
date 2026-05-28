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
            // Lấy toàn bộ batch 1 lần duy nhất
            var allBatches = _batchRepository.GetAll();

            // Validate trước — đảm bảo đủ hàng cho tất cả sản phẩm
            foreach (OrderDetail detail in details)
            {
                var batches = allBatches
                    .Where(x => x.ProductId == detail.ProductId)
                    .ToList();

                bool ok = _fifoRule.Apply(batches, detail.Quantity, out _);
                if (!ok) return false;
            }

            // Apply FIFO và cập nhật ExportedQuantity cho từng batch
            foreach (OrderDetail detail in details)
            {
                var batches = allBatches
                    .Where(x => x.ProductId == detail.ProductId)
                    .ToList();

                _fifoRule.Apply(batches, detail.Quantity, out var deductions);

                foreach (var deduction in deductions)
                {
                    var batch = allBatches.FirstOrDefault(x => x.BatchId == deduction.BatchId);
                    if (batch != null)
                    {
                        batch.ExportedQuantity += deduction.QuantityToDeduct;
                        if (batch.AvailableQuantity <= 0)
                            batch.Status = "Out of Stock";
                    }
                }
            }

            // Ghi batch một lần duy nhất
            _batchRepository.Update(allBatches);

            // Tạo invoice
            var invoices = _exportRepository.GetAll();
            int nextNumber = IdGenerator.GetNextNumber(
                invoices.Select(x => x.ExportId).ToList(), "EXP");

            ExportInvoice invoice = new ExportInvoice
            {
                ExportId = IdGenerator.GenerateExportId(nextNumber),
                EmployeeName = employeeName,
                Destination = destination,
                ExportDate = DateTime.Now,
                Status = "Completed",
                OrderDetails = details,
                TotalAmount = details.Sum(x => x.TotalPrice)
            };

            _exportRepository.Add(invoice);

            foreach (OrderDetail detail in details)
                CreateTransaction(detail.ProductId, detail.Quantity, invoice.ExportId);

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

            // Lấy toàn bộ batch list để sửa trực tiếp (không phải copy)
            var allBatches = _batchRepository.GetAll();
            foreach (var d in deductions)
            {
                var batch = allBatches.FirstOrDefault(x => x.BatchId == d.BatchId);
                if (batch != null)
                    batch.ExportedQuantity += d.QuantityToDeduct;
            }
            _batchRepository.Update(allBatches);

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

            // Lấy toàn bộ batch list 1 lần để sửa
            var allBatches = _batchRepository.GetAll();
            foreach (var detail in invoice.OrderDetails)
            {
                var batches = allBatches.Where(x => x.ProductId == detail.ProductId).ToList();
                bool ok = _fifoRule.Apply(batches, detail.Quantity, out var deductions);
                if (!ok) return false;

                foreach (var d in deductions)
                {
                    var batch = allBatches.FirstOrDefault(x => x.BatchId == d.BatchId);
                    if (batch != null)
                        batch.ExportedQuantity += d.QuantityToDeduct;
                }

                CreateTransaction(detail.ProductId, detail.Quantity, exportId);
            }
            _batchRepository.Update(allBatches);
            invoice.Status = "Completed";
            _exportRepository.Update(invoice);
            return true;
        }

    }
}