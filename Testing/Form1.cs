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

        Controller c = new Controller();
        public string s = "";
        public int total=0;
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
            c.LoadList();
            textBox2.Text = c.DisplayList();
            textBox1.Text = c.LoadMax();
            label4.Text = "Total Used:";
            label4.Text += c.CalTotal().ToString();
            if (textBox1.Text != "")
            {
                textBox1.ReadOnly = true;
                float avai = c.CalAva();
                PrintStatus(avai);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text)&&(textBox1.ReadOnly==false))
            {
                textBox1.ReadOnly = true;
                c.WriteTotal(textBox1.Text);
                float avai = c.CalAva();
                PrintStatus(avai);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text))
            {
                c.add(DateTime.Now.ToString("MM/dd/yyyy"), textBox3.Text, float.Parse(textBox4.Text));
                c.WriteList();
                textBox2.Text = c.DisplayList();
                label4.Text = "Total Used:";
                label4.Text += c.CalTotal().ToString();
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    float avai = c.CalAva();
                    PrintStatus(avai);
                }
                textBox3.Text = "";
                textBox4.Text = "";
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

        
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '*')
            {
                e.Handled = true;
            }
        }
        public void PrintStatus(float avai)
        {
            if (avai >= 0)
            {
                label6.Text = "";
                label6.Text += avai.ToString();
            }
            else
            {
                label5.Text = "Over " + Math.Abs(avai);
                label6.Text = "";
            }
        }
    }
}
