using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaja_Tabela
{

    public partial class Form1 : Form
    {

        Tab tabelca = new Tab();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            tabelca.dodaj(Convert.ToInt32(textBox1.Text));
            label1.Text = tabelca.ToString();
        }

        private void vsebujeButton_Click(object sender, EventArgs e)
        {
            bool statement = tabelca.vsebuje(Convert.ToInt32(textBox1.Text));
            if (statement == true)
            {
                MessageBox.Show("Tabelca vsebuje element " + textBox1.Text);
            }
            else
            {
                MessageBox.Show("Tabelca ne vsebuje element " + textBox1.Text);
                
            }
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Najmanjsa stevila je: " + tabelca.min() + " ejga Joža!");
        }

        private void maxButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Največja stevila je: " + tabelca.max() + " ejga Joža!");
        }

        private void vsotaButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vsota vseh stevil je: " + tabelca.vsota() + " ejga Joža!");
        }

        private void povprecjeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Povprečje vseh stevil je: " + tabelca.povprecje() + " ejga Joža!");
        }
    }

    public class Tab
    {
        private int[] tabela = new int[100];
        public int dolzina = 0;

        // Metode

        public void dodaj(int x)
        {
            tabela[dolzina] = x;
            dolzina++;
        }

        public bool vsebuje(int x)
        {
            for (int i = 0; i < dolzina; i++)
            {
                if (x == tabela[i])
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string besedica = "";

            for(int i = 0; i< dolzina; i++)
            {
                besedica += tabela[i] + ", ";
            }

            return besedica;
        }

        public int vsota(){

            int _vsota = 0;

            for (int i = 0; i < dolzina; i++)
            {
                _vsota += tabela[i];
            }

            return _vsota;
        }

        public int min()
        {
            int _min = tabela[0];

            for (int i = 0; i < dolzina; i++)
            {
                if(_min > tabela[i])
                {
                    _min = tabela[i];
                }
            }

            return _min;

        }

        public int max()
        {
            int _max = tabela[0];

            for (int i = 0; i < dolzina; i++)
            {
                if (_max < tabela[i])
                {
                    _max = tabela[i];
                }
            }

            return _max;

        }

        public double povprecje()
        {
            
            return Convert.ToDouble(vsota()) / Convert.ToDouble(dolzina);
        }


    }
}
