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

namespace WinApp.Views.Gender
{
    public partial class Index : UserControl
    {
        public event EventHandler GenderIndexAddGender;
        public event EventHandler GenderIndexEditGender;
        public event EventHandler GenderIndexRemoveGender;
        private List<Entity.Gender> genders;

        public Index()
        {
            InitializeComponent();
            this.UpdateView();
            this.dataGridGenders.Columns[0].Visible = false;
            this.dataGridGenders.Columns[1].Width = 190;
            this.dataGridGenders.Columns[2].Width = 190;
            this.dataGridGenders.Columns[3].Width = 190;
            this.dataGridGenders.Columns[4].Width = 187;
        }

        public void UpdateView()
        {
            this.genders = (new GenderRepository()).FindAll();
            this.dataGridGenders.DataSource = this.genders;
            this.dataGridGenders.ResetBindings();
        }

        private void btnAddGender_Click(object sender, EventArgs e)
        {
            if (this.GenderIndexAddGender != null)
            {
                this.GenderIndexAddGender(this, EventArgs.Empty);
            }
        }

        private void btnEditGender_Click(object sender, EventArgs e)
        {
            if (this.GenderIndexEditGender != null)
            {
                this.GenderIndexEditGender((Entity.Gender)dataGridGenders.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }

        private void btnRemoveGender_Click(object sender, EventArgs e)
        {
            if (this.GenderIndexRemoveGender != null)
            {
                this.GenderIndexRemoveGender((Entity.Gender)dataGridGenders.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }
    }
}
