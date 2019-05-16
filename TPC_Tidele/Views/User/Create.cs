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

namespace TPC_Tidele.Views.User
{
    public partial class Create : UserControl
    {
        public event EventHandler UserCreateGoBack;
        // private List<Nations>

        public Create()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.UserCreateGoBack != null)
            {
                this.UserCreateGoBack(this, EventArgs.Empty);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Administrator administrator = new Administrator();
                NationRepository nationRepository = new NationRepository();
                administrator.Name = txtName.Text.ToString().Trim();
                administrator.LastName = txtLastName.Text.ToString().Trim();
                administrator.Email = txtEmail.Text.ToString().Trim();
                administrator.BornDate = dateBornDate.Value;
                administrator.Gender = radioF.Checked ? 'F' : radioM.Checked ? 'M' : 'O';
                administrator.Nationality = nationRepository.getNation(comboNationality.SelectedValue.ToString());
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
