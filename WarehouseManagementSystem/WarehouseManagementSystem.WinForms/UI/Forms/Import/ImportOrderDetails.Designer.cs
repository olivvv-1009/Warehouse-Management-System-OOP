namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    partial class ImportOrderDetails
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblSupplier = new Label();
            lblDate = new Label();
            lblStatus = new Label();
            lblCreatedBy = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label10 = new Label();
            panel3 = new Panel();
            dgvProduct = new DataGridView();
            btnClose = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(btnClose, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 222F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.Size = new Size(770, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(764, 34);
            label1.TabIndex = 0;
            label1.Text = "Import Order Detail";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(764, 124);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(label4, 0, 2);
            tableLayoutPanel2.Controls.Add(label5, 1, 2);
            tableLayoutPanel2.Controls.Add(lblSupplier, 0, 1);
            tableLayoutPanel2.Controls.Add(lblDate, 1, 1);
            tableLayoutPanel2.Controls.Add(lblStatus, 0, 3);
            tableLayoutPanel2.Controls.Add(lblCreatedBy, 1, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(764, 124);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(376, 31);
            label2.TabIndex = 0;
            label2.Text = "Supplier";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(385, 0);
            label3.Name = "label3";
            label3.Size = new Size(376, 31);
            label3.TabIndex = 1;
            label3.Text = "Date";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 62);
            label4.Name = "label4";
            label4.Size = new Size(376, 31);
            label4.TabIndex = 2;
            label4.Text = "Status";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(385, 62);
            label5.Name = "label5";
            label5.Size = new Size(376, 31);
            label5.TabIndex = 3;
            label5.Text = "Created by";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Dock = DockStyle.Fill;
            lblSupplier.Location = new Point(3, 31);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(376, 31);
            lblSupplier.TabIndex = 4;
            lblSupplier.Text = "label6";
            lblSupplier.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Dock = DockStyle.Fill;
            lblDate.Location = new Point(385, 31);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(376, 31);
            lblDate.TabIndex = 5;
            lblDate.Text = "label7";
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(3, 93);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(376, 31);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "label8";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.AutoSize = true;
            lblCreatedBy.Dock = DockStyle.Fill;
            lblCreatedBy.Location = new Point(385, 93);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(376, 31);
            lblCreatedBy.TabIndex = 7;
            lblCreatedBy.Text = "label9";
            lblCreatedBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(label10, 0, 0);
            tableLayoutPanel3.Controls.Add(panel3, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 167);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15.7407408F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 84.25926F));
            tableLayoutPanel3.Size = new Size(764, 216);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(758, 34);
            label10.TabIndex = 0;
            label10.Text = "Product";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(dgvProduct);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(758, 176);
            panel3.TabIndex = 1;
            // 
            // dgvProduct
            // 
            dgvProduct.BackgroundColor = SystemColors.Control;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Dock = DockStyle.Fill;
            dgvProduct.Location = new Point(0, 0);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.Size = new Size(758, 176);
            dgvProduct.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Dock = DockStyle.Right;
            btnClose.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(673, 389);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 28);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click_1;
            // 
            // ImportOrderDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "ImportOrderDetails";
            Text = "ImportOrderDetails";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblSupplier;
        private Label lblDate;
        private Label lblStatus;
        private Label lblCreatedBy;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label10;
        private Button btnClose;
        private Panel panel3;
        private DataGridView dgvProduct;
    }
}