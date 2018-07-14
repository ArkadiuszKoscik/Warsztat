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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PokazZleceniabutton_Click(object sender, EventArgs e)
        {
            ZleceniaForm zleceniaOkno = new ZleceniaForm();
            zleceniaOkno.Show();
        }

        private void PokazKlientowButton_Click(object sender, EventArgs e)
        {
            KlienciForm klienciOkno = new KlienciForm();
            klienciOkno.Show();
        }

        private void PokazAutaButton_Click(object sender, EventArgs e)
        {
            AutaForm autaOkno = new AutaForm();
            autaOkno.Show();
        }

        private void PokazCzesciButton_Click(object sender, EventArgs e)
        {
            CzesciForm czesciOkno = new CzesciForm();
            czesciOkno.Show();
        }

        private void PokazMagazynyButton_Click(object sender, EventArgs e)
        {
        }

        private void PokazMechanikowButton_Click(object sender, EventArgs e)
        {
            MechanicyForm mechanicyOkno = new MechanicyForm();
            mechanicyOkno.Show();
        }

    }
}
