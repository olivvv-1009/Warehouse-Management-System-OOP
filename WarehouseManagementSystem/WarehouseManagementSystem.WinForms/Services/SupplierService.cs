using System.Collections.Generic;
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

        public bool Delete(string id)
        {
            repo.Delete(id);

            return true;
        }
    }
}