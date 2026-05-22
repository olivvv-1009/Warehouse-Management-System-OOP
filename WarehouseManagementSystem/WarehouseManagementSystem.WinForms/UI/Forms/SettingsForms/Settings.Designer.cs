namespace WarehouseManagementSystem.WinForms.UI.Forms.SettingsForms
{
    partial class Settings
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            cbQuestion = new ComboBox();
            txtAnswer = new TextBox();
            label13 = new Label();
            label14 = new Label();
            label12 = new Label();
            btnSaveSecurity = new Button();
            panel1 = new Panel();
            dtBirth = new DateTimePicker();
            txtFullName = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            btnSaveProfile = new Button();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            btnChangePassword = new Button();
            txtConfirmPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtOldPassword = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label8 = new Label();
            label15 = new Label();
            cboGender = new ComboBox();
            cboRole = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 737F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 263F));
            tableLayoutPanel1.Controls.Add(panel4, 1, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 337F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 663F));
            tableLayoutPanel1.Size = new Size(1470, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Azure;
            panel4.Controls.Add(cbQuestion);
            panel4.Controls.Add(txtAnswer);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(btnSaveSecurity);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(740, 340);
            panel4.Name = "panel4";
            panel4.Size = new Size(727, 657);
            panel4.TabIndex = 0;
            // 
            // cbQuestion
            // 
            cbQuestion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbQuestion.FormattingEnabled = true;
            cbQuestion.Location = new Point(38, 104);
            cbQuestion.Name = "cbQuestion";
            cbQuestion.Size = new Size(649, 30);
            cbQuestion.TabIndex = 15;
            // 
            // txtAnswer
            // 
            txtAnswer.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnswer.Location = new Point(38, 219);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(649, 30);
            txtAnswer.TabIndex = 13;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(38, 169);
            label13.Name = "label13";
            label13.Size = new Size(172, 26);
            label13.TabIndex = 13;
            label13.Text = "Security Answer:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(38, 60);
            label14.Name = "label14";
            label14.Size = new Size(185, 26);
            label14.TabIndex = 14;
            label14.Text = "Security Question:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(22, 14);
            label12.Name = "label12";
            label12.Size = new Size(204, 29);
            label12.TabIndex = 13;
            label12.Text = "Security Question";
            // 
            // btnSaveSecurity
            // 
            btnSaveSecurity.BackColor = Color.LightSlateGray;
            btnSaveSecurity.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveSecurity.ForeColor = SystemColors.ButtonHighlight;
            btnSaveSecurity.Location = new Point(569, 308);
            btnSaveSecurity.Name = "btnSaveSecurity";
            btnSaveSecurity.Size = new Size(118, 38);
            btnSaveSecurity.TabIndex = 13;
            btnSaveSecurity.Text = "Save";
            btnSaveSecurity.UseVisualStyleBackColor = false;
            btnSaveSecurity.Click += btnSaveSecurity_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lavender;
            panel1.Controls.Add(cboRole);
            panel1.Controls.Add(cboGender);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(dtBirth);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(731, 331);
            panel1.TabIndex = 0;
            // 
            // dtBirth
            // 
            dtBirth.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtBirth.Location = new Point(172, 129);
            dtBirth.Name = "dtBirth";
            dtBirth.Size = new Size(480, 27);
            dtBirth.TabIndex = 9;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(172, 62);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(480, 30);
            txtFullName.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(28, 130);
            label7.Name = "label7";
            label7.Size = new Size(138, 26);
            label7.TabIndex = 6;
            label7.Text = "Date of Birth:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 262);
            label4.Name = "label4";
            label4.Size = new Size(61, 26);
            label4.TabIndex = 3;
            label4.Text = "Role:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 66);
            label2.Name = "label2";
            label2.Size = new Size(115, 26);
            label2.TabIndex = 1;
            label2.Text = "Full Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 19);
            label1.Name = "label1";
            label1.Size = new Size(242, 29);
            label1.TabIndex = 0;
            label1.Text = "Personal Information";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lavender;
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(btnSaveProfile);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(740, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(727, 331);
            panel2.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(136, 194);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(551, 30);
            txtAddress.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(136, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(551, 30);
            txtEmail.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(136, 58);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(551, 30);
            txtPhone.TabIndex = 11;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.BackColor = Color.LightSlateGray;
            btnSaveProfile.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveProfile.ForeColor = SystemColors.ButtonHighlight;
            btnSaveProfile.Location = new Point(569, 255);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(118, 38);
            btnSaveProfile.TabIndex = 6;
            btnSaveProfile.Text = "Save";
            btnSaveProfile.UseVisualStyleBackColor = false;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(38, 62);
            label6.Name = "label6";
            label6.Size = new Size(77, 26);
            label6.TabIndex = 5;
            label6.Text = "Phone:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(38, 130);
            label5.Name = "label5";
            label5.Size = new Size(71, 26);
            label5.TabIndex = 4;
            label5.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 194);
            label3.Name = "label3";
            label3.Size = new Size(94, 26);
            label3.TabIndex = 2;
            label3.Text = "Address:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.AliceBlue;
            panel3.Controls.Add(btnChangePassword);
            panel3.Controls.Add(txtConfirmPassword);
            panel3.Controls.Add(txtNewPassword);
            panel3.Controls.Add(txtOldPassword);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label8);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 340);
            panel3.Name = "panel3";
            panel3.Size = new Size(731, 657);
            panel3.TabIndex = 2;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.LightSlateGray;
            btnChangePassword.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = SystemColors.ButtonHighlight;
            btnChangePassword.Location = new Point(534, 308);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(118, 38);
            btnChangePassword.TabIndex = 12;
            btnChangePassword.Text = "Change";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(28, 239);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(624, 30);
            txtConfirmPassword.TabIndex = 10;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(28, 165);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(624, 30);
            txtNewPassword.TabIndex = 11;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOldPassword.Location = new Point(28, 89);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(624, 30);
            txtOldPassword.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(28, 210);
            label9.Name = "label9";
            label9.Size = new Size(193, 26);
            label9.TabIndex = 10;
            label9.Text = "Confirm Password:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(28, 136);
            label10.Name = "label10";
            label10.Size = new Size(157, 26);
            label10.TabIndex = 11;
            label10.Text = "New Password:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(28, 60);
            label11.Name = "label11";
            label11.Size = new Size(149, 26);
            label11.TabIndex = 12;
            label11.Text = "Old Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(9, 14);
            label8.Name = "label8";
            label8.Size = new Size(205, 29);
            label8.TabIndex = 10;
            label8.Text = "Change Password";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(28, 198);
            label15.Name = "label15";
            label15.Size = new Size(86, 26);
            label15.TabIndex = 10;
            label15.Text = "Gender:";
            // 
            // cboGender
            // 
            cboGender.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(172, 190);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(190, 30);
            cboGender.TabIndex = 11;
            // 
            // cboRole
            // 
            cboRole.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(172, 255);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(190, 30);
            cboRole.TabIndex = 12;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Settings";
            Size = new Size(1470, 753);
            Load += Settings_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Label label7;
        private Label label4;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label3;
        private DateTimePicker dtBirth;
        private TextBox txtFullName;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnSaveProfile;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label8;
        private Label label13;
        private Label label14;
        private Label label12;
        private Button btnSaveSecurity;
        private Button btnChangePassword;
        private TextBox txtConfirmPassword;
        private TextBox txtNewPassword;
        private TextBox txtOldPassword;
        private ComboBox cbQuestion;
        private TextBox txtAnswer;
        private ComboBox cboRole;
        private ComboBox cboGender;
        private Label label15;
    }
}

