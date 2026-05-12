using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class LocationService
    {
        private readonly LocationRepository
            _locationRepository;

        public LocationService()
        {
            _locationRepository =
                new LocationRepository();
        }

        public List<WarehouseLocation>
            GetAllLocations()
        {
            return _locationRepository.GetAll();
        }

        public WarehouseLocation
            FindLocationByCode(
                string locationCode)
        {
            return _locationRepository
                .FindByCode(locationCode);
        }

        public WarehouseLocation
            GetAvailableLocation()
        {
            return _locationRepository
                .GetAvailableLocation();
        }
    }
}