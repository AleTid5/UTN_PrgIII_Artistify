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
    public partial class Index : UserControl
    {
        public event EventHandler UserIndexAddUser;
        private List<Administrator> administrators = (new AdministratorRepository()).FindAll();

        public Index()
        {
            InitializeComponent();
            this.dataGridUsers.DataSource = administrators;
            this.dataGridUsers.Columns[4].Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.UserIndexAddUser != null)
            {
                this.UserIndexAddUser(this, EventArgs.Empty);
            }
        }
    }
}
