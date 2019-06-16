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
                this.ChangeFormStatus();
                var user = new AbstractUser();

                if (this.chkModerator.Checked) {
                    user = new Moderator();
                } else {
                    user = new Administrator();
                }

                user.Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 5, 50);
                user.LastName = NativeRules.CheckString(txtLastName.Text.ToString().Trim(), "Apellido inválido", 5, 50);
                user.Email = NativeRules.CheckString((new MailAddress(txtEmail.Text.ToString().Trim())).Address, "Email inválido", int.MinValue, 100);
                user.BornDate = dateBornDate.Value;
                user.Gender = radioF.Checked ? 'F' : radioM.Checked ? 'M' : 'O';
                user.Nationality = new NationRepository().GetNation(comboNationality.SelectedValue.ToString());
                user.Status = new StatusRepository().GetStatus("N");

                if (this.chkModerator.Checked) {
                    new ModeratorRepository().Add((Moderator)user);
                    MessageBox.Show("El Moderador se ha creado exitosamente!");
                } else {
                    new AdministratorRepository().Add((Administrator)user);
                    MessageBox.Show("El Administrador se ha creado exitosamente!");
                }
                this.btnBack_Click(sender, e);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } finally
            {
                this.ChangeFormStatus();
            }
        }

        private void CleanForm()
        {
            txtName.Text = txtLastName.Text = txtEmail.Text = "";
            dateBornDate.Value = DateTime.Today;
            radioM.Checked = ! (radioF.Checked = radioO.Checked = false);
        }

        private void chkModerator_CheckedChanged(object sender, EventArgs e)
        {
            this.chkModerator.Text = this.chkModerator.Checked ? "Moderador" : "Administrador";
        }

        private void ChangeFormStatus()
        {
            this.txtName.Enabled = !this.txtName.Enabled;
            this.txtLastName.Enabled = !this.txtLastName.Enabled;
            this.txtEmail.Enabled = !this.txtEmail.Enabled;
            this.dateBornDate.Enabled = !this.dateBornDate.Enabled;
            this.radioM.Enabled = !this.radioM.Enabled;
            this.radioF.Enabled = !this.radioF.Enabled;
            this.radioO.Enabled = !this.radioO.Enabled;
            this.comboNationality.Enabled = !this.comboNationality.Enabled;
            this.chkModerator.Enabled = !this.chkModerator.Enabled;
            this.btnBack.Enabled = !this.btnBack.Enabled;
            this.btnAccept.Enabled = !this.btnAccept.Enabled;
        }
    }
}
