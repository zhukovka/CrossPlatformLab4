using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryConverterAppClient.BinaryConverterServiceReference;

namespace BinaryConverterAppClient
{
    public partial class Form1 : Form
    {
        private BinaryConverterClient service;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            service = new BinaryConverterClient();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                int m = Int32.Parse(inputBox.Text);
                string binary = service.GetBinary(m);
                string oneCount = service.GetOneCount(m);
                MessageBox.Show($"Binary of {m} is {binary}. It has {oneCount} of 1");
            }
            catch (FormatException err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
