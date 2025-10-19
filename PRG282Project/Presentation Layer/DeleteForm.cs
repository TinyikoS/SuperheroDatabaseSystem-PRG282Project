using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282Project.Presentation_Layer
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //askes if user is sure about deleting a superhero
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this superhero?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //proceeds to delete superhero

            }
            else
            {
                //cancels deletion
                MessageBox.Show("Superhero Deletion Canceled");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //link to main form
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
