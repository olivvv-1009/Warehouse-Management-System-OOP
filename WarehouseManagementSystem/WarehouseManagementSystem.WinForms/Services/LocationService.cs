using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class LocationService
    {
        private readonly LocationRepository
            _locationRepository;

        private readonly LocationAssignmentRule
            _assignmentRule;

        public LocationService()
        {
            _locationRepository =
                new LocationRepository();

            _assignmentRule =
                new LocationAssignmentRule();
        }

        public List<WarehouseLocation>
            GetAllLocations()
        {
            return _locationRepository
                .GetAll();
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

        public WarehouseLocation
            FindBestLocation(
                string productId,
                int quantity)
        {
            List<WarehouseLocation> locations =
                _locationRepository
                    .GetAll();

            return _assignmentRule
                .FindAvailableLocation(
                    locations,
                    productId,
                    quantity
                );
        }
    }
}