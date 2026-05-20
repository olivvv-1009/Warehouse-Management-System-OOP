using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class LookupService
    {
        private List<ProductDisplayModel>
            products;

        private List<Supplier>
            suppliers;

        private List<Batch>
            batches;

        private List<InventoryItem>
            inventories;

        private List<Account>
            accounts;

        private List<Profile>
            profiles;

        public LookupService(
            List<ProductDisplayModel> products,
            List<Supplier> suppliers,
            List<Batch> batches,
            List<InventoryItem> inventories,
            List<Account> accounts,
            List<Profile> profiles)
        {
            this.products =
                products;

            this.suppliers =
                suppliers;

            this.batches =
                batches;

            this.inventories =
                inventories;

            this.accounts =
                accounts;

            this.profiles =
                profiles;
        }

        // ================= PRODUCT =================

        public ProductDisplayModel
            GetProductById(
            string productId)
        {
            int i;

            for (
                i = 0;
                i < products.Count;
                i++
            )
            {
                if (
                    products[i]
                        .ProductID
                    == productId
                )
                {
                    return products[i];
                }
            }

            return null;
        }

        public string GetProductName(
            string productId)
        {
            ProductDisplayModel
                product =
                    GetProductById(
                        productId
                    );

            if (product != null)
            {
                return product.Name;
            }

            return "Unknown Product";
        }

        public string GetProductCategory(
            string productId)
        {
            ProductDisplayModel
                product =
                    GetProductById(
                        productId
                    );

            if (product != null)
            {
                return product.Category;
            }

            return string.Empty;
        }

        public int GetMinimumStock(
            string productId)
        {
            ProductDisplayModel
                product =
                    GetProductById(
                        productId
                    );

            if (product != null)
            {
                return product.MinStock;
            }

            return 0;
        }

        // ================= SUPPLIER =================

        public Supplier GetSupplierById(
            string supplierId)
        {
            int i;

            for (
                i = 0;
                i < suppliers.Count;
                i++
            )
            {
                if (
                    suppliers[i]
                        .SupplierId
                    == supplierId
                )
                {
                    return suppliers[i];
                }
            }

            return null;
        }

        public string GetSupplierName(
            string supplierId)
        {
            Supplier supplier =
                GetSupplierById(
                    supplierId
                );

            if (supplier != null)
            {
                return supplier
                    .SupplierName;
            }

            return "Unknown Supplier";
        }

        public string GetSupplierPhone(
            string supplierId)
        {
            Supplier supplier =
                GetSupplierById(
                    supplierId
                );

            if (supplier != null)
            {
                return supplier
                    .PhoneNumber;
            }

            return string.Empty;
        }

        // ================= BATCH =================

        public Batch GetBatchById(
            string batchId)
        {
            int i;

            for (
                i = 0;
                i < batches.Count;
                i++
            )
            {
                if (
                    batches[i]
                        .BatchId
                    == batchId
                )
                {
                    return batches[i];
                }
            }

            return null;
        }

        public int GetRemainingQuantity(
            string batchId)
        {
            Batch batch =
                GetBatchById(
                    batchId
                );

            if (batch != null)
            {
                return batch
                    .RemainingQuantity;
            }

            return 0;
        }

        public decimal GetImportPrice(
            string batchId)
        {
            Batch batch =
                GetBatchById(
                    batchId
                );

            if (batch != null)
            {
                return batch
                    .ImportPrice;
            }

            return 0;
        }

        // ================= INVENTORY =================

        public InventoryItem
            GetInventoryByBatch(
            string batchId)
        {
            int i;

            for (
                i = 0;
                i < inventories.Count;
                i++
            )
            {
                if (
                    inventories[i]
                        .BatchId
                    == batchId
                )
                {
                    return inventories[i];
                }
            }

            return null;
        }

        public InventoryItem
            GetInventoryByProduct(
            string productId)
        {
            int i;

            for (
                i = 0;
                i < inventories.Count;
                i++
            )
            {
                if (
                    inventories[i]
                        .ProductId
                    == productId
                )
                {
                    return inventories[i];
                }
            }

            return null;
        }

        public int GetInventoryQuantity(
            string productId)
        {
            InventoryItem
                inventory =
                    GetInventoryByProduct(
                        productId
                    );

            if (inventory != null)
            {
                return inventory
                    .Quantity;
            }

            return 0;
        }

        public string GetStockStatus(
            string productId)
        {
            InventoryItem
                inventory =
                    GetInventoryByProduct(
                        productId
                    );

            if (inventory != null)
            {
                return inventory
                    .StockStatus;
            }

            return "Unknown";
        }

        // ================= ACCOUNT =================

        public Account GetAccountById(
            string accountId)
        {
            int i;

            for (
                i = 0;
                i < accounts.Count;
                i++
            )
            {
                if (
                    accounts[i]
                        .AccountId
                    == accountId
                )
                {
                    return accounts[i];
                }
            }

            return null;
        }

        public string GetUsername(
            string accountId)
        {
            Account account =
                GetAccountById(
                    accountId
                );

            if (account != null)
            {
                return account
                    .Username;
            }

            return string.Empty;
        }

        public string GetRole(
            string accountId)
        {
            Account account =
                GetAccountById(
                    accountId
                );

            if (account != null)
            {
                return account
                    .Role;
            }

            return string.Empty;
        }

        // ================= PROFILE =================

        public Profile
            GetProfileByAccountId(
            string accountId)
        {
            int i;

            for (
                i = 0;
                i < profiles.Count;
                i++
            )
            {
                if (
                    profiles[i]
                        .AccountId
                    == accountId
                )
                {
                    return profiles[i];
                }
            }

            return null;
        }

        public string GetFullName(
            string accountId)
        {
            Profile profile =
                GetProfileByAccountId(
                    accountId
                );

            if (profile != null)
            {
                return profile
                    .FullName;
            }

            return string.Empty;
        }

        public string GetPhone(
            string accountId)
        {
            Profile profile =
                GetProfileByAccountId(
                    accountId
                );

            if (profile != null)
            {
                return profile
                    .Phone;
            }

            return string.Empty;
        }
    }
}