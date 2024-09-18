using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Шифр_Виженера
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] ruLang = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            
            List<int> textOne = new List<int>();
            List<int> textTwo = new List<int>();
            List<int> textThree = new List<int>();
            List<int> key = new List<int>();

            textBox3.Text = "";

            foreach (var bukva in textBox1.Text)
                for (int i = 0; i < ruLang.Length; i++)
                    if (bukva == ruLang[i]) { textOne.Add(i); break; } else if (bukva == ' ') { textThree.Add(textOne.Count); break; }

            foreach (var bukva in textBox2.Text)
                for (int i = 0; i < ruLang.Length; i++)
                    if (bukva == ruLang[i]) { key.Add(i); break; } else if (bukva == ' ') { key.Add(-1); break; }

            for (int i = 0; i < textOne.Count; i++)
                textTwo.Add((textOne[i] + key[i % key.Count]) % ruLang.Length);
            
            for (int i = 0; i < textTwo.Count; i++)
            {
                foreach (var probel in textThree)
                    if (i == probel) textBox3.Text += " ";

                textBox3.Text += $"{ruLang[textTwo[i]]}";
            }
            
        }
    }
}
