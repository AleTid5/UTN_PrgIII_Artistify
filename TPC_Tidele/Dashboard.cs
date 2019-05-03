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
    public partial class Dashboard : Form
    {
        public Login LoginParent;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            this.Hide();
            dataAccess.LoginParent = this.LoginParent;
            dataAccess.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.LoginParent.Show();
        }
    }
}
