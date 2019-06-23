using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; //required to read XMLs [B]<-- too obvious to comment (don't add comments like that)
using System.Windows.Forms;
using System.IO; //required to save text to file [B]-- too obvious to comment (don't add comments like that)

namespace XML_machine
{
    public partial class Form1 : Form
    {
        OpenFileDialog opener = new OpenFileDialog(); //create "open file" object [B]<-- too obvious to comment (don't add comments like that)

        //Global (class level) constructors:
        string log_file = "";
        string error_log_file = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "XML Machine"; //change app title  [B]<-- too obvious to comment (don't add comments like that) -- it applies to other comments as well.
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; //no resizing
            this.MaximizeBox = false; //no maximizing

            DateTime program_start = DateTime.Now;
            log_file = program_start.ToString("yyyyMMdd_HHmmss") + "_log.txt"; //generate names for log files from time of program launch
            error_log_file = program_start.ToString("yyyyMMdd_HHmmss") + "_error_log.txt";
        }

        private void DisplayConsole(string console_content) //alias to write things in console [B]<-- the method name should be named to something that is obvious enough without the comment
        {
            my_console.Text += console_content;
            File.AppendAllText(log_file, console_content);
        }

        private void DisplayError(string error_msg) //alias to display errors [B]<-- the method name should be named to something that is obvious enough without the comment
        {
            my_console.Text += error_msg;
            File.AppendAllText(error_log_file, error_msg);
            File.AppendAllText(log_file, error_msg);
            MessageBox.Show(error_msg);
        }

        private void Button1_Click(object sender, EventArgs e) //browse button clicked 
        {
            if (opener.ShowDialog() == DialogResult.OK) //display browse window, and if success then:
            {
                file_path.Text = opener.FileName; //display file name in GUI
            }
        }

        private void Enable_Second_Button(object sender, EventArgs e) //enable second button. Triggered by changing value of filename, operation number or operation type.
        {
            if ((file_path.Text != "") && (operation_selector.Text != "") && (counter_box.Text != "")) //if none of required textboxes is blank
            {
                calculate_button.Enabled = true; //user can proceed with calculation
            }
            else
            {
                calculate_button.Enabled = false;
            }
        }

        private void Clear_button_Click(object sender, EventArgs e) //clear console
        {
            my_console.Text = "";
        }

        //global (class level) contructors:
        int no_of_values = 0; //number of <value> elements, read from XML
        int no_of_operations = 0; //number of operations to perform, given by User
        List<int> imported_a = new List<int>(); //list of A values
        List<int> imported_b = new List<int>(); //list of B values

        bool Open_and_read() //as the name suggest, this method is to open and read file. It also launches "calculate" method.
        {
            DisplayConsole($"Opening file:\r\n{file_path.Text}\r\n"); //display msg
            
            try
            {
                no_of_operations = Int32.Parse(counter_box.Text); //counter to count number of "value" elements
            }
            catch //error of parsing counter_box int integer. Probably not a number.
            {
                DisplayError("Error while setting up operations counter. Please input valid integer number.\r\n");
                return false; ; //stop this function
            }
            DisplayConsole("Opening complete.\r\n");

            using (XmlTextReader reader = new XmlTextReader(opener.FileName)) //open file by its name. "Using" means this object will be disposed after being used
            {
                try
                {
                    DisplayConsole("----------\r\n" +
                                   "Reading values...\r\n");

                    while (reader.Read()) //count number of "Value" elements
                    {
                        if (reader.Name == "value")
                        {
                            imported_a.Add(Int32.Parse(reader.GetAttribute("a"))); //read values, parse them to Integer, and save to lists
                            imported_b.Add(Int32.Parse(reader.GetAttribute("b")));
                            DisplayConsole($"Value ({no_of_values})\r\n\ta: {reader.GetAttribute("a")}\r\n\tb: {reader.GetAttribute("b")}\r\n");
                            no_of_values++;
                        }
                    }
                }
                catch //error detected
                {
                    //[B]it makes sense to get some details on the error - what went wrong? Invalid attribute value? Which attribute? No attribute? 
                    DisplayError("Error while reading values from XML file. Please provide valid XML file with valid 'a' and 'b' parameters.\r\n");
                    return false; ; //stop this function
                }
            }
            DisplayConsole("Number of Value elements detected: " + no_of_values + "\r\n");

            //setup progress bar
            progress_bar.Minimum = 0;
            progress_bar.Maximum = no_of_values * no_of_operations;
            progress_bar.Value = 0;
            progress_bar.Step = 1;
            return true;
        }
             
