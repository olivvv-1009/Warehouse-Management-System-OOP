namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    partial class ExportOrderDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new Panel();
            tableLayoutMain = new TableLayoutPanel();
            lblTitle = new Label();
            panelInfo = new Panel();
            tableInfo = new TableLayoutPanel();
            lblLabelDestination = new Label();
            lblLabelDate = new Label();
            lblLabelStatus = new Label();
            lblLabelCreatedBy = new Label();
            lblDestination = new Label();
            lblDate = new Label();
            lblStatus = new Label();
            lblCreatedBy = new Label();
            lblSectionTitle = new Label();
            flowBatches = new FlowLayoutPanel();
            btnClose = new Button();

            panelMain.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelInfo.SuspendLayout();
            tableInfo.SuspendLayout();
            SuspendLayout();

            // ── panelMain ────────────────────────────────────────
            panelMain.Controls.Add(tableLayoutMain);
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.FromArgb(245, 246, 250);
            panelMain.Padding = new Padding(20);
            panelMain.Name = "panelMain";

            // ── tableLayoutMain ──────────────────────────────────
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.Controls.Add(lblTitle, 0, 0);
            tableLayoutMain.Controls.Add(panelInfo, 0, 1);
            tableLayoutMain.Controls.Add(flowBatches, 0, 2);
            tableLayoutMain.Controls.Add(btnClose, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Name = "tableLayoutMain";

            // ── lblTitle ─────────────────────────────────────────
            lblTitle.Text = "Export Order Details";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Name = "lblTitle";

            // ── panelInfo ────────────────────────────────────────
            panelInfo.BackColor = Color.White;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(tableInfo);
            panelInfo.Dock = DockStyle.Fill;
            panelInfo.Padding = new Padding(15, 10, 15, 10);
            panelInfo.Margin = new Padding(0, 6, 0, 10);
            panelInfo.Name = "panelInfo";

            // ── tableInfo ────────────────────────────────────────
            tableInfo.ColumnCount = 2;
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableInfo.RowCount = 4;
            tableInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableInfo.Controls.Add(lblLabelDestination, 0, 0);
            tableInfo.Controls.Add(lblLabelDate, 1, 0);
            tableInfo.Controls.Add(lblDestination, 0, 1);
            tableInfo.Controls.Add(lblDate, 1, 1);
            tableInfo.Controls.Add(lblLabelStatus, 0, 2);
            tableInfo.Controls.Add(lblLabelCreatedBy, 1, 2);
            tableInfo.Controls.Add(lblStatus, 0, 3);
            tableInfo.Controls.Add(lblCreatedBy, 1, 3);
            tableInfo.Dock = DockStyle.Fill;
            tableInfo.Name = "tableInfo";

            // ── Header labels (nhỏ, xám) ─────────────────────────
            lblLabelDestination.Text = "Destination";
            lblLabelDestination.Font = new Font("Segoe UI", 9F);
            lblLabelDestination.ForeColor = Color.FromArgb(120, 120, 120);
            lblLabelDestination.Dock = DockStyle.Fill;
            lblLabelDestination.TextAlign = ContentAlignment.BottomLeft;
            lblLabelDestination.Name = "lblLabelDestination";

            lblLabelDate.Text = "Date";
            lblLabelDate.Font = new Font("Segoe UI", 9F);
            lblLabelDate.ForeColor = Color.FromArgb(120, 120, 120);
            lblLabelDate.Dock = DockStyle.Fill;
            lblLabelDate.TextAlign = ContentAlignment.BottomLeft;
            lblLabelDate.Name = "lblLabelDate";

            lblLabelStatus.Text = "Status";
            lblLabelStatus.Font = new Font("Segoe UI", 9F);
            lblLabelStatus.ForeColor = Color.FromArgb(120, 120, 120);
            lblLabelStatus.Dock = DockStyle.Fill;
            lblLabelStatus.TextAlign = ContentAlignment.BottomLeft;
            lblLabelStatus.Name = "lblLabelStatus";

            lblLabelCreatedBy.Text = "Created By";
            lblLabelCreatedBy.Font = new Font("Segoe UI", 9F);
            lblLabelCreatedBy.ForeColor = Color.FromArgb(120, 120, 120);
            lblLabelCreatedBy.Dock = DockStyle.Fill;
            lblLabelCreatedBy.TextAlign = ContentAlignment.BottomLeft;
            lblLabelCreatedBy.Name = "lblLabelCreatedBy";

            // ── Value labels (đậm) ───────────────────────────────
            lblDestination.Text = "";
            lblDestination.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDestination.Dock = DockStyle.Fill;
            lblDestination.TextAlign = ContentAlignment.TopLeft;
            lblDestination.Name = "lblDestination";

            lblDate.Text = "";
            lblDate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDate.Dock = DockStyle.Fill;
            lblDate.TextAlign = ContentAlignment.TopLeft;
            lblDate.Name = "lblDate";

            lblStatus.Text = "";
            lblStatus.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.TextAlign = ContentAlignment.TopLeft;
            lblStatus.Name = "lblStatus";

            lblCreatedBy.Text = "";
            lblCreatedBy.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCreatedBy.Dock = DockStyle.Fill;
            lblCreatedBy.TextAlign = ContentAlignment.TopLeft;
            lblCreatedBy.Name = "lblCreatedBy";

            // ── lblSectionTitle (dùng trong code, không add vào layout) ──
            lblSectionTitle.Text = "Products & Batch Allocations";
            lblSectionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSectionTitle.AutoSize = true;
            lblSectionTitle.Name = "lblSectionTitle";

            // ── flowBatches ──────────────────────────────────────
            flowBatches.AutoScroll = true;
            flowBatches.FlowDirection = FlowDirection.TopDown;
            flowBatches.WrapContents = false;
            flowBatches.Dock = DockStyle.Fill;
            flowBatches.BackColor = Color.FromArgb(245, 246, 250);
            flowBatches.Padding = new Padding(0, 4, 0, 0);
            flowBatches.Name = "flowBatches";

            // ── btnClose ─────────────────────────────────────────
            btnClose.Text = "Close";
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.BackColor = Color.FromArgb(37, 99, 235);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(100, 36);
            btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnClose.Margin = new Padding(0, 7, 0, 7);
            btnClose.Name = "btnClose";
            btnClose.Click += btnClose_Click;

            // ── Form ─────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 560);
            Controls.Add(panelMain);
            Name = "ExportOrderDetails";
            Text = "Export Order Details";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            panelMain.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            tableInfo.ResumeLayout(false);
            tableInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private TableLayoutPanel tableLayoutMain;
        private Label lblTitle;
        private Panel panelInfo;
        private TableLayoutPanel tableInfo;
        private Label lblLabelDestination;
        private Label lblLabelDate;
        private Label lblLabelStatus;
        private Label lblLabelCreatedBy;
        private Label lblDestination;
        private Label lblDate;
        private Label lblStatus;
        private Label lblCreatedBy;
        private Label lblSectionTitle;
        private FlowLayoutPanel flowBatches;
        private Button btnClose;
    }
}
