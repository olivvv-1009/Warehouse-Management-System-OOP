using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class DestinationRepository
    {
        private readonly string _path = FileHelper.GetFilePath("destination.json");

        public List<Destination> GetAll()
        {
            if (!File.Exists(_path))
                return new List<Destination>();

            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Destination>>(json)
                ?? new List<Destination>();
        }
    }
}
