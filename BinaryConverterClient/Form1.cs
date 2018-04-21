using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryConverterClient.BinaryConverterService;

namespace BinaryConverterClient
{
    public partial class Form1 : Form
    {
        private BinaryConverterService.BinaryConverterClient service;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            service = new BinaryConverterService.BinaryConverterClient();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                int m = Int32.Parse("abc");
                outputLabel.Text = "Binary format is: " + service.GetBinary(42);
            }
            catch (FormatException err)
            {
                Console.WriteLine(err.Message);
                outputLabel.Text = "Please enter a number";
            }
        }
    }
}
