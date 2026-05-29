using System;
using WMS.Models.Inventory;

namespace WMS.Models.Orders
{
    public class ImportInvoice : Order
    {
        public ImportInvoice(string orderId, Users.Employee employee)
            : base(orderId, employee)
        {
        }

        public override void Process(Warehouse warehouse)
        {
            Console.WriteLine($"[IMPORT] Order ID: {OrderId}");
            Console.WriteLine($"Processed by: {Employee?.FullName}");

            foreach (var detail in Details)
            {
                Console.WriteLine($"Importing ProductId: {detail.ProductId}, Quantity: {detail.Quantity}");
            }
        }
    }
}