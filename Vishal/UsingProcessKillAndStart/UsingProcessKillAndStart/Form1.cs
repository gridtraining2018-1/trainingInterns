using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UsingProcessKillAndStart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("winword");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("excel");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach(var process in Process.GetProcessesByName(comboBox1.Text))
            {
                process.Kill();
            }
        }
    }
}
