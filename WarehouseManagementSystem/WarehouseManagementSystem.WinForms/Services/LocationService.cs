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
        private readonly BatchRepository
    _batchRepository;

        public LocationService()
        {
            _locationRepository =
                new LocationRepository();

            _assignmentRule =
                new LocationAssignmentRule();
            _batchRepository =
    new BatchRepository();
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
                .FindByCode(
                    locationCode
                );
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
    string category,
    int quantity,
    List<string> usedRacks
)
        {
            RebuildLocationCapacity();
            List<WarehouseLocation> locations =
                _locationRepository
                    .GetAll();

            return _assignmentRule
    .FindAvailableLocation(
        locations,
        productId,
        category,
        quantity,
        usedRacks
    );
        }
        public void RebuildLocationCapacity()
        {
            List<WarehouseLocation> locations =
                _locationRepository.GetAll();

            List<Batch> batches =
                _batchRepository.GetAll();

            int i;

            for (i = 0; i < locations.Count; i++)
            {
                locations[i].UsedCapacity = 0;
            }

            int j;

            for (j = 0; j < batches.Count; j++)
            {
                Batch batch = batches[j];

                int k;

                for (k = 0; k < locations.Count; k++)
                {
                    if (
                        locations[k].LocationCode ==
                        batch.LocationCode
                    )
                    {
                        locations[k].UsedCapacity +=
                            batch.RemainingQuantity;

                        break;
                    }
                }
            }

            _locationRepository
                .UpdateLocations(
                    locations
                );
        }
    }
}