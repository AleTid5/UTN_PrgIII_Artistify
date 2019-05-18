using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.User;
using Business;
using Domain;
using Business.Rules;
using System.Net.Mail;

namespace TPC_Tidele.Views.Category
{
    public partial class Create : UserControl
    {
        public event EventHandler GoBack;

        public Create()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.GoBack != null)
            {
                this.CleanForm();
                this.GoBack(this, EventArgs.Empty);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.Category category = new Domain.Category
                {
                    Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 1, 25),
                    BlockedAge = Convert.ToInt32(txtAge.Text.ToString().Trim())
                };

                (new CategoryRepository()).AddCategory(category);
                MessageBox.Show("La categoría se ha creado exitosamente!");
                this.btnBack_Click(sender, e);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CleanForm()
        {
            txtName.Text = txtAge.Text = "";
        }
    }
}
