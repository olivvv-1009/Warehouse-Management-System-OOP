using System.Windows.Forms;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    partial class ReturnSupplier
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
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpReturnDate = new DateTimePicker();
            cboImportInvoice = new ComboBox();
            txtSupplier = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            lbCreatedby = new Label();
            txtReason = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnCancel = new Button();
            btnSubmit = new Button();
            dgvProducts = new DataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
            panel1.Size = new Size(710, 528);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 4);
            tableLayoutPanel1.Controls.Add(dgvProducts, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.Size = new Size(680, 498);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(674, 50);
            label1.TabIndex = 0;
            label1.Text = "Return to Supplier";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 266F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(label4, 2, 0);
            tableLayoutPanel2.Controls.Add(dtpReturnDate, 2, 1);
            tableLayoutPanel2.Controls.Add(cboImportInvoice, 0, 1);
            tableLayoutPanel2.Controls.Add(txtSupplier, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(674, 74);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(198, 37);
            label2.TabIndex = 0;
            label2.Text = "Import Invoice";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(207, 0);
            label3.Name = "label3";
            label3.Size = new Size(198, 37);
            label3.TabIndex = 1;
            label3.Text = "Supplier";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(411, 0);
            label4.Name = "label4";
            label4.Size = new Size(260, 37);
            label4.TabIndex = 2;
            label4.Text = "Date";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Dock = DockStyle.Fill;
            dtpReturnDate.Location = new Point(411, 40);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(260, 30);
            dtpReturnDate.TabIndex = 4;
            dtpReturnDate.Value = new DateTime(2026, 5, 20, 22, 16, 59, 827);
            // 
            // cboImportInvoice
            // 
            cboImportInvoice.Dock = DockStyle.Fill;
            cboImportInvoice.FormattingEnabled = true;
            cboImportInvoice.Location = new Point(3, 40);
            cboImportInvoice.Name = "cboImportInvoice";
            cboImportInvoice.Size = new Size(198, 30);
            cboImportInvoice.TabIndex = 5;
            cboImportInvoice.SelectedIndexChanged += cboImportInvoice_SelectedIndexChanged;
            // 
            // txtSupplier
            // 
            txtSupplier.Dock = DockStyle.Fill;
            txtSupplier.Location = new Point(207, 40);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(198, 30);
            txtSupplier.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label5, 0, 0);
            tableLayoutPanel3.Controls.Add(label6, 1, 0);
            tableLayoutPanel3.Controls.Add(lbCreatedby, 0, 1);
            tableLayoutPanel3.Controls.Add(txtReason, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 133);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(674, 65);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(331, 32);
            label5.TabIndex = 0;
            label5.Text = "Created by";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(340, 0);
            label6.Name = "label6";
            label6.Size = new Size(331, 32);
            label6.TabIndex = 1;
            label6.Text = "Reason";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCreatedby
            // 
            lbCreatedby.AutoSize = true;
            lbCreatedby.Dock = DockStyle.Fill;
            lbCreatedby.Location = new Point(3, 32);
            lbCreatedby.Name = "lbCreatedby";
            lbCreatedby.Size = new Size(331, 33);
            lbCreatedby.TabIndex = 2;
            lbCreatedby.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtReason
            // 
            txtReason.Dock = DockStyle.Fill;
            txtReason.Location = new Point(340, 35);
            txtReason.Name = "txtReason";
            txtReason.PlaceholderText = "Enter the reason returning to supplier";
            txtReason.Size = new Size(331, 30);
            txtReason.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.47482F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5251789F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tableLayoutPanel4.Controls.Add(btnCancel, 1, 0);
            tableLayoutPanel4.Controls.Add(btnSubmit, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 457);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(674, 38);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(456, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 32);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.LimeGreen;
            btnSubmit.Dock = DockStyle.Fill;
            btnSubmit.ForeColor = SystemColors.ActiveCaptionText;
            btnSubmit.Location = new Point(559, 3);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 32);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.BackgroundColor = SystemColors.Control;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 204);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(674, 247);
            dgvProducts.TabIndex = 4;
            // 
            // ReturnSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 528);
            Controls.Add(panel1);
            Name = "ReturnSupplier";
            Text = "ReturnSupplier";
            Load += ReturnSupplier_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpReturnDate;
        private ComboBox cboImportInvoice;
        private Label label5;
        private Label label6;
        private Label lbCreatedby;
        private TextBox txtReason;
        private Button btnCancel;
        private Button btnSubmit;
        private DataGridView dgvProducts;
        private TextBox txtSupplier;
    }
}