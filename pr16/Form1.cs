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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
using System.Collections;

namespace pr16
{
    public partial class Form1 : Form
    {
        int i = 0;
        int selected = -1;
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList stud = new ArrayList();
        private void Form1_Load(object sender, EventArgs e)
        {
            DATA();
        }
        private void DATA()
        {
            stud.Clear();
            dataGridView1.Rows.Clear();
            StreamReader sr = new StreamReader("1.txt");
            while (!sr.EndOfStream)
            {
                stud.Add(sr.ReadLine());
            }
            sr.Close();
            foreach (var item in stud)
            {
                string line = item.ToString();
                string[] str = line.Split(',');
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = str[0];
                dataGridView1.Rows[i].Cells[1].Value = str[1];
                dataGridView1.Rows[i].Cells[2].Value = str[2];
                dataGridView1.Rows[i].Cells[3].Value = str[3];
                dataGridView1.Rows[i].Cells[4].Value = str[4];
                i++;
            }
            i = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            selected = index;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string re = textBox5.Text;
            dataGridView1.Rows.Clear();
            int i = 0;
            StreamReader sr = new StreamReader("1.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] str = line.Split(',');
                if (line.Contains(re))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = str[0];
                    dataGridView1.Rows[i].Cells[1].Value = str[1];
                    dataGridView1.Rows[i].Cells[2].Value = str[2];
                    dataGridView1.Rows[i].Cells[3].Value = str[3];
                    dataGridView1.Rows[i].Cells[4].Value = str[4];
                    i++;
                }
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Есть пустое(ые) поле(я)!!!");
            }
            else
            {
                stud.Add($"{textBox1.Text},{textBox2.Text},{textBox3.Text},{textBox4.Text},{textBox6.Text}");
                File.Delete("1.txt");
                foreach (var item in stud)
                {
                    File.AppendAllText("1.txt",item.ToString()+"\n");
                }
                DATA();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Есть пустое(ые) поле(я)!!!");
            }
            else
            {
                int index = selected != -1 ? selected : 0;
                string stroka = $"{textBox1.Text},{textBox2.Text},{textBox3.Text},{textBox4.Text},{textBox6.Text}";
                stud[index] = stroka;
                File.Delete("1.txt");
                foreach (var item in stud)
                {
                    File.AppendAllText("1.txt", item.ToString() + "\n");
                }
                DATA();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = selected != -1 ? selected : 0;
            stud.RemoveAt(index);

            File.Delete("1.txt");
            foreach (var item in stud)
            {
                File.AppendAllText("1.txt", item.ToString() + "\n");
            }
            DATA();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
        }
    }
}
