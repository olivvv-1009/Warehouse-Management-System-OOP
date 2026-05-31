using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Interfaces;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private const string FileName = "products.json";
        private List<Product> _products;

        public ProductRepository()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                _products = FileHelper.ReadJsonList<Product>(FileName);
                if (_products == null)
                {
                    _products = new List<Product>();
                }
            }
            catch
            {
                _products = new List<Product>();
            }
        }

        public void Save(List<Product> items)
        {
            _products = items;
            Save();
        }

        public List<Product> GetAll()
        {
            return new List<Product>(_products);
        }

        public Product GetById(string productId)
        {
            return _products.FirstOrDefault(p => p.ProductID == productId);
        }

        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_products.Any(p => p.ProductID == product.ProductID))
                throw new InvalidOperationException($"Product with ID {product.ProductID} already exists");

            _products.Add(product);
            Save();
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var existingProduct = GetById(product.ProductID);
            if (existingProduct == null)
                throw new InvalidOperationException($"Product with ID {product.ProductID} not found");

            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.MinStock = product.MinStock;
            Save();
            LoadProducts();
        }

        public void Delete(string productId)
        {
            var product = GetById(productId);
            if (product != null)
            {
                _products.Remove(product);
                Save();
            }
        }

        public void Save()
        {
            try
            {
                FileHelper.WriteJsonList(FileName, _products);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error saving products: {ex.Message}", ex);
            }
        }

        public bool Exists(string productId)
        {
            return _products.Any(p => p.ProductID == productId);
        }

        public void Reload()
        {
            LoadProducts();
        }

    }
}
