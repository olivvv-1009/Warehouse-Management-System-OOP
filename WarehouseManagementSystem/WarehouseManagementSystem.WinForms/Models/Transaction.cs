using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Transaction
    {
        public static class Types
        {
            public const string Import =
                "IMPORT";

            public const string Export =
                "EXPORT";

            public const string Return =
                "RETURN";
        }

        public string TransactionId
        {
            get;
            set;
        }

        public string ProductId
        {
            get;
            set;
        }

        public string TransactionType
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string ReferenceId
        {
            get;
            set;
        }

        public Transaction()
        {
            TransactionId =
                string.Empty;

            ProductId =
                string.Empty;

            TransactionType =
                string.Empty;

            ReferenceId =
                string.Empty;

            Date =
                DateTime.Now;
        }

        public virtual void Undo()
        {
        }

        public virtual void Redo()
        {
        }
    }
}