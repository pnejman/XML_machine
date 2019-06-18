namespace XML_machine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browse_button = new System.Windows.Forms.Button();
            this.file_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.operation_selector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.counter_box = new System.Windows.Forms.TextBox();
            this.calculate_button = new System.Windows.Forms.Button();
            this.my_console = new System.Windows.Forms.TextBox();
            this.clear_button = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(21, 42);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 0;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.Button1_Click);
            // 
            // file_path
            // 
            this.file_path.Location = new System.Drawing.Point(113, 45);
            this.file_path.Name = "file_path";
            this.file_path.ReadOnly = true;
            this.file_path.Size = new System.Drawing.Size(459, 20);
            this.file_path.TabIndex = 1;
            this.file_path.TextChanged += new System.EventHandler(this.Enable_Second_Button);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select operation:";
            // 
            // operation_selector
            // 
            this.operation_selector.FormattingEnabled = true;
            this.operation_selector.Items.AddRange(new object[] {
            "Multiply",
            "Divide",
            "Power",
            "Substract"});
            this.operation_selector.Location = new System.Drawing.Point(113, 95);
            this.operation_selector.Name = "operation_selector";
            this.operation_selector.Size = new System.Drawing.Size(186, 21);
            this.operation_selector.TabIndex = 3;
            this.operation_selector.TextChanged += new System.EventHandler(this.Enable_Second_Button);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of operations:";
            // 
            // counter_box
            // 
            this.counter_box.Location = new System.Drawing.Point(472, 95);
            this.counter_box.Name = "counter_box";
            this.counter_box.Size = new System.Drawing.Size(100, 20);
            this.counter_box.TabIndex = 5;
            this.counter_box.TextChanged += new System.EventHandler(this.Enable_Second_Button);
            // 
            // calculate_button
            // 
            this.calculate_button.Enabled = false;
            this.calculate_button.Location = new System.Drawing.Point(21, 149);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(75, 23);
            this.calculate_button.TabIndex = 6;
            this.calculate_button.Text = "Calculate";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.Button2_Click);
            // 
            // my_console
            // 
            this.my_console.Location = new System.Drawing.Point(21, 187);
            this.my_console.Multiline = true;
            this.my_console.Name = "my_console";
            this.my_console.ReadOnly = true;
            this.my_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.my_console.Size = new System.Drawing.Size(551, 251);
            this.my_console.TabIndex = 7;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(113, 149);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(90, 23);
            this.clear_button.TabIndex = 8;
            this.clear_button.Text = "Clear console";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title_label.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.title_label.Location = new System.Drawing.Point(412, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(160, 20);
            this.title_label.TabIndex = 9;
            this.title_label.Text = "XML Machine v.1.1";
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(21, 454);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(551, 21);
            this.progress_bar.TabIndex = 10;
            this.progress_bar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 489);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.my_console);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.counter_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.operation_selector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.file_path);
            this.Controls.Add(this.browse_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox operation_selector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox counter_box;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.TextBox my_console;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.ProgressBar progress_bar;
    }
}

