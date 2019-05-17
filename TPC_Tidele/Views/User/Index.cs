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
        public event EventHandler UserIndexEditUser;
        public event EventHandler UserIndexRemoveUser;
        private List<Administrator> administrators;

        public Index()
        {
            InitializeComponent();
            this.UpdateList();
            this.dataGridUsers.Columns[4].Visible = false;
        }

        public void UpdateList()
        {
            this.administrators = (new AdministratorRepository()).FindAll();
            this.dataGridUsers.DataSource = administrators;
            this.dataGridUsers.ResetBindings();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.UserIndexAddUser != null)
            {
                this.UserIndexAddUser(this, EventArgs.Empty);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (this.UserIndexEditUser != null)
            {
                this.UserIndexEditUser((Administrator)dataGridUsers.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (this.UserIndexRemoveUser != null)
            {
                this.UserIndexRemoveUser((Administrator)dataGridUsers.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }
    }
}
