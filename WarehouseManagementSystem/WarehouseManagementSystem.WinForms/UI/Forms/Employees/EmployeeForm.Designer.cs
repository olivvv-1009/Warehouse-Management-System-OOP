namespace WarehouseManagementSystem.WinForms.UI.Forms.Employees
{
    partial class EmployeeForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnAdd = new Button();
            label1 = new Label();
            panel2 = new Panel();
            txtSearch = new TextBox();
            panel3 = new Panel();
            dgvEmployee = new DataGridView();
            EmployeeId = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            Reset = new DataGridViewButtonColumn();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 241F));
            tableLayoutPanel1.Size = new Size(1262, 693);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1256, 90);
            panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(1019, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(240, 45);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+ Add Employee";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 21);
            label1.Name = "label1";
            label1.Size = new Size(173, 38);
            label1.TabIndex = 0;
            label1.Text = "Employees";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 99);
            panel2.Name = "panel2";
            panel2.Size = new Size(1256, 92);
            panel2.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(18, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1235, 36);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvEmployee);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 197);
            panel3.Name = "panel3";
            panel3.Size = new Size(1256, 493);
            panel3.TabIndex = 2;
            // 
            // dgvEmployee
            // 
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEmployee.BackgroundColor = Color.White;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Columns.AddRange(new DataGridViewColumn[] { EmployeeId, FullName, DateOfBirth, Gender, PhoneNumber, Email, Address, Role, Edit, Delete, Reset });
            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.Location = new Point(0, 0);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.Size = new Size(1256, 493);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellClick += dgvEmployee_CellClick;
            // 
            // EmployeeId
            // 
            EmployeeId.HeaderText = "Employee Id";
            EmployeeId.MinimumWidth = 6;
            EmployeeId.Name = "EmployeeId";
            // 
            // FullName
            // 
            FullName.HeaderText = "Full Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Date Of Birth";
            DateOfBirth.MinimumWidth = 6;
            DateOfBirth.Name = "DateOfBirth";
            // 
            // Gender
            // 
            Gender.HeaderText = "Gender";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // Address
            // 
            Address.HeaderText = "Address";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            // 
            // Role
            // 
            Role.HeaderText = "Role";
            Role.MinimumWidth = 6;
            Role.Name = "Role";
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Text = "Edit";
            Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // Reset
            // 
            Reset.HeaderText = "Reset";
            Reset.MinimumWidth = 6;
            Reset.Name = "Reset";
            Reset.Text = "Reset";
            Reset.UseColumnTextForButtonValue = true;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "EmployeeForm";
            Size = new Size(1262, 693);
            Load += EmployeeForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnAdd;
        private Label label1;
        private Panel panel2;
        private TextBox txtSearch;
        private Panel panel3;
        private DataGridView dgvEmployee;
        private DataGridViewTextBoxColumn EmployeeId;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
        private DataGridViewButtonColumn Reset;
    }
}
