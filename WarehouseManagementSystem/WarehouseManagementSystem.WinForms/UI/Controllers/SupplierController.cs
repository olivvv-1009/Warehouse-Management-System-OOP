using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Controllers
{
    public class SupplierController
    {
        private SupplierService service;

        public SupplierController()
        {
            service = new SupplierService();
        }

        public List<Supplier> GetAll()
        {
            return service.GetAll();
        }

        public Supplier GetById(string id)
        {
            return service.GetById(id);
        }

        public List<Supplier> Search(string keyword)
        {
            return service.Search(keyword);
        }

        public bool Add(Supplier supplier)
        {
            return service.Add(supplier);
        }

        public bool Update(Supplier supplier)
        {
            return service.Update(supplier);
        }

        public bool Delete(string id)
        {
            return service.Delete(id);
        }
    }
}