using System;
using System.Collections.Generic;
using WMS.Models.Inventory;
using WMS.Models.Users;

namespace WMS.Models.Orders
{
    // 👉 dùng abstract để thể hiện trừu tượng 
    public abstract class Order
    {
        public string OrderId { get; set; } = "";

        // 👉 Aggregation/Composition với OrderDetail
        public List<OrderDetail> Details { get; set; }

        // 👉 Association với Employee
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

        public Order(string orderId, Employee employee)
        {
            OrderId = orderId;
            Employee = employee;
            Details = new List<OrderDetail>();
        }

        // 👉 method để thể hiện rõ association
        public void AssignEmployee(Employee employee)
        {
            Employee = employee;
        }

        // 👉 abstract → bắt subclass phải override (đa hình + trừu tượng)
        public abstract void Process(Warehouse warehouse);
    }
}