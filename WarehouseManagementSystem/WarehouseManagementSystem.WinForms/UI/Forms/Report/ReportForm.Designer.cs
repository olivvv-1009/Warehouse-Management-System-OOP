namespace WarehouseManagementSystem.WinForms.UI.Forms.Report
{
    partial class ReportForm
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
            tlRoot = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnExport = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel4 = new Panel();
            label2 = new Label();
            cboType = new ComboBox();
            panel5 = new Panel();
            dtStart = new DateTimePicker();
            label4 = new Label();
            panel6 = new Panel();
            dtEnd = new DateTimePicker();
            label3 = new Label();
            panel3 = new Panel();
            cboCategory = new ComboBox();
            label5 = new Label();
            tlContent = new TableLayoutPanel();
            chartReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlSummary = new Panel();
            dgvReport = new DataGridView();
            tlRoot.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            tlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // tlRoot
            // 
            tlRoot.ColumnCount = 1;
            tlRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlRoot.Controls.Add(tableLayoutPanel1, 0, 0);
            tlRoot.Controls.Add(tableLayoutPanel2, 0, 1);
            tlRoot.Controls.Add(tlContent, 0, 2);
            tlRoot.Dock = DockStyle.Fill;
            tlRoot.Location = new Point(0, 0);
            tlRoot.Name = "tlRoot";
            tlRoot.RowCount = 3;
            tlRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tlRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 113F));
            tlRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 266F));
            tlRoot.Size = new Size(1321, 607);
            tlRoot.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1315, 61);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(651, 55);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 17);
            label1.Name = "label1";
            label1.Size = new Size(132, 38);
            label1.TabIndex = 0;
            label1.Text = "Reports";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnExport);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(660, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(652, 55);
            panel2.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExport.Location = new Point(433, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(216, 49);
            btnExport.TabIndex = 0;
            btnExport.Text = "Export Report";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += exportBtn_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(panel4, 0, 0);
            tableLayoutPanel2.Controls.Add(panel5, 2, 0);
            tableLayoutPanel2.Controls.Add(panel6, 3, 0);
            tableLayoutPanel2.Controls.Add(panel3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 70);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1315, 107);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(label2);
            panel4.Controls.Add(cboType);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(322, 101);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 10);
            label2.Name = "label2";
            label2.Size = new Size(127, 26);
            label2.TabIndex = 1;
            label2.Text = "Report Type";
            // 
            // cboType
            // 
            cboType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboType.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(3, 49);
            cboType.Name = "cboType";
            cboType.Size = new Size(316, 34);
            cboType.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(dtStart);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(659, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(322, 101);
            panel5.TabIndex = 1;
            // 
            // dtStart
            // 
            dtStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtStart.CalendarFont = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtStart.Location = new Point(3, 50);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(319, 27);
            dtStart.TabIndex = 4;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(116, 10);
            label4.Name = "label4";
            label4.Size = new Size(103, 26);
            label4.TabIndex = 3;
            label4.Text = "Start Date";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(dtEnd);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(987, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(325, 101);
            panel6.TabIndex = 1;
            // 
            // dtEnd
            // 
            dtEnd.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtEnd.CalendarFont = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtEnd.Location = new Point(3, 49);
            dtEnd.Name = "dtEnd";
            dtEnd.Size = new Size(319, 27);
            dtEnd.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(108, 10);
            label3.Name = "label3";
            label3.Size = new Size(97, 26);
            label3.TabIndex = 2;
            label3.Text = "End Date";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(cboCategory);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(331, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(322, 101);
            panel3.TabIndex = 0;
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(3, 49);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(316, 34);
            cboCategory.TabIndex = 3;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(118, 10);
            label5.Name = "label5";
            label5.Size = new Size(96, 26);
            label5.TabIndex = 4;
            label5.Text = "Category";
            // 
            // tlContent
            // 
            tlContent.ColumnCount = 1;
            tlContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlContent.Controls.Add(chartReport, 0, 0);
            tlContent.Controls.Add(pnlSummary, 0, 1);
            tlContent.Controls.Add(dgvReport, 0, 2);
            tlContent.Dock = DockStyle.Fill;
            tlContent.Location = new Point(3, 183);
            tlContent.Name = "tlContent";
            tlContent.RowCount = 3;
            tlContent.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlContent.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlContent.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlContent.Size = new Size(1315, 421);
            tlContent.TabIndex = 2;
            // 
            // chartReport
            // 
            chartArea1.Name = "ChartArea1";
            chartReport.ChartAreas.Add(chartArea1);
            chartReport.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartReport.Legends.Add(legend1);
            chartReport.Location = new Point(3, 3);
            chartReport.Name = "chartReport";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartReport.Series.Add(series1);
            chartReport.Size = new Size(1309, 134);
            chartReport.TabIndex = 0;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.White;
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(3, 143);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(1309, 134);
            pnlSummary.TabIndex = 1;
            // 
            // dgvReport
            // 
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(3, 283);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(1309, 135);
            dgvReport.TabIndex = 2;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlRoot);
            Name = "ReportForm";
            Size = new Size(1321, 607);
            tlRoot.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlRoot;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnExport;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private Label label4;
        private Panel panel6;
        private Label label3;
        private Panel panel3;
        private Label label5;
        private ComboBox cboType;
        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;
        private ComboBox cboCategory;
        private TableLayoutPanel tlContent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReport;
        private Panel pnlSummary;
        private DataGridView dgvReport;
    }
}
