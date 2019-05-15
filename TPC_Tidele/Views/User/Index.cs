using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPC_Tidele.Views.User
{
    public partial class Index : UserControl
    {
        public event EventHandler UserIndexAddUser;

        public Index()
        {
            InitializeComponent();
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
