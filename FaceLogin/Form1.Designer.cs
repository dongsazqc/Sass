namespace FaceLogin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSqlusername = new Label();
            txtTenantCode = new TextBox();
            lnkPaste = new LinkLabel();
            btnLogin = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblSqlusername
            // 
            lblSqlusername.AutoSize = true;
            lblSqlusername.Location = new Point(53, 139);
            lblSqlusername.Name = "lblSqlusername";
            lblSqlusername.Size = new Size(79, 20);
            lblSqlusername.TabIndex = 0;
            lblSqlusername.Text = "Mã kết nối";
            // 
            // txtTenantCode
            // 
            txtTenantCode.Location = new Point(161, 132);
            txtTenantCode.Multiline = true;
            txtTenantCode.Name = "txtTenantCode";
            txtTenantCode.Size = new Size(524, 34);
            txtTenantCode.TabIndex = 1;
            // 
            // lnkPaste
            // 
            lnkPaste.AutoSize = true;
            lnkPaste.Location = new Point(137, 169);
            lnkPaste.Name = "lnkPaste";
            lnkPaste.Size = new Size(36, 20);
            lnkPaste.TabIndex = 2;
            lnkPaste.TabStop = true;
            lnkPaste.Text = "Dán";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(542, 185);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Thực hiện";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(661, 185);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Thực hiện";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 305);
            Controls.Add(button1);
            Controls.Add(btnLogin);
            Controls.Add(lnkPaste);
            Controls.Add(txtTenantCode);
            Controls.Add(lblSqlusername);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSqlusername;
        private TextBox txtTenantCode;
        private LinkLabel lnkPaste;
        private Button btnLogin;
        private Button button1;
    }
}
