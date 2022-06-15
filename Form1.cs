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

namespace UKOL1506
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            int soucet = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                StreamWriter streamWriter = new StreamWriter("cisla.txt");
                while (!streamReader.EndOfStream)
                {
                    int soucetRadek = 0;
                    string s = streamReader.ReadLine();
                    streamWriter.WriteLine(s);
                    listBox1.Items.Add(s);
                    char[] mezery = { ' ', '\t' };
                    string[] pole = s.Split(mezery);

                    for (int i = 0; i < pole.Count(); i++)
                    {
                        int cisla = Convert.ToInt32(pole[i]);
                        soucet += cisla;
                        soucetRadek += cisla;
                    }
                    listBox2.Items.Add("Soucet na radku: " + soucetRadek);
                }
                streamReader.Close();
                streamWriter.WriteLine("Celkovy soucet: " + soucet);
                streamWriter.Close();

                File.Delete(openFileDialog1.FileName);
                File.Move("cisla.txt", openFileDialog1.FileName);
                StreamReader streamReader1 = new StreamReader(openFileDialog1.FileName);
                while (!streamReader1.EndOfStream)
                {
                    string s = streamReader1.ReadLine();
                    listBox3.Items.Add(s);
                }
                streamReader1.Close();
            }
        }
    }
}
