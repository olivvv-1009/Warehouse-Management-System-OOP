#nullable enable
namespace WarehouseManagementSystem.WinForms.UI.Forms.Export
{
    partial class CreateExportInvoice
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panelMain = new Panel();
            lblTitle = new Label();
            tableTop = new TableLayoutPanel();
            lblDestLabel = new Label();
            lblDateLabel = new Label();
            lblEmpLabel = new Label();
            txtDestination = new TextBox();
            dtpDate = new DateTimePicker();
            lblEmployeeValue = new Label();
            panelProductsHeader = new Panel();
            label5 = new Label();
            btnAddProduct = new Button();
            dgvProducts = new DataGridView();
            colProduct = new DataGridViewComboBoxColumn();
            colAvailable = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colFifo = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            panelFifoNote = new Panel();
            lblFifoTitle = new Label();
            lblFifoDesc = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSaveDraft = new Button();
            btnComplete = new Button();
            panelMain.SuspendLayout();
            tableTop.SuspendLayout();
            panelProductsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelFifoNote.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(tableTop);
            panelMain.Controls.Add(panelProductsHeader);
            panelMain.Controls.Add(dgvProducts);
            panelMain.Controls.Add(panelFifoNote);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(35, 25, 35, 20);
            panelMain.Size = new Size(970, 662);
            panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(20, 20, 20);
            lblTitle.Location = new Point(35, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(342, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Export Invoice";
            // 
            // tableTop
            // 
            tableTop.ColumnCount = 3;
            tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableTop.Controls.Add(lblDestLabel, 0, 0);
            tableTop.Controls.Add(lblDateLabel, 1, 0);
            tableTop.Controls.Add(lblEmpLabel, 2, 0);
            tableTop.Controls.Add(txtDestination, 0, 1);
            tableTop.Controls.Add(dtpDate, 1, 1);
            tableTop.Controls.Add(lblEmployeeValue, 2, 1);
            tableTop.Location = new Point(35, 82);
            tableTop.Margin = new Padding(4);
            tableTop.Name = "tableTop";
            tableTop.RowCount = 2;
            tableTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableTop.Size = new Size(900, 80);
            tableTop.TabIndex = 1;
            // 
            // lblDestLabel
            // 
            lblDestLabel.Dock = DockStyle.Fill;
            lblDestLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDestLabel.ForeColor = Color.FromArgb(50, 50, 50);
            lblDestLabel.Location = new Point(4, 0);
            lblDestLabel.Margin = new Padding(4, 0, 4, 0);
            lblDestLabel.Name = "lblDestLabel";
            lblDestLabel.Size = new Size(316, 32);
            lblDestLabel.TabIndex = 0;
            lblDestLabel.Text = "Destination *";
            lblDestLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblDateLabel
            // 
            lblDateLabel.Dock = DockStyle.Fill;
            lblDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateLabel.ForeColor = Color.FromArgb(50, 50, 50);
            lblDateLabel.Location = new Point(328, 0);
            lblDateLabel.Margin = new Padding(4, 0, 4, 0);
            lblDateLabel.Name = "lblDateLabel";
            lblDateLabel.Size = new Size(280, 32);
            lblDateLabel.TabIndex = 1;
            lblDateLabel.Text = "Date *";
            lblDateLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblEmpLabel
            // 
            lblEmpLabel.Dock = DockStyle.Fill;
            lblEmpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpLabel.ForeColor = Color.FromArgb(50, 50, 50);
            lblEmpLabel.Location = new Point(616, 0);
            lblEmpLabel.Margin = new Padding(4, 0, 4, 0);
            lblEmpLabel.Name = "lblEmpLabel";
            lblEmpLabel.Size = new Size(280, 32);
            lblEmpLabel.TabIndex = 2;
            lblEmpLabel.Text = "Created By Employee";
            lblEmpLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtDestination
            // 
            txtDestination.BorderStyle = BorderStyle.FixedSingle;
            txtDestination.Dock = DockStyle.Fill;
            txtDestination.Font = new Font("Segoe UI", 10F);
            txtDestination.Location = new Point(0, 34);
            txtDestination.Margin = new Padding(0, 2, 18, 0);
            txtDestination.Name = "txtDestination";
            txtDestination.PlaceholderText = "e.g., Customer A - HCM";
            txtDestination.Size = new Size(306, 34);
            txtDestination.TabIndex = 3;
            // 
            // dtpDate
            // 
            dtpDate.Dock = DockStyle.Fill;
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(324, 34);
            dtpDate.Margin = new Padding(0, 2, 18, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(270, 34);
            dtpDate.TabIndex = 4;
            // 
            // lblEmployeeValue
            // 
            lblEmployeeValue.Dock = DockStyle.Fill;
            lblEmployeeValue.Font = new Font("Segoe UI", 10F);
            lblEmployeeValue.ForeColor = Color.FromArgb(100, 100, 100);
            lblEmployeeValue.Location = new Point(612, 34);
            lblEmployeeValue.Margin = new Padding(0, 2, 0, 0);
            lblEmployeeValue.Name = "lblEmployeeValue";
            lblEmployeeValue.Size = new Size(288, 46);
            lblEmployeeValue.TabIndex = 5;
            lblEmployeeValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelProductsHeader
            // 
            panelProductsHeader.BackColor = Color.Transparent;
            panelProductsHeader.Controls.Add(label5);
            panelProductsHeader.Controls.Add(btnAddProduct);
            panelProductsHeader.Location = new Point(35, 180);
            panelProductsHeader.Margin = new Padding(4);
            panelProductsHeader.Name = "panelProductsHeader";
            panelProductsHeader.Size = new Size(900, 45);
            panelProductsHeader.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(50, 50, 50);
            label5.Location = new Point(0, 10);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(100, 25);
            label5.TabIndex = 0;
            label5.Text = "Products *";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduct.BackColor = Color.White;
            btnAddProduct.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddProduct.ForeColor = Color.FromArgb(37, 99, 235);
            btnAddProduct.Location = new Point(738, 4);
            btnAddProduct.Margin = new Padding(4);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(162, 38);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProduct, colAvailable, colQuantity, colFifo, colRemove });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle6;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.FromArgb(230, 230, 230);
            dgvProducts.Location = new Point(35, 230);
            dgvProducts.Margin = new Padding(4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.RowTemplate.Height = 48;
            dgvProducts.ScrollBars = ScrollBars.Vertical;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(900, 250);
            dgvProducts.TabIndex = 3;
            // 
            // colProduct
            // 
            colProduct.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colProduct.FillWeight = 220F;
            colProduct.FlatStyle = FlatStyle.Flat;
            colProduct.HeaderText = "Product";
            colProduct.MinimumWidth = 8;
            colProduct.Name = "colProduct";
            // 
            // colAvailable
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            colAvailable.DefaultCellStyle = dataGridViewCellStyle2;
            colAvailable.FillWeight = 80F;
            colAvailable.HeaderText = "Available";
            colAvailable.MinimumWidth = 8;
            colAvailable.Name = "colAvailable";
            colAvailable.ReadOnly = true;
            // 
            // colQuantity
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            colQuantity.FillWeight = 80F;
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 8;
            colQuantity.Name = "colQuantity";
            // 
            // colFifo
            // 
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(37, 99, 235);
            colFifo.DefaultCellStyle = dataGridViewCellStyle4;
            colFifo.FillWeight = 160F;
            colFifo.HeaderText = "FIFO Allocation";
            colFifo.MinimumWidth = 8;
            colFifo.Name = "colFifo";
            colFifo.ReadOnly = true;
            // 
            // colRemove
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(185, 28, 28);
            colRemove.DefaultCellStyle = dataGridViewCellStyle5;
            colRemove.FillWeight = 36F;
            colRemove.FlatStyle = FlatStyle.Flat;
            colRemove.HeaderText = "";
            colRemove.MinimumWidth = 8;
            colRemove.Name = "colRemove";
            colRemove.Text = "✕";
            colRemove.UseColumnTextForButtonValue = true;
            // 
            // panelFifoNote
            // 
            panelFifoNote.BackColor = Color.FromArgb(239, 246, 255);
            panelFifoNote.Controls.Add(lblFifoTitle);
            panelFifoNote.Controls.Add(lblFifoDesc);
            panelFifoNote.Location = new Point(35, 495);
            panelFifoNote.Margin = new Padding(4);
            panelFifoNote.Name = "panelFifoNote";
            panelFifoNote.Padding = new Padding(18, 10, 18, 10);
            panelFifoNote.Size = new Size(900, 72);
            panelFifoNote.TabIndex = 4;
            // 
            // lblFifoTitle
            // 
            lblFifoTitle.AutoSize = true;
            lblFifoTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFifoTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblFifoTitle.Location = new Point(18, 12);
            lblFifoTitle.Margin = new Padding(4, 0, 4, 0);
            lblFifoTitle.Name = "lblFifoTitle";
            lblFifoTitle.Size = new Size(214, 25);
            lblFifoTitle.TabIndex = 0;
            lblFifoTitle.Text = "FIFO (First-In-First-Out):";
            // 
            // lblFifoDesc
            // 
            lblFifoDesc.AutoSize = true;
            lblFifoDesc.Font = new Font("Segoe UI", 9F);
            lblFifoDesc.ForeColor = Color.FromArgb(37, 99, 235);
            lblFifoDesc.Location = new Point(18, 38);
            lblFifoDesc.Margin = new Padding(4, 0, 4, 0);
            lblFifoDesc.Name = "lblFifoDesc";
            lblFifoDesc.Size = new Size(556, 25);
            lblFifoDesc.TabIndex = 1;
            lblFifoDesc.Text = "Products will be automatically allocated from the oldest batches first.";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSaveDraft);
            panelButtons.Controls.Add(btnComplete);
            panelButtons.Location = new Point(35, 585);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(900, 60);
            panelButtons.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.5F);
            btnCancel.Location = new Point(482, 5);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(138, 50);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.BackColor = Color.White;
            btnSaveDraft.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnSaveDraft.FlatStyle = FlatStyle.Flat;
            btnSaveDraft.Font = new Font("Segoe UI", 9.5F);
            btnSaveDraft.Location = new Point(625, 5);
            btnSaveDraft.Margin = new Padding(4);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(138, 50);
            btnSaveDraft.TabIndex = 1;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = false;
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.FromArgb(220, 53, 69);
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnComplete.ForeColor = Color.White;
            btnComplete.Location = new Point(768, 5);
            btnComplete.Margin = new Padding(4);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(138, 50);
            btnComplete.TabIndex = 2;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = false;
            // 
            // CreateExportInvoice
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 662);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateExportInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Export Invoice";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            tableTop.ResumeLayout(false);
            tableTop.PerformLayout();
            panelProductsHeader.ResumeLayout(false);
            panelProductsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelFifoNote.ResumeLayout(false);
            panelFifoNote.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ── Fields ───────────────────────────────────────────────
        private System.Windows.Forms.Panel panelMain = null!;
        private System.Windows.Forms.Label lblTitle = null!;
        private System.Windows.Forms.TableLayoutPanel tableTop = null!;
        private System.Windows.Forms.Label lblDestLabel = null!;
        private System.Windows.Forms.Label lblDateLabel = null!;
        private System.Windows.Forms.Label lblEmpLabel = null!;
        private System.Windows.Forms.TextBox txtDestination = null!;
        private System.Windows.Forms.DateTimePicker dtpDate = null!;
        private System.Windows.Forms.Label lblEmployeeValue = null!;
        private System.Windows.Forms.Panel panelProductsHeader = null!;
        private System.Windows.Forms.Label label5 = null!;
        private System.Windows.Forms.Button btnAddProduct = null!;
        private System.Windows.Forms.DataGridView dgvProducts = null!;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduct = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFifo = null!;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove = null!;
        private System.Windows.Forms.Panel panelFifoNote = null!;
        private System.Windows.Forms.Label lblFifoTitle = null!;
        private System.Windows.Forms.Label lblFifoDesc = null!;
        private System.Windows.Forms.Panel panelButtons = null!;
        private System.Windows.Forms.Button btnCancel = null!;
        private System.Windows.Forms.Button btnSaveDraft = null!;
        private System.Windows.Forms.Button btnComplete = null!;
    }
}
