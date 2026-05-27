namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    partial class CreateExportInvoice
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
            panelMain = new Panel();
            tableButton = new TableLayoutPanel();
            btnComplete = new Button();
            btnSaveDraft = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            dgvProducts = new DataGridView();
            Product = new DataGridViewTextBoxColumn();
            Available = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            FIFO_Allocation = new DataGridViewTextBoxColumn();
            tableProductHeader = new TableLayoutPanel();
            label5 = new Label();
            btnAddProduct = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblEmployeeValue = new Label();
            txtDestination = new TextBox();
            dtpDate = new DateTimePicker();
            label1 = new Label();
            panelMain.SuspendLayout();
            tableButton.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            tableProductHeader.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(tableButton);
            panelMain.Controls.Add(panel1);
            panelMain.Controls.Add(dgvProducts);
            panelMain.Controls.Add(tableProductHeader);
            panelMain.Controls.Add(tableLayoutPanel1);
            panelMain.Controls.Add(label1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(25);
            panelMain.Size = new Size(678, 678);
            panelMain.TabIndex = 0;
            // 
            // tableButton
            // 
            tableButton.ColumnCount = 3;
            tableButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableButton.Controls.Add(btnComplete, 2, 0);
            tableButton.Controls.Add(btnSaveDraft, 1, 0);
            tableButton.Controls.Add(btnCancel, 0, 0);
            tableButton.Location = new Point(303, 596);
            tableButton.Name = "tableButton";
            tableButton.RowCount = 1;
            tableButton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableButton.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableButton.Size = new Size(347, 54);
            tableButton.TabIndex = 5;
            // 
            // btnComplete
            // 
            btnComplete.Anchor = AnchorStyles.None;
            btnComplete.BackColor = Color.LightCoral;
            btnComplete.Location = new Point(233, 10);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(108, 34);
            btnComplete.TabIndex = 2;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = false;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.Anchor = AnchorStyles.None;
            btnSaveDraft.Location = new Point(117, 10);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(108, 34);
            btnSaveDraft.TabIndex = 1;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Location = new Point(3, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 34);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(26, 476);
            panel1.Name = "panel1";
            panel1.Size = new Size(624, 76);
            panel1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.HotTrack;
            label7.Location = new Point(18, 38);
            label7.Name = "label7";
            label7.Size = new Size(556, 25);
            label7.TabIndex = 1;
            label7.Text = "Products will be automatically allocated from the oldest batches first.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.AliceBlue;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.RoyalBlue;
            label6.Location = new Point(18, 13);
            label6.Name = "label6";
            label6.Size = new Size(219, 25);
            label6.TabIndex = 0;
            label6.Text = "FIFO (First-In-First-Out): ";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { Product, Available, Quantity, FIFO_Allocation });
            dgvProducts.Location = new Point(26, 316);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(624, 122);
            dgvProducts.TabIndex = 3;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.MinimumWidth = 8;
            Product.Name = "Product";
            Product.Width = 170;
            // 
            // Available
            // 
            Available.HeaderText = "Available";
            Available.MinimumWidth = 8;
            Available.Name = "Available";
            Available.Width = 120;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.Width = 120;
            // 
            // FIFO_Allocation
            // 
            FIFO_Allocation.HeaderText = "FIFO_Allocation";
            FIFO_Allocation.MinimumWidth = 8;
            FIFO_Allocation.Name = "FIFO_Allocation";
            FIFO_Allocation.Width = 220;
            // 
            // tableProductHeader
            // 
            tableProductHeader.ColumnCount = 2;
            tableProductHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableProductHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableProductHeader.Controls.Add(label5, 0, 0);
            tableProductHeader.Controls.Add(btnAddProduct, 1, 0);
            tableProductHeader.Location = new Point(26, 220);
            tableProductHeader.Name = "tableProductHeader";
            tableProductHeader.RowCount = 1;
            tableProductHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableProductHeader.Size = new Size(624, 60);
            tableProductHeader.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(3, 17);
            label5.Name = "label5";
            label5.Size = new Size(100, 25);
            label5.TabIndex = 0;
            label5.Text = "Products *";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.None;
            btnAddProduct.BackColor = Color.SeaShell;
            btnAddProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddProduct.Location = new Point(447, 13);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(165, 34);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(lblEmployeeValue, 2, 1);
            tableLayoutPanel1.Controls.Add(txtDestination, 0, 1);
            tableLayoutPanel1.Controls.Add(dtpDate, 1, 1);
            tableLayoutPanel1.Location = new Point(28, 79);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(622, 104);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(419, 13);
            label4.Name = "label4";
            label4.Size = new Size(193, 25);
            label4.TabIndex = 2;
            label4.Text = "Created By Employee";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(275, 13);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 1;
            label3.Text = "Date *";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(41, 13);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 0;
            label2.Text = "Destination *";
            // 
            // lblEmployeeValue
            // 
            lblEmployeeValue.Anchor = AnchorStyles.None;
            lblEmployeeValue.AutoSize = true;
            lblEmployeeValue.Location = new Point(516, 65);
            lblEmployeeValue.Name = "lblEmployeeValue";
            lblEmployeeValue.Size = new Size(0, 25);
            lblEmployeeValue.TabIndex = 5;
            // 
            // txtDestination
            // 
            txtDestination.Anchor = AnchorStyles.None;
            txtDestination.Location = new Point(27, 62);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(150, 31);
            txtDestination.TabIndex = 3;
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Bottom;
            dtpDate.CustomFormat = "MM/dd/yyyy";
            dtpDate.DropDownAlign = LeftRightAlignment.Right;
            dtpDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dtpDate.Location = new Point(225, 70);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(164, 31);
            dtpDate.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(342, 45);
            label1.TabIndex = 0;
            label1.Text = "Create Export Invoice";
            // 
            // CreateExportInvoice
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 678);
            Controls.Add(panelMain);
            Name = "CreateExportInvoice";
            Text = "CreateExportInvoice";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            tableButton.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            tableProductHeader.ResumeLayout(false);
            tableProductHeader.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox txtDestination;
        private DateTimePicker dtpDate;
        private Label lblEmployeeValue;
        private TableLayoutPanel tableProductHeader;
        private Label label5;
        private DataGridView dgvProducts;
        private Button btnAddProduct;
        private TableLayoutPanel tableButton;
        private Panel panel1;
        private Label label7;
        private Label label6;
        private Button btnCancel;
        private Button btnComplete;
        private Button btnSaveDraft;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Available;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn FIFO_Allocation;
    }
}