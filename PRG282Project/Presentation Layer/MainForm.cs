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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //link to welcome form
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //link to Insert Form
            InsertForm insertForm = new InsertForm();
            insertForm.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //link to Update Form
            UpdateForm updateForm = new UpdateForm();
            updateForm.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //link to Delete Form
            DeleteForm deleteForm = new DeleteForm();
            deleteForm.Show();
            this.Hide();
        }
    }
}
