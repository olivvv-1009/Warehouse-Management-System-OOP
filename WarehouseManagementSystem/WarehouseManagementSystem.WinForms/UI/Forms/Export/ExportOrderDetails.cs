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
            lblTitle.Text = $"Export Order Details - {_invoice.InvoiceId}";
            lblDestination.Text = string.IsNullOrWhiteSpace(_invoice.Destination)
                ? "—" : _invoice.Destination;
            lblDate.Text = _invoice.CreatedDate.ToString("yyyy-MM-dd");
            lblStatus.Text = "Completed";
            lblStatus.ForeColor = Color.SeaGreen;
            lblCreatedBy.Text = _invoice.EmployeeName;
        }

        // ─── OnLoad: build sau khi form render xong (width chính xác) ─

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BuildBatchSection();

        }

        // ─── Xây dựng section Products & Batch Allocations ───────

        private void BuildBatchSection()
        {
            flowBatches.Controls.Clear();
            flowBatches.AutoScroll = true;
            flowBatches.WrapContents = false;
            flowBatches.FlowDirection = FlowDirection.TopDown;

            int cardWidth =
    flowBatches.Width - 40;

            if (cardWidth < 700)
            {
                cardWidth = 700;
            }

            // ── Tiêu đề "Products & Batch Allocations" ──
            Label sectionLbl = new Label();
            sectionLbl.Text = "Products & Batch Allocations";
            sectionLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            sectionLbl.AutoSize = false;
            sectionLbl.Width = cardWidth;
            sectionLbl.Height = 38;
            sectionLbl.Margin = new Padding(0, 4, 0, 6);
            sectionLbl.TextAlign = ContentAlignment.MiddleLeft;
            sectionLbl.ForeColor = Color.FromArgb(20, 20, 20);
            flowBatches.Controls.Add(sectionLbl);

            // ── Mỗi OrderDetail = 1 card sản phẩm ──
            foreach (OrderDetail detail in _invoice.OrderDetails)
            {
                string productName = detail.ProductId;
                var product = _productService.GetProductById(detail.ProductId);
                if (product != null) productName = product.Name;

                List<Batch> batches = _batchRepo.GetByProductId(detail.ProductId);
                batches.Sort((a, b) => a.CreatedDate.CompareTo(b.CreatedDate));

                List<(Batch batch, int qty)> allocations =
                    AllocateFifo(batches, detail.Quantity);

                Panel card = BuildProductCard(productName, detail.Quantity,
                                              allocations, cardWidth);
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

            if (result.Count == 0 && batches.Count > 0)
                result.Add((batches[0], needed));

            return result;
        }

        // ─── Tạo card cho 1 sản phẩm ─────────────────────────────

        private Panel BuildProductCard(
            string productName,
            int totalQty,
            List<(Batch batch, int qty)> allocations,
            int cardWidth)
        {
            const int PAD = 16;
            int yPos = PAD;

            Panel card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Width = cardWidth;
            card.Margin = new Padding(0, 0, 0, 10);

            // ── Header: product name (trái) + Total (phải) ──
            int innerW = cardWidth - PAD * 2 - 2; // -2 for border

            Label lblName = new Label();
            lblName.Text = productName;
            lblName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblName.AutoSize = false;
            lblName.Width = (int)(innerW * 0.65);
            lblName.Height = 30;
            lblName.Location = new Point(PAD, yPos);
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            lblName.ForeColor = Color.FromArgb(20, 20, 20);

            Label lblTotal = new Label();
            lblTotal.Text = $"Total: {totalQty} units";
            lblTotal.Font = new Font("Segoe UI", 9.5F);
            lblTotal.ForeColor = Color.FromArgb(90, 90, 90);
            lblTotal.AutoSize = false;
            lblTotal.Width = innerW - (int)(innerW * 0.65);
            lblTotal.Height = 30;
            lblTotal.Location = new Point(PAD + (int)(innerW * 0.65), yPos);
            lblTotal.TextAlign = ContentAlignment.MiddleRight;

            card.Controls.Add(lblName);
            card.Controls.Add(lblTotal);
            yPos += 36;

            // ── Batch rows ──
            int batchRowW = innerW;

            foreach (var (batch, qty) in allocations)
            {
                Panel batchRow = new Panel();
                batchRow.BackColor = Color.FromArgb(248, 250, 252);
                batchRow.Width = batchRowW;
                batchRow.Height = 36;
                batchRow.Location = new Point(PAD, yPos);
                batchRow.BorderStyle = BorderStyle.FixedSingle;

                // Batch ID — hiện đủ (không cắt)
                Label lblBatchId = new Label();
                lblBatchId.Text = batch.BatchId;
                lblBatchId.Font = new Font("Segoe UI", 9.5F);
                lblBatchId.ForeColor = Color.FromArgb(50, 50, 50);
                lblBatchId.AutoSize = false;
                lblBatchId.Width = (int)(batchRowW * 0.45);
                lblBatchId.Height = 36;
                lblBatchId.Location = new Point(10, 0);
                lblBatchId.TextAlign = ContentAlignment.MiddleLeft;

                // "X units from yyyy-MM-dd" bên phải
                string importStr = batch.LocationCode.ToString();
                Label lblBatchInfo = new Label();
                lblBatchInfo.Text = $"{qty} units from {importStr}";
                lblBatchInfo.Font = new Font("Segoe UI", 9.5F);
                lblBatchInfo.ForeColor = Color.FromArgb(80, 80, 80);
                lblBatchInfo.AutoSize = false;
                lblBatchInfo.Width = batchRowW - (int)(batchRowW * 0.45) - 10;
                lblBatchInfo.Height = 36;
                lblBatchInfo.Location = new Point((int)(batchRowW * 0.45), 0);
                lblBatchInfo.TextAlign = ContentAlignment.MiddleRight;

                batchRow.Controls.Add(lblBatchId);
                batchRow.Controls.Add(lblBatchInfo);
                card.Controls.Add(batchRow);
                yPos += 40;
            }

            yPos += PAD;
            card.Height = yPos;
            return card;
        }

        // ─── Close ───────────────────────────────────────────────

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
