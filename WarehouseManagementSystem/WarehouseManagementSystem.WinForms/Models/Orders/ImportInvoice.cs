using System.Linq;
using WMS.Models.Inventory;

namespace WMS.Models.Orders
{
    public class ImportInvoice : Order
    {
        public override void Process(Warehouse warehouse)
        {
            var items = warehouse.GetAllInventory();

            foreach (var detail in Details)
            {
                var item = items.FirstOrDefault(x => x.ProductId == detail.ProductId);

                if (item != null)
                {
                    item.AddStock(detail.Quantity);
                }
            }
        }
    }
}