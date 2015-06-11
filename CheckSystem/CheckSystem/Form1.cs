using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckSystem
{
    public partial class Form1 : Form
    {
        public double total;
        public Form1()
        {
            InitializeComponent();
            calway.Items.AddRange(new object[] { "正常收费", "打八折", "满300反100"});
            calway.SelectedIndex = 0;
            label5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalPrices = 0d;
            CashContex cashcontex = new CashContex(calway.SelectedItem.ToString());
            totalPrices = cashcontex.CashResult(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text));

            total = total + totalPrices;
            listBox1.Items.Add("单价: " + textBox1.Text + "数量: " + textBox2.Text + " " + calway.SelectedItem + " 合计： " + totalPrices.ToString());
            label5.Text=total.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label5.Text = "";
            total = 0;
            calway.SelectedIndex = 0;
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
