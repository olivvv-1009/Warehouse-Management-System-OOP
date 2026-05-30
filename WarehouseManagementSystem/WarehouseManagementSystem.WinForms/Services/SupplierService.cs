using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Rules;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class SupplierService : ISupplierService
    {
        private SupplierRepository repo;
        private SupplierRule rule;

        public SupplierService()
        {
            repo = new SupplierRepository();
            rule = new SupplierRule();
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public Supplier GetById(string id)
        {
            return repo.GetById(id);
        }

        public List<Supplier> Search(string keyword)
        {
            List<Supplier> result = new List<Supplier>();
            List<Supplier> list = repo.GetAll();

            if (keyword == null)
                keyword = "";

            keyword = keyword.ToLower();

            int i;
            for (i = 0; i < list.Count; i++)
            {
                string name = list[i].SupplierName.ToLower();
                string phone = list[i].PhoneNumber.ToLower();

                if (name.Contains(keyword) || phone.Contains(keyword))
                {
                    result.Add(list[i]);
                }
            }

            return result;
        } 

        public bool Add(Supplier supplier)
        {
            if (!rule.IsValid(supplier))
                return false;

            List<Supplier> list =
                repo.GetAll();

            List<string> ids =
                new List<string>();

            for (int i = 0;
                i < list.Count;
                i++)
            {
                ids.Add(list[i].SupplierId);
            }

            int next =
                IdGenerator.GetNextNumber(
                    ids,
                    "SP"
                );

            supplier.SupplierId =
                "SP" + next.ToString("D4");

            supplier.IsActive = true;

            repo.Add(supplier);

            return true;
        }

        public bool Update(Supplier supplier)
        {
            if (!rule.IsValid(supplier))
                return false;

            repo.Update(supplier);

            return true;
        }

        private bool HasInventory(string supplierId)
        {
            List<Batch> batches =
                FileHelper.ReadJsonList<Batch>("batch.json");

            if (batches == null)
                return false;

            foreach (Batch batch in batches)
            {
                if (batch.SupplierId == supplierId
                    && batch.Quantity > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Delete(string id)
        {
            if (HasInventory(id))
            {
                return false;
            }

            repo.Delete(id);

            return true;
        }

    }
}