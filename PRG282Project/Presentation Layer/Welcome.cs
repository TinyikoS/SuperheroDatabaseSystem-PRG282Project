using PRG282Project.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282Project
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //link to main form
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //exit program
            Application.Exit();
        }
    }
}
