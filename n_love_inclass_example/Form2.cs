using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace n_love_inclass_example
{
    public partial class Form2 : Form// Form2 extends the Form
    {
        public Form2(string fileName)//added parameter fileName to the initial constructor
        {
            InitializeComponent();

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            //to read from the file
            StreamReader sr = new StreamReader(fs);

            string line;
            //1 line - is until a linebreak.. null - the end of file
            while ((line=sr.ReadLine()) !=null) {
                txtDisplay.Text += line + "\n"; // concatenation for the display form
            }
            //close the filestream and streamreader
            sr.Close();
            fs.Close();
        }
    }
}
