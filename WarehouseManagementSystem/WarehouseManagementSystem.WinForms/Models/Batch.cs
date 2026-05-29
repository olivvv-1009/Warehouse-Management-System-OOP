using System;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class Batch
    {
        public string BatchId { get; set; }
        public string ProductId { get; set; }
        public string SupplierId { get; set; }
        public string LocationCode { get; set; }

        // Số lượng nhập ban đầu — không bao giờ thay đổi
        public int Quantity { get; set; }

        // Số lượng đã xuất kho (tích lũy)
        public int ExportedQuantity { get; set; }

        // Số lượng còn lại sau return từ nhà cung cấp
        public int RemainingQuantity { get; set; }

        // Số lượng khả dụng để xuất = Quantity - ExportedQuantity
        public int AvailableQuantity
        {
            get
            {
                return RemainingQuantity;
            }
        }

        public decimal ImportPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

        public Batch()
        {
            BatchId = string.Empty;
            ProductId = string.Empty;
            LocationCode = string.Empty;
            Quantity = 0;
            ExportedQuantity = 0;
            RemainingQuantity = 0;
            ImportPrice = 0;
            CreatedDate = DateTime.Now;
            Status = "Stored";
        }
    }
}