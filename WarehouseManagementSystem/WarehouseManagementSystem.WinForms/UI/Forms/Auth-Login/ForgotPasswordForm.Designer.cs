namespace WarehouseManagementSystem.WinForms.UI.Forms.Auth_Login
{
    partial class ForgotPasswordForm
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
            txtUsername = new TextBox();
            label1 = new Label();
            lblQuestion = new Label();
            btnLoad = new Button();
            txtAnswer = new TextBox();
            btnVerify = new Button();
            label2 = new Label();
            txtNewPassword = new TextBox();
            btnReset = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(221, 34);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(382, 30);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 35);
            label1.Name = "label1";
            label1.Size = new Size(114, 29);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(46, 132);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(110, 29);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "Question:";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.SlateGray;
            btnLoad.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(451, 81);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(105, 34);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtAnswer
            // 
            txtAnswer.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnswer.Location = new Point(42, 183);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(561, 30);
            txtAnswer.TabIndex = 4;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.SlateGray;
            btnVerify.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(451, 238);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(105, 34);
            btnVerify.TabIndex = 5;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 285);
            label2.Name = "label2";
            label2.Size = new Size(163, 29);
            label2.TabIndex = 6;
            label2.Text = "New Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(42, 336);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(561, 30);
            txtNewPassword.TabIndex = 7;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.SlateGray;
            btnReset.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(451, 386);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(105, 34);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(664, 450);
            Controls.Add(btnReset);
            Controls.Add(txtNewPassword);
            Controls.Add(label2);
            Controls.Add(btnVerify);
            Controls.Add(txtAnswer);
            Controls.Add(btnLoad);
            Controls.Add(lblQuestion);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Name = "ForgotPasswordForm";
            Text = "ForgotPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private Label label1;
        private Label lblQuestion;
        private Button btnLoad;
        private TextBox txtAnswer;
        private Button btnVerify;
        private Label label2;
        private TextBox txtNewPassword;
        private Button btnReset;
    }
}