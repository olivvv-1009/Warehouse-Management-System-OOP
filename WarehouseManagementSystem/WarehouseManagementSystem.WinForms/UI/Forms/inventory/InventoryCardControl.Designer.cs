namespace WarehouseManagementSystem.WinForms.UI.Forms.inventory
{
    partial class InventoryCardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAction = new Label();
            lblStatus = new Label();
            lblZone = new Label();
            lblShelf = new Label();
            lblImportPrice = new Label();
            lblImportDate = new Label();
            lblRemainQty = new Label();
            lblSupplier = new Label();
            lblBatchID = new Label();
            panelBatch = new Panel();
            dgvBatch = new DataGridView();
            panelHeader.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBatch).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(tableLayoutPanel1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(983, 57);
            panelHeader.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightGray;
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(lblAction, 8, 0);
            tableLayoutPanel1.Controls.Add(lblStatus, 7, 0);
            tableLayoutPanel1.Controls.Add(lblZone, 6, 0);
            tableLayoutPanel1.Controls.Add(lblShelf, 5, 0);
            tableLayoutPanel1.Controls.Add(lblImportPrice, 4, 0);
            tableLayoutPanel1.Controls.Add(lblImportDate, 3, 0);
            tableLayoutPanel1.Controls.Add(lblRemainQty, 2, 0);
            tableLayoutPanel1.Controls.Add(lblSupplier, 1, 0);
            tableLayoutPanel1.Controls.Add(lblBatchID, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(983, 57);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Dock = DockStyle.Fill;
            lblAction.Location = new Point(882, 0);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(98, 57);
            lblAction.TabIndex = 8;
            lblAction.Text = "Action";
            lblAction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(784, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(92, 57);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblZone
            // 
            lblZone.AutoSize = true;
            lblZone.Dock = DockStyle.Fill;
            lblZone.Location = new Point(716, 0);
            lblZone.Name = "lblZone";
            lblZone.Size = new Size(62, 57);
            lblZone.TabIndex = 6;
            lblZone.Text = "Zone";
            lblZone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShelf
            // 
            lblShelf.AutoSize = true;
            lblShelf.Dock = DockStyle.Fill;
            lblShelf.Location = new Point(648, 0);
            lblShelf.Name = "lblShelf";
            lblShelf.Size = new Size(62, 57);
            lblShelf.TabIndex = 5;
            lblShelf.Text = "Shelf";
            lblShelf.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblImportPrice
            // 
            lblImportPrice.AutoSize = true;
            lblImportPrice.Dock = DockStyle.Fill;
            lblImportPrice.Location = new Point(521, 0);
            lblImportPrice.Name = "lblImportPrice";
            lblImportPrice.Size = new Size(121, 57);
            lblImportPrice.TabIndex = 4;
            lblImportPrice.Text = "ImportPrice";
            lblImportPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblImportDate
            // 
            lblImportDate.AutoSize = true;
            lblImportDate.Dock = DockStyle.Fill;
            lblImportDate.Location = new Point(394, 0);
            lblImportDate.Name = "lblImportDate";
            lblImportDate.Size = new Size(121, 57);
            lblImportDate.TabIndex = 3;
            lblImportDate.Text = "ImportDate";
            lblImportDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRemainQty
            // 
            lblRemainQty.AutoSize = true;
            lblRemainQty.Dock = DockStyle.Fill;
            lblRemainQty.Location = new Point(247, 0);
            lblRemainQty.Name = "lblRemainQty";
            lblRemainQty.Size = new Size(141, 57);
            lblRemainQty.TabIndex = 2;
            lblRemainQty.Text = "RemainingQty";
            lblRemainQty.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Dock = DockStyle.Fill;
            lblSupplier.Location = new Point(120, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(121, 57);
            lblSupplier.TabIndex = 1;
            lblSupplier.Text = "Supplier";
            lblSupplier.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBatchID
            // 
            lblBatchID.AutoSize = true;
            lblBatchID.Dock = DockStyle.Fill;
            lblBatchID.Location = new Point(3, 0);
            lblBatchID.Name = "lblBatchID";
            lblBatchID.Size = new Size(111, 57);
            lblBatchID.TabIndex = 0;
            lblBatchID.Text = "BatchID";
            lblBatchID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBatch
            // 
            panelBatch.Controls.Add(dgvBatch);
            panelBatch.Dock = DockStyle.Top;
            panelBatch.Location = new Point(0, 57);
            panelBatch.Name = "panelBatch";
            panelBatch.Size = new Size(983, 112);
            panelBatch.TabIndex = 1;
            // 
            // dgvBatch
            // 
            dgvBatch.BackgroundColor = Color.White;
            dgvBatch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBatch.Dock = DockStyle.Fill;
            dgvBatch.Location = new Point(0, 0);
            dgvBatch.Name = "dgvBatch";
            dgvBatch.ReadOnly = true;
            dgvBatch.RowHeadersVisible = false;
            dgvBatch.RowHeadersWidth = 51;
            dgvBatch.Size = new Size(983, 112);
            dgvBatch.TabIndex = 0;
            // 
            // InventoryCardControl
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBatch);
            Controls.Add(panelHeader);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "InventoryCardControl";
            Size = new Size(983, 183);
            panelHeader.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelBatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBatch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelBatch;
        private DataGridView dgvBatch;
        private Label lblBatchID;
        private Label lblAction;
        private Label lblStatus;
        private Label lblZone;
        private Label lblShelf;
        private Label lblImportPrice;
        private Label lblImportDate;
        private Label lblRemainQty;
        private Label lblSupplier;
    }
}
