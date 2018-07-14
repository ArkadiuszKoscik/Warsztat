using bazadanych.Controller;
using bazadanych.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bazadanych
{
    public partial class NowaCzescForm : Form
    {
        MagazynyController controller = new MagazynyController();
        int id;

        public NowaCzescForm(int id = -1)
        {
            InitializeComponent();

            this.id = id;
            if (id >= 0)
            {
                Czesc czesc = controller.pobierzCzesc(id);

                textBox1.Text = czesc.nazwa;
                textBox2.Text = czesc.opis;
                textBox3.Text = czesc.cenaCzesci.ToString();
            }
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            string nazwa = textBox1.Text;
            string opis = textBox2.Text;
            decimal cena = Convert.ToDecimal(textBox3.Text);

            if(id < 0)
                controller.dodajCzesc(nazwa, opis, cena);
            else
                controller.edytujCzesc(id, nazwa, opis, cena);
            
            Close();
        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
