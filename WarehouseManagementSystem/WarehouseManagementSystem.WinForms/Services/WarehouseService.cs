using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class WarehouseService
    {
        private readonly LocationRepository
            _locationRepository;

        public WarehouseService()
        {
            _locationRepository =
                new LocationRepository();
        }

        public bool HasEnoughCapacity(
            WarehouseLocation location,
            int quantity)
        {
            if (location == null)
            {
                return false;
            }

            if (location.UsedCapacity + quantity
                > location.Capacity)
            {
                return false;
            }

            return true;
        }

        public void UpdateUsedCapacity(
            WarehouseLocation location,
            int quantity)
        {
            location.UsedCapacity += quantity;

            _locationRepository.Update();
        }
    }
}