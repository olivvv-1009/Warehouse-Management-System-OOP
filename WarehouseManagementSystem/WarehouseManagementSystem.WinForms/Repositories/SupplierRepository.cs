using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class SupplierRepository
    {
        private const string FilePath =
            "supplier.json";

        private List<Supplier> suppliers;

        public SupplierRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            suppliers =
                FileHelper.ReadJsonList<Supplier>(
                    FilePath
                );

            if (suppliers == null)
            {
                suppliers =
                    new List<Supplier>();
            }
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                suppliers
            );
        }

        public List<Supplier> GetAll()
        {
            List<Supplier> list =
                FileHelper.ReadJsonList<Supplier>(FilePath);

            if (list == null)
                list = new List<Supplier>();

            suppliers = list; // optional sync
            return list;
        }

        public Supplier GetById(string id)
        {
            for (int i = 0;
                i < suppliers.Count;
                i++)
            {
                if (suppliers[i].SupplierId == id)
                {
                    return suppliers[i];
                }
            }

            return null;
        }

        public void Add(Supplier supplier)
        {
            suppliers.Add(supplier);

            SaveData();
        }

        public void Update(Supplier supplier)
        {
            for (int i = 0;
                i < suppliers.Count;
                i++)
            {
                if (suppliers[i].SupplierId
                    == supplier.SupplierId)
                {
                    suppliers[i] = supplier;
                    break;
                }
            }

            SaveData();
        }

        public void Delete(string id)
        {
            for (int i = 0;
                i < suppliers.Count;
                i++)
            {
                if (suppliers[i].SupplierId == id)
                {
                    suppliers.RemoveAt(i);
                    break;
                }
            }

            SaveData();
        }
    }
}