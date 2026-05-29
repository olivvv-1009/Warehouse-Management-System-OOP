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
            cardImport = new Panel();
            cardExport = new Panel();
            dgvTransactions = new DataGridView();
            lblTotalTxLabel = new Label();
            lblTotalTx = new Label();
            lblImportLabel = new Label();
            lblTotalImport = new Label();
            lblExportLabel = new Label();
            lblTotalExport = new Label();
            tableMain.SuspendLayout();
            panelTitle.SuspendLayout();
            panelFilter.SuspendLayout();
            panelCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.BackColor = Color.FromArgb(245, 246, 250);
            tableMain.ColumnCount = 1;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableMain.Controls.Add(panelTitle, 0, 0);
            tableMain.Controls.Add(panelFilter, 0, 1);
            tableMain.Controls.Add(panelCards, 0, 2);
            tableMain.Controls.Add(dgvTransactions, 0, 3);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Name = "tableMain";
            tableMain.Padding = new Padding(20, 16, 20, 12);
            tableMain.RowCount = 4;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableMain.Size = new Size(1036, 554);
            tableMain.TabIndex = 0;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.Transparent;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(lblAutoGen);
            panelTitle.Dock = DockStyle.Fill;
            panelTitle.Location = new Point(20, 16);
            panelTitle.Margin = new Padding(0, 0, 0, 8);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(996, 44);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(20, 20, 20);
            lblTitle.Location = new Point(0, 6);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Transactions";
            // 
            // lblAutoGen
            // 
            lblAutoGen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAutoGen.BackColor = Color.FromArgb(239, 246, 255);
            lblAutoGen.BorderStyle = BorderStyle.FixedSingle;
            lblAutoGen.Font = new Font("Segoe UI", 9F);
            lblAutoGen.ForeColor = Color.FromArgb(37, 99, 235);
            lblAutoGen.Location = new Point(1296, 8);
            lblAutoGen.Name = "lblAutoGen";
            lblAutoGen.Size = new Size(340, 30);
            lblAutoGen.TabIndex = 1;
            lblAutoGen.Text = "Auto-Generated:  No manual entry allowed";
            lblAutoGen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.BorderStyle = BorderStyle.FixedSingle;
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
            panelFilter.Dock = DockStyle.Fill;
            panelFilter.Location = new Point(20, 68);
            panelFilter.Margin = new Padding(0, 0, 0, 8);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(996, 80);
            panelFilter.TabIndex = 1;
            // 
            // lblTypeHeader
            // 
            lblTypeHeader.AutoSize = true;
            lblTypeHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTypeHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblTypeHeader.Location = new Point(16, 12);
            lblTypeHeader.Name = "lblTypeHeader";
            lblTypeHeader.Size = new Size(127, 20);
            lblTypeHeader.TabIndex = 0;
            lblTypeHeader.Text = "Transaction Type";
            // 
            // cmbType
            // 
            cmbType.Font = new Font("Segoe UI", 9.5F);
            cmbType.Location = new Point(16, 34);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(160, 29);
            cmbType.TabIndex = 1;
            // 
            // lblProductHeader
            // 
            lblProductHeader.AutoSize = true;
            lblProductHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblProductHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblProductHeader.Location = new Point(196, 12);
            lblProductHeader.Name = "lblProductHeader";
            lblProductHeader.Size = new Size(64, 20);
            lblProductHeader.TabIndex = 2;
            lblProductHeader.Text = "Product";
            // 
            // cmbProduct
            // 
            cmbProduct.Font = new Font("Segoe UI", 9.5F);
            cmbProduct.Location = new Point(196, 34);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(220, 29);
            cmbProduct.TabIndex = 3;
            // 
            // lblStartHeader
            // 
            lblStartHeader.AutoSize = true;
            lblStartHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStartHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblStartHeader.Location = new Point(440, 12);
            lblStartHeader.Name = "lblStartHeader";
            lblStartHeader.Size = new Size(80, 20);
            lblStartHeader.TabIndex = 4;
            lblStartHeader.Text = "Start Date";
            // 
            // chkStart
            // 
            chkStart.Location = new Point(440, 36);
            chkStart.Name = "chkStart";
            chkStart.Size = new Size(16, 16);
            chkStart.TabIndex = 5;
            // 
            // dtpStart
            // 
            dtpStart.Enabled = false;
            dtpStart.Font = new Font("Segoe UI", 9.5F);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(462, 32);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(160, 29);
            dtpStart.TabIndex = 6;
            // 
            // lblEndHeader
            // 
            lblEndHeader.AutoSize = true;
            lblEndHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblEndHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblEndHeader.Location = new Point(642, 12);
            lblEndHeader.Name = "lblEndHeader";
            lblEndHeader.Size = new Size(72, 20);
            lblEndHeader.TabIndex = 7;
            lblEndHeader.Text = "End Date";
            // 
            // chkEnd
            // 
            chkEnd.Location = new Point(642, 36);
            chkEnd.Name = "chkEnd";
            chkEnd.Size = new Size(16, 16);
            chkEnd.TabIndex = 8;
            // 
            // dtpEnd
            // 
            dtpEnd.Enabled = false;
            dtpEnd.Font = new Font("Segoe UI", 9.5F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(664, 32);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(160, 29);
            dtpEnd.TabIndex = 9;
            // 
            // panelCards
            // 
            panelCards.BackColor = Color.Transparent;
            panelCards.Controls.Add(cardTotalTx);
            panelCards.Controls.Add(cardImport);
            panelCards.Controls.Add(cardExport);
            panelCards.Dock = DockStyle.Fill;
            panelCards.Location = new Point(20, 156);
            panelCards.Margin = new Padding(0, 0, 0, 8);
            panelCards.Name = "panelCards";
            panelCards.Size = new Size(996, 100);
            panelCards.TabIndex = 2;
            // 
            // cardTotalTx
            // 
            cardTotalTx.Location = new Point(0, 0);
            cardTotalTx.Name = "cardTotalTx";
            cardTotalTx.Size = new Size(200, 100);
            cardTotalTx.TabIndex = 0;
            // 
            // cardImport
            // 
            cardImport.Location = new Point(0, 0);
            cardImport.Name = "cardImport";
            cardImport.Size = new Size(200, 100);
            cardImport.TabIndex = 1;
            // 
            // cardExport
            // 
            cardExport.Location = new Point(0, 0);
            cardExport.Name = "cardExport";
            cardExport.Size = new Size(200, 100);
            cardExport.TabIndex = 2;
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.ColumnHeadersHeight = 29;
            dgvTransactions.Dock = DockStyle.Fill;
            dgvTransactions.Location = new Point(20, 264);
            dgvTransactions.Margin = new Padding(0);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(996, 278);
            dgvTransactions.TabIndex = 3;
            // 
            // lblTotalTxLabel
            // 
            lblTotalTxLabel.Location = new Point(0, 0);
            lblTotalTxLabel.Name = "lblTotalTxLabel";
            lblTotalTxLabel.Size = new Size(100, 23);
            lblTotalTxLabel.TabIndex = 0;
            // 
            // lblTotalTx
            // 
            lblTotalTx.Location = new Point(0, 0);
            lblTotalTx.Name = "lblTotalTx";
            lblTotalTx.Size = new Size(100, 23);
            lblTotalTx.TabIndex = 0;
            // 
            // lblImportLabel
            // 
            lblImportLabel.Location = new Point(0, 0);
            lblImportLabel.Name = "lblImportLabel";
            lblImportLabel.Size = new Size(100, 23);
            lblImportLabel.TabIndex = 0;
            // 
            // lblTotalImport
            // 
            lblTotalImport.Location = new Point(0, 0);
            lblTotalImport.Name = "lblTotalImport";
            lblTotalImport.Size = new Size(100, 23);
            lblTotalImport.TabIndex = 0;
            // 
            // lblExportLabel
            // 
            lblExportLabel.Location = new Point(0, 0);
            lblExportLabel.Name = "lblExportLabel";
            lblExportLabel.Size = new Size(100, 23);
            lblExportLabel.TabIndex = 0;
            // 
            // lblTotalExport
            // 
            lblTotalExport.Location = new Point(0, 0);
            lblTotalExport.Name = "lblTotalExport";
            lblTotalExport.Size = new Size(100, 23);
            lblTotalExport.TabIndex = 0;
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableMain);
            Name = "TransactionForm";
            Size = new Size(1036, 554);
            tableMain.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
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