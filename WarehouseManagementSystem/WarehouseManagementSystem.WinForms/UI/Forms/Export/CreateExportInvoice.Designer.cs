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
            panelMain = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            tableTop = new System.Windows.Forms.TableLayoutPanel();
            lblDestLabel = new System.Windows.Forms.Label();
            lblDateLabel = new System.Windows.Forms.Label();
            lblEmpLabel = new System.Windows.Forms.Label();
            txtDestination = new System.Windows.Forms.ComboBox();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            lblEmployeeValue = new System.Windows.Forms.Label();
            panelProductsHeader = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            btnAddProduct = new System.Windows.Forms.Button();
            dgvProducts = new System.Windows.Forms.DataGridView();
            colProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            colAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFifo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            panelFifoNote = new System.Windows.Forms.Panel();
            lblFifoTitle = new System.Windows.Forms.Label();
            lblFifoDesc = new System.Windows.Forms.Label();
            panelButtons = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();
            btnSaveDraft = new System.Windows.Forms.Button();
            btnComplete = new System.Windows.Forms.Button();

            panelMain.SuspendLayout();
            panelProductsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelFifoNote.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();

            // ── panelMain ────────────────────────────────────────
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Padding = new System.Windows.Forms.Padding(28, 20, 28, 16);
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(tableTop);
            panelMain.Controls.Add(panelProductsHeader);
            panelMain.Controls.Add(dgvProducts);
            panelMain.Controls.Add(panelFifoNote);
            panelMain.Controls.Add(panelButtons);

            // ── Title ────────────────────────────────────────────
            lblTitle.Text = "Create Export Invoice";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(20, 20, 20);
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(28, 20);

            // ── tableTop: 3 cột (Destination | Date | Employee) ──
            tableTop.ColumnCount = 3;
            tableTop.RowCount = 2;
            tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            tableTop.Location = new System.Drawing.Point(28, 66);
            tableTop.Size = new System.Drawing.Size(720, 64);
            tableTop.Controls.Add(lblDestLabel, 0, 0);
            tableTop.Controls.Add(lblDateLabel, 1, 0);
            tableTop.Controls.Add(lblEmpLabel, 2, 0);
            tableTop.Controls.Add(txtDestination, 0, 1);
            tableTop.Controls.Add(dtpDate, 1, 1);
            tableTop.Controls.Add(lblEmployeeValue, 2, 1);

            // labels row
            lblDestLabel.Text = "Destination *";
            lblDestLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDestLabel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblDestLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDestLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            lblDateLabel.Text = "Date *";
            lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDateLabel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDateLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            lblEmpLabel.Text = "Created By Employee";
            lblEmpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEmpLabel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblEmpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            lblEmpLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            // controls row
            txtDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            txtDestination.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDestination.Margin = new System.Windows.Forms.Padding(0, 2, 14, 0);
            txtDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtDestination.Name = "txtDestination";

            dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDate.Margin = new System.Windows.Forms.Padding(0, 2, 14, 0);
            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate.Name = "dtpDate";

            lblEmployeeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            lblEmployeeValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblEmployeeValue.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            lblEmployeeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblEmployeeValue.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            lblEmployeeValue.Name = "lblEmployeeValue";

            // ── Products header ──────────────────────────────────
            panelProductsHeader.Location = new System.Drawing.Point(28, 144);
            panelProductsHeader.Size = new System.Drawing.Size(720, 36);
            panelProductsHeader.BackColor = System.Drawing.Color.Transparent;
            panelProductsHeader.Controls.Add(label5);
            panelProductsHeader.Controls.Add(btnAddProduct);

            label5.Text = "Products *";
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(0, 8);

            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnAddProduct.BackColor = System.Drawing.Color.White;
            btnAddProduct.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnAddProduct.Size = new System.Drawing.Size(130, 30);
            btnAddProduct.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            btnAddProduct.Location = new System.Drawing.Point(590, 3);
            btnAddProduct.Name = "btnAddProduct";

            // ── DataGridView ─────────────────────────────────────
            dgvProducts.Location = new System.Drawing.Point(28, 184);
            dgvProducts.Size = new System.Drawing.Size(720, 200);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.BackgroundColor = System.Drawing.Color.White;
            dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.RowTemplate.Height = 48;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvProducts.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvProducts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            dgvProducts.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvProducts.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // col: Product (combobox, rộng nhất)
            colProduct.Name = "colProduct";
            colProduct.HeaderText = "Product";
            colProduct.FillWeight = 220;
            colProduct.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            colProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // col: Available (readonly, center)
            colAvailable.Name = "colAvailable";
            colAvailable.HeaderText = "Available";
            colAvailable.FillWeight = 80;
            colAvailable.ReadOnly = true;
            colAvailable.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colAvailable.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // col: Quantity (editable, center) — user nhập số
            colQuantity.Name = "colQuantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.FillWeight = 80;
            colQuantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // col: FIFO Allocation (readonly)
            colFifo.Name = "colFifo";
            colFifo.HeaderText = "FIFO Allocation";
            colFifo.FillWeight = 160;
            colFifo.ReadOnly = true;
            colFifo.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            colFifo.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // col: Remove button
            colRemove.Name = "colRemove";
            colRemove.HeaderText = "";
            colRemove.FillWeight = 36;
            colRemove.Text = "✕";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            colRemove.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            colRemove.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colRemove.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            colRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            dgvProducts.Columns.AddRange(colProduct, colAvailable, colQuantity, colFifo, colRemove);

            // ── FIFO note ────────────────────────────────────────
            panelFifoNote.Location = new System.Drawing.Point(28, 396);
            panelFifoNote.Size = new System.Drawing.Size(720, 58);
            panelFifoNote.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            panelFifoNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            panelFifoNote.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            panelFifoNote.Controls.Add(lblFifoTitle);
            panelFifoNote.Controls.Add(lblFifoDesc);
            panelFifoNote.Name = "panelFifoNote";

            lblFifoTitle.Text = "FIFO (First-In-First-Out):";
            lblFifoTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblFifoTitle.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            lblFifoTitle.AutoSize = true;
            lblFifoTitle.Location = new System.Drawing.Point(14, 10);

            lblFifoDesc.Text = "Products will be automatically allocated from the oldest batches first.";
            lblFifoDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFifoDesc.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            lblFifoDesc.AutoSize = true;
            lblFifoDesc.Location = new System.Drawing.Point(14, 30);

            // ── Buttons ──────────────────────────────────────────
            panelButtons.Location = new System.Drawing.Point(28, 468);
            panelButtons.Size = new System.Drawing.Size(720, 48);
            panelButtons.BackColor = System.Drawing.Color.Transparent;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSaveDraft);
            panelButtons.Controls.Add(btnComplete);
            panelButtons.Name = "panelButtons";

            btnCancel.Text = "Cancel";
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnCancel.Size = new System.Drawing.Size(110, 40);
            btnCancel.Location = new System.Drawing.Point(386, 4);
            btnCancel.BackColor = System.Drawing.Color.White;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            btnCancel.Name = "btnCancel";

            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnSaveDraft.Size = new System.Drawing.Size(110, 40);
            btnSaveDraft.Location = new System.Drawing.Point(500, 4);
            btnSaveDraft.BackColor = System.Drawing.Color.White;
            btnSaveDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveDraft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            btnSaveDraft.Name = "btnSaveDraft";

            btnComplete.Text = "Complete";
            btnComplete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnComplete.Size = new System.Drawing.Size(110, 40);
            btnComplete.Location = new System.Drawing.Point(614, 4);
            btnComplete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnComplete.ForeColor = System.Drawing.Color.White;
            btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.Name = "btnComplete";

            // ── Form ─────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(776, 530);
            Controls.Add(panelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Create Export Invoice";
            Name = "CreateExportInvoice";

            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
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
        private System.Windows.Forms.ComboBox txtDestination = null!;
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
