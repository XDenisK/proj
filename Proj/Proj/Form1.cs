using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Под заказ", "Под документ", "Отсутствует" });
            //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            char number = keyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (Char.IsLetterOrDigit(number))
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                listBox1.Items.Add("Товар: --- ");
            }
            else
            {
                listBox1.Items.Add("Товар: " + textBox1.Text);
            }
            if (textBox2.TextLength == 0)
            {
                listBox1.Items.Add("Категория товара: --- ");
            }
            else
            {
                listBox1.Items.Add("Категория товара: " + textBox2.Text);
            }
            if (textBox3.TextLength == 0)
            {
                listBox1.Items.Add("Поставщик: --- ");
            }
            else
            {
                listBox1.Items.Add("Поставщик: " + textBox3.Text);
            }
            if (textBox4.TextLength == 0)
            {
                listBox1.Items.Add("Номер места на складе: --- ");
            }
            else
            {
                listBox1.Items.Add("Номер места на складе: " + textBox4.Text);
            }
            if (textBox5.TextLength == 0)
            {
                listBox1.Items.Add("Количество: --- шт.");
            }
            else
            {
                //if()
                listBox1.Items.Add("Количество: " + textBox5.Text + "   шт.");
            }
            if (comboBox1.Text.Length == 0)
            {
                listBox1.Items.Add("Признак резерва: --- ");
            }
            else
            {
                listBox1.Items.Add("Признак резерва: " + comboBox1.Text);
            }
            listBox1.Items.Add("   ----------------------------------------------");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
            //comboBox2.Items.Clear();
            /*
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex= 0;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker3.CustomFormat = "HH:mm";
           
        }    
        private void Button1_Click(object sender, EventArgs e) //Refresh
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            };
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Regex regex = new Regex(@"[А-Я а-я]+\s[А-Я а-я]+\s[А-Я а-я]+");
                string selectedFile = openFileDialog1.FileName;                
                listBox1.Items.Clear();
                string[] input = File.ReadAllLines(selectedFile);
                for (int i = 0; i < input.Length; i++)
                {
                    if(regex.IsMatch(input[i]))
                    {
                        listBox2.Items.Add(regex.Match(input[i]));
                    }
                }
            }
        }         
        private void Button2_Click(object sender, EventArgs e)//New form 
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
               
                Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            };
            //string[] output = listBox1.Items.ToString().Split('|');
          
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Name = saveFileDialog1.FileName;
                File.WriteAllText(Name, listBox1.Text.ToString());
                using (StreamWriter sw = new StreamWriter(Name))
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        sw.WriteLine(listBox1.Items[i].ToString());
                }
            }   
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            MessageBox.Show("Я бы этим не пользовался");
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Regex regex = new Regex(@"");
                string selectedFile = openFileDialog1.FileName;
                listBox1.Items.Clear();
                string[] input = File.ReadAllLines(selectedFile);
                for (int i = 0; i < input.Length; i++)
                {
                    if (regex.IsMatch(input[i]))
                    {
                        listBox1.Items.Add(regex.Match(input[i]));
                    }
                }
            }
        }

Данил Морозов, [29.12.2022 21:58]
private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            };
        
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Name = saveFileDialog1.FileName;
                File.WriteAllText(Name, listBox1.Text.ToString());
                using (StreamWriter sw = new StreamWriter(Name))
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        sw.WriteLine(listBox1.Items[i].ToString());
                }
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.ShowDialog();
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string s1 = "---", s2 = "---", s3 = "---", s4 = "---", s5 = "---", s6 = "---", s7 = "---", s8 = "---";

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
 
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = listBox2.SelectedItem.ToString();
            s3 = textBox3.Text;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            s1 = listBox1.Items.Count.ToString();
            Regex regexs2 = new Regex(@"[А-Я а-я]+");
            //Город
            if (regexs2.IsMatch(textBox2.Text))
            {
                if (textBox2.TextLength != 0)
                {
                    textBox2.Text = regexs2.Match(textBox2.Text).ToString();
                    s2 = textBox2.Text;
                }          
            }
            Regex regexs3 = new Regex(@"[А-Я а-я]+\s[А-Я а-я]+\s[А-Я а-я]+");
            //ФИО
            if (checkBox1.Checked)
            {
                s4 = checkBox1.Text.ToString();
                checkBox2.Checked = false;
            }
            else
            {
                s4 = checkBox2.Text.ToString();
                checkBox1.Checked = false;
            }                
            if(checkBox1.Checked == false & checkBox2.Checked == false)
            {
                MessageBox.Show("Выберите категорию");
                s4 = "Нет значения";
            }
            s5 = comboBox1.SelectedItem.ToString(); // исправить данное          
            s7 = dateTimePicker2.Text.ToString();
            s8 = dateTimePicker3.Text.ToString();            
            textBox2.Clear();
            textBox3.Clear();                             
            listBox1.Items.Add(s1 + ", " + s2 + ", " + s3 + ", " + s4 + ", " + s5 + ", " + dateTimePicker1.Text.ToString() + ", " + s7 + ", " + s8 + ".");
            
        }
        private void какПользоватьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f1= new Form2();
            f1.ShowDialog();
        }
    }
}
             */
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Regex regex = new Regex(@"[А-Я а-я]+[:]{1}\s[А-Я а-я a-z A-Z 0-9]+");
                string selectedFile = openFileDialog.FileName;
                string[] input = File.ReadAllLines(selectedFile);
                for (int a = 0; a < input.Length; a++)
                {
                    if (regex.IsMatch(input[a]))
                    {
                        listBox1.Items.Add(regex.Match(input[a]));
                        if (input[a] == "Дата поставки:")
                        {
                            listBox1.Items.Add("   ----------------------------------------------");
                        }
                    }
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
