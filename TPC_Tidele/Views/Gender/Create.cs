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
using Repository;
using Domain;
using System.Net.Mail;
using Common.Rules;

namespace TPC_Tidele.Views.Gender
{
    public partial class Create : UserControl
    {
        public event EventHandler GoBack;
        private List<MediaType> mediaTypes = (new MediaTypeRepository()).FindAll();
        private List<Domain.Gender> genders = (new GenderRepository()).FindAll();

        public Create()
        {
            InitializeComponent();
            this.comboMediaType.DataSource = mediaTypes;
            this.comboMediaType.DisplayMember = "Type";
            this.comboMediaType.ValueMember = "Id";
            this.comboParentGender.DataSource = genders;
            this.comboParentGender.DisplayMember = "Name";
            this.comboParentGender.ValueMember = "Id";
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
                Domain.Gender gender = new Domain.Gender
                {
                    Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 5, 50),
                    MediaType = (new MediaTypeRepository()).GetMediaType(int.Parse(comboMediaType.SelectedValue.ToString())),
                    ParentGender = (new GenderRepository()).GetGender(int.Parse(comboParentGender.SelectedValue.ToString()))
                };

                (new GenderRepository()).AddGender(gender);
                MessageBox.Show("El género se ha creado exitosamente!");
                this.btnBack_Click(sender, e);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CleanForm()
        {
            txtName.Text = "";
            this.genders = (new GenderRepository()).FindAll();
        }
    }
}
