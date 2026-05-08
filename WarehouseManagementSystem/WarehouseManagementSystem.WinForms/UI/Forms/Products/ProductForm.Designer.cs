namespace WarehouseManagementSystem.WinForms.UI.Forms.Products
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
			label1 = new Label();
			searchTB = new TextBox();
			searchBtn = new Button();
			categoryCB = new ComboBox();
			dataGridView1 = new DataGridView();
			addproductBtn = new Button();

			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();

			// label1
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(51, 51, 51);
			label1.Location = new Point(32, 25);
			label1.Name = "label1";
			label1.Size = new Size(110, 30);
			label1.TabIndex = 0;
			label1.Text = "Products";

			// searchTB
			searchTB.Location = new Point(37, 70);
			searchTB.Name = "searchTB";
			searchTB.Size = new Size(340, 28);
			searchTB.TabIndex = 1;
			searchTB.Font = new Font("Segoe UI", 11F);
			searchTB.PlaceholderText = "Search by name or code...";

			// searchBtn
			searchBtn.Location = new Point(385, 70);
			searchBtn.Name = "searchBtn";
			searchBtn.Size = new Size(40, 28);
			searchBtn.TabIndex = 2;
			searchBtn.Text = "🔍";
			searchBtn.Font = new Font("Segoe UI", 11F);
			searchBtn.BackColor = Color.WhiteSmoke;
			searchBtn.FlatStyle = FlatStyle.Flat;

			// categoryCB
			categoryCB.FormattingEnabled = true;
			categoryCB.Location = new Point(440, 70);
			categoryCB.Name = "categoryCB";
			categoryCB.Size = new Size(180, 28);
			categoryCB.TabIndex = 3;
			categoryCB.Font = new Font("Segoe UI", 11F);

			// addproductBtn
			addproductBtn.Location = new Point(540, 20);
			addproductBtn.Name = "addproductBtn";
			addproductBtn.Size = new Size(180, 36);
			addproductBtn.TabIndex = 5;
			addproductBtn.Text = "+ Add Product";
			addproductBtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			addproductBtn.BackColor = Color.FromArgb(0, 123, 255);
			addproductBtn.ForeColor = Color.White;
			addproductBtn.FlatStyle = FlatStyle.Flat;

			// dataGridView1
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(37, 120);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(683, 350);
			dataGridView1.TabIndex = 4;
			dataGridView1.Font = new Font("Segoe UI", 11F);
			dataGridView1.BackgroundColor = Color.White;
			dataGridView1.EnableHeadersVisualStyles = false;
			dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
			dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			dataGridView1.RowTemplate.Height = 32;

			// Add Actions column (Edit/Delete)
			var actionsCol = new DataGridViewButtonColumn();
			actionsCol.Name = "Actions";
			actionsCol.HeaderText = "Actions";
			actionsCol.Text = "✏️ / 🗑️";
			actionsCol.UseColumnTextForButtonValue = true;
			actionsCol.Width = 90;
			if (!dataGridView1.Columns.Contains("Actions"))
			{
				dataGridView1.Columns.Add(actionsCol);
			}

			// ProductForm
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(addproductBtn);
			Controls.Add(dataGridView1);
			Controls.Add(categoryCB);
			Controls.Add(searchBtn);
			Controls.Add(searchTB);
			Controls.Add(label1);
			Name = "ProductForm";
			Size = new Size(760, 500);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox searchTB;
		private Button searchBtn;
		private ComboBox categoryCB;
		private DataGridView dataGridView1;
		private Button addproductBtn;
	}
}
