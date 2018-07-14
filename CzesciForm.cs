using bazadanych.Model;
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
    public partial class CzesciForm : Form
    {
        MagazynyController controller = new MagazynyController();

        public CzesciForm()
        {
            InitializeComponent();

            CzesciListView.View = View.Details;
            CzesciListView.GridLines = true;
            CzesciListView.FullRowSelect = true;

            //Add column header
            CzesciListView.Columns.Add("ID", 40);
            CzesciListView.Columns.Add("Nazwa", 100);
            CzesciListView.Columns.Add("Opis", 200);
            CzesciListView.Columns.Add("Ilość", 40);
            CzesciListView.Columns.Add("Cena", 70);

            this.odswiezCzesci();

            MagazynyListView.View = View.Details;
            MagazynyListView.GridLines = true;
            MagazynyListView.FullRowSelect = true;

            //Add column header
            MagazynyListView.Columns.Add("ID", 40);
            MagazynyListView.Columns.Add("Adres", 150);
            MagazynyListView.Columns.Add("Nazwa", 150);
            MagazynyListView.Columns.Add("Ilość", 50);

            ZleceniaListView.View = View.Details;
            ZleceniaListView.GridLines = true;
            ZleceniaListView.FullRowSelect = true;

            //Add column header
            ZleceniaListView.Columns.Add("ID", 40);
            ZleceniaListView.Columns.Add("Ilość", 50);
            ZleceniaListView.Columns.Add("Data zlecenia", 70);
            ZleceniaListView.Columns.Add("Auto", 100);
            ZleceniaListView.Columns.Add("Właściciel", 100);
            ZleceniaListView.Columns.Add("Mechanik", 100);
            ZleceniaListView.Columns.Add("Opis usterki", 200);
            ZleceniaListView.Columns.Add("Opis naprawy", 200);
        }

        private void odswiezCzesci()
        {
            var czesci = controller.pobierzWszystkieCzesci();

            //Add items in the listview
            string[] arr = new string[5];
            ListViewItem itm;

            CzesciListView.Items.Clear();
            //Add first item
            foreach (var czesc in czesci)
            {
                arr[0] = czesc.id.ToString();
                arr[1] = czesc.nazwa;
                arr[2] = czesc.opis;
                arr[3] = controller.pobierzIlosc(czesc.id).ToString();
                arr[4] = czesc.cenaCzesci.ToString();
                itm = new ListViewItem(arr);
                CzesciListView.Items.Add(itm);
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";

            ZleceniaListView.Clear();
            MagazynyListView.Clear();
        }

        private void odzwiezReszte()
        {
            try
            {
                int idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
                Czesc czesc = controller.pobierzCzesc(idCzesci);

                //Add items in the listview
                string[] arr = new string[8];
                ListViewItem itm;

                MagazynyListView.Items.Clear();
                //Add first item
                foreach (var magazyn in czesc.gdzieDostepne)
                {
                    arr[0] = magazyn.idMagazynu.id.ToString();
                    arr[1] = magazyn.idMagazynu.adres;
                    arr[2] = magazyn.idMagazynu.nazwa;
                    arr[3] = magazyn.ilosc.ToString();
                    itm = new ListViewItem(arr);
                    MagazynyListView.Items.Add(itm);
                }


                ZleceniaListView.Items.Clear();
                //Add first item
                foreach (var zlecenie in czesc.gdziePotrzebne)
                {
                    arr[0] = zlecenie.idZlecenia.id.ToString();
                    arr[1] = zlecenie.ilosc.ToString();
                    arr[2] = zlecenie.idZlecenia.dataZlecenia.ToString();
                    arr[3] = zlecenie.idZlecenia.idAuta.marka + " " + zlecenie.idZlecenia.idAuta.model;
                    arr[4] = zlecenie.idZlecenia.idAuta.idKlienta.imie + " " + zlecenie.idZlecenia.idAuta.idKlienta.nazwisko;
                    arr[5] = zlecenie.idZlecenia.idMechanika.imie + " " + zlecenie.idZlecenia.idMechanika.nazwisko;
                    arr[6] = zlecenie.idZlecenia.opisUsterki;
                    arr[7] = zlecenie.idZlecenia.opisNaprawy;
                    itm = new ListViewItem(arr);
                    ZleceniaListView.Items.Add(itm);
                }
            }
            catch { }
        }

        private void DodajNowaCzescButton_Click(object sender, EventArgs e)
        {
            NowaCzescForm nowaCzescOkno = new NowaCzescForm();
            nowaCzescOkno.ShowDialog();
            odswiezCzesci();
        }

        private void CzesciListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);

            Czesc czesc = controller.pobierzCzesc(idCzesci);

            textBox1.Text = czesc.id.ToString();
            textBox2.Text = czesc.nazwa;
            textBox3.Text = czesc.opis;
            textBox4.Text = czesc.cenaCzesci.ToString();
            textBox5.Text = controller.pobierzIlosc(czesc.id).ToString();

            odzwiezReszte();
        }

        private void UsunCzescButton_Click(object sender, EventArgs e)
        {
            int idCzesci;
            try
            {
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnej części", "Nie można usunąć czesci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć czesc o ID: " + idCzesci + " z bazy i magazynów?", "Usuwanie części", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            try
            {
                controller.usunCzesc(idCzesci);
            }
            catch (Exception exc)
            {
                string mes = exc.Message;
                MessageBox.Show(mes, "Nie można usunąć czesci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            odswiezCzesci();
        }

        private void DodajDoMagazynuButton_Click(object sender, EventArgs e)
        {
            int idCzesci;
            try
            {
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                idCzesci = -1;
            }

        }

        private void EdytujCzęśćButton_Click(object sender, EventArgs e)
        {
            int idCzesci;
            try
            {
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnej części", "Nie można edytować części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            NowaCzescForm oknoEdycji = new NowaCzescForm(idCzesci);
            oknoEdycji.ShowDialog();
            controller = new MagazynyController();
            odswiezCzesci();
        }

        private void EdytujCzesciWMagazynieButton_Click(object sender, EventArgs e)
        {
            int idCzesci;
            try
            {
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnej czesci", "Nie można edytować ilosci czesci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idMagazynu;
            try
            {
                idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego magazynu", "Nie można edytować ilosci czesci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void UsunZMagazynuButton_Click(object sender, EventArgs e)
        {
            int idMagazynu;
            int idCzesci;
            try
            {
                idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego magazynu lub części", "Nie można usunąć części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć części z magazynu o ID: " + idMagazynu, "Usuwanie czesci z magazynu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            controller.usunCzesciZMagazynu(idCzesci, idMagazynu);
            odzwiezReszte();
        }

    }
}
