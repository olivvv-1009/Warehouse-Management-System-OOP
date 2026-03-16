using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models.Inventory
{
    public interface IStockManageable
    {
        void AddStock(int amount);
        void RemoveStock(int amount);
    }
}