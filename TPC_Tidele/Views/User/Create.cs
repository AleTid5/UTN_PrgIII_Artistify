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

namespace TPC_Tidele.Views.User
{
    public partial class Create : UserControl
    {
        public event EventHandler GoBack;
        private List<Nation> Nations = (new NationRepository()).FindAll();

        public Create()
        {
            InitializeComponent();
            this.comboNationality.DataSource = Nations;
            this.comboNationality.DisplayMember = "Name";
            this.comboNationality.ValueMember = "Code";
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
                Administrator administrator = new Administrator();
                NationRepository nationRepository = new NationRepository();
                administrator.Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 5, 50);
                administrator.LastName = NativeRules.CheckString(txtLastName.Text.ToString().Trim(), "Apellido inválido", 5, 50);
                administrator.Email = NativeRules.CheckString((new MailAddress(txtEmail.Text.ToString().Trim())).Address, "Email inválido", int.MinValue, 100);
                administrator.BornDate = dateBornDate.Value;
                administrator.Gender = radioF.Checked ? 'F' : radioM.Checked ? 'M' : 'O';
                administrator.Nationality = nationRepository.GetNation(comboNationality.SelectedValue.ToString());

                AdministratorRepository administratorRepository = new AdministratorRepository();
                administratorRepository.AddAdmin(administrator);
                MessageBox.Show("El Administrador se ha creado exitosamente!");
                this.btnBack_Click(sender, e);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CleanForm()
        {
            txtName.Text = txtLastName.Text = txtEmail.Text = "";
            dateBornDate.Value = DateTime.Today;
            radioM.Checked = ! (radioF.Checked = radioO.Checked = false);
        }
    }
}
