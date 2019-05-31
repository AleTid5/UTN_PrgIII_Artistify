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
using Repository;

namespace TPC_Tidele.Views.Category
{
    public partial class Index : UserControl
    {
        public event EventHandler CategoryIndexAddCategory;
        public event EventHandler CategoryIndexEditCategory;
        public event EventHandler CategoryIndexRemoveCategory;
        private List<Domain.Category> categories;

        public Index()
        {
            InitializeComponent();
            this.UpdateList();
        }

        public void UpdateList()
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
                this.CategoryIndexEditCategory((Domain.Category)dataGridCategories.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (this.CategoryIndexRemoveCategory != null)
            {
                this.CategoryIndexRemoveCategory((Domain.Category)dataGridCategories.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }
    }
}
