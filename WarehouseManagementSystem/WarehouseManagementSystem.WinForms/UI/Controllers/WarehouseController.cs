using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.Controllers
{
    internal class WarehouseController
    {
        private readonly LocationService
            _locationService;

        public WarehouseController()
        {
            _locationService =
                new LocationService();
        }

        public List<WarehouseLocation>
            GetAllLocations()
        {
            return _locationService
                .GetAllLocations();
        }

        public WarehouseLocation
            GetAvailableLocation()
        {
            return _locationService
                .GetAvailableLocation();
        }
    }
}