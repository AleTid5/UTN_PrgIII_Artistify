using Repository;
using Entity.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.Views;

namespace WinApp
{
    public partial class Layout : Form
    {
        public Layout()
        {
            InitializeComponent();
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            this.Dashboard.UpdateView();
            this.Dashboard.BringToFront();
            this.LoadEvents();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Dashboard.UpdateView();
            this.Dashboard.BringToFront();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.UserIndex.UpdateView();
            this.UserIndex.BringToFront();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            this.CategoryIndex.UpdateView();
            this.CategoryIndex.BringToFront();
        }

        private void btnGenders_Click(object sender, EventArgs e)
        {
            this.GenderIndex.UpdateView();
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
            this.CategoryEdit.SetCategory(sender as Entity.Category);
            this.CategoryEdit.FillForm();
            this.CategoryEdit.BringToFront();
        }

        private void CategoryIndex_RemoveCategory(object sender, EventArgs e)
        {
            try
            {
                (new CategoryRepository()).RemoveCategory(sender as Entity.Category);
                this.CategoryIndex.UpdateView();
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
            this.GenderEdit.SetGender(sender as Entity.Gender);
            this.GenderEdit.FillForm();
            this.GenderEdit.BringToFront();
        }

        private void GenderIndex_RemoveGender(object sender, EventArgs e)
        {
            try
            {
                (new GenderRepository()).Remove(sender as Entity.Gender);
                this.GenderIndex.UpdateView();
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
            this.UserEdit.SetUser(sender as AbstractUser);
            this.UserEdit.FillForm();
            this.UserEdit.BringToFront();
        }

        private void UserIndex_RemoveUser(object sender, EventArgs e)
        {
            try
            {
                new UserRepository().Remove(sender as AbstractUser);                
                this.UserIndex.UpdateView();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
