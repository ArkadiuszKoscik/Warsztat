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
    public partial class NoweZlecenieForm : Form
    {
        private ZleceniaController controller = new ZleceniaController();
        int idZlecenia;

        public NoweZlecenieForm(int idZlecenia = -1)
        {
            InitializeComponent();

            //wypełnianie pól w przypadku edycji
            this.idZlecenia = idZlecenia;
            int idKlienta = -1;
            int idMechanika = -1;
            if (idZlecenia >= 0)
            {
                Zlecenie zlecenie = controller.pobierzZlecenie(idZlecenia);
                idKlienta = zlecenie.idAuta.idKlienta.id;
                idMechanika = zlecenie.idMechanika.id;
                KosztTextBox.Text = zlecenie.koszt.ToString();
                OpisTextBox.Text = zlecenie.opisUsterki;
                UsuniecieTextBox.Text = zlecenie.opisNaprawy;
            }

            var klienci = controller.pobierzWszystkichKlientow();
            int index = 0;
            foreach(var klient in klienci)
            {
                KlienciComboBox.Items.Add(klient.imie + " " + klient.nazwisko);
                if (klient.id == idKlienta)
                    KlienciComboBox.SelectedIndex = index;
                index++;
            }

            if (idZlecenia >= 0)
            {
                Zlecenie zlecenie = controller.pobierzZlecenie(idZlecenia);
                int idAuta = zlecenie.idAuta.id;
                index = 0;
                foreach (var auto in zlecenie.idAuta.idKlienta.pojazdy)
                {
                    AutaComboBox.Items.Add(auto.marka + " " + auto.model);
                    if (auto.id == idAuta)
                        AutaComboBox.SelectedIndex = index;
                    index++;
                }
            }

            var mechanicy = controller.pobierzWszystkichMechanikow();
            index = 0;
            foreach (var mechanik in mechanicy)
            {
                MechanicyComboBox.Items.Add(mechanik.imie + " " + mechanik.nazwisko);
                if (mechanik.id == idMechanika)
                    MechanicyComboBox.SelectedIndex = index;
                index++;
            }
        }

        private void DodajCzescbutton_Click(object sender, EventArgs e)
        {

        }

        private void NowyKlientButton_Click(object sender, EventArgs e)
        {
            NowyMechanikForm nowyKlientOkno = new NowyMechanikForm();
            nowyKlientOkno.ShowDialog();

            KlienciComboBox.Items.Clear();
            var klienci = controller.pobierzWszystkichKlientow();
            foreach (var klient in klienci)
            {
                KlienciComboBox.Items.Add(klient.imie + " " + klient.nazwisko);
            }
        }

        private void KlienciComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indeks = KlienciComboBox.SelectedIndex;
            
            var klienci = controller.pobierzWszystkichKlientow();
            int idKlienta = klienci.ElementAt(indeks).id;

            var auta = controller.pobierzAutaKlienta(idKlienta);
            AutaComboBox.Items.Clear();
            foreach (var auto in auta)
            {
                AutaComboBox.Items.Add(auto.marka + " " + auto.model);
            }
        }

        private void NoweAutoButton_Click(object sender, EventArgs e)
        {
            int indeks = KlienciComboBox.SelectedIndex;
            if (indeks < 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego klienta");
            }
            else
            {
                var klienci = controller.pobierzWszystkichKlientow();
                int idKlienta = klienci.ElementAt(indeks).id;

                NoweAutoForm noweAutoOkno = new NoweAutoForm(idKlienta);
                noweAutoOkno.ShowDialog();

                var auta = controller.pobierzAutaKlienta(idKlienta);
                AutaComboBox.Items.Clear();
                foreach (var auto in auta)
                {
                    AutaComboBox.Items.Add(auto.marka + " " + auto.model);
                }
            }
            
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            int indeks = KlienciComboBox.SelectedIndex;
            int idKlienta;
            if (indeks < 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego klienta", "Nie można dodać zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var klienci = controller.pobierzWszystkichKlientow();
            idKlienta = klienci.ElementAt(indeks).id;

            indeks = AutaComboBox.SelectedIndex;
            if (indeks < 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego auta", "Nie można dodać zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var auta = controller.pobierzAutaKlienta(idKlienta);
            int idAuta = auta.ElementAt(indeks).id;

            indeks = MechanicyComboBox.SelectedIndex;
            if (indeks < 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego mechanika", "Nie można dodać zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var mechanicy = controller.pobierzWszystkichMechanikow();
            int idMechanika = mechanicy.ElementAt(indeks).id;

            decimal koszt;
            if(KosztTextBox.Text.Length == 0)
            {
                MessageBox.Show("Nie wpisano kosztu", "Nie można dodać zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                koszt = Convert.ToDecimal(KosztTextBox.Text);
            }
            catch 
            {
                MessageBox.Show("Wpisano błędny koszt.\nPoprawny to np: 18,99", "Nie można dodać zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (OpisTextBox.Text.Length == 0)
            {
                MessageBox.Show("Nie wpisano opisu usterki", "Nie można dodać zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string opisUsterki = OpisTextBox.Text;

            string opisNaprawy = UsuniecieTextBox.Text;

            koszt = Convert.ToDecimal(KosztTextBox.Text);
            if (idZlecenia < 0)
                controller.dodajZlecenie(idAuta, idMechanika, opisUsterki, opisNaprawy, koszt);
            else
                controller.edytujZlecenie(idZlecenia, idAuta, idMechanika, opisUsterki, opisNaprawy, koszt);

            this.Close();
        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
