using TPC_Tidele.Views;

namespace TPC_Tidele
{
    partial class Layout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Layout));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenders = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.Dashboard = new TPC_Tidele.Views.Dashboard();
            this.CategoryCreate = new TPC_Tidele.Views.Category.Create();
            this.CategoryEdit = new TPC_Tidele.Views.Category.Edit();
            this.CategoryIndex = new TPC_Tidele.Views.Category.Index();
            this.GenderCreate = new TPC_Tidele.Views.Gender.Create();
            this.GenderEdit = new TPC_Tidele.Views.Gender.Edit();
            this.GenderIndex = new TPC_Tidele.Views.Gender.Index();
            this.UserCreate = new TPC_Tidele.Views.User.Create();
            this.UserEdit = new TPC_Tidele.Views.User.Edit();
            this.UserIndex = new TPC_Tidele.Views.User.Index();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel2.Controls.Add(this.btnGenders);
            this.panel2.Controls.Add(this.btnCategories);
            this.panel2.Controls.Add(this.btnUsers);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 450);
            this.panel2.TabIndex = 5;
            // 
            // btnGenders
            // 
            this.btnGenders.FlatAppearance.BorderSize = 0;
            this.btnGenders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenders.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenders.ForeColor = System.Drawing.Color.White;
            this.btnGenders.Image = ((System.Drawing.Image)(resources.GetObject("btnGenders.Image")));
            this.btnGenders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenders.Location = new System.Drawing.Point(1, 286);
            this.btnGenders.Name = "btnGenders";
            this.btnGenders.Size = new System.Drawing.Size(153, 34);
            this.btnGenders.TabIndex = 8;
            this.btnGenders.Text = "  Géneros";
            this.btnGenders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenders.UseVisualStyleBackColor = true;
            this.btnGenders.Click += new System.EventHandler(this.btnGenders_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Image = ((System.Drawing.Image)(resources.GetObject("btnCategories.Image")));
            this.btnCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.Location = new System.Drawing.Point(3, 236);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(153, 34);
            this.btnCategories.TabIndex = 7;
            this.btnCategories.Text = "  Categorías";
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(3, 186);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(153, 34);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "  Usuarios";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(64, 396);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(32, 35);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(2, 138);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(155, 32);
            this.btnDashboard.TabIndex = 6;
            this.btnDashboard.Text = "  Home";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(-10, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 22);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(171, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(761, 439);
            this.panel3.TabIndex = 8;
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
            // Dashboard
            // 
            this.Dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.Dashboard.Location = new System.Drawing.Point(161, 22);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(759, 439);
            this.Dashboard.TabIndex = 8;
            // 
            // CategoryCreate
            // 
            this.CategoryCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.CategoryCreate.Location = new System.Drawing.Point(161, 22);
            this.CategoryCreate.Name = "CategoryCreate";
            this.CategoryCreate.Size = new System.Drawing.Size(758, 439);
            this.CategoryCreate.TabIndex = 11;
            // 
            // CategoryEdit
            // 
            this.CategoryEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.CategoryEdit.Location = new System.Drawing.Point(161, 22);
            this.CategoryEdit.Name = "CategoryEdit";
            this.CategoryEdit.Size = new System.Drawing.Size(758, 439);
            this.CategoryEdit.TabIndex = 12;
            // 
            // CategoryIndex
            // 
            this.CategoryIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.CategoryIndex.Location = new System.Drawing.Point(161, 22);
            this.CategoryIndex.Name = "CategoryIndex";
            this.CategoryIndex.Size = new System.Drawing.Size(758, 439);
            this.CategoryIndex.TabIndex = 9;
            // 
            // GenderCreate
            // 
            this.GenderCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.GenderCreate.Location = new System.Drawing.Point(161, 22);
            this.GenderCreate.Name = "GenderCreate";
            this.GenderCreate.Size = new System.Drawing.Size(758, 439);
            this.GenderCreate.TabIndex = 11;
            // 
            // GenderEdit
            // 
            this.GenderEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.GenderEdit.Location = new System.Drawing.Point(161, 22);
            this.GenderEdit.Name = "GenderEdit";
            this.GenderEdit.Size = new System.Drawing.Size(758, 439);
            this.GenderEdit.TabIndex = 12;
            // 
            // GenderIndex
            // 
            this.GenderIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.GenderIndex.Location = new System.Drawing.Point(161, 22);
            this.GenderIndex.Name = "GenderIndex";
            this.GenderIndex.Size = new System.Drawing.Size(758, 439);
            this.GenderIndex.TabIndex = 9;
            // 
            // UserCreate
            // 
            this.UserCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.UserCreate.Location = new System.Drawing.Point(161, 22);
            this.UserCreate.Name = "UserCreate";
            this.UserCreate.Size = new System.Drawing.Size(758, 439);
            this.UserCreate.TabIndex = 11;
            // 
            // UserEdit
            // 
            this.UserEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.UserEdit.Location = new System.Drawing.Point(161, 22);
            this.UserEdit.Name = "UserEdit";
            this.UserEdit.Size = new System.Drawing.Size(758, 439);
            this.UserEdit.TabIndex = 12;
            // 
            // UserIndex
            // 
            this.UserIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.UserIndex.Location = new System.Drawing.Point(161, 22);
            this.UserIndex.Name = "UserIndex";
            this.UserIndex.Size = new System.Drawing.Size(758, 439);
            this.UserIndex.TabIndex = 9;
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(923, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Dashboard);
            this.Controls.Add(this.CategoryCreate);
            this.Controls.Add(this.CategoryEdit);
            this.Controls.Add(this.CategoryIndex);
            this.Controls.Add(this.GenderCreate);
            this.Controls.Add(this.GenderEdit);
            this.Controls.Add(this.GenderIndex);
            this.Controls.Add(this.UserCreate);
            this.Controls.Add(this.UserEdit);
            this.Controls.Add(this.UserIndex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Layout_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel3;
        private Dashboard Dashboard;
        private Views.Category.Index CategoryIndex;
        private Views.Category.Create CategoryCreate;
        private Views.Category.Edit CategoryEdit;
        private Views.Gender.Index GenderIndex;
        private Views.Gender.Create GenderCreate;
        private Views.Gender.Edit GenderEdit;
        private Views.User.Index UserIndex;
        private Views.User.Create UserCreate;
        private Views.User.Edit UserEdit;
        private System.Windows.Forms.Button btnGenders;
        private System.Windows.Forms.Button btnCategories;
    }
}