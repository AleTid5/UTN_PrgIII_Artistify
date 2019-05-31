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

namespace TPC_Tidele.Views.Gender
{
    public partial class Index : UserControl
    {
        public event EventHandler GenderIndexAddGender;
        public event EventHandler GenderIndexEditGender;
        public event EventHandler GenderIndexRemoveGender;
        private List<Domain.Gender> genders;

        public Index()
        {
            InitializeComponent();
            this.UpdateList();
        }

        public void UpdateList()
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
                this.GenderIndexEditGender((Domain.Gender)dataGridGenders.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }

        private void btnRemoveGender_Click(object sender, EventArgs e)
        {
            if (this.GenderIndexRemoveGender != null)
            {
                this.GenderIndexRemoveGender((Domain.Gender)dataGridGenders.CurrentRow.DataBoundItem, EventArgs.Empty);
            }
        }
    }
}
