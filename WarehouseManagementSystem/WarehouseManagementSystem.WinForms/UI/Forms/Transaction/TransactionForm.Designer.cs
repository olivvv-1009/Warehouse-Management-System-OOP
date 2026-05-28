#nullable enable
using System.Drawing;
using System.Windows.Forms;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Transaction
{
    partial class TransactionForm
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Khởi tạo controls ─────────────────────────────────
            tableMain = new TableLayoutPanel();
            panelTitle = new Panel();
            lblTitle = new Label();
            lblAutoGen = new Label();
            panelFilter = new Panel();
            lblTypeHeader = new Label();
            cmbType = new ComboBox();
            lblProductHeader = new Label();
            cmbProduct = new ComboBox();
            lblStartHeader = new Label();
            chkStart = new CheckBox();
            dtpStart = new DateTimePicker();
            lblEndHeader = new Label();
            chkEnd = new CheckBox();
            dtpEnd = new DateTimePicker();
            panelCards = new Panel();
            cardTotalTx = new Panel();
            lblTotalTxLabel = new Label();
            lblTotalTx = new Label();
            cardImport = new Panel();
            lblImportLabel = new Label();
            lblTotalImport = new Label();
            cardExport = new Panel();
            lblExportLabel = new Label();
            lblTotalExport = new Label();
            dgvTransactions = new DataGridView();

            SuspendLayout();
            tableMain.SuspendLayout();

            // ════════════════════════════════════════════════════
            // TableLayoutPanel chính — 4 hàng cố định + 1 fill
            // ════════════════════════════════════════════════════
            tableMain.Dock = DockStyle.Fill;
            tableMain.BackColor = Color.FromArgb(245, 246, 250);
            tableMain.Padding = new Padding(20, 16, 20, 12);
            tableMain.ColumnCount = 1;
            tableMain.RowCount = 4;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));   // Row 0: Title
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));   // Row 1: Filter
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));  // Row 2: Cards
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // Row 3: Grid (fill)
            tableMain.Controls.Add(panelTitle, 0, 0);
            tableMain.Controls.Add(panelFilter, 0, 1);
            tableMain.Controls.Add(panelCards, 0, 2);
            tableMain.Controls.Add(dgvTransactions, 0, 3);

            // ════════════════════════════════════════════════════
            // Row 0 — Title panel
            // ════════════════════════════════════════════════════
            panelTitle.Dock = DockStyle.Fill;
            panelTitle.BackColor = Color.Transparent;
            panelTitle.Margin = new Padding(0, 0, 0, 8);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(lblAutoGen);

            lblTitle.Text = "Transactions";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(20, 20, 20);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(0, 6);

            lblAutoGen.Text = "Auto-Generated:  No manual entry allowed";
            lblAutoGen.Font = new Font("Segoe UI", 9F);
            lblAutoGen.ForeColor = Color.FromArgb(37, 99, 235);
            lblAutoGen.BackColor = Color.FromArgb(239, 246, 255);
            lblAutoGen.AutoSize = false;
            lblAutoGen.Size = new Size(340, 30);
            lblAutoGen.TextAlign = ContentAlignment.MiddleCenter;
            lblAutoGen.BorderStyle = BorderStyle.FixedSingle;
            lblAutoGen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAutoGen.Location = new Point(panelTitle.Width - 340, 8);

            panelTitle.Resize += (s, e) =>
                lblAutoGen.Location = new Point(panelTitle.Width - 340, 8);

            // ════════════════════════════════════════════════════
            // Row 1 — Filter panel
            // ════════════════════════════════════════════════════
            panelFilter.Dock = DockStyle.Fill;
            panelFilter.BackColor = Color.White;
            panelFilter.BorderStyle = BorderStyle.FixedSingle;
            panelFilter.Margin = new Padding(0, 0, 0, 8);
            panelFilter.Controls.Add(lblTypeHeader);
            panelFilter.Controls.Add(cmbType);
            panelFilter.Controls.Add(lblProductHeader);
            panelFilter.Controls.Add(cmbProduct);
            panelFilter.Controls.Add(lblStartHeader);
            panelFilter.Controls.Add(chkStart);
            panelFilter.Controls.Add(dtpStart);
            panelFilter.Controls.Add(lblEndHeader);
            panelFilter.Controls.Add(chkEnd);
            panelFilter.Controls.Add(dtpEnd);

            lblTypeHeader.Text = "Transaction Type";
            lblTypeHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTypeHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblTypeHeader.AutoSize = true;
            lblTypeHeader.Location = new Point(16, 12);

            cmbType.Location = new Point(16, 34);
            cmbType.Size = new Size(160, 28);
            cmbType.Font = new Font("Segoe UI", 9.5F);

            lblProductHeader.Text = "Product";
            lblProductHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblProductHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblProductHeader.AutoSize = true;
            lblProductHeader.Location = new Point(196, 12);

            cmbProduct.Location = new Point(196, 34);
            cmbProduct.Size = new Size(220, 28);
            cmbProduct.Font = new Font("Segoe UI", 9.5F);

            lblStartHeader.Text = "Start Date";
            lblStartHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStartHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblStartHeader.AutoSize = true;
            lblStartHeader.Location = new Point(440, 12);

            chkStart.Location = new Point(440, 36);
            chkStart.Size = new Size(16, 16);
            chkStart.Checked = false;
            chkStart.CheckedChanged += (s, e) => { dtpStart.Enabled = chkStart.Checked; ApplyFilter(); };

            dtpStart.Location = new Point(462, 32);
            dtpStart.Size = new Size(160, 28);
            dtpStart.Font = new Font("Segoe UI", 9.5F);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Enabled = false;

            lblEndHeader.Text = "End Date";
            lblEndHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblEndHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblEndHeader.AutoSize = true;
            lblEndHeader.Location = new Point(642, 12);

            chkEnd.Location = new Point(642, 36);
            chkEnd.Size = new Size(16, 16);
            chkEnd.Checked = false;
            chkEnd.CheckedChanged += (s, e) => { dtpEnd.Enabled = chkEnd.Checked; ApplyFilter(); };

            dtpEnd.Location = new Point(664, 32);
            dtpEnd.Size = new Size(160, 28);
            dtpEnd.Font = new Font("Segoe UI", 9.5F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Enabled = false;

            // ════════════════════════════════════════════════════
            // Row 2 — Cards panel (3 card ngang nhau)
            // ════════════════════════════════════════════════════
            panelCards.Dock = DockStyle.Fill;
            panelCards.BackColor = Color.Transparent;
            panelCards.Margin = new Padding(0, 0, 0, 8);
            panelCards.Controls.Add(cardTotalTx);
            panelCards.Controls.Add(cardImport);
            panelCards.Controls.Add(cardExport);

            BuildCard(cardTotalTx, lblTotalTxLabel, "TOTAL TRANSACTIONS",
                      lblTotalTx, "0", Color.FromArgb(100, 116, 139));
            BuildCard(cardImport, lblImportLabel, "TOTAL IMPORTED",
                      lblTotalImport, "0", Color.FromArgb(21, 128, 61));
            BuildCard(cardExport, lblExportLabel, "TOTAL EXPORTED",
                      lblTotalExport, "0", Color.FromArgb(185, 28, 28));

            // Căn 3 card đều nhau khi resize
            panelCards.Resize += (s, e) => LayoutCards();
            panelCards.VisibleChanged += (s, e) => LayoutCards();

            // ════════════════════════════════════════════════════
            // Row 3 — DataGridView (fill)
            // ════════════════════════════════════════════════════
            dgvTransactions.Dock = DockStyle.Fill;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.Margin = new Padding(0);

            // ════════════════════════════════════════════════════
            // UserControl
            // ════════════════════════════════════════════════════
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableMain);
            Name = "TransactionForm";
            Dock = DockStyle.Fill;

            tableMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void BuildCard(Panel card, Label lblLabel, string labelText,
                               Label lblValue, string defaultVal, Color valueColor)
        {
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            lblLabel.Text = labelText;
            lblLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblLabel.ForeColor = Color.FromArgb(120, 120, 120);
            lblLabel.AutoSize = false;
            lblLabel.Location = new Point(16, 14);
            lblLabel.Size = new Size(card.Width - 32, 20);
            lblLabel.TextAlign = ContentAlignment.MiddleLeft;

            lblValue.Text = defaultVal;
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue.ForeColor = valueColor;
            lblValue.AutoSize = false;
            lblValue.Location = new Point(16, 38);
            lblValue.Size = new Size(card.Width - 32, 44);
            lblValue.TextAlign = ContentAlignment.MiddleLeft;

            card.Controls.Add(lblLabel);
            card.Controls.Add(lblValue);
        }

        private void LayoutCards()
        {
            int w = panelCards.ClientSize.Width;
            int h = panelCards.ClientSize.Height;
            int gap = 12;
            int cardW = (w - gap * 2) / 3;
            if (cardW < 80) return;

            cardTotalTx.SetBounds(0, 0, cardW, h);
            cardImport.SetBounds(cardW + gap, 0, cardW, h);
            cardExport.SetBounds((cardW + gap) * 2, 0, cardW, h);

            // cập nhật width của labels bên trong
            foreach (var card in new[] { cardTotalTx, cardImport, cardExport })
                foreach (Control c in card.Controls)
                    c.Width = cardW - 32;
        }

        // ── Fields ────────────────────────────────────────────────
        private TableLayoutPanel tableMain = null!;
        private Panel panelTitle = null!;
        private Label lblTitle = null!;
        private Label lblAutoGen = null!;
        private Panel panelFilter = null!;
        private Label lblTypeHeader = null!;
        private ComboBox cmbType = null!;
        private Label lblProductHeader = null!;
        private ComboBox cmbProduct = null!;
        private Label lblStartHeader = null!;
        private CheckBox chkStart = null!;
        private DateTimePicker dtpStart = null!;
        private Label lblEndHeader = null!;
        private CheckBox chkEnd = null!;
        private DateTimePicker dtpEnd = null!;
        private Panel panelCards = null!;
        private Panel cardTotalTx = null!;
        private Label lblTotalTxLabel = null!;
        private Label lblTotalTx = null!;
        private Panel cardImport = null!;
        private Label lblImportLabel = null!;
        private Label lblTotalImport = null!;
        private Panel cardExport = null!;
        private Label lblExportLabel = null!;
        private Label lblTotalExport = null!;
        private DataGridView dgvTransactions = null!;
    }
}