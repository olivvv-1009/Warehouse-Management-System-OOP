using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WMS.Data
{
    public static class DataSerializer
    {
        public static void SaveToFile<T>(string path, T data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        public static T LoadFromFile<T>(string path)
        {
            if (!File.Exists(path))
                return default;

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
