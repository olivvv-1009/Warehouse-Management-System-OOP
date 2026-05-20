using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Controllers
{
    public class ReturnController
    {
        private ReturnService _service;

        public ReturnController()
        {
            _service =
                new ReturnService();
        }

        public List<ReturnOrder> GetAll()
        {
            return _service.GetAll();
        }

        public bool CreateReturnOrder(
            ReturnOrder returnOrder)
        {
            return _service
                .CreateReturnOrder(
                    returnOrder
                );
        }

        public bool AddProductToReturnOrder(
            string returnOrderId,
            ReturnOrderDetail detail)
        {
            return _service
                .AddProductToReturnOrder(
                    returnOrderId,
                    detail
                );
        }

        public ReturnOrder FindById(
            string returnOrderId)
        {
            return _service.FindById(
                returnOrderId
            );
        }

        public void Delete(
            string returnOrderId)
        {
            _service.Delete(
                returnOrderId
            );
        }

        public void Update(
            List<ReturnOrder> returnOrders)
        {
            _service.Update(
                returnOrders
            );
        }
    }
}
