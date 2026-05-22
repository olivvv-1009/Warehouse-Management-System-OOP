namespace WarehouseManagementSystem.WinForms.UI.Forms.Products
{
	partial class ProductForm
	{
		
		private System.ComponentModel.IContainer components = null;

		
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Component Designer generated code


        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            searchTB = new TextBox();
            searchBtn = new Button();
            categoryCB = new ComboBox();
            dataGridView1 = new DataGridView();
            addproductBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 51);
            label1.TabIndex = 0;
            label1.Text = "Products";
            // 
            // searchTB
            // 
            searchTB.Dock = DockStyle.Fill;
            searchTB.Font = new Font("Segoe UI", 11F);
            searchTB.Location = new Point(3, 4);
            searchTB.Margin = new Padding(3, 4, 3, 4);
            searchTB.Name = "searchTB";
            searchTB.PlaceholderText = "Search by name or code...";
            searchTB.Size = new Size(390, 32);
            searchTB.TabIndex = 1;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.WhiteSmoke;
            searchBtn.Dock = DockStyle.Fill;
            searchBtn.FlatStyle = FlatStyle.Flat;
            searchBtn.Font = new Font("Segoe UI", 11F);
            searchBtn.Location = new Point(399, 4);
            searchBtn.Margin = new Padding(3, 4, 3, 4);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(45, 34);
            searchBtn.TabIndex = 2;
            searchBtn.Text = "🔍";
            searchBtn.UseVisualStyleBackColor = false;
            // 
            // categoryCB
            // 
            categoryCB.Dock = DockStyle.Fill;
            categoryCB.Font = new Font("Segoe UI", 11F);
            categoryCB.FormattingEnabled = true;
            categoryCB.Location = new Point(450, 4);
            categoryCB.Margin = new Padding(3, 4, 3, 4);
            categoryCB.Name = "categoryCB";
            categoryCB.Size = new Size(390, 33);
            categoryCB.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new Font("Segoe UI", 11F);
            dataGridView1.Location = new Point(13, 119);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(843, 360);
            dataGridView1.TabIndex = 4;
            // 
            // addproductBtn
            // 
            addproductBtn.BackColor = Color.FromArgb(0, 123, 255);
            addproductBtn.Dock = DockStyle.Fill;
            addproductBtn.FlatStyle = FlatStyle.Flat;
            addproductBtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            addproductBtn.ForeColor = Color.White;
            addproductBtn.Location = new Point(677, 4);
            addproductBtn.Margin = new Padding(3, 4, 3, 4);
            addproductBtn.Name = "addproductBtn";
            addproductBtn.Size = new Size(163, 43);
            addproductBtn.TabIndex = 5;
            addproductBtn.Text = "+ Add Product";
            addproductBtn.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(869, 493);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(searchBtn, 1, 0);
            tableLayoutPanel2.Controls.Add(categoryCB, 2, 0);
            tableLayoutPanel2.Controls.Add(searchTB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(13, 70);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(843, 42);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 169F));
            tableLayoutPanel3.Controls.Add(addproductBtn, 1, 0);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(13, 13);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(843, 51);
            tableLayoutPanel3.TabIndex = 8;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductForm";
            Size = new Size(869, 493);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
		private TextBox searchTB;
		private Button searchBtn;
		private ComboBox categoryCB;
		private DataGridView dataGridView1;
		private Button addproductBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
    }
}
