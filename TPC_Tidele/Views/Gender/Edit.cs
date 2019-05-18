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
using Domain;
using Business;
using Business.Rules;
using System.Net.Mail;

namespace TPC_Tidele.Views.Gender
{
    public partial class Edit : UserControl
    {
        public event EventHandler GoBack;
        Domain.Gender gender = new Domain.Gender();
        private List<MediaType> mediaTypes = (new MediaTypeRepository()).FindAll();
        private List<Domain.Gender> genders = (new GenderRepository()).FindAll();
        private List<Status> statuses = (new StatusRepository()).FindAll();

        public Edit()
        {
            InitializeComponent();
            this.comboMediaType.DataSource = mediaTypes;
            this.comboMediaType.DisplayMember = "Type";
            this.comboMediaType.ValueMember = "Id";
            this.comboParentGender.DataSource = genders;
            this.comboParentGender.DisplayMember = "Name";
            this.comboParentGender.ValueMember = "Id";
            this.comboStatus.DataSource = statuses;
            this.comboStatus.DisplayMember = "Name";
            this.comboStatus.ValueMember = "Code";
        }

        public void SetGender(Domain.Gender gender)
        {
            this.gender = gender;
            this.genders = (new GenderRepository()).FindAll();
            this.statuses = (new StatusRepository()).FindAll();
        }

        public void FillForm()
        {
            txtName.Text = this.gender.Name;
            comboMediaType.SelectedValue = this.gender.MediaType.Id;
            comboParentGender.SelectedValue = this.gender.ParentGender.Id;
            comboStatus.SelectedValue = this.gender.Status.Code;
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
                this.gender.Name = txtName.Text;
                this.gender.MediaType = (new MediaTypeRepository().GetMediaType(int.Parse(comboMediaType.SelectedValue.ToString())));
                this.gender.ParentGender = (new GenderRepository()).GetGender(int.Parse(comboParentGender.SelectedValue.ToString()));
                this.gender.Status = (new StatusRepository().GetStatus(comboStatus.SelectedValue.ToString()));

                (new GenderRepository()).EditGender(this.gender);
                MessageBox.Show("El género se ha editado exitosamente!");
                this.btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CleanForm()
        {
            txtName.Text = "";
        }
    }
}
