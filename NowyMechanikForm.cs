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
    public partial class NowyMechanikForm : Form
    {
        ZleceniaController controller = new ZleceniaController();
        int id;

        public NowyMechanikForm(int id = -1)
        {
            InitializeComponent();

            this.id = id;
            if(id >= 0)
            {
                var mechanik = controller.pobierzMechanika(id);
                ImieTextBox.Text = mechanik.imie;
                NazwiskoTextBox.Text = mechanik.nazwisko;
                PensjaTextBox.Text = mechanik.pensja.ToString();
            }
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            string imie = ImieTextBox.Text;
            string nazwisko = NazwiskoTextBox.Text;
            decimal pensja = Convert.ToDecimal(PensjaTextBox.Text);

            if(id < 0)
                controller.dodajMechanika(imie, nazwisko, pensja);
            else
                controller.edytujMechanika(id, imie, nazwisko, pensja);
            this.Close();
        }

        private void AnulujButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
