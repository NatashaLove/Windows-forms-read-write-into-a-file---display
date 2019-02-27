using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_GUI
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            if(MessageBox.Show("Are you sure you want to clear?", "Confirm Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtErrors.Text = "";
                txtID.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtErrors.Text = "";

            if(String.IsNullOrWhiteSpace(txtID.Text))
            {
                txtErrors.Text += "ID Cannot be empty.";
            }
            else
            {
                PersonalInformation personalInformation = new PersonalInformation(txtID.Text);
                personalInformation.ShowDialog();
            }
        }
    }
}
