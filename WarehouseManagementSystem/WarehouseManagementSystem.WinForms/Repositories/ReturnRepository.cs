using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ReturnRepository
    {
        private const string FilePath =
            "returnorder.json";

        private List<ReturnOrder>
            _returnOrders = new List<ReturnOrder>();

        public ReturnRepository()
        {
            LoadData();
        }

        // ================= LOAD =================

        private void LoadData()
        {
            _returnOrders =
                FileHelper
                    .ReadJsonList<ReturnOrder>(
                        FilePath
                    );

            if (_returnOrders == null)
            {
                _returnOrders =
                    new List<ReturnOrder>();
            }
        }

        // ================= SAVE =================

        private void SaveData()
        {
            FileHelper
                .WriteJsonList(
                    FilePath,
                    _returnOrders
                );
        }

        // ================= GET ALL =================

        public List<ReturnOrder>
            GetAll()
        {
            return _returnOrders;
        }

        // ================= FIND =================

        public ReturnOrder? FindById(
            string InvoiceId)
        {
            int i;

            for (
                i = 0;
                i < _returnOrders.Count;
                i++
            )
            {
                if (
                    _returnOrders[i]
                        .InvoiceId
                    == InvoiceId
                )
                {
                    return _returnOrders[i];
                }
            }

            return null;
        }

        // ================= ADD =================

        public bool Add(
            ReturnOrder returnOrder)
        {
            if (returnOrder == null)
            {
                return false;
            }

            _returnOrders
                .Add(returnOrder);

            SaveData();

            return true;
        }

        // ================= ADD DETAIL =================

        public bool AddDetail(
            string InvoiceId,
            ReturnOrderDetail detail)
        {
            ReturnOrder? returnOrder =
                FindById(
                    InvoiceId
                );

            if (
                returnOrder == null
                || detail == null
            )
            {
                return false;
            }

            returnOrder
                .Details
                .Add(detail);

            SaveData();

            return true;
        }

        // ================= UPDATE =================

        public bool Update(
            ReturnOrder updatedOrder)
        {
            if (updatedOrder == null)
            {
                return false;
            }

            int i;

            for (
                i = 0;
                i < _returnOrders.Count;
                i++
            )
            {
                if (
                    _returnOrders[i]
                        .InvoiceId
                    == updatedOrder
                        .InvoiceId
                )
                {
                    _returnOrders[i] =
                        updatedOrder;

                    SaveData();

                    return true;
                }
            }

            return false;
        }

        // ================= DELETE =================

        public bool Delete(
            string InvoiceId)
        {
            int i;

            for (
                i = 0;
                i < _returnOrders.Count;
                i++
            )
            {
                if (
                    _returnOrders[i]
                        .InvoiceId
                    == InvoiceId
                )
                {
                    _returnOrders
                        .RemoveAt(i);

                    SaveData();

                    return true;
                }
            }

            return false;
        }
    }
}