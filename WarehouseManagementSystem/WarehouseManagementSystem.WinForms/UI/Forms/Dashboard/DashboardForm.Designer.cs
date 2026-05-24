namespace WarehouseManagementSystem.WinForms.UI.Forms.Dashboard
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pnlInventoryValue = new Panel();
            lblInventoryValue = new Label();
            label4 = new Label();
            pnlLowStock = new Panel();
            lblLowStockValue = new Label();
            label5 = new Label();
            pnlTotalProducts = new Panel();
            lblTotalProductsValue = new Label();
            label2 = new Label();
            pnlTotalInventory = new Panel();
            lblTotalInventoryValue = new Label();
            label3 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel7 = new Panel();
            chartCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel6 = new Panel();
            chartImportExport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel9 = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            dgvTransactions = new DataGridView();
            panel3 = new Panel();
            label9 = new Label();
            panel8 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            dgvAlerts = new DataGridView();
            panel2 = new Panel();
            label8 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlInventoryValue.SuspendLayout();
            pnlLowStock.SuspendLayout();
            pnlTotalProducts.SuspendLayout();
            pnlTotalInventory.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCategory).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartImportExport).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 106F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 348F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tableLayoutPanel1.Size = new Size(1421, 719);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 341F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 364F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 385F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            tableLayoutPanel2.Controls.Add(pnlInventoryValue, 3, 0);
            tableLayoutPanel2.Controls.Add(pnlLowStock, 2, 0);
            tableLayoutPanel2.Controls.Add(pnlTotalProducts, 0, 0);
            tableLayoutPanel2.Controls.Add(pnlTotalInventory, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1415, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pnlInventoryValue
            // 
            pnlInventoryValue.BackColor = Color.White;
            pnlInventoryValue.Controls.Add(lblInventoryValue);
            pnlInventoryValue.Controls.Add(label4);
            pnlInventoryValue.Dock = DockStyle.Fill;
            pnlInventoryValue.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlInventoryValue.Location = new Point(1093, 3);
            pnlInventoryValue.Name = "pnlInventoryValue";
            pnlInventoryValue.Size = new Size(319, 94);
            pnlInventoryValue.TabIndex = 3;
            // 
            // lblInventoryValue
            // 
            lblInventoryValue.BackColor = Color.Gold;
            lblInventoryValue.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInventoryValue.ForeColor = Color.White;
            lblInventoryValue.Location = new Point(83, 51);
            lblInventoryValue.Name = "lblInventoryValue";
            lblInventoryValue.Size = new Size(135, 33);
            lblInventoryValue.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(53, 13);
            label4.Name = "label4";
            label4.Size = new Size(204, 32);
            label4.TabIndex = 3;
            label4.Text = "Inventory Value";
            // 
            // pnlLowStock
            // 
            pnlLowStock.BackColor = Color.White;
            pnlLowStock.Controls.Add(lblLowStockValue);
            pnlLowStock.Controls.Add(label5);
            pnlLowStock.Dock = DockStyle.Fill;
            pnlLowStock.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlLowStock.Location = new Point(708, 3);
            pnlLowStock.Name = "pnlLowStock";
            pnlLowStock.Size = new Size(379, 94);
            pnlLowStock.TabIndex = 2;
            // 
            // lblLowStockValue
            // 
            lblLowStockValue.BackColor = Color.Red;
            lblLowStockValue.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLowStockValue.ForeColor = Color.White;
            lblLowStockValue.Location = new Point(124, 51);
            lblLowStockValue.Name = "lblLowStockValue";
            lblLowStockValue.Size = new Size(135, 33);
            lblLowStockValue.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(86, 13);
            label5.Name = "label5";
            label5.Size = new Size(210, 32);
            label5.TabIndex = 4;
            label5.Text = "Low Stock Items";
            // 
            // pnlTotalProducts
            // 
            pnlTotalProducts.BackColor = Color.White;
            pnlTotalProducts.Controls.Add(lblTotalProductsValue);
            pnlTotalProducts.Controls.Add(label2);
            pnlTotalProducts.Dock = DockStyle.Fill;
            pnlTotalProducts.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlTotalProducts.Location = new Point(3, 3);
            pnlTotalProducts.Name = "pnlTotalProducts";
            pnlTotalProducts.Size = new Size(335, 94);
            pnlTotalProducts.TabIndex = 1;
            // 
            // lblTotalProductsValue
            // 
            lblTotalProductsValue.BackColor = Color.DodgerBlue;
            lblTotalProductsValue.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalProductsValue.ForeColor = Color.White;
            lblTotalProductsValue.Location = new Point(89, 51);
            lblTotalProductsValue.Name = "lblTotalProductsValue";
            lblTotalProductsValue.Size = new Size(135, 33);
            lblTotalProductsValue.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 13);
            label2.Name = "label2";
            label2.Size = new Size(188, 32);
            label2.TabIndex = 1;
            label2.Text = "Total Products";
            // 
            // pnlTotalInventory
            // 
            pnlTotalInventory.BackColor = Color.White;
            pnlTotalInventory.Controls.Add(lblTotalInventoryValue);
            pnlTotalInventory.Controls.Add(label3);
            pnlTotalInventory.Dock = DockStyle.Fill;
            pnlTotalInventory.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlTotalInventory.Location = new Point(344, 3);
            pnlTotalInventory.Name = "pnlTotalInventory";
            pnlTotalInventory.Size = new Size(358, 94);
            pnlTotalInventory.TabIndex = 0;
            // 
            // lblTotalInventoryValue
            // 
            lblTotalInventoryValue.BackColor = Color.LimeGreen;
            lblTotalInventoryValue.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalInventoryValue.ForeColor = Color.White;
            lblTotalInventoryValue.Location = new Point(101, 51);
            lblTotalInventoryValue.Name = "lblTotalInventoryValue";
            lblTotalInventoryValue.Size = new Size(135, 33);
            lblTotalInventoryValue.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(70, 13);
            label3.Name = "label3";
            label3.Size = new Size(198, 32);
            label3.TabIndex = 2;
            label3.Text = "Total Inventory";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel7, 1, 0);
            tableLayoutPanel3.Controls.Add(panel6, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 181);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1415, 342);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(chartCategory);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(710, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(702, 336);
            panel7.TabIndex = 2;
            // 
            // chartCategory
            // 
            chartArea1.Name = "ChartArea1";
            chartCategory.ChartAreas.Add(chartArea1);
            chartCategory.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartCategory.Legends.Add(legend1);
            chartCategory.Location = new Point(0, 0);
            chartCategory.Name = "chartCategory";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartCategory.Series.Add(series1);
            chartCategory.Size = new Size(702, 336);
            chartCategory.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(chartImportExport);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(701, 336);
            panel6.TabIndex = 1;
            // 
            // chartImportExport
            // 
            chartArea2.Name = "ChartArea1";
            chartImportExport.ChartAreas.Add(chartArea2);
            chartImportExport.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartImportExport.Legends.Add(legend2);
            chartImportExport.Location = new Point(0, 0);
            chartImportExport.Name = "chartImportExport";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartImportExport.Series.Add(series2);
            chartImportExport.Size = new Size(701, 336);
            chartImportExport.TabIndex = 6;
            chartImportExport.Text = "chart1";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(panel9, 1, 0);
            tableLayoutPanel4.Controls.Add(panel8, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 529);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(1415, 187);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(tableLayoutPanel6);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(710, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(702, 181);
            panel9.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(dgvTransactions, 0, 1);
            tableLayoutPanel6.Controls.Add(panel3, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 15.9836063F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 84.0163956F));
            tableLayoutPanel6.Size = new Size(702, 181);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Dock = DockStyle.Fill;
            dgvTransactions.Location = new Point(3, 31);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(696, 147);
            dgvTransactions.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Controls.Add(label9);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(696, 22);
            panel3.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(216, 25);
            label9.TabIndex = 8;
            label9.Text = "Recent Transactions";
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(tableLayoutPanel5);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(701, 181);
            panel8.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(dgvAlerts, 0, 1);
            tableLayoutPanel5.Controls.Add(panel2, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1654129F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 83.83459F));
            tableLayoutPanel5.Size = new Size(701, 181);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // dgvAlerts
            // 
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlerts.Dock = DockStyle.Fill;
            dgvAlerts.Location = new Point(3, 32);
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.RowHeadersWidth = 51;
            dgvAlerts.Size = new Size(695, 146);
            dgvAlerts.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(695, 23);
            panel2.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(71, 25);
            label8.TabIndex = 6;
            label8.Text = "Alerts";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1415, 66);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 13);
            label1.Name = "label1";
            label1.Size = new Size(178, 38);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "DashboardForm";
            Size = new Size(1421, 719);
            Load += DashboardForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlInventoryValue.ResumeLayout(false);
            pnlInventoryValue.PerformLayout();
            pnlLowStock.ResumeLayout(false);
            pnlLowStock.PerformLayout();
            pnlTotalProducts.ResumeLayout(false);
            pnlTotalProducts.PerformLayout();
            pnlTotalInventory.ResumeLayout(false);
            pnlTotalInventory.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCategory).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartImportExport).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            panel9.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel8.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlInventoryValue;
        private Panel pnlLowStock;
        private Panel pnlTotalProducts;
        private Panel pnlTotalInventory;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel7;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel9;
        private Panel panel8;
        private Panel panel1;
        private Label label1;
        private Label lblInventoryValue;
        private Label label4;
        private Label lblLowStockValue;
        private Label label5;
        private Label lblTotalProductsValue;
        private Label label2;
        private Label lblTotalInventoryValue;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategory;
        private DataGridView dgvAlerts;
        private Label label8;
        private DataGridView dgvTransactions;
        private Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartImportExport;
        private TableLayoutPanel tableLayoutPanel6;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel2;
    }
}
