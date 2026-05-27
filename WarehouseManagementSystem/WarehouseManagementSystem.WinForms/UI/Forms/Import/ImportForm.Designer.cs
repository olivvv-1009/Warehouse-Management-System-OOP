namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    partial class ImportForm
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            btnCreate = new Button();
            btnReturn = new Button();
            dgvImportOrders = new DataGridView();
            colImportId = new DataGridViewTextBoxColumn();
            colSupplier = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colItems = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colReturnStatus = new DataGridViewTextBoxColumn();
            colCreatedBy = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImportOrders).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(19);
            panel1.Size = new Size(1066, 691);
            panel1.TabIndex = 1;
            panel1.Paint += this.panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvImportOrders, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(19, 19);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new Size(1028, 653);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += this.tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.6156654F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.6205635F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.76377F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(btnCreate, 2, 0);
            tableLayoutPanel2.Controls.Add(btnReturn, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 4);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel2.Size = new Size(1020, 56);
            tableLayoutPanel2.TabIndex = 3;
            tableLayoutPanel2.Paint += this.tableLayoutPanel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(416, 56);
            label1.TabIndex = 0;
            label1.Text = "Import Orders";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += this.label1_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.LimeGreen;
            btnCreate.Dock = DockStyle.Fill;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(730, 4);
            btnCreate.Margin = new Padding(4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(286, 48);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create Import Order";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.DarkOrange;
            btnReturn.Dock = DockStyle.Fill;
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(428, 4);
            btnReturn.Margin = new Padding(4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(294, 48);
            btnReturn.TabIndex = 1;
            btnReturn.Text = "Return to Supplier";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // dgvImportOrders
            // 
            dgvImportOrders.AllowUserToAddRows = false;
            dgvImportOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportOrders.BackgroundColor = Color.White;
            dgvImportOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImportOrders.Columns.AddRange(new DataGridViewColumn[] { colImportId, colSupplier, colDate, colItems, colStatus, colReturnStatus, colCreatedBy, colAction });
            dgvImportOrders.Dock = DockStyle.Fill;
            dgvImportOrders.Location = new Point(4, 68);
            dgvImportOrders.Margin = new Padding(4);
            dgvImportOrders.Name = "dgvImportOrders";
            dgvImportOrders.RowHeadersVisible = false;
            dgvImportOrders.RowHeadersWidth = 51;
            dgvImportOrders.Size = new Size(1020, 581);
            dgvImportOrders.TabIndex = 2;
            dgvImportOrders.CellContentClick += dgvImportOrders_CellContentClick;
            dgvImportOrders.CellDoubleClick += dgvImportOrders_CellDoubleClick;
            // 
            // colImportId
            // 
            colImportId.HeaderText = "Invoice ID";
            colImportId.MinimumWidth = 8;
            colImportId.Name = "colImportId";
            // 
            // colSupplier
            // 
            colSupplier.HeaderText = "Supplier";
            colSupplier.MinimumWidth = 8;
            colSupplier.Name = "colSupplier";
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 8;
            colDate.Name = "colDate";
            // 
            // colItems
            // 
            colItems.HeaderText = "Items";
            colItems.MinimumWidth = 8;
            colItems.Name = "colItems";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // colReturnStatus
            // 
            colReturnStatus.HeaderText = "Return Status";
            colReturnStatus.MinimumWidth = 8;
            colReturnStatus.Name = "colReturnStatus";
            // 
            // colCreatedBy
            // 
            colCreatedBy.HeaderText = "Created By";
            colCreatedBy.MinimumWidth = 8;
            colCreatedBy.Name = "colCreatedBy";
            // 
            // colAction
            // 
            colAction.HeaderText = "Actions";
            colAction.MinimumWidth = 8;
            colAction.Name = "colAction";
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "ImportForm";
            Size = new Size(1066, 691);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImportOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private DataGridView dgvImportOrders;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnCreate;
        private Button btnReturn;
        private DataGridViewTextBoxColumn colImportId;
        private DataGridViewTextBoxColumn colSupplier;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colItems;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colReturnStatus;
        private DataGridViewTextBoxColumn colCreatedBy;
        private DataGridViewTextBoxColumn colAction;
    }
}
