using bazadanych.Controller;
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
    public partial class NowyMagazynForm : Form
    {
        MagazynyController controller = new MagazynyController();
        int id;

        public NowyMagazynForm(int id = -1)
        {
            InitializeComponent();

            this.id = id;
            if (id >= 0)
            {
                var magazyn = controller.pobierzMagazyn(id);

                textBox1.Text = magazyn.adres;
                textBox2.Text = magazyn.nazwa;
            }
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            string nazwa = textBox2.Text;
            string adres = textBox1.Text;

            if(id < 0)
                controller.dodajMagazyn(adres, nazwa);
            else
                controller.edytujMagazyn(id, adres, nazwa);

            Close();
        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
