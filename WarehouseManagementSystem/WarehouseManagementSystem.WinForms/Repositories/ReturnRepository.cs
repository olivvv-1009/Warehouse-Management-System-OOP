using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ReturnRepository
    {
        private const string FilePath =
            "returnOrders.json";

        private List<ReturnOrder> _returnOrders;

        public ReturnRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            _returnOrders =
                FileHelper.ReadJsonList<ReturnOrder>(
                    FilePath
                );

            if (_returnOrders == null)
            {
                _returnOrders =
                    new List<ReturnOrder>();
            }
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                _returnOrders
            );
        }

        public List<ReturnOrder> GetAll()
        {
            return _returnOrders;
        }

        public bool AddReturnOrder(
            ReturnOrder returnOrder)
        {
            _returnOrders.Add(returnOrder);

            SaveData();

            return true;
        }

        public bool AddDetail(
            string returnOrderId,
            ReturnOrderDetail detail)
        {
            for (int i = 0;
                 i < _returnOrders.Count;
                 i++)
            {
                if (_returnOrders[i]
                    .ReturnOrderId ==
                    returnOrderId)
                {
                    _returnOrders[i]
                        .Details
                        .Add(detail);

                    SaveData();

                    return true;
                }
            }

            return false;
        }

        public void Update(
            List<ReturnOrder> returnOrders)
        {
            _returnOrders = returnOrders;

            SaveData();
        }

        public void Delete(
            string returnOrderId)
        {
            for (int i = 0;
                 i < _returnOrders.Count;
                 i++)
            {
                if (_returnOrders[i]
                    .ReturnOrderId ==
                    returnOrderId)
                {
                    _returnOrders
                        .RemoveAt(i);

                    SaveData();

                    break;
                }
            }
        }

        public ReturnOrder FindById(
            string returnOrderId)
        {
            for (int i = 0;
                 i < _returnOrders.Count;
                 i++)
            {
                if (_returnOrders[i]
                    .ReturnOrderId ==
                    returnOrderId)
                {
                    return _returnOrders[i];
                }
            }

            return null;
        }
    }
}