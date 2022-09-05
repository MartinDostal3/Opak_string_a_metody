using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opak_string_a_metody
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            int pocetRadku = textBox1.Lines.Count();
            string[] p = new string[pocetRadku];
            listBox1.Items.Clear();
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                string radek = textBox1.Lines[i];
                char[] oddelovace = { ',', ' ', '.' };
                string[] slova = radek.Split(oddelovace, StringSplitOptions.RemoveEmptyEntries);
                string nejkratsiSlovo = slova[0];
                for (int j = 0; j < slova.Length; j++)
                {
                    if (slova[j].Length < nejkratsiSlovo.Length)
                    {
                        nejkratsiSlovo = slova[j];
                    }
                }
                p[i] = nejkratsiSlovo;
                listBox1.Items.Add(p[i]);
            }
        }

        void ZpracujPole(string[] pole, string podretezec, out string prvnisCifrou, out string posledniKonci)
        {
            prvnisCifrou = string.Empty;
            posledniKonci = string.Empty;
            bool nalCif = false;
            for (int i = 0; i < pole.Length; i++)
            {
                string slovo = pole[i];
                for (int j = 0; j < slovo.Length && !nalCif; j++)
                {
                    if (char.IsNumber(slovo[j]))
                    {
                        prvnisCifrou = slovo;
                        nalCif = true;
                    }
                }
                if (slovo.EndsWith(podretezec))
                {
                    posledniKonci = slovo;
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] pole = { "Bohdan", "S0S", "Jablko", "Oko","haf","aha", "Břenek" };
            string podretezec = "ha";
            string prvnisCifrou = string.Empty;
            string posledniKonci = string.Empty;
            ZpracujPole(pole, podretezec, out prvnisCifrou, out posledniKonci);
            MessageBox.Show("První slovo obsahující cifru je: " + prvnisCifrou);
            MessageBox.Show("Poslední řetězec končící zadaným podřetězcem je: " + posledniKonci);


        }
    }
}
