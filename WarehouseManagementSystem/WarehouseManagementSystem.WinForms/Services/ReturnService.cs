using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ReturnService
    {
        private readonly ReturnRepository _repository;
        private readonly BatchRepository _batchRepository;
        private readonly TransactionRepository _transactionRepository;

        public ReturnService()
        {
            _repository = new ReturnRepository();
            _batchRepository = new BatchRepository();
            _transactionRepository = new TransactionRepository();
        }

        // ================= GET ALL =================

        public List<ReturnOrder>
            GetAll()
        {
            return _repository
                .GetAll();
        }

        // ================= CREATE =================

        public bool CreateReturnOrder(
            ReturnOrder returnOrder)
        {
            if (returnOrder == null)
            {
                return false;
            }

            // ===== GENERATE ID =====

            List<ReturnOrder> orders =
                _repository
                    .GetAll();

            List<string> ids =
    new List<string>();

            foreach (ReturnOrder order in orders)
            {
                ids.Add(
                    order.InvoiceId
                );
            }

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        ids,
                        "RT"
                    );

            returnOrder.InvoiceId =
                IdGenerator
                    .GenerateReturnId(
                        nextNumber
                    );

            // ===== UPDATE BATCH =====

            List<Batch> batches =
                _batchRepository.GetAll();

            foreach (ReturnOrderDetail detail in returnOrder.Details)
            {
                foreach (Batch batch in batches)
                {
                    if (batch.BatchId == detail.BatchId)
                    {
                        batch.RemainingQuantity -= detail.Quantity;

                        if (batch.RemainingQuantity < 0)
                        {
                            batch.RemainingQuantity = 0;
                        }

                        if (batch.RemainingQuantity == 0)
                        {
                            batch.Status = "Out of Stock";
                        }

                        break;
                    }
                }
            }

            _batchRepository.Update(batches);


            // ===== SAVE RETURN ORDER =====

            bool saved = _repository.Add(returnOrder);

            if (saved)
            {
                // Tạo transaction RETURN cho mỗi sản phẩm
                foreach (var detail in returnOrder.Details)
                {
                    List<Transaction> transactions = _transactionRepository.GetAll();
                    int txNextNumber = IdGenerator.GetNextNumber(
                        transactions.Select(x => x.TransactionId).ToList(), "TRN");

                    Transaction transaction = new Transaction();
                    transaction.TransactionId = IdGenerator.GenerateTransactionId(txNextNumber);
                    transaction.ProductId = detail.ProductId;
                    transaction.Quantity = detail.Quantity;
                    transaction.TransactionType = Transaction.Types.Return;
                    transaction.ReferenceId = returnOrder.InvoiceId;
                    _transactionRepository.Add(transaction);
                }
            }

            return saved;
        }

        // ================= ADD DETAIL =================

        public bool AddProductToReturnOrder(
            string InvoiceId,
            ReturnOrderDetail detail)
        {
            if (detail == null)
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    detail.ProductId
                )
            )
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    detail.BatchId
                )
            )
            {
                return false;
            }

            if (
                detail.Quantity <= 0
            )
            {
                return false;
            }

            return _repository
                .AddDetail(
                    InvoiceId,
                    detail
                );
        }

        // ================= FIND =================

        public ReturnOrder FindById(
            string InvoiceId)
        {
            return _repository
                .FindById(
                    InvoiceId
                );
        }

        // ================= DELETE =================

        public bool Delete(
            string InvoiceId)
        {
            return _repository
                .Delete(
                    InvoiceId
                );
        }

        // ================= UPDATE =================

        public bool Update(
            ReturnOrder returnOrder)
        {
            if (returnOrder == null)
            {
                return false;
            }

            return _repository
                .Update(
                    returnOrder
                );
        }
    }
}