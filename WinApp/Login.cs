using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPC_Tidele
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                new AdministratorRepository().AuthenticateOrFail(this.txtUser.Text.ToString(),
                                                                 this.txtPassword.Text.ToString());

                switch (Session.user.Status.Code)
                {
                    case "A":
                        Layout layout = new Layout();
                        this.Hide();
                        layout.ShowDialog();
                        this.Close();
                        break;
                    case "N":
                        this.ChangeForm();
                        break;
                    default:
                        throw new Exception("Su usuario no está habilitado para ingresar al sistema. Póngase en contacto con un administrador.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtPassword.Text = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPasswordChange.Text.Trim().ToString() != this.txtPasswordChange2.Text.Trim().ToString())
                    throw new Exception("Las contraseñas no son iguales");

                new UserRepository().ChangePassword(this.txtPasswordChange.Text.Trim().ToString());
                this.ChangeForm();
                this.txtPassword.Text = this.txtPasswordChange2.Text.Trim().ToString();
                MessageBox.Show("La contraseña ha sido modificada exitosamente!");
                this.BtnLogin_Click(sender, e);
            }
            catch (Exception ex)
            {
                this.lblPasswordChangeError.Text = ex.Message.ToString();
            }
        }

        private void ChangeForm()
        {
            this.lblPasswordChange.Visible = !this.lblPasswordChange.Visible;
            this.txtPasswordChange.Visible = !this.txtPasswordChange.Visible;
            this.lblPasswordChange2.Visible = !this.lblPasswordChange2.Visible;
            this.txtPasswordChange2.Visible = !this.txtPasswordChange2.Visible;
            this.btnPasswordChange.Visible = !this.btnPasswordChange.Visible;
            this.lblUser.Visible = !this.lblUser.Visible;
            this.txtUser.Visible = !this.txtUser.Visible;
            this.lblPassword.Visible = !this.lblPassword.Visible;
            this.txtPassword.Visible = !this.txtPassword.Visible;
            this.BtnLogin.Visible = !this.BtnLogin.Visible;
        }
    }
}
