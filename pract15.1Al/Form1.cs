using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace pract15._1Al
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pocht ad = new Pocht();
        ArrayList p = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || numericUpDown1.Value == 100000)
            {
                MessageBox.Show("Есть пустые поля");
            }
            else
            {
                int indexToSelect = listBox1.SelectedIndex;
                listBox1.SetSelected(indexToSelect, true);
                listBox1.Items[indexToSelect] = $"Улица: {textBox1.Text}, Город: {textBox2.Text}, Область: {textBox3.Text}, Код: {numericUpDown1.Value}";
                string[] lines = File.ReadAllLines("1.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i==indexToSelect)
                    {
                        lines[i] = $"Улица: {textBox1.Text}, Город: {textBox2.Text}, Область: {textBox3.Text}, Код: {numericUpDown1.Value}";
                    }
                }
                File.WriteAllLines("1.txt", lines);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("1.txt"))
            {
                StreamReader sw = File.OpenText("1.txt");
                while (!sw.EndOfStream)
                {
                   string st = sw.ReadLine();
                   p.Add(st);
                }
                sw.Close();
                foreach (string r in p)
                {
                    listBox1.Items.Add(r);
                }
            }
            else
            {
                MessageBox.Show("Файла нет");
            }
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            p.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.Value=100000;
            button2.Enabled = true;
        }
    }
}
