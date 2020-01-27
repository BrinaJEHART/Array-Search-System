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
            textBox1.Clear();
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

        private void binaryButton_Click(object sender, EventArgs e)
        {

            try
            {
                int y = tabelca.binarno(Convert.ToInt32(textBox1.Text));
                
                if (y == -2)
                {
                    MessageBox.Show("Tabela ni urejena.");
                }
                else if (y == -1)
                {
                    MessageBox.Show("Element ni v tabeli");

                }
                else
                {
                    MessageBox.Show("Binarno: " + y);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Prišlo je do napake ejga Joža!");

            }

   
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

        public bool urejeno()
        {
            int item = tabela[0];
            for(int i = 1; i < dolzina; i++)
            {
                if(item > tabela[i])
                {
                    return false;
                } else
                {
                    item = tabela[i];
                }
                Console.WriteLine(item);
            }

            return true;

        }

        public int binarno(int y)
        {
            if(!urejeno())
            {
                return -2;
            }
            int start = 0;
            int mid = 0;
            int last = dolzina-1;

            while (start <= last) {
                Console.WriteLine(mid + "neki");
                mid = (start + last) / 2;
                if (tabela[mid] < y)
                {
                    start = mid +1;
                }
                else if (tabela[mid] > y) {
                    last = mid -1;
                }
                else{
                    return mid;
                }
            }
            return -1;
        }


    }
}
