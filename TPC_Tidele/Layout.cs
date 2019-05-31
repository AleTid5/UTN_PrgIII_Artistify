using Repository;
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

        private void btnCategories_Click(object sender, EventArgs e)
        {
            this.CategoryIndex.UpdateList();
            this.CategoryIndex.BringToFront();
        }

        private void btnGenders_Click(object sender, EventArgs e)
        {
            this.GenderIndex.UpdateList();
            this.GenderIndex.BringToFront();
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
            this.CategoryIndex.CategoryIndexAddCategory += new EventHandler(this.CategoryIndex_AddCategory);
            this.CategoryIndex.CategoryIndexEditCategory += new EventHandler(this.CategoryIndex_EditCategory);
            this.CategoryIndex.CategoryIndexRemoveCategory += new EventHandler(this.CategoryIndex_RemoveCategory);
            this.GenderIndex.GenderIndexAddGender += new EventHandler(this.GenderIndex_AddGender);
            this.GenderIndex.GenderIndexEditGender += new EventHandler(this.GenderIndex_EditGender);
            this.GenderIndex.GenderIndexRemoveGender += new EventHandler(this.GenderIndex_RemoveGender);
            this.UserIndex.UserIndexAddUser += new EventHandler(this.UserIndex_AddUser);
            this.UserIndex.UserIndexEditUser += new EventHandler(this.UserIndex_EditUser);
            this.UserIndex.UserIndexRemoveUser += new EventHandler(this.UserIndex_RemoveUser);
            this.CategoryCreate.GoBack += new EventHandler(this.btnCategories_Click);
            this.CategoryEdit.GoBack += new EventHandler(this.btnCategories_Click);
            this.GenderCreate.GoBack += new EventHandler(this.btnGenders_Click);
            this.GenderEdit.GoBack += new EventHandler(this.btnGenders_Click);
            this.UserCreate.GoBack += new EventHandler(this.btnUsers_Click);
            this.UserEdit.GoBack += new EventHandler(this.btnUsers_Click);
        }

        private void CategoryIndex_AddCategory(object sender, EventArgs e)
        {
            this.CategoryCreate.BringToFront();
        }

        private void CategoryIndex_EditCategory(object sender, EventArgs e)
        {
            this.CategoryEdit.SetCategory(sender as Domain.Category);
            this.CategoryEdit.FillForm();
            this.CategoryEdit.BringToFront();
        }

        private void CategoryIndex_RemoveCategory(object sender, EventArgs e)
        {
            try
            {
                (new CategoryRepository()).RemoveCategory(sender as Domain.Category);
                this.CategoryIndex.UpdateList();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GenderIndex_AddGender(object sender, EventArgs e)
        {
            this.GenderCreate.BringToFront();
        }

        private void GenderIndex_EditGender(object sender, EventArgs e)
        {
            this.GenderEdit.SetGender(sender as Domain.Gender);
            this.GenderEdit.FillForm();
            this.GenderEdit.BringToFront();
        }

        private void GenderIndex_RemoveGender(object sender, EventArgs e)
        {
            try
            {
                (new GenderRepository()).RemoveGender(sender as Domain.Gender);
                this.GenderIndex.UpdateList();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
