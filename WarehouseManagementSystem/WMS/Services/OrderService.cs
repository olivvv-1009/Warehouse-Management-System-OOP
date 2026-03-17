using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMS.Models.Inventory;
using WMS.Models.Orders;
using WMS.Models.Users;

namespace WMS.Services
{
    public class OrderService
    {
        public void ProcessOrder(Order order, Warehouse warehouse)
        {
            order.Process(warehouse);
        }
          
    }
}

