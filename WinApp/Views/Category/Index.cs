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

namespace TPC_Tidele.Views.Category
{
    public partial class Index : UserControl
    {
        public event EventHandler CategoryIndexAddCategory;
        public event EventHandler CategoryIndexEditCategory;
        public event EventHandler CategoryIndexRemoveCategory;
        private List<Entity.Category> categories;

        public Index()
        {
            InitializeComponent();
            this.UpdateView();
            this.dataGridCategories.Columns[0].Visible = false;
            this.dataGridCategories.Columns[1].Width = 253;
            this.dataGridCategories.Columns[2].Width = 253;
            this.dataGridCategories.Columns[3].Width = 251;
        }

        public void UpdateView()
        {
            this.categories = (new CategoryRepository()).FindAll();
            this.dataGridCategories.DataSource = categories;
            this.dataGridCategories.ResetBindings();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (this.CategoryIndexAddCategory != null)
            {
                this.CategoryIndexAddCategory(this, EventArgs.Empty);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (this.CategoryIndexEditCategory != null)
            {
                this.CategoryIndexEditCategory((Entity.Category)dataGridCategories.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (this.CategoryIndexRemoveCategory != null)
            {
                this.CategoryIndexRemoveCategory((Entity.Category)dataGridCategories.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }
    }
}
