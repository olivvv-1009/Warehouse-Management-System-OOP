using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class CapacityRule
    {
        public bool CheckCapacity(
            WarehouseLocation location,
            int quantity)
        {
            int remainingCapacity =
                location.Capacity -
                location.UsedCapacity;

            if (quantity <= remainingCapacity)
            {
                return true;
            }

            return false;
        }
    }
}