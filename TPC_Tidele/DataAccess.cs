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

namespace TPC_Tidele
{
    public partial class DataAccess : Form
    {
        public Login LoginParent;

        public DataAccess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.LoginParent = this.LoginParent;
            dashboard.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.LoginParent.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try {
                NationRepository Nation = new NationRepository();
                Random Random = new Random();
                List<String> NationCodes = new List<String>();
                NationCodes.Add("ARG");
                NationCodes.Add("BRA");
                NationCodes.Add("CAN");
                NationCodes.Add("CHL");
                NationCodes.Add("ECU");
                NationCodes.Add("FRA");
                NationCodes.Add("GRC");
                NationCodes.Add("HTI");
                NationCodes.Add("IRN");
                NationCodes.Add("LBY");

                String NationName = Nation.getNation(NationCodes[Random.Next(NationCodes.Count) - 1]).Name;

                MessageBox.Show(NationName);
            }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                NationRepository Nation = new NationRepository();
                int InputCode = int.Parse(this.Txt_PhoneNumber.Text.ToString());
                String NationName = Nation.getNation(InputCode).Name;
                
                MessageBox.Show(NationName);
            }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
