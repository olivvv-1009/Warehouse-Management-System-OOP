namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    partial class ProductForm
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
            this.labelTitle = new System.Windows.Forms.Label();
			this.panelTop = new System.Windows.Forms.Panel();
			this.btnAddProduct = new System.Windows.Forms.Button();
			this.panelSearch = new System.Windows.Forms.Panel();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnFilter = new System.Windows.Forms.Button();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.dgvProducts = new System.Windows.Forms.DataGridView();

			this.panelTop.SuspendLayout();
			this.panelSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
			SuspendLayout();

			// labelTitle
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelTitle.Location = new System.Drawing.Point(20, 15);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Text = "Products";

            // panelTop
			this.panelTop.Controls.Add(this.labelTitle);
			this.panelTop.Controls.Add(this.btnAddProduct);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Height = 60;
			this.panelTop.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.TabIndex = 0;

            // btnAddProduct
			this.btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
			this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnAddProduct.ForeColor = System.Drawing.Color.White;
			this.btnAddProduct.Location = new System.Drawing.Point(700, 12); // Adjusted for typical form width
			this.btnAddProduct.Name = "btnAddProduct";
			this.btnAddProduct.Size = new System.Drawing.Size(130, 35);
			this.btnAddProduct.TabIndex = 1;
			this.btnAddProduct.Text = "+  Add Product";
			this.btnAddProduct.UseVisualStyleBackColor = false;

            // panelSearch
			this.panelSearch.Controls.Add(this.txtSearch);
			this.panelSearch.Controls.Add(this.btnFilter);
			this.panelSearch.Controls.Add(this.cmbCategory);
			this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSearch.Height = 50;
			this.panelSearch.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
			this.panelSearch.BackColor = System.Drawing.Color.White;
			this.panelSearch.Location = new System.Drawing.Point(0, 60);
			this.panelSearch.Name = "panelSearch";
			this.panelSearch.TabIndex = 1;

            // txtSearch
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtSearch.PlaceholderText = "Search by name or code...";
			this.txtSearch.Location = new System.Drawing.Point(0, 10);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(300, 25);
			this.txtSearch.TabIndex = 0;

            // btnFilter
			this.btnFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnFilter.Text = "🔍"; // Unicode for search icon
			this.btnFilter.Location = new System.Drawing.Point(310, 10);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(35, 25);
			this.btnFilter.TabIndex = 1;

            // cmbCategory
			this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategory.Location = new System.Drawing.Point(600, 10); // Adjusted for typical form width
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(160, 25);
			this.cmbCategory.TabIndex = 2;
			this.cmbCategory.Items.AddRange(new object[] { "All Categories", "Electronics" });


			// dgvProducts
			this.dgvProducts.AllowUserToAddRows = false;
			this.dgvProducts.AllowUserToDeleteRows = false;
			this.dgvProducts.AllowUserToResizeRows = false;
			this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
			this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProducts.Location = new System.Drawing.Point(0, 110);
			this.dgvProducts.MultiSelect = false;
			this.dgvProducts.ReadOnly = true;
			this.dgvProducts.RowHeadersVisible = false;
			this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvProducts.Name = "dgvProducts";
			this.dgvProducts.TabIndex = 3;

			// Add columns only if not in design mode
			if (!System.ComponentModel.LicenseManager.UsageMode.Equals(System.ComponentModel.LicenseUsageMode.Designtime))
			{
				if (this.dgvProducts.Columns.Count == 0)
				{
					this.dgvProducts.Columns.Add("ProductCode", "Product Code");
					this.dgvProducts.Columns.Add("Name", "Name");
					this.dgvProducts.Columns.Add("Category", "Category");
					this.dgvProducts.Columns.Add("AvgImportPrice", "Avg Import Price");
					this.dgvProducts.Columns.Add("MinStock", "Min Stock");
					this.dgvProducts.Columns.Add("Status", "Status");
					var actionsCol = new System.Windows.Forms.DataGridViewButtonColumn();
					actionsCol.Name = "Actions";
					actionsCol.HeaderText = "Actions";
					actionsCol.Text = "Edit/Delete";
					actionsCol.UseColumnTextForButtonValue = true;
					this.dgvProducts.Columns.Add(actionsCol);
				}
			}

            // ProductForm (UserControl)
			this.Controls.Add(this.dgvProducts);
			this.Controls.Add(this.panelSearch);
			this.Controls.Add(this.panelTop);
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ProductForm";
			this.Size = new System.Drawing.Size(850, 500);
			this.Load += ProductForm_Load;

			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelSearch.ResumeLayout(false);
			this.panelSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
			ResumeLayout(false);
		}

        #endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Button btnAddProduct;
		private System.Windows.Forms.Panel panelSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.DataGridView dgvProducts;
	}
}
