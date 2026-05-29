using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Save(List<T> items);
    }
}
