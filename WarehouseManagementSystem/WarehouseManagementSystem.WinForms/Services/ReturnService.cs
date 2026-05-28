using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ReturnService
    {
        private readonly ReturnRepository
            _repository;

        private readonly BatchRepository
            _batchRepository;

        public ReturnService()
        {
            _repository =
                new ReturnRepository();

            _batchRepository =
                new BatchRepository();
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

            foreach (ReturnOrder order
                in orders)
            {
                ids.Add(
                    order.ReturnOrderId
                );
            }

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        ids,
                        "RT"
                    );

            returnOrder.ReturnOrderId =
                IdGenerator
                    .GenerateReturnId(
                        nextNumber
                    );

            // ===== UPDATE BATCH =====

            List<Batch> batches =
                _batchRepository
                    .GetAll();

            foreach (
                ReturnOrderDetail detail
                in returnOrder.Details
            )
            {
                foreach (Batch batch
                    in batches)
                {
                    if (
                        batch.BatchId
                        == detail.BatchId
                    )
                    {
                        batch.RemainingQuantity -=
                            detail.Quantity;

                        if (
                            batch.RemainingQuantity
                            < 0
                        )
                        {
                            batch.RemainingQuantity =
                                0;
                        }

                        if (
                            batch.RemainingQuantity
                            == 0
                        )
                        {
                            batch.Status =
                                "Out of Stock";
                        }

                        break;
                    }
                }
            }

            _batchRepository
                .Update(
                    batches
                );

            // ===== SAVE RETURN ORDER =====

            return _repository
                .Add(
                    returnOrder
                );
        }

        // ================= ADD DETAIL =================

        public bool AddProductToReturnOrder(
            string returnOrderId,
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
                    returnOrderId,
                    detail
                );
        }

        // ================= FIND =================

        public ReturnOrder FindById(
            string returnOrderId)
        {
            return _repository
                .FindById(
                    returnOrderId
                );
        }

        // ================= DELETE =================

        public bool Delete(
            string returnOrderId)
        {
            return _repository
                .Delete(
                    returnOrderId
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