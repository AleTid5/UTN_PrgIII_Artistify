using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity.User;
using Entity;
using System.Net.Mail;
using Repository;
using Common.Rules;

namespace WinApp.Views.User
{
    public partial class Edit : UserControl
    {
        public event EventHandler GoBack;
        AbstractUser user = new AbstractUser();
        private List<Nation> Nations = (new NationRepository()).FindAll();
        private List<Status> statuses = (new StatusRepository()).FindAll();

        public Edit()
        {
            InitializeComponent();
            this.comboNationality.DataSource = Nations;
            this.comboNationality.DisplayMember = "Name";
            this.comboNationality.ValueMember = "Code";
            this.comboStatus.DataSource = statuses;
            this.comboStatus.DisplayMember = "Name";
            this.comboStatus.ValueMember = "Code";
        }

        public void SetUser(AbstractUser user)
        {
            this.user = user;
            statuses = (new StatusRepository()).FindAll();
        }

        public void FillForm()
        {
            txtName.Text = this.user.Name;
            txtLastName.Text = this.user.LastName;
            txtEmail.Text = this.user.Email;
            dateBornDate.Value = this.user.BornDate;
            radioF.Checked = this.user.Gender == 'F';
            radioM.Checked = this.user.Gender == 'M';
            radioO.Checked = this.user.Gender == 'O';
            comboNationality.SelectedValue = this.user.Nationality.Code;
            comboStatus.SelectedValue = this.user.Status.Code;
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
                this.user.Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 5, 50);
                this.user.LastName = NativeRules.CheckString(txtLastName.Text.ToString().Trim(), "Apellido inválido", 5, 50);
                this.user.Email = NativeRules.CheckString((new MailAddress(txtEmail.Text.ToString().Trim())).Address, "Email inválido", int.MinValue, 100);
                this.user.BornDate = dateBornDate.Value;
                this.user.Gender = radioF.Checked ? 'F' : radioM.Checked ? 'M' : 'O';
                this.user.Nationality = new NationRepository().GetNation(comboNationality.SelectedValue.ToString());
                this.user.Status = new StatusRepository().GetStatus(comboStatus.SelectedValue.ToString());

                new UserRepository().Edit(this.user);
                MessageBox.Show("El Usuario se ha editado exitosamente!");
                this.btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CleanForm()
        {
            txtName.Text = txtLastName.Text = txtEmail.Text = "";
            dateBornDate.Value = DateTime.Today;
            radioM.Checked = !(radioF.Checked = radioO.Checked = false);
        }
    }
}
