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
    public partial class DataAccess : Form
    {
        public Login LoginParent;

        public DataAccess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.LoginParent = this.LoginParent;
            dashboard.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.LoginParent.Show();
        }
    }
}
