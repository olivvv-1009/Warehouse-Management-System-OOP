using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ReturnService
    {
        private ReturnRepository _repository;

        public ReturnService()
        {
            _repository =
                new ReturnRepository();
        }

        public List<ReturnOrder> GetAll()
        {
            return _repository.GetAll();
        }

        public bool CreateReturnOrder(
            ReturnOrder returnOrder)
        {
            if (returnOrder == null)
            {
                return false;
            }

            if (returnOrder.ReturnOrderId == "")
            {
                return false;
            }

            return _repository
                .AddReturnOrder(returnOrder);
        }

        public bool AddProductToReturnOrder(
            string returnOrderId,
            ReturnOrderDetail detail)
        {
            if (detail == null)
            {
                return false;
            }

            if (detail.ProductId == "")
            {
                return false;
            }

            if (detail.Quantity <= 0)
            {
                return false;
            }

            return _repository.AddDetail(
                returnOrderId,
                detail
            );
        }

        public ReturnOrder FindById(
            string returnOrderId)
        {
            return _repository.FindById(
                returnOrderId
            );
        }

        public void Delete(
            string returnOrderId)
        {
            _repository.Delete(
                returnOrderId
            );
        }

        public void Update(
            List<ReturnOrder> returnOrders)
        {
            _repository.Update(
                returnOrders
            );
        }
    }
}