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
            lblProductId = new Label();
            lblProductName = new Label();
            lblQuantity = new Label();
            lblMinStock = new Label();
            panelBatch = new Panel();
            dgvBatch = new DataGridView();
            lblStatus = new Label();
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
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5325127F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5799675F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.9261875F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.50791F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.4534225F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(lblProductId, 0, 0);
            tableLayoutPanel1.Controls.Add(lblProductName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblQuantity, 2, 0);
            tableLayoutPanel1.Controls.Add(lblMinStock, 3, 0);
            tableLayoutPanel1.Controls.Add(lblStatus, 4, 0);
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
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Dock = DockStyle.Fill;
            lblProductId.Location = new Point(3, 0);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(127, 57);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Product ID";
            lblProductId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Dock = DockStyle.Fill;
            lblProductName.Location = new Point(136, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(294, 57);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            lblProductName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Dock = DockStyle.Fill;
            lblQuantity.Location = new Point(436, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(170, 57);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMinStock
            // 
            lblMinStock.AutoSize = true;
            lblMinStock.Dock = DockStyle.Fill;
            lblMinStock.Location = new Point(612, 0);
            lblMinStock.Name = "lblMinStock";
            lblMinStock.Size = new Size(185, 57);
            lblMinStock.TabIndex = 3;
            lblMinStock.Text = "Min Stock";
            lblMinStock.TextAlign = ContentAlignment.MiddleCenter;
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
            dgvBatch.RowHeadersWidth = 51;
            dgvBatch.Size = new Size(983, 112);
            dgvBatch.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(803, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(177, 57);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InventoryCardControl
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
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
        private Label lblProductId;
        private Label lblProductName;
        private Label lblQuantity;
        private Label lblMinStock;
        private Panel panelBatch;
        private DataGridView dgvBatch;
        private Label lblStatus;
    }
}
