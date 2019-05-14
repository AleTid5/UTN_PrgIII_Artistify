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
using TPC_Tidele.Views;

namespace TPC_Tidele
{
    public partial class Layout : Form
    {
        public Layout()
        {
            InitializeComponent();
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            this.FillDashboard();
            this.Dashboard.BringToFront();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.UserIndex.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.FillDashboard();
            this.Dashboard.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close()  ;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void FillDashboard()
        {
            this.Dashboard.txtMusicAdded.Text  = (new MusicRepository()).GetRepositoryCount().ToString();
            this.Dashboard.txtVideosAdded.Text = (new VideoRepository()).GetRepositoryCount().ToString();
            this.Dashboard.txtBooksAdded.Text  = (new BookRepository()).GetRepositoryCount().ToString();
            this.Dashboard.txtImagesAdded.Text = (new ImageRepository()).GetRepositoryCount().ToString();
        }
    }
}
