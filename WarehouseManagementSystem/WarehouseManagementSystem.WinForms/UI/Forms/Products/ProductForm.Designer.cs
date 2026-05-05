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
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(32, 25);
			label1.Name = "label1";
			label1.Size = new Size(67, 15);
			label1.TabIndex = 0;
			label1.Text = "PRODUCTS";
			// 
			// searchTB
			// 
			searchTB.Location = new Point(37, 60);
			searchTB.Name = "searchTB";
			searchTB.Size = new Size(361, 23);
			searchTB.TabIndex = 1;
			// 
			// searchBtn
			// 
			searchBtn.Location = new Point(421, 60);
			searchBtn.Name = "searchBtn";
			searchBtn.Size = new Size(75, 23);
			searchBtn.TabIndex = 2;
			searchBtn.Text = "Search";
			searchBtn.UseVisualStyleBackColor = true;
			// 
			// categoryCB
			// 
			categoryCB.FormattingEnabled = true;
			categoryCB.Location = new Point(502, 61);
			categoryCB.Name = "categoryCB";
			categoryCB.Size = new Size(121, 23);
			categoryCB.TabIndex = 3;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(40, 115);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(583, 287);
			dataGridView1.TabIndex = 4;
			// 
			// addproductBtn
			// 
			addproductBtn.Location = new Point(502, 17);
			addproductBtn.Name = "addproductBtn";
			addproductBtn.Size = new Size(121, 23);
			addproductBtn.TabIndex = 5;
			addproductBtn.Text = "Add Product";
			addproductBtn.UseVisualStyleBackColor = true;
			addproductBtn.Click += addproductBtn_Click;
			// 
			// ProductForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(addproductBtn);
			Controls.Add(dataGridView1);
			Controls.Add(categoryCB);
			Controls.Add(searchBtn);
			Controls.Add(searchTB);
			Controls.Add(label1);
			Name = "ProductForm";
			Size = new Size(638, 417);
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
