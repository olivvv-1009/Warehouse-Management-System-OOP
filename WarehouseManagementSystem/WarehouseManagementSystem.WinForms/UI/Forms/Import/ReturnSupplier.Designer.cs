namespace WarehouseManagementSystem.WinForms.UI.Forms.Import
{
    partial class ReturnSupplier
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lbSupplier = new Label();
            Date = new DateTimePicker();
            comboBox1 = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            lbCreatedby = new Label();
            textBox1 = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnCancel = new Button();
            btnSubmit = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(710, 279);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.7142868F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(680, 249);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(674, 42);
            label1.TabIndex = 0;
            label1.Text = "Return to Supplier";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 266F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(label4, 2, 0);
            tableLayoutPanel2.Controls.Add(lbSupplier, 1, 1);
            tableLayoutPanel2.Controls.Add(Date, 2, 1);
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 45);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(674, 77);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(198, 38);
            label2.TabIndex = 0;
            label2.Text = "Import Invoice";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(207, 0);
            label3.Name = "label3";
            label3.Size = new Size(198, 38);
            label3.TabIndex = 1;
            label3.Text = "Supplier";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(411, 0);
            label4.Name = "label4";
            label4.Size = new Size(260, 38);
            label4.TabIndex = 2;
            label4.Text = "Date";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbSupplier
            // 
            lbSupplier.AutoSize = true;
            lbSupplier.Dock = DockStyle.Fill;
            lbSupplier.Location = new Point(207, 38);
            lbSupplier.Name = "lbSupplier";
            lbSupplier.Size = new Size(198, 39);
            lbSupplier.TabIndex = 3;
            lbSupplier.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Date
            // 
            Date.Dock = DockStyle.Fill;
            Date.Location = new Point(411, 41);
            Date.MaxDate = new DateTime(2026, 5, 11, 0, 0, 0, 0);
            Date.Name = "Date";
            Date.Size = new Size(260, 30);
            Date.TabIndex = 4;
            Date.Value = new DateTime(2026, 5, 11, 0, 0, 0, 0);
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 30);
            comboBox1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label5, 0, 0);
            tableLayoutPanel3.Controls.Add(label6, 1, 0);
            tableLayoutPanel3.Controls.Add(lbCreatedby, 0, 1);
            tableLayoutPanel3.Controls.Add(textBox1, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 128);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(674, 73);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(331, 36);
            label5.TabIndex = 0;
            label5.Text = "Created by";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(340, 0);
            label6.Name = "label6";
            label6.Size = new Size(331, 36);
            label6.TabIndex = 1;
            label6.Text = "Reason";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCreatedby
            // 
            lbCreatedby.AutoSize = true;
            lbCreatedby.Dock = DockStyle.Fill;
            lbCreatedby.Location = new Point(3, 36);
            lbCreatedby.Name = "lbCreatedby";
            lbCreatedby.Size = new Size(331, 37);
            lbCreatedby.TabIndex = 2;
            lbCreatedby.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(340, 39);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter the reason returning to supplier";
            textBox1.Size = new Size(331, 30);
            textBox1.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.47482F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5251789F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tableLayoutPanel4.Controls.Add(btnCancel, 1, 0);
            tableLayoutPanel4.Controls.Add(btnSubmit, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 207);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(674, 39);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(456, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 33);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.LimeGreen;
            btnSubmit.Dock = DockStyle.Fill;
            btnSubmit.ForeColor = SystemColors.ActiveCaptionText;
            btnSubmit.Location = new Point(559, 3);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 33);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // ReturnSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 279);
            Controls.Add(panel1);
            Name = "ReturnSupplier";
            Text = "ReturnSupplier";
            Load += ReturnSupplier_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbSupplier;
        private DateTimePicker Date;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private Label lbCreatedby;
        private TextBox textBox1;
        private Button btnCancel;
        private Button btnSubmit;
    }
}