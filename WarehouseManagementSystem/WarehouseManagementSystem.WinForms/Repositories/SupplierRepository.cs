using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class SupplierRepository
    {
        private const string FilePath =
            "supplier.json";

        private List<Supplier> _suppliers;

        public SupplierRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            _suppliers =
                FileHelper.ReadJsonList<Supplier>(
                    FilePath
                );

            if (_suppliers == null)
            {
                _suppliers =
                    new List<Supplier>();
            }
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                _suppliers
            );
        }

        public List<Supplier> GetAll()
        {
            return _suppliers;
        }

        public void Add(Supplier supplier)
        {
            _suppliers.Add(supplier);

            SaveData();
        }

        public Supplier FindById(
            string supplierId)
        {
            for (int i = 0;
                i < _suppliers.Count;
                i++)
            {
                if (_suppliers[i].SupplierId
                    == supplierId)
                {
                    return _suppliers[i];
                }
            }

            return null;
        }

        public void Update()
        {
            SaveData();
        }
    }
}