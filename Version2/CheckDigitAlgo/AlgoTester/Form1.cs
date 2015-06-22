using System;
using System.Windows.Forms;
using CheckDigitAlgo;

namespace AlgoTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            object result = null;

            if(comboBox1.SelectedItem.Equals("Innove"))
            {
                result =  Globe.CheckDigitInnove(Convert.ToInt32(textBox1.Text));
            }
            if(comboBox1.SelectedItem.Equals("Globe Handy"))
            { 
                result = Globe.CheckDigitGlobeHandy(Convert.ToInt32(textBox1.Text));
            }
            if (comboBox1.SelectedItem.Equals("Asialink"))
            {
                result = Globe.CheckAsialink(textBox1.Text);
            }
            if (comboBox1.SelectedItem.Equals("VECO"))
            {
                result = Globe.CheckDigitVeco(textBox1.Text);
            }
            if (comboBox1.SelectedItem.Equals("PLDT"))
            {
                result = Globe.CheckDigitPLDT(textBox1.Text);
            }  

            MessageBox.Show(result.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Innove");
            comboBox1.Items.Add("Globe Handy");
            comboBox1.Items.Add("Asialink");
            comboBox1.Items.Add("VECO");
            comboBox1.Items.Add("PLDT");
        }
    }
}
