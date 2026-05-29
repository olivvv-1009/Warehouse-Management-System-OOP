using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Interfaces
{
    public interface ISupplierService
    {
        List<Supplier> GetAll();

        Supplier GetById(string id);

        List<Supplier> Search(string keyword);

        bool Add(Supplier supplier);

        bool Update(Supplier supplier);

        bool Delete(string id);
    }
}
