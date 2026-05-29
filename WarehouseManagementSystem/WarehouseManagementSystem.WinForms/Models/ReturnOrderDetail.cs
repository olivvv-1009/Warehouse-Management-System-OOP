using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ReturnOrderDetail
    {
        // Mã sản phẩm
        public string ProductId { get; set; }

        // Mã lô hàng
        public string BatchId { get; set; }

        // Số lượng trả
        public int Quantity { get; set; }

        // Đơn giá nhập
        public decimal UnitPrice { get; set; }

        // Lý do trả
        public string ReturnReason { get; set; }

        // Thành tiền
        public decimal TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

        public ReturnOrderDetail()
        {
            ProductId = string.Empty;

            BatchId = string.Empty;

            Quantity = 0;

            UnitPrice = 0;

            ReturnReason = string.Empty;

        }
    }
}
