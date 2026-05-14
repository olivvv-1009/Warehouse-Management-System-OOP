using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class SupplierService
    {
        private readonly SupplierRepository
            _supplierRepository;

        public SupplierService()
        {
            _supplierRepository =
                new SupplierRepository();
        }

        public List<Supplier>
            GetAllSuppliers()
        {
            return _supplierRepository
                .GetAll();
        }
    }
}