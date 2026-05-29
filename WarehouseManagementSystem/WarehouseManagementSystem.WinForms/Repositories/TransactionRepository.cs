using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class TransactionRepository
    {
        private readonly string _path =
            FileHelper.GetFilePath(
                "transaction.json"
            );

        public List<Transaction>
            GetAll()
        {
            if (!File.Exists(_path))
            {
                return
                    new List<Transaction>();
            }

            string json =
                File.ReadAllText(
                    _path
                );

            return JsonSerializer
                .Deserialize<
                    List<Transaction>
                >(json)
                ??
                new List<Transaction>();
        }

        public void Add(
            Transaction transaction)
        {
            List<Transaction>
                transactions =
                    GetAll();

            transactions.Add(
                transaction
            );

            Save(
                transactions
            );
        }

        public List<Transaction>
            GetByProductId(
                string productId)
        {
            return GetAll()
                .Where(
                    x =>
                    x.ProductId
                    ==
                    productId
                )
                .ToList();
        }

        public List<Transaction>
            GetByType(
                string type)
        {
            return GetAll()
                .Where(
                    x =>
                    x.TransactionType
                    ==
                    type
                )
                .ToList();
        }

        private void Save(
            List<Transaction>
                transactions)
        {
            string json =
                JsonSerializer
                .Serialize(
                    transactions,
                    new JsonSerializerOptions
                    {
                        WriteIndented =
                            true
                    }
                );

            File.WriteAllText(
                _path,
                json
            );
        }
    }
}