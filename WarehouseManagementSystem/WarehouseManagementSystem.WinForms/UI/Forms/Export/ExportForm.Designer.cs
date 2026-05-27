namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    partial class ExportForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            btnCreateExport = new Button();
            dgvExportOrders = new DataGridView();
            InvoiceId = new DataGridViewTextBoxColumn();
            Destination = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Items = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            CreatedBy = new DataGridViewTextBoxColumn();
            Action = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExportOrders).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15, 15, 15, 15);
            panel1.Size = new Size(698, 434);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvExportOrders, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(668, 404);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.73107F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.26893F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(btnCreateExport, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(662, 45);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(455, 45);
            label1.TabIndex = 0;
            label1.Text = "Export Orders";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCreateExport
            // 
            btnCreateExport.BackColor = Color.Tomato;
            btnCreateExport.Dock = DockStyle.Fill;
            btnCreateExport.ForeColor = Color.White;
            btnCreateExport.Location = new Point(464, 3);
            btnCreateExport.Name = "btnCreateExport";
            btnCreateExport.Size = new Size(195, 39);
            btnCreateExport.TabIndex = 2;
            btnCreateExport.Text = "Create Export Invoice";
            btnCreateExport.UseVisualStyleBackColor = false;
            btnCreateExport.Click += btnCreateExportInvoice_Click;
            // 
            // dgvExportOrders
            // 
            dgvExportOrders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 192, 192);
            dgvExportOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvExportOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExportOrders.BackgroundColor = Color.White;
            dgvExportOrders.ColumnHeadersHeight = 34;
            dgvExportOrders.Columns.AddRange(new DataGridViewColumn[] { InvoiceId, Destination, Date, Items, Status, CreatedBy, Action });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Menu;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvExportOrders.DefaultCellStyle = dataGridViewCellStyle2;
            dgvExportOrders.Dock = DockStyle.Top;
            dgvExportOrders.Location = new Point(3, 54);
            dgvExportOrders.Name = "dgvExportOrders";
            dgvExportOrders.ReadOnly = true;
            dgvExportOrders.RowHeadersVisible = false;
            dgvExportOrders.RowHeadersWidth = 51;
            dgvExportOrders.Size = new Size(662, 346);
            dgvExportOrders.TabIndex = 2;
            // 
            // InvoiceId
            // 
            InvoiceId.FillWeight = 90F;
            InvoiceId.HeaderText = "Invoice ID";
            InvoiceId.MinimumWidth = 8;
            InvoiceId.Name = "InvoiceId";
            InvoiceId.ReadOnly = true;
            // 
            // Destination
            // 
            Destination.HeaderText = "Destination";
            Destination.MinimumWidth = 8;
            Destination.Name = "Destination";
            Destination.ReadOnly = true;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.MinimumWidth = 8;
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // Items
            // 
            Items.HeaderText = "Items";
            Items.MinimumWidth = 8;
            Items.Name = "Items";
            Items.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // CreatedBy
            // 
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MinimumWidth = 8;
            CreatedBy.Name = "CreatedBy";
            CreatedBy.ReadOnly = true;
            // 
            // Action
            // 
            Action.HeaderText = "Actions";
            Action.MinimumWidth = 8;
            Action.Name = "Action";
            Action.ReadOnly = true;
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ExportForm";
            Size = new Size(698, 434);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExportOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private DataGridView dgvExportOrders;
        private Button btnCreateExport;
        private DataGridViewTextBoxColumn InvoiceId;
        private DataGridViewTextBoxColumn Destination;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Items;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn CreatedBy;
        private DataGridViewTextBoxColumn Action;
    }
}
