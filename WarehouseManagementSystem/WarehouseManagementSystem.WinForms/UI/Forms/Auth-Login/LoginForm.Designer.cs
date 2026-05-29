namespace WarehouseManagementSystem.WinForms.UI.Forms
{
    partial class LoginForm
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
            btnForgot = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label5 = new Label();
            lblAttempts = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnForgot);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblAttempts);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(225, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(495, 338);
            panel1.TabIndex = 0;
            // 
            // btnForgot
            // 
            btnForgot.Font = new Font("Times New Roman", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnForgot.Location = new Point(273, 264);
            btnForgot.Name = "btnForgot";
            btnForgot.Size = new Size(176, 46);
            btnForgot.TabIndex = 7;
            btnForgot.Text = "Forgot Password";
            btnForgot.UseVisualStyleBackColor = true;
            btnForgot.Click += btnForgot_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.SlateGray;
            btnLogin.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(76, 264);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(115, 46);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(189, 143);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(279, 30);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(189, 79);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(279, 30);
            txtUsername.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(34, 75);
            label5.Name = "label5";
            label5.Size = new Size(122, 29);
            label5.TabIndex = 3;
            label5.Text = "Username";
            // 
            // lblAttempts
            // 
            lblAttempts.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttempts.Location = new Point(34, 205);
            lblAttempts.Name = "lblAttempts";
            lblAttempts.Size = new Size(434, 29);
            lblAttempts.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 139);
            label3.Name = "label3";
            label3.Size = new Size(118, 29);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(202, 25);
            label2.Name = "label2";
            label2.Size = new Size(96, 29);
            label2.TabIndex = 0;
            label2.Text = "LOGIN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(146, 45);
            label1.Name = "label1";
            label1.Size = new Size(653, 38);
            label1.TabIndex = 1;
            label1.Text = "WAREHOUSE MANAGEMENT SYSTEM";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(963, 524);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += this.LoginForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label5;
        private Label lblAttempts;
        private Label label3;
        private Label label2;
        private Button btnForgot;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
    }
}