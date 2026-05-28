using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Services;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    public partial class ExportOrderDetails : Form
    {
        private readonly ExportInvoice _invoice;
        private readonly BatchRepository _batchRepo;
        private readonly ProductService _productService;

        public ExportOrderDetails(ExportInvoice invoice)
        {
            InitializeComponent();
            _invoice = invoice;
            _batchRepo = new BatchRepository();
            _productService = new ProductService();
            LoadData();
        }

        // ─── Load data ────────────────────────────────────────────

        private void LoadData()
        {
            lblTitle.Text = $"Export Order Details - {_invoice.ExportId}";
            lblDestination.Text = "—";
            lblDate.Text = _invoice.ExportDate.ToString("yyyy-MM-dd");
            lblStatus.Text = "Completed";
            lblStatus.ForeColor = Color.SeaGreen;
            lblCreatedBy.Text = _invoice.EmployeeName;

            BuildBatchSection();
        }

        // ─── Xây dựng section Products & Batch Allocations ───────

        private void BuildBatchSection()
        {
            flowBatches.Controls.Clear();

            // Tiêu đề section
            Label sectionLbl = new Label();
            sectionLbl.Text = "Products & Batch Allocations";
            sectionLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            sectionLbl.AutoSize = false;
            sectionLbl.Height = 34;
            sectionLbl.Width = GetCardWidth();
            sectionLbl.TextAlign = ContentAlignment.MiddleLeft;
            sectionLbl.Margin = new Padding(0, 0, 0, 4);
            flowBatches.Controls.Add(sectionLbl);

            // Mỗi OrderDetail = 1 sản phẩm
            foreach (OrderDetail detail in _invoice.OrderDetails)
            {
                // Tên sản phẩm
                string productName = detail.ProductId;
                var product = _productService.GetProductById(detail.ProductId);
                if (product != null) productName = product.Name;

                // Lấy danh sách batch của sản phẩm này (FIFO)
                List<Batch> batches = _batchRepo.GetByProductId(detail.ProductId);
                batches.Sort((a, b) => a.ImportDate.CompareTo(b.ImportDate));

                // Phân bổ FIFO: tính xem mỗi batch lấy bao nhiêu
                List<(Batch batch, int qty)> allocations = AllocateFifo(batches, detail.Quantity);

                Panel card = BuildProductCard(productName, detail.Quantity, allocations);
                flowBatches.Controls.Add(card);
            }
        }

        // ─── FIFO allocation ──────────────────────────────────────

        private List<(Batch, int)> AllocateFifo(List<Batch> batches, int needed)
        {
            var result = new List<(Batch, int)>();
            int remaining = needed;

            foreach (Batch b in batches)
            {
                if (remaining <= 0) break;
                int take = Math.Min(b.Quantity, remaining);
                if (take > 0)
                {
                    result.Add((b, take));
                    remaining -= take;
                }
            }

            // Nếu không tìm được batch nào phù hợp, vẫn hiển thị dòng tổng
            if (result.Count == 0 && batches.Count > 0)
            {
                result.Add((batches[0], needed));
            }

            return result;
        }

        // ─── Tạo card cho 1 sản phẩm ─────────────────────────────

        private Panel BuildProductCard(
            string productName,
            int totalQty,
            List<(Batch batch, int qty)> allocations)
        {
            int cardWidth = GetCardWidth();

            Panel card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Width = cardWidth;
            card.Padding = new Padding(14, 10, 14, 10);
            card.Margin = new Padding(0, 0, 0, 10);

            int yPos = 10;

            // ── Header: tên sản phẩm + total ──
            Label lblName = new Label();
            lblName.Text = productName;
            lblName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblName.AutoSize = false;
            lblName.Width = cardWidth / 2;
            lblName.Height = 26;
            lblName.Location = new Point(14, yPos);
            lblName.TextAlign = ContentAlignment.MiddleLeft;

            Label lblTotal = new Label();
            lblTotal.Text = $"Total: {totalQty} units";
            lblTotal.Font = new Font("Segoe UI", 9.5F);
            lblTotal.ForeColor = Color.FromArgb(80, 80, 80);
            lblTotal.AutoSize = false;
            lblTotal.Width = cardWidth / 2 - 28;
            lblTotal.Height = 26;
            lblTotal.Location = new Point(cardWidth / 2, yPos);
            lblTotal.TextAlign = ContentAlignment.MiddleRight;

            card.Controls.Add(lblName);
            card.Controls.Add(lblTotal);
            yPos += 32;

            // ── Batch rows ──
            foreach (var (batch, qty) in allocations)
            {
                Panel batchRow = new Panel();
                batchRow.BackColor = Color.FromArgb(248, 250, 252);
                batchRow.Width = cardWidth - 30;
                batchRow.Height = 30;
                batchRow.Location = new Point(14, yPos);
                batchRow.BorderStyle = BorderStyle.None;

                Label lblBatchId = new Label();
                lblBatchId.Text = batch.BatchId;
                lblBatchId.Font = new Font("Segoe UI", 9.5F);
                lblBatchId.ForeColor = Color.FromArgb(60, 60, 60);
                lblBatchId.AutoSize = false;
                lblBatchId.Width = (cardWidth - 30) / 2;
                lblBatchId.Height = 30;
                lblBatchId.Location = new Point(10, 0);
                lblBatchId.TextAlign = ContentAlignment.MiddleLeft;

                string importStr = batch.ImportDate.ToString("yyyy-MM-dd");
                Label lblBatchInfo = new Label();
                lblBatchInfo.Text = $"{qty} units from {importStr}";
                lblBatchInfo.Font = new Font("Segoe UI", 9.5F);
                lblBatchInfo.ForeColor = Color.FromArgb(80, 80, 80);
                lblBatchInfo.AutoSize = false;
                lblBatchInfo.Width = (cardWidth - 30) / 2 - 10;
                lblBatchInfo.Height = 30;
                lblBatchInfo.Location = new Point((cardWidth - 30) / 2, 0);
                lblBatchInfo.TextAlign = ContentAlignment.MiddleRight;

                batchRow.Controls.Add(lblBatchId);
                batchRow.Controls.Add(lblBatchInfo);
                card.Controls.Add(batchRow);
                yPos += 34;
            }

            yPos += 10;
            card.Height = yPos;
            return card;
        }

        // ─── Helper: chiều rộng card ──────────────────────────────

        private int GetCardWidth()
        {
            // flowBatches.ClientSize.Width có thể chưa sẵn lúc khởi tạo
            int w = flowBatches.ClientSize.Width;
            return w > 50 ? w - 6 : 720;
        }

        // ─── Resize: rebuild khi form thay đổi kích thước ────────

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Rebuild sau khi form đã render xong để GetCardWidth() chính xác
            BuildBatchSection();
        }

        // ─── Close ───────────────────────────────────────────────

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}