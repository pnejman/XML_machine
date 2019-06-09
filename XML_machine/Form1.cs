using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace XML_machine
{
    public partial class Form1 : Form
    {
        OpenFileDialog opener = new OpenFileDialog(); //create open file object
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "XML Machine";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (opener.ShowDialog() == DialogResult.OK) //display browse window, and if succes then:
            {
                textBox1.Text = opener.FileName; //diplay file name
                button2.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (XmlTextReader reader = new XmlTextReader(opener.FileName)) //open file by its name. Using = well be dosposed after being used
            {
                try //check if file is valid
                {
                    while (reader.Read()) //read the whole file
                    {

                    }
                }

                catch //file is not valid
                {
                    MessageBox.Show("Error. Invalid XML file.");
                }
            }
        }
    }
}
