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
            string InvoiceId,
            ReturnOrderDetail detail)
        {
            return _service
                .AddProductToReturnOrder(
                    InvoiceId,
                    detail
                );
        }

        public ReturnOrder FindById(
            string InvoiceId)
        {
            return _service.FindById(
                InvoiceId
            );
        }

        public void Delete(
            string InvoiceId)
        {
            _service.Delete(
                InvoiceId
            );
        }

        public bool Update(
    ReturnOrder returnOrder)
        {
            return _service.Update(
                returnOrder
            );
        }
    }
}
