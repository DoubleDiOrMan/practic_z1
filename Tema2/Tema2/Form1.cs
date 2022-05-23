using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Summa(double x, double e, out int n, out double s)
        {
            if (Math.Abs(x) > 1)
                throw new ArgumentException("Аргумент x задан неверно", "Ошибка");
            if (e <= 0 || e >= 1)
                throw new ArgumentException("Точность задана неверно", "Ошибка");

            s = 0;
            double current = -x, next = 0;
            n = 0;

            while (Math.Abs(current / next) > e)
            {
                s += current;
                n++;
                next = current;
                current *= (x * x - 2 * n * x * x / (2 * n + 1));
            }

            s = (Math.PI/2) - s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            double x, eps;
            label3.Text = "";

            try
            {
                eps = Convert.ToDouble(textBox1.Text);
                x = Convert.ToDouble(textBox2.Text);
                double Summ;
                Summa(x, eps, out count, out Summ);
                label3.Text = "arcctg = " + (Math.PI / 2 - Math.Atan(x)) + "\nСумма ряда = " + Summ + "\nКоличество членов ряда = " + count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar == '\b'
            || (Char.IsNumber(e.KeyChar)
            || (!textBox1.Text.Contains(',') && e.KeyChar == ',' && textBox1.TextLength >= 1)
            || (!textBox1.Text.Contains(',') && e.KeyChar == ',' && textBox1.TextLength >= 2)))
            {

            }
            else
            {
                e.Handled = true;
            }
        }
         
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar == '\b'
           || (Char.IsNumber(e.KeyChar) || (e.KeyChar == '-' && textBox2.TextLength == 0)
           || (!textBox2.Text.Contains(',') && e.KeyChar == ',' && textBox2.TextLength >= 1 && !textBox2.Text.Contains('-'))
           || (!textBox2.Text.Contains(',') && e.KeyChar == ',' && textBox2.TextLength >= 2 && textBox2.Text.Contains('-'))))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
