namespace TPC_Tidele.Views.Gender
{
    partial class Index
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddGender = new System.Windows.Forms.Button();
            this.dataGridGenders = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditGender = new System.Windows.Forms.Button();
            this.btnRemoveGender = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGenders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddGender
            // 
            this.btnAddGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(24)))));
            this.btnAddGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGender.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.btnAddGender.ForeColor = System.Drawing.Color.White;
            this.btnAddGender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddGender.Location = new System.Drawing.Point(703, 397);
            this.btnAddGender.Name = "btnAddGender";
            this.btnAddGender.Size = new System.Drawing.Size(30, 30);
            this.btnAddGender.TabIndex = 6;
            this.btnAddGender.Tag = "";
            this.btnAddGender.Text = "+";
            this.btnAddGender.UseVisualStyleBackColor = false;
            this.btnAddGender.Click += new System.EventHandler(this.btnAddGender_Click);
            // 
            // dataGridGenders
            // 
            this.dataGridGenders.AllowUserToAddRows = false;
            this.dataGridGenders.AllowUserToDeleteRows = false;
            this.dataGridGenders.AllowUserToResizeColumns = false;
            this.dataGridGenders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.NullValue = "Sin datos";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridGenders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridGenders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.dataGridGenders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = "Sin datos";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGenders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridGenders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.NullValue = "Sin datos";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridGenders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridGenders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridGenders.Location = new System.Drawing.Point(23, 69);
            this.dataGridGenders.MultiSelect = false;
            this.dataGridGenders.Name = "dataGridGenders";
            this.dataGridGenders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.NullValue = "Sin datos";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGenders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridGenders.RowHeadersVisible = false;
            dataGridViewCellStyle5.NullValue = "Sin datos";
            this.dataGridGenders.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridGenders.Size = new System.Drawing.Size(711, 316);
            this.dataGridGenders.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 43);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(17, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Géneros";
            // 
            // btnEditGender
            // 
            this.btnEditGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(24)))));
            this.btnEditGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGender.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.btnEditGender.ForeColor = System.Drawing.Color.White;
            this.btnEditGender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditGender.Location = new System.Drawing.Point(658, 397);
            this.btnEditGender.Name = "btnEditGender";
            this.btnEditGender.Size = new System.Drawing.Size(30, 30);
            this.btnEditGender.TabIndex = 7;
            this.btnEditGender.Text = "✎";
            this.btnEditGender.UseVisualStyleBackColor = false;
            this.btnEditGender.Click += new System.EventHandler(this.btnEditGender_Click);
            // 
            // btnRemoveGender
            // 
            this.btnRemoveGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(24)))));
            this.btnRemoveGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGender.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.btnRemoveGender.ForeColor = System.Drawing.Color.White;
            this.btnRemoveGender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveGender.Location = new System.Drawing.Point(613, 397);
            this.btnRemoveGender.Name = "btnRemoveGender";
            this.btnRemoveGender.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveGender.TabIndex = 8;
            this.btnRemoveGender.Text = "🗑";
            this.btnRemoveGender.UseVisualStyleBackColor = false;
            this.btnRemoveGender.Click += new System.EventHandler(this.btnRemoveGender_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.Controls.Add(this.btnRemoveGender);
            this.Controls.Add(this.btnEditGender);
            this.Controls.Add(this.btnAddGender);
            this.Controls.Add(this.dataGridGenders);
            this.Controls.Add(this.panel1);
            this.Name = "Index";
            this.Size = new System.Drawing.Size(758, 439);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGenders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddGender;
        private System.Windows.Forms.DataGridView dataGridGenders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditGender;
        private System.Windows.Forms.Button btnRemoveGender;
    }
}
