using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zarplata_windows_forms_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8) //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Add(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
            listBox1.Items.Insert(i, textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int received_summ = 0;
            const int quantity_nominals = 11;
            int[] all_nominals_value = new int[quantity_nominals] { 5000, 2000, 1000, 500, 200, 100, 50, 10, 5, 2, 1 };
            string[] each_nominals_quantity_string = new string[quantity_nominals];
            int[] each_nominals_quantity_int = new int[quantity_nominals];

            for (int i = 0; i < quantity_nominals; i++)
            {
                each_nominals_quantity_string[i] = listBox1.Items[i].ToString();
                each_nominals_quantity_int[i] = Convert.ToInt32(each_nominals_quantity_string[i]);
                received_summ += (all_nominals_value[i] * each_nominals_quantity_int[i]);
            }
            textBox2.Text = received_summ.ToString();

        }      
    }
}
