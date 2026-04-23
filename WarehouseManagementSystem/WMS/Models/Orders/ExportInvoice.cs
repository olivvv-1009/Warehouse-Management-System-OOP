using System;
using WMS.Models.Inventory;

namespace WMS.Models.Orders
{
    public class ExportInvoice : Order
    {
        public ExportInvoice(string orderId, Users.Employee employee)
            : base(orderId, employee)
        {
        }

        public override void Process(Warehouse warehouse)
        {
            Console.WriteLine($"[EXPORT] Order ID: {OrderId}");
            Console.WriteLine($"Processed by: {Employee?.FullName}");

            foreach (var detail in Details)
            {
                Console.WriteLine($"Exporting ProductId: {detail.ProductId}, Quantity: {detail.Quantity}");
            }
        }
    }
}