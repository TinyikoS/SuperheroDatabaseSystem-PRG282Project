using PRG282Project.Data_Layer;
using PRG282Project.LogicLayer;
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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //link to main form
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHeroID.Text))
                {
                    MessageBox.Show("Please enter a Hero ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Please enter a Full Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbSuperpower.Text))
                {
                    MessageBox.Show("Please select a Super power.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Hero updatedHero = new Hero(
                    txtHeroID.Text.Trim(),
                    txtFullName.Text.Trim(),
                    (int)nupAge.Value,
                    cmbSuperpower.Text,
                    (int)nupExamScore.Value
                    );

                FileHandler filehandler = new FileHandler();
                bool succcess = filehandler.UpdateHero(updatedHero);

                if (succcess)
                {
                    MessageBox.Show("Hero has been successfully updated");

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to update Hero");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }
        
        private void ClearForm()
        {
            txtHeroID.Clear();
            txtFullName.Clear();
            nupAge.Value = 16;
            cmbSuperpower.SelectedIndex = -1;
            nupExamScore.Value = 0;
        }
    }
}
