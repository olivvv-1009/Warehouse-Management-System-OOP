using System.Collections.Generic;
using WMS.Models.Inventory;
using WMS.Models.Users;
namespace WMS.Models.Orders
{
    public class Order
    {
        public List<OrderDetail> Details { get; set; }
        public Employee? Employee { get; set; }
        public Order()
        {
            Details = new List<OrderDetail>();
        }
        public Order(Employee employee)
        {
            Details = new List<OrderDetail>();
            Employee = employee;
        }

        public virtual void Process(Warehouse warehouse)
        {
            Console.WriteLine($"Order processed by: {Employee?.FullName}");
        }
    }
}