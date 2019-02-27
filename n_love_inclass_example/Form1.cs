using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// had to add it because it is and all the Forms in a separate folder:
using Example_GUI;

namespace n_love_inclass_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            //this. refers/means Form1
            this.Visible = false;
            StartupForm f = new StartupForm();
            f.ShowDialog();// shows the actual form
            //the showDialog form stays open until it is closed - and code below foesn't run until it is closed

            this.Visible = true; // Visible is a property

        }
    }
}
