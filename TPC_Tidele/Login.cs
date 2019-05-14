using Business;
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
                List<String> userData = new List<String> {
                    this.txtUser.Text.ToString(),
                    this.txtPassword.Text.ToString()
                };

                AdministratorRepository administratorRepository = new AdministratorRepository();
                administratorRepository.AuthenticateOrFail(userData);

                Layout layout = new Layout();
                this.Hide();
                layout.ShowDialog();
                this.Close();
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
    }
}
