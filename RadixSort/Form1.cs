
namespace RadixSort
{
    // C# program for the above approach
    using System;
    using System.Collections.Generic;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.InputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(12, 45);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputBox.Size = new System.Drawing.Size(303, 440);
            this.OutputBox.TabIndex = 0;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculateButton.Location = new System.Drawing.Point(177, 10);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(138, 29);
            this.CalculateButton.TabIndex = 1;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(12, 10);
            this.InputBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.InputBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(150, 27);
            this.InputBox.TabIndex = 2;
            this.InputBox.ThousandsSeparator = true;
            this.InputBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(327, 497);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.OutputBox);
            this.MaximumSize = new System.Drawing.Size(345, 544);
            this.MinimumSize = new System.Drawing.Size(345, 544);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InputBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool[] prime_status_array = new bool[1000000];
        private int[] prime_status_count = new int[1000000];
        private int[] prime_status_count1 = new int[1000000];
        private int[] prime_status_count2 = new int[1000000];
        private int[] prime_status_count3 = new int[1000000];


        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int input_number;

            for (int i = 0; i < prime_status_array.Length; i++)
            {
                prime_status_array.SetValue(false, i);
                prime_status_count.SetValue(0, i);
                prime_status_count1.SetValue(0, i);
                prime_status_count2.SetValue(0, i);
                prime_status_count3.SetValue(0, i);
            }

            input_number = (int)InputBox.Value;

            check_prime_2(input_number);

            int total_count = 0;
            OutputBox.Text += "Result\r\n";
            for (int i = 0; i <= input_number; i++)
            {
                if (prime_status_array[i] == true)
                {
                    OutputBox.Text += i.ToString() + "\r\n";
                    total_count++;
                }
            }
            OutputBox.Text += "Total: " + total_count.ToString();
        }


        private void check_prime_1(int n)
        {
            prime_status_array[2] = true;
            prime_status_array[3] = true;

            int number;

            for (int x = 1; x < Math.Sqrt(n); x++)
            {
                for (int y = 1; y < Math.Sqrt(n); y++)
                {
                    //first
                    number = 4 * (int)Math.Pow(x, 2) + (int)Math.Pow(y, 2);
                    if (number < n && (number % 12 == 1 || number % 12 == 5))
                    {
                        prime_status_count1[number]++;
                    }

                    //second
                    number = 3 * (int)Math.Pow(x, 2) + (int)Math.Pow(y, 2);
                    if (number < n && number % 6 == 1)
                    {
                        prime_status_count2[number]++;
                    }

                    //third
                    number = 3 * (int)Math.Pow(x, 2) - (int)Math.Pow(y, 2);
                    if (number < n && number % 12 == 11)
                    {
                        prime_status_count3[number]++;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (prime_status_count1[i] % 2 == 1 || prime_status_count2[i] % 2 == 1 || prime_status_count3[i] % 2 == 1)
                {
                    prime_status_array[i] = true;
                }
            }

            //Exclude squares
            for (int i = 0; i < Math.Sqrt(n); i++)
            {
                int square = i * i;
                if (prime_status_array[square])
                {
                    for (int temp_value = square; temp_value < n; temp_value += square)
                    {
                        prime_status_array[temp_value] = false;
                    }
                }
            }

            OutputBox.Text = "Debug\r\n";

            for (int i = 0; i < n; i++)
            {
                if (prime_status_count1[i] % 2 == 1 || prime_status_count2[i] % 2 == 1 || prime_status_count3[i] % 2 == 1)
                {
                    OutputBox.Text += "Condition " + i.ToString() + "\r\n";
                    OutputBox.Text += "Counts " + prime_status_count1[i].ToString() + " " + prime_status_count2[i].ToString() + " " + prime_status_count3[i].ToString() + "\r\n";
                    OutputBox.Text += "Array " + prime_status_array[i].ToString() + "\r\n\r\n";
                }
                else
                {
                    OutputBox.Text += "No condition " + i.ToString() + "\r\n";
                    OutputBox.Text += "Counts " + prime_status_count1[i].ToString() + " " + prime_status_count2[i].ToString() + " " + prime_status_count3[i].ToString() + "\r\n";
                    OutputBox.Text += "Array " + prime_status_array[i].ToString() + "\r\n\r\n";
                }
            }
        }


        private void check_prime_2(int n)
        {
            for (int i = 0; i < prime_status_array.Length; i++)
            {
                prime_status_array.SetValue(true, i);
            }

            for (int x = 2; x <= n; x++)
            {
                if (prime_status_array[x] == true)
                {
                    for (int y = 2 * x; y <= n; y += x)
                    {
                        prime_status_array[y] = false;
                    }
                }
            }

            OutputBox.Text = "Debug\r\n";

        }

    }
}