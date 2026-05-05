namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    partial class AddProductForm
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

		private void InitializeComponent()
		{
			lblTitle = new Label();
			lblProductName = new Label();
			txtProductName = new TextBox();
			lblCategory = new Label();
			lblMinStock = new Label();
			txtMinStock = new TextBox();
			pnlNote = new Panel();
			lblNote = new Label();
			btnCancel = new Button();
			btnAdd = new Button();
			txtCategory = new ComboBox();
			pnlNote.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			lblTitle.Location = new Point(24, 18);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(171, 25);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Add New Product";
			// 
			// lblProductName
			// 
			lblProductName.AutoSize = true;
			lblProductName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblProductName.Location = new Point(24, 60);
			lblProductName.Name = "lblProductName";
			lblProductName.Size = new Size(116, 19);
			lblProductName.TabIndex = 1;
			lblProductName.Text = "Product Name *";
			// 
			// txtProductName
			// 
			txtProductName.Font = new Font("Segoe UI", 10F);
			txtProductName.Location = new Point(24, 82);
			txtProductName.Name = "txtProductName";
			txtProductName.Size = new Size(480, 25);
			txtProductName.TabIndex = 2;
			// 
			// lblCategory
			// 
			lblCategory.AutoSize = true;
			lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblCategory.Location = new Point(24, 120);
			lblCategory.Name = "lblCategory";
			lblCategory.Size = new Size(82, 19);
			lblCategory.TabIndex = 3;
			lblCategory.Text = "Category *";
			// 
			// lblMinStock
			// 
			lblMinStock.AutoSize = true;
			lblMinStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblMinStock.Location = new Point(24, 180);
			lblMinStock.Name = "lblMinStock";
			lblMinStock.Size = new Size(123, 19);
			lblMinStock.TabIndex = 5;
			lblMinStock.Text = "Minimum Stock *";
			// 
			// txtMinStock
			// 
			txtMinStock.Font = new Font("Segoe UI", 10F);
			txtMinStock.Location = new Point(24, 202);
			txtMinStock.Name = "txtMinStock";
			txtMinStock.Size = new Size(480, 25);
			txtMinStock.TabIndex = 6;
			txtMinStock.Text = "10";
			// 
			// pnlNote
			// 
			pnlNote.BackColor = Color.FromArgb(230, 242, 255);
			pnlNote.Controls.Add(lblNote);
			pnlNote.Location = new Point(24, 242);
			pnlNote.Name = "pnlNote";
			pnlNote.Size = new Size(480, 60);
			pnlNote.TabIndex = 7;
			// 
			// lblNote
			// 
			lblNote.AutoSize = true;
			lblNote.Font = new Font("Segoe UI", 9F);
			lblNote.ForeColor = Color.FromArgb(33, 64, 95);
			lblNote.Location = new Point(10, 10);
			lblNote.MaximumSize = new Size(460, 0);
			lblNote.Name = "lblNote";
			lblNote.Size = new Size(449, 30);
			lblNote.TabIndex = 0;
			lblNote.Text = "Note: Average Import Price is automatically calculated from import orders. Supplier information is linked through import batches, not directly to products.";
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Font = new Font("Segoe UI", 10F);
			btnCancel.Location = new Point(270, 320);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(100, 35);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			btnAdd.Font = new Font("Segoe UI", 10F);
			btnAdd.Location = new Point(404, 320);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(100, 35);
			btnAdd.TabIndex = 9;
			btnAdd.Text = "Add Product";
			btnAdd.UseVisualStyleBackColor = true;
			// 
			// txtCategory
			// 
			txtCategory.FormattingEnabled = true;
			txtCategory.Location = new Point(25, 148);
			txtCategory.Name = "txtCategory";
			txtCategory.Size = new Size(479, 23);
			txtCategory.TabIndex = 10;
			// 
			// AddProductForm
			// 
			AcceptButton = btnAdd;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(530, 380);
			Controls.Add(txtCategory);
			Controls.Add(lblTitle);
			Controls.Add(lblProductName);
			Controls.Add(txtProductName);
			Controls.Add(lblCategory);
			Controls.Add(lblMinStock);
			Controls.Add(txtMinStock);
			Controls.Add(pnlNote);
			Controls.Add(btnCancel);
			Controls.Add(btnAdd);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AddProductForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Add New Product";
			pnlNote.ResumeLayout(false);
			pnlNote.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.TextBox txtMinStock;
        private System.Windows.Forms.Panel pnlNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
		private ComboBox txtCategory;
	}
}
