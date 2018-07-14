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
    public partial class NowyKlientForm : Form
    {
        ZleceniaController controller = new ZleceniaController();
        int id;

        public NowyKlientForm(int id = -1)
        {
            InitializeComponent();
            
            this.id = id;
            if(id >= 0)
            {
                var klient = controller.pobierzKlienta(id);

                ImieTextBox.Text = klient.imie;
                NazwiskoTextBox.Text = klient.nazwisko;
                TelefonTextBox.Text = klient.telefon;
            }
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            string imie = ImieTextBox.Text;
            string nazwisko = NazwiskoTextBox.Text;
            string telefon = TelefonTextBox.Text;

            if(id < 0)
                controller.dodajKlienta(imie, nazwisko, telefon);
            else
                controller.edytujKlienta(id, imie, nazwisko, telefon);
            this.Close();
        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
