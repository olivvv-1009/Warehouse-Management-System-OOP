using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Files
{
public class FileHelper
    {
        private static readonly string BaseDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "WarehouseManagementSystem"
        );

        private static readonly string DataDirectory = Path.Combine(BaseDirectory, "Data", "Files");

        public FileHelper()
        {
            EnsureDirectoriesExist();
        }

        public static void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }
        }

        public static string GetFilePath(string fileName)
        {
            return Path.Combine(DataDirectory, fileName);
        }

        public static string ReadJsonFile(string fileName)
        {
            string filePath = GetFilePath(fileName);
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
                return "[]";
            }
            catch (Exception ex)
            {
                throw new IOException($"Error reading file {fileName}: {ex.Message}", ex);
            }
        }

        public static void WriteJsonFile(string fileName, string jsonContent)
        {
            string filePath = GetFilePath(fileName);
            try
            {
                EnsureDirectoriesExist();
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing file {fileName}: {ex.Message}", ex);
            }
        }

        public static T ReadJsonObject<T>(string fileName) where T : class
        {
            string jsonContent = ReadJsonFile(fileName);
            if (string.IsNullOrWhiteSpace(jsonContent) || jsonContent == "[]")
            {
                return null;
            }
            try
            {
                return JsonSerializer.Deserialize<T>(jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error deserializing JSON from {fileName}: {ex.Message}", ex);
            }
        }

        public static List<T> ReadJsonList<T>(string fileName) where T : class
        {
            string jsonContent = ReadJsonFile(fileName);
            try
            {
                if (string.IsNullOrWhiteSpace(jsonContent) || jsonContent == "[]")
                {
                    return new List<T>();
                }
                return JsonSerializer.Deserialize<List<T>>(jsonContent) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new IOException($"Error deserializing JSON list from {fileName}: {ex.Message}", ex);
            }
        }

        public static void WriteJsonList<T>(string fileName, List<T> items) where T : class
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonContent = JsonSerializer.Serialize(items, options);
                WriteJsonFile(fileName, jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error serializing list to {fileName}: {ex.Message}", ex);
            }
        }

        public static void WriteJsonObject<T>(string fileName, T item) where T : class
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonContent = JsonSerializer.Serialize(item, options);
                WriteJsonFile(fileName, jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error serializing object to {fileName}: {ex.Message}", ex);
            }
        }
    }
}
