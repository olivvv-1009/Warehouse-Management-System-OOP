using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class ReturnOrder
    {
        // Mã phiếu trả
        public string ReturnOrderId { get; set; }

        // Đơn nhập gốc
        public string ImportInvoiceId { get; set; }

        // Nhà cung cấp
        public string SupplierId { get; set; }

        // Nhân viên tạo phiếu
        public string EmployeeId { get; set; }

        // Ngày trả hàng
        public DateTime ReturnDate { get; set; }

        // Trạng thái phiếu
        public string Status { get; set; }

        // Danh sách sản phẩm trả
        public List<ReturnOrderDetail> Details
        { get; set; }

        // Tổng tiền phiếu trả
        public decimal TotalAmount
        {
            get
            {
                decimal total = 0;

                foreach (var detail in Details)
                {
                    total += detail.TotalPrice;
                }

                return total;
            }
        }

        public ReturnOrder()
        {
            ReturnOrderId = string.Empty;

            ImportInvoiceId = string.Empty;

            SupplierId = string.Empty;

            EmployeeId = string.Empty;

            Status = "Pending";

            ReturnDate = DateTime.Now;

            Details =
                new List<ReturnOrderDetail>();
        }
    }
}