        private void Calculate()
        {
            DisplayConsole("----------\r\n" +
                           "Calculating...\r\n");
            progress_bar.Visible = true;

            //[B]instead of j, k etc you can use better names for the iterator indexing variables (something more obvious for the reader)
            for (int current_value = 0; current_value < no_of_values; current_value++) //calculate as many times as there are "value" elements
            {
                int result = imported_b[current_value]; //reset result

                //[B]use string interpolation rather than concatenation. It reads better:)
                DisplayConsole($"Value ({current_value})\r\n" +
                               $"\tA = {imported_a[current_value]}, " +
                               $"B = {imported_b[current_value]}, " +
                               $"Operation = {operation_selector.Text}, " +
                               $"Number of operations = {no_of_operations}\r\n"); //display things

                switch (operation_selector.Text)
                {
                    case "Multiply":
                        try
                        {
                            for (int current_operation = 0; current_operation < no_of_operations; current_operation++)
                            {
                                DisplayConsole($"\t{imported_a[current_value]} * {result} = {(imported_a[current_value] * result)}\r\n");
                                result = imported_a[current_value] * result;
                                progress_bar.PerformStep();
                            }
                        }
                        catch
                        {
                            DisplayError("Error while multiplying.\r\n");
                            return;
                        }
                        break;

                    case "Divide":
                        try
                        {
                            double f_result = Convert.ToDouble(imported_b[current_value]);
                            for (int current_operation = 0; current_operation < no_of_operations; current_operation++)
                            {
                                DisplayConsole($"\t{Convert.ToDouble(imported_a[current_value])} / {f_result} =  {(Convert.ToDouble(imported_a[current_value]) / f_result)}\r\n");
                                f_result = Convert.ToDouble(imported_a[current_value]) / f_result;
                                progress_bar.PerformStep();
                            }
                        }
                        catch
                        {
                            DisplayError("Error while dividing.\r\n");
                            return;
                        }
                        break;

                    case "Power":
                        try
                        {
                            double d_result = Convert.ToDouble(imported_b[current_value]);
                            for (int current_operation = 0; current_operation < no_of_operations; current_operation++)
                            {
                                DisplayConsole($"\t{imported_a[current_value]} ^ {d_result} = {Math.Pow(Convert.ToDouble(imported_a[current_value]), d_result)}\r\n");
                                d_result = Math.Pow(Convert.ToDouble(imported_a[current_value]), d_result);
                                progress_bar.PerformStep();
                            }
                        }
                        catch
                        {
                            DisplayError("Error while powering.\r\n");
                            return;
                        }
                        break;

                    case "Substract":
                        try
                        {
                            for (int current_operation = 0; current_operation < no_of_operations; current_operation++)
                            {
                                DisplayConsole($"\t{imported_a[current_value]} - {result} = {(imported_a[current_value] - result)}\r\n");
                                result = imported_a[current_value] - result;
                                progress_bar.PerformStep();
                            }
                        }
                        catch
                        {
                            DisplayError("Error while substracting.\r\n");
                            return;
                        }
                        break;

                    default:
                        DisplayError("Error while initializing operation. Please select valid operation from the list.\r\n");
                        return; //by default "break" is needed in every case, including "default". However if "return" is used (which technically makes "break" unreachable) adding "break" is not necessary.
                }
            }
            DisplayConsole("Calculation complete\r\n" +
                           "----------\r\n");
            MessageBox.Show("Job finished!");
            //byebye progress bar
            progress_bar.Value = 0;
            progress_bar.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e) //calculate button clicked [B]<-- this method is too long (it contains too much processing, too many 'logical operations')
        //[B]as a rule of thumb, if a method is too long to fit on screen, split it into smaller methods
        {
            no_of_values = 0; //reset number of <value> elements
            no_of_operations = 0; //reset number of operations to perform
            imported_a = new List<int>(); //reset list of A values
            imported_b = new List<int>(); //reset list of B values

            if(Open_and_read())
            {
                Calculate();
            }
        }
    }
}
