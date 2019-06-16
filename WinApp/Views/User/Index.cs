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
using Repository;

namespace WinApp.Views.User
{
    public partial class Index : UserControl
    {
        public event EventHandler UserIndexAddUser;
        public event EventHandler UserIndexEditUser;
        public event EventHandler UserIndexRemoveUser;

        public Index()
        {
            InitializeComponent();
            this.UpdateView();
            this.dataGridUsers.Columns[0].Visible = false;
            this.dataGridUsers.Columns[4].Visible = false;
        }

        public void UpdateView()
        {
            this.dataGridUsers.DataSource = new UserRepository().FindAll(new List<String>{ "Administrators", "Moderators" });
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
                this.UserIndexEditUser((AbstractUser)dataGridUsers.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (this.UserIndexRemoveUser != null)
            {
                this.UserIndexRemoveUser((AbstractUser)dataGridUsers.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }
    }
}
