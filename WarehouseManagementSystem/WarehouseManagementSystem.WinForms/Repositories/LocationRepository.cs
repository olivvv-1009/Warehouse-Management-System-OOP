using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    internal class LocationRepository
    {
        private const string FilePath =
            "warehouse_map.json";

        private List<WarehouseLocation> _locations;

        public LocationRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            _locations =
                FileHelper.ReadJsonList<
                    WarehouseLocation
                >(FilePath);

            if (_locations == null)
            {
                _locations =
                    new List<
                        WarehouseLocation>();
            }
        }

        private void SaveData()
        {
            FileHelper.WriteJsonList(
                FilePath,
                _locations
            );
        }

        public List<WarehouseLocation> GetAll()
        {
            return new List<
    WarehouseLocation>(
        _locations
    );
        }

        public WarehouseLocation FindByCode(
            string locationCode)
        {
            int i;

            for (i = 0; i < _locations.Count; i++)
            {
                if (_locations[i].LocationCode
                    == locationCode)
                {
                    return _locations[i];
                }
            }

            return null;
        }

        public void Update()
        {
            SaveData();
        }

        public WarehouseLocation GetAvailableLocation()
        {
            WarehouseLocation bestLocation = null;

            int i;

            for (i = 0; i < _locations.Count; i++)
            {
                if (_locations[i].UsedCapacity
                    < _locations[i].Capacity)
                {
                    if (bestLocation == null)
                    {
                        bestLocation = _locations[i];
                    }
                    else
                    {
                        if (_locations[i].Priority
                            < bestLocation.Priority)
                        {
                            bestLocation = _locations[i];
                        }
                    }
                }
            }

            return bestLocation;
        }
    }
}