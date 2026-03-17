using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Data
{
    public class FileManager
    {
        public void SaveData<T>(string path, T data)
        {
            DataSerializer.SaveToFile(path, data);
            Console.WriteLine("Data saved successfully.");
        }

        public T LoadData<T>(string path)
        {
            Console.WriteLine("Loading data...");
            return DataSerializer.LoadFromFile<T>(path);
        }

        public void Backup(string source, string backup)
        {
            System.IO.File.Copy(source, backup, true);
        }

        public void Restore(string backup, string target)
        {
            System.IO.File.Copy(backup, target, true);
        }
    }
}
