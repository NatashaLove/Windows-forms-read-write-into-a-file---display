using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;// for file stream
using n_love_inclass_example;

namespace Example_GUI
{
    public partial class PersonalInformation : Form
    {
        public PersonalInformation()
        {
            InitializeComponent();
        }

        public PersonalInformation(string ID)
        {
            InitializeComponent();
            txtID.Text = ID;
        }

        private void ClearFields()
        {
            if(MessageBox.Show("Are you sure you want to clear the form?", "Confirm Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtErrors.Text = "";
                txtFirstName.Text = "";
                txtMidInit.Text = "";
                txtLastName.Text = "";
                txtAge.Text = "";
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
            if (MessageBox.Show("Are you sure you want to exit this form?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtErrors.Text = "";
            //the boolean checks if the form has errors- if at least one false - 
            //error message will be displayed below (All errors at once by appending eachh text to a string Builder

            bool goodForm = true;
            string id, firstName, midInit, lastName;
            int age = 0;
            StringBuilder sb = new StringBuilder();

            Person p;

            id = txtID.Text;

            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                firstName = "";
                sb.Append("First name cannot be blank.\n");
                goodForm = false;
            }
            else
            {
                firstName = txtFirstName.Text;
            }

            midInit = (String.IsNullOrWhiteSpace(txtMidInit.Text)) ? " " : txtMidInit.Text;

            if(String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lastName = "";
                sb.Append("Last name cannot be blank.\n");
                goodForm = false;
            }
            else
            {
                lastName = txtLastName.Text;
            }

            if(String.IsNullOrWhiteSpace(txtAge.Text))
            {
                sb.Append("Age cannot be blank.\n");
                goodForm = false;
            }
            else
            {
                if(!(Int32.TryParse(txtAge.Text, out age)))
                {
                    sb.Append("Age must be numeric.\n");
                    goodForm = false;
                }
            }
            //if no errors = goodForm:
            if(goodForm)
            {
                try
                {
                    //name will be created later
                    string fileName = "";// "who.txt"

                    //if radio button for student is checked - a student form is created
                    if (radStudent.Checked)
                    {
                        p = new Student(id, firstName, midInit, lastName, age);
                        fileName = "student.txt";
                    }
                    // if not checked - employee form is created
                    else
                    {
                        p = new Employee(id, firstName, midInit, lastName, age);
                        fileName = "employee.txt";
                    }

                    FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                    // Append - adds to the file/ OpenOrcreate - rewrites file

                    StreamWriter sw = new StreamWriter(fs);// tool -class with methods built in to write into a file
                    //object sw will write intofile the info from the p.ToString
                    sw.WriteLine(p.ToString());
                    
                    //need to close StreamWriter and filestream / access to file- or won't be able to use/ write into other files...
                    sw.Close();
                    fs.Close();

                    MessageBox.Show(p.DisplayInformation());
                    Form2 info = new Form2(fileName);
                    info.ShowDialog();

                }
                catch (AgeBelowZeroException ex)
                {
                    txtErrors.Text = ex.Message + "\n";
                }
                catch (Exception ex)
                {
                    txtErrors.Text = ex.Message + "\n";
                }
            }
            else
            {
                txtErrors.Text = sb.ToString();
            }
        }
    }
}
