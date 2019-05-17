using Business;
using Domain.User;
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
        AdministratorRepository AdministratorRepository = new AdministratorRepository();

        public Layout()
        {
            InitializeComponent();
        }

        public void SetAdminRepository(AdministratorRepository AdministratorRepository)
        {
            this.AdministratorRepository = AdministratorRepository;
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            this.FillDashboard();
            this.Dashboard.BringToFront();
            this.LoadEvents();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.FillDashboard();
            this.Dashboard.BringToFront();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.UserIndex.UpdateList();
            this.UserIndex.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.Dashboard.txtMusicAdded.Text = (new MusicRepository()).GetRepositoryCount().ToString();
            this.Dashboard.txtVideosAdded.Text = (new VideoRepository()).GetRepositoryCount().ToString();
            this.Dashboard.txtBooksAdded.Text = (new BookRepository()).GetRepositoryCount().ToString();
            this.Dashboard.txtImagesAdded.Text = (new ImageRepository()).GetRepositoryCount().ToString();
        }

        private void LoadEvents()
        {
            this.UserIndex.UserIndexAddUser += new EventHandler(this.UserIndex_AddUser);
            this.UserIndex.UserIndexEditUser += new EventHandler(this.UserIndex_EditUser);
            this.UserIndex.UserIndexRemoveUser += new EventHandler(this.UserIndex_RemoveUser);
            this.UserCreate.GoBack += new EventHandler(this.btnUsers_Click);
            this.UserEdit.GoBack += new EventHandler(this.btnUsers_Click);
        }

        private void UserIndex_AddUser(object sender, EventArgs e)
        {
            this.UserCreate.BringToFront();
        }

        private void UserIndex_EditUser(object sender, EventArgs e)
        {
            this.UserEdit.SetUser(sender as Administrator);
            this.UserEdit.FillForm();
            this.UserEdit.BringToFront();
        }

        private void UserIndex_RemoveUser(object sender, EventArgs e)
        {
            try
            {
                this.AdministratorRepository.RemoveAdmin(sender as Administrator);
                this.UserIndex.UpdateList();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
