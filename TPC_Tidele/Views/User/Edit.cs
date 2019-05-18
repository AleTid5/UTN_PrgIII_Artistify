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

namespace TPC_Tidele.Views.User
{
    public partial class Edit : UserControl
    {
        public event EventHandler GoBack;
        Administrator administrator = new Administrator();
        private List<Nation> Nations = (new NationRepository()).FindAll();

        public Edit()
        {
            InitializeComponent();
            this.comboNationality.DataSource = Nations;
            this.comboNationality.DisplayMember = "Name";
            this.comboNationality.ValueMember = "Code";
        }

        public void SetUser(Administrator administrator)
        {
            this.administrator = administrator;
        }

        public void FillForm()
        {
            txtName.Text = this.administrator.Name;
            txtLastName.Text = this.administrator.LastName;
            txtEmail.Text = this.administrator.Email;
            dateBornDate.Value = this.administrator.BornDate;
            radioF.Checked = this.administrator.Gender == 'F';
            radioM.Checked = this.administrator.Gender == 'M';
            radioO.Checked = this.administrator.Gender == 'O';
            comboNationality.SelectedValue = this.administrator.Nationality.Code;
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
                NationRepository nationRepository = new NationRepository();
                this.administrator.Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 5, 50);
                this.administrator.LastName = NativeRules.CheckString(txtLastName.Text.ToString().Trim(), "Apellido inválido", 5, 50);
                this.administrator.Email = NativeRules.CheckString((new MailAddress(txtEmail.Text.ToString().Trim())).Address, "Email inválido", int.MinValue, 100);
                this.administrator.BornDate = dateBornDate.Value;
                this.administrator.Gender = radioF.Checked ? 'F' : radioM.Checked ? 'M' : 'O';
                this.administrator.Nationality = nationRepository.GetNation(comboNationality.SelectedValue.ToString());

                AdministratorRepository administratorRepository = new AdministratorRepository();
                administratorRepository.EditAdmin(administrator);
                MessageBox.Show("El Administrador se ha editado exitosamente!");
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
