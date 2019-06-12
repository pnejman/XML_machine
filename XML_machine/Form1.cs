using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; //required to read XMLs
using System.Windows.Forms;
using System.IO; //required to save text to file

namespace XML_machine
{
    public partial class Form1 : Form
    {
        OpenFileDialog opener = new OpenFileDialog(); //create "open file" object

        public Form1()
        {
            InitializeComponent();
            this.Text = "XML Machine"; //change app title
            File.WriteAllText("log.txt", ""); //clear log files
            File.WriteAllText("error_log.txt", "");
        }

        private void Display(string to_display) //alias to write things in console
        {
            my_console.Text += to_display;
            File.AppendAllText("log.txt", to_display);
        }

        private void DisplayError(string to_display) //alias to display errors
        {
            my_console.Text += to_display;
            File.AppendAllText("error_log.txt", to_display);
            MessageBox.Show(to_display);

        }

        private void Button1_Click(object sender, EventArgs e) //browse button clicked
        {
            if (opener.ShowDialog() == DialogResult.OK) //display browse window, and if success then:
            {
                file_path.Text = opener.FileName; //display file name in GUI
            }
        }

        private void Enable_Second_Button(object sender, EventArgs e) //enable second button
        {
            if ((file_path.Text != "") && (operation_selector.Text != "")) //if none of required textboxes is blank
            {
                calculate_button.Enabled = true; //user can proceed with calculation
            }
        }

        private void Button2_Click(object sender, EventArgs e) //calculate button clicked
        {
            Display("Opening file:\r\n" + file_path.Text + "\r\n"); //display msg
            int value_elements = 0; //counter to count number of "value" elements
            List<int> imported_a = new List<int>(); //list of A values
            List<int> imported_b = new List<int>(); //list of B values

            using (XmlTextReader reader = new XmlTextReader(opener.FileName)) //open file by its name. "Using" means this object well be disposed after being used
            {
                try //watch for errors
                {
                    Display("Opening complete.\r\n----------\r\nReading values...\r\n");

                    while (reader.Read()) //count number of "Value" elements
                    {
                        if (reader.Name == "value")
                        {
                            imported_a.Add(Int32.Parse(reader.GetAttribute("a"))); //read values, parse them to Integer, and save to lists
                            imported_b.Add(Int32.Parse(reader.GetAttribute("b")));
                            Display("Value (" + value_elements + ")\r\n\ta: " + reader.GetAttribute("a") + "\r\n\tb: " + reader.GetAttribute("b") + "\r\n");
                            value_elements++;
                        }
                    }

                    Display("Number of 'Value' elements detected: " + value_elements + "\r\n");
                    counter_box.Text = "" + value_elements;
                }
                catch //error detected
                {
                    DisplayError("Error while processing XML file.\r\n");
                    return; //stop this function
                }
            }

            Display("----------\r\nCalculating...\r\n");
            for (int j = 0; j < value_elements; j++) //calculate as many times as there are "value" elements
            {
                int result = imported_b[j]; //reset result
                Display("Value (" + j + ")\r\n\tA = " + imported_a[j] +", B = "+ imported_b[j] + ", Operation = " + operation_selector.Text +", Number of operations = "+value_elements+"\r\n"); //display things

                switch (operation_selector.Text)
                {
                    case "Multiply":
                        try
                        {
                            for (int k = 0; k < value_elements; k++)
                            {
                                Display("\t" + imported_a[j] + " * " + result + " = " + (imported_a[j] * result) + "\r\n");
                                result = imported_a[j] * result;
                            }
                        }
                        catch
                        {
                            DisplayError("Error while multiplying.\r\n");
                        }
                        break;

                    case "Divide":
                        try
                        {
                            double f_result = Convert.ToDouble(imported_b[j]);
                            for (int k = 0; k < value_elements; k++)
                            {
                                Display("\t" + Convert.ToDouble(imported_a[j]) + " / " + f_result + " = " + (Convert.ToDouble(imported_a[j]) / f_result) + "\r\n");
                                f_result = Convert.ToDouble(imported_a[j]) / f_result;
                            }
                        }
                        catch
                        {
                            DisplayError("Error while dividing.\r\n");
                        }
                        break;

                    case "Power":
                        try
                        {
                            double d_result = Convert.ToDouble(imported_b[j]);
                            for (int k = 0; k < value_elements; k++)
                            {
                                Display("\t" + imported_a[j] + " ^ " + d_result + " = " + Math.Pow(Convert.ToDouble(imported_a[j]), d_result) + "\r\n");
                                d_result = Math.Pow(Convert.ToDouble(imported_a[j]), d_result);
                            }
                        }
                        catch
                        {
                            DisplayError("Error while powering.\r\n");
                        }
                        break;

                    case "Substract":
                        try
                        {
                            for (int k = 0; k < value_elements; k++)
                            {
                                Display("\t" + imported_a[j] + " - " + result + " = " + (imported_a[j] - result) + "\r\n");
                                result = imported_a[j] - result;
                            }
                        }
                        catch
                        {
                            DisplayError("Error while substracting.\r\n");
                        }
                        break;
                }
            }
            Display("Calculation complete\r\n----------\r\n");
        }

        private void Clear_button_Click(object sender, EventArgs e) //clear console
        {
            my_console.Text = "";
            Display("Console screen has been cleared.\r\n");
        }
    }
}
