using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPC_Tidele.Views.User
{
    public partial class Create : UserControl
    {
        public event EventHandler UserCreateGoBack;

        public Create()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.UserCreateGoBack != null)
            {
                this.UserCreateGoBack(this, EventArgs.Empty);
            }
        }
    }
}
