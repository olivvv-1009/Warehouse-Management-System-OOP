using System.Collections.Generic;
using WMS.Models.Inventory;

namespace WMS.Models.Orders
{
    public class Order
    {
        public List<OrderDetail> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }

        public virtual void Process(Warehouse warehouse)
        {
        }
    }
}