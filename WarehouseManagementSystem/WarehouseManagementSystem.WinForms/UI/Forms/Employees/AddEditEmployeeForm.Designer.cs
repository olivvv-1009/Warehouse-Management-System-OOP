namespace WarehouseManagementSystem.WinForms.UI.Forms.Employees
{
    partial class AddEditEmployeeForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtFullName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            dtpDOB = new DateTimePicker();
            cboGender = new ComboBox();
            cboRole = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 24);
            label1.Name = "label1";
            label1.Size = new Size(124, 29);
            label1.TabIndex = 0;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(514, 90);
            label2.Name = "label2";
            label2.Size = new Size(66, 29);
            label2.TabIndex = 1;
            label2.Text = "Role:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 314);
            label3.Name = "label3";
            label3.Size = new Size(102, 29);
            label3.TabIndex = 2;
            label3.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 237);
            label4.Name = "label4";
            label4.Size = new Size(77, 29);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 163);
            label5.Name = "label5";
            label5.Size = new Size(172, 29);
            label5.TabIndex = 4;
            label5.Text = "Phone Number:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(514, 24);
            label6.Name = "label6";
            label6.Size = new Size(93, 29);
            label6.TabIndex = 5;
            label6.Text = "Gender:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(32, 90);
            label7.Name = "label7";
            label7.Size = new Size(154, 29);
            label7.TabIndex = 6;
            label7.Text = "Date Of Birth:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(514, 368);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 43);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(661, 368);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 43);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(162, 24);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(326, 30);
            txtFullName.TabIndex = 9;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(210, 162);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(560, 30);
            txtPhone.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(115, 236);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(655, 30);
            txtEmail.TabIndex = 11;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(140, 313);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(630, 30);
            txtAddress.TabIndex = 12;
            // 
            // dtpDOB
            // 
            dtpDOB.CalendarFont = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDOB.Location = new Point(192, 90);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(296, 27);
            dtpDOB.TabIndex = 13;
            // 
            // cboGender
            // 
            cboGender.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(613, 23);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(157, 30);
            cboGender.TabIndex = 14;
            // 
            // cboRole
            // 
            cboRole.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(586, 87);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(184, 30);
            cboRole.TabIndex = 15;
            // 
            // AddEditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(812, 430);
            Controls.Add(cboRole);
            Controls.Add(cboGender);
            Controls.Add(dtpDOB);
            Controls.Add(txtAddress);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtFullName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddEditEmployeeForm";
            Text = "AddEditEmployeeForm";
            Load += AddEditEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtFullName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private DateTimePicker dtpDOB;
        private ComboBox cboGender;
        private ComboBox cboRole;
    }
}