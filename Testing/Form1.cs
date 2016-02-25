using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.SetBounds(20, 50, 650, 190);
            textBox2.Multiline = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.ReadOnly = true;
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            int total = 0;
            string path = DateTime.Now.ToString("MM/yyyy");
            if (File.Exists(path))
            {
                textBox2.Text = File.ReadAllText(path);
            }
            if (File.Exists("total" + path))
            {
                textBox1.Text = File.ReadAllText("total" + path);
                textBox1.ReadOnly = true;
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                string[] lines = textBox2.Text.ToString().Split('\u000A');
                foreach (string line in lines)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        string[] words = line.Split('*');
                        int num = Int32.Parse(words[2].ToString());
                        total += num;
                    }
                }
            }
            label4.Text = "Total Used:";
            label4.Text += total.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.ReadOnly = true;
                string path ="total"+ DateTime.Now.ToString("MM/yyyy");
                File.WriteAllText(path, textBox1.Text);
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total = Int32.Parse(label4.Text.ToString().Split(':')[1]);
            if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text))
            {
                string s = DateTime.Now.ToString("MM/dd/yyyy") + "*" + textBox3.Text + "*" + textBox4.Text + "\u000D\u000A";
                textBox2.AppendText(s);
                string path = DateTime.Now.ToString("MM/yyyy");
                File.WriteAllText(path, "");
                File.WriteAllText(path, textBox2.Text);
                total += Int32.Parse(textBox4.Text.ToString());
                label4.Text = "Total Used:";
                label4.Text += total.ToString();
            }
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
