using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ReturnService
    {
        private ReturnRepository
            _repository;

        private BatchRepository
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

            // ===== AUTO GENERATE ID =====

            List<ReturnOrder> orders =
                _repository
                    .GetAll();

            List<string> ids =
                new List<string>();

            int i;

            for (
                i = 0;
                i < orders.Count;
                i++
            )
            {
                ids.Add(
                    orders[i]
                        .ReturnOrderId
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

            for (
                i = 0;
                i <
                returnOrder
                    .Details.Count;
                i++
            )
            {
                ReturnOrderDetail
                    detail =
                        returnOrder
                            .Details[i];

                int j;

                for (
                    j = 0;
                    j < batches.Count;
                    j++
                )
                {
                    if (
                        batches[j]
                            .ProductId
                        == detail
                            .ProductId
                    )
                    {
                        batches[j]
                            .RemainingQuantity -=
                                detail
                                    .Quantity;

                        if (
                            batches[j]
                                .RemainingQuantity
                            < 0
                        )
                        {
                            batches[j]
                                .RemainingQuantity = 0;
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
                detail.ProductId
                == ""
            )
            {
                return false;
            }

            if (
                detail.Quantity
                <= 0
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