namespace WarehouseManagementSystem.WinForms.UI.Suppliers
{
    partial class AddEditSupplierForm
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
            btnSave = new Button();
            btnCancel = new Button();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 34);
            label1.Name = "label1";
            label1.Size = new Size(169, 29);
            label1.TabIndex = 0;
            label1.Text = "Supplier Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 307);
            label2.Name = "label2";
            label2.Size = new Size(102, 29);
            label2.TabIndex = 1;
            label2.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 211);
            label3.Name = "label3";
            label3.Size = new Size(83, 29);
            label3.TabIndex = 2;
            label3.Text = "Phone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 117);
            label4.Name = "label4";
            label4.Size = new Size(77, 29);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SkyBlue;
            btnSave.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(411, 417);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 43);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(545, 417);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 43);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += this.btnCancel_Click;
            // 
            // txtName
            // 
            txtName.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(34, 66);
            txtName.Name = "txtName";
            txtName.Size = new Size(616, 36);
            txtName.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(34, 243);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(616, 36);
            txtPhone.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(34, 339);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(616, 36);
            txtAddress.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(34, 149);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(616, 36);
            txtEmail.TabIndex = 9;
            // 
            // AddEditSupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 486);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddEditSupplierForm";
            Text = "AddEditSupplierForm";
            Load += AddEditSupplierForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtEmail;
    }
}