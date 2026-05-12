using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WarehouseManagementSystem.WinForms.Files
{
    public static class FileHelper
    {
        // =====================================
        // Local AppData Folder
        // =====================================

        private static readonly string BaseDirectory =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "WarehouseManagementSystem"
            );

        private static readonly string DataDirectory =
            Path.Combine(
                BaseDirectory,
                "Data",
                "Files"
            );

        // =====================================
        // Project Template Folder
        // =====================================

        private static readonly string TemplateDirectory =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "Files"
            );

        // =====================================
        // JSON Options
        // =====================================

        private static readonly JsonSerializerOptions
            JsonOptions =
                new JsonSerializerOptions
                {
                    WriteIndented = true
                };

        // =====================================
        // Static Constructor
        // =====================================

        static FileHelper()
        {
            EnsureDirectoriesExist();
        }

        // =====================================
        // Create Directories
        // =====================================

        public static void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(
                    DataDirectory);
            }
        }

        // =====================================
        // Get Local File Path
        // =====================================

        public static string GetFilePath(
            string fileName)
        {
            return Path.Combine(
                DataDirectory,
                fileName);
        }

        // =====================================
        // Create Local File From Template
        // =====================================

        public static void EnsureDataFileExists(
            string fileName)
        {
            string localPath =
                GetFilePath(fileName);

            string templatePath =
                Path.Combine(
                    TemplateDirectory,
                    fileName);

            // Local file chưa tồn tại
            if (!File.Exists(localPath))
            {
                // Nếu project có template
                if (File.Exists(templatePath))
                {
                    File.Copy(
                        templatePath,
                        localPath);
                }
                else
                {
                    // Không có template
                    File.WriteAllText(
                        localPath,
                        "[]");
                }
            }
        }

        // =====================================
        // Delete File
        // =====================================

        public static void DeleteFile(
            string fileName)
        {
            string filePath =
                GetFilePath(fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        // =====================================
        // Read Raw JSON
        // =====================================

        public static string ReadJsonFile(
            string fileName)
        {
            EnsureDataFileExists(fileName);

            string filePath =
                GetFilePath(fileName);

            try
            {
                return File.ReadAllText(
                    filePath);
            }
            catch (Exception ex)
            {
                throw new IOException(
                    $"Error reading file: {fileName}",
                    ex);
            }
        }

        // =====================================
        // Write Raw JSON
        // =====================================

        public static void WriteJsonFile(
            string fileName,
            string jsonContent)
        {
            string filePath =
                GetFilePath(fileName);

            try
            {
                EnsureDirectoriesExist();

                File.WriteAllText(
                    filePath,
                    jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException(
                    $"Error writing file: {fileName}",
                    ex);
            }
        }

        // =====================================
        // Read Object
        // =====================================

        public static T ReadJsonObject<T>(
            string fileName)
            where T : class
        {
            try
            {
                string jsonContent =
                    ReadJsonFile(fileName);

                if (string.IsNullOrWhiteSpace(jsonContent)
                    || jsonContent == "[]")
                {
                    return null;
                }

                return JsonSerializer.Deserialize<T>(
                    jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException(
                    $"Error deserializing object from: {fileName}",
                    ex);
            }
        }

        // =====================================
        // Write Object
        // =====================================

        public static void WriteJsonObject<T>(
            string fileName,
            T item)
            where T : class
        {
            try
            {
                string jsonContent =
                    JsonSerializer.Serialize(
                        item,
                        JsonOptions);

                WriteJsonFile(
                    fileName,
                    jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException(
                    $"Error serializing object to: {fileName}",
                    ex);
            }
        }

        // =====================================
        // Read List
        // =====================================

        public static List<T> ReadJsonList<T>(
            string fileName)
            where T : class
        {
            try
            {
                string jsonContent =
                    ReadJsonFile(fileName);

                if (string.IsNullOrWhiteSpace(jsonContent)
                    || jsonContent == "[]")
                {
                    return new List<T>();
                }

                List<T> items =
                    JsonSerializer.Deserialize<List<T>>(
                        jsonContent);

                if (items == null)
                {
                    return new List<T>();
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new IOException(
                    $"Error deserializing list from: {fileName}",
                    ex);
            }
        }

        // =====================================
        // Write List
        // =====================================

        public static void WriteJsonList<T>(
            string fileName,
            List<T> items)
            where T : class
        {
            try
            {
                string jsonContent =
                    JsonSerializer.Serialize(
                        items,
                        JsonOptions);

                WriteJsonFile(
                    fileName,
                    jsonContent);
            }
            catch (Exception ex)
            {
                throw new IOException(
                    $"Error serializing list to: {fileName}",
                    ex);
            }
        }
    }
}