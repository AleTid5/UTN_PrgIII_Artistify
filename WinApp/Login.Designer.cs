namespace WinApp
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPasswordChange2 = new System.Windows.Forms.Label();
            this.lblPasswordChange = new System.Windows.Forms.Label();
            this.txtPasswordChange2 = new System.Windows.Forms.TextBox();
            this.txtPasswordChange = new System.Windows.Forms.TextBox();
            this.btnPasswordChange = new System.Windows.Forms.Button();
            this.lblPasswordChangeError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.txtUser.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtUser.Location = new System.Drawing.Point(365, 187);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(211, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPassword.Location = new System.Drawing.Point(365, 255);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(211, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUser.Location = new System.Drawing.Point(362, 171);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPassword.Location = new System.Drawing.Point(362, 239);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña";
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.BtnLogin.Location = new System.Drawing.Point(409, 306);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(119, 24);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "Ingresar";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(-10, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 22);
            this.panel1.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(96)))), ((int)(((byte)(98)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(96)))), ((int)(((byte)(98)))));
            this.btnClose.Location = new System.Drawing.Point(914, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(11, 11);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(427, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblPasswordChange2
            // 
            this.lblPasswordChange2.AutoSize = true;
            this.lblPasswordChange2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPasswordChange2.Location = new System.Drawing.Point(362, 239);
            this.lblPasswordChange2.Name = "lblPasswordChange2";
            this.lblPasswordChange2.Size = new System.Drawing.Size(108, 13);
            this.lblPasswordChange2.TabIndex = 12;
            this.lblPasswordChange2.Text = "Confirmar Contraseña";
            this.lblPasswordChange2.Visible = false;
            // 
            // lblPasswordChange
            // 
            this.lblPasswordChange.AutoSize = true;
            this.lblPasswordChange.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPasswordChange.Location = new System.Drawing.Point(362, 171);
            this.lblPasswordChange.Name = "lblPasswordChange";
            this.lblPasswordChange.Size = new System.Drawing.Size(96, 13);
            this.lblPasswordChange.TabIndex = 11;
            this.lblPasswordChange.Text = "Nueva Contraseña";
            this.lblPasswordChange.Visible = false;
            // 
            // txtPasswordChange2
            // 
            this.txtPasswordChange2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.txtPasswordChange2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPasswordChange2.Location = new System.Drawing.Point(365, 255);
            this.txtPasswordChange2.Name = "txtPasswordChange2";
            this.txtPasswordChange2.PasswordChar = '*';
            this.txtPasswordChange2.Size = new System.Drawing.Size(211, 20);
            this.txtPasswordChange2.TabIndex = 10;
            this.txtPasswordChange2.Visible = false;
            // 
            // txtPasswordChange
            // 
            this.txtPasswordChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.txtPasswordChange.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPasswordChange.Location = new System.Drawing.Point(365, 187);
            this.txtPasswordChange.Name = "txtPasswordChange";
            this.txtPasswordChange.PasswordChar = '*';
            this.txtPasswordChange.Size = new System.Drawing.Size(211, 20);
            this.txtPasswordChange.TabIndex = 9;
            this.txtPasswordChange.Visible = false;
            // 
            // btnPasswordChange
            // 
            this.btnPasswordChange.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPasswordChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasswordChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnPasswordChange.Location = new System.Drawing.Point(409, 306);
            this.btnPasswordChange.Name = "btnPasswordChange";
            this.btnPasswordChange.Size = new System.Drawing.Size(119, 24);
            this.btnPasswordChange.TabIndex = 13;
            this.btnPasswordChange.Text = "Cambiar Contraseña";
            this.btnPasswordChange.UseVisualStyleBackColor = false;
            this.btnPasswordChange.Visible = false;
            this.btnPasswordChange.Click += new System.EventHandler(this.btnPasswordChange_Click);
            // 
            // lblPasswordChangeError
            // 
            this.lblPasswordChangeError.AutoSize = true;
            this.lblPasswordChangeError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPasswordChangeError.Location = new System.Drawing.Point(392, 284);
            this.lblPasswordChangeError.Name = "lblPasswordChangeError";
            this.lblPasswordChangeError.Size = new System.Drawing.Size(0, 13);
            this.lblPasswordChangeError.TabIndex = 14;
            this.lblPasswordChangeError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(923, 462);
            this.Controls.Add(this.lblPasswordChangeError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPasswordChange2);
            this.Controls.Add(this.lblPasswordChange);
            this.Controls.Add(this.txtPasswordChange2);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.btnPasswordChange);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPasswordChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apollum | Login";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPasswordChange2;
        private System.Windows.Forms.Label lblPasswordChange;
        private System.Windows.Forms.TextBox txtPasswordChange2;
        private System.Windows.Forms.TextBox txtPasswordChange;
        private System.Windows.Forms.Button btnPasswordChange;
        private System.Windows.Forms.Label lblPasswordChangeError;
    }
}

