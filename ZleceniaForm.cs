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
    public partial class ZleceniaForm : Form
    {
        private ZleceniaController controller = new Controller.ZleceniaController();

        public ZleceniaForm()
        {
            InitializeComponent();

            ZleceniaListView.View = View.Details;
            ZleceniaListView.GridLines = true;
            ZleceniaListView.FullRowSelect = true;

            //Add column header
            ZleceniaListView.Columns.Add("ID", 40);
            ZleceniaListView.Columns.Add("Opis usterki", 200);
            ZleceniaListView.Columns.Add("Data zlecenia", 100);
            ZleceniaListView.Columns.Add("Koszt", 70);
            ZleceniaListView.Columns.Add("Mechanik", 100);
            ZleceniaListView.Columns.Add("Właściciel", 100);

            this.odswiez();

            CzesciListView.View = View.Details;
            CzesciListView.GridLines = true;
            CzesciListView.FullRowSelect = true;

            //Add column header
            CzesciListView.Columns.Add("ID", 40);
            CzesciListView.Columns.Add("Nazwa", 100);
            CzesciListView.Columns.Add("Opis", 200);
            CzesciListView.Columns.Add("Cena", 70);
            CzesciListView.Columns.Add("Ilość", 40);
            CzesciListView.Columns.Add("Koszt", 70);
            
        }

        private void odswiez()
        {
            var zlecenia = controller.pobierzWszystkieZlecenia();

            //Add items in the listview
            string[] arr = new string[6];
            ListViewItem itm;

            ZleceniaListView.Items.Clear();
            //Add first item
            foreach (var zlecenie in zlecenia)
            {
                arr[0] = zlecenie.id.ToString();
                arr[1] = zlecenie.opisUsterki;
                arr[2] = zlecenie.dataZlecenia.ToString();
                arr[3] = zlecenie.koszt.ToString();
                arr[4] = zlecenie.idMechanika.imie + " " + zlecenie.idMechanika.nazwisko;
                arr[5] = zlecenie.idAuta.idKlienta.imie + " " + zlecenie.idAuta.idKlienta.nazwisko;
                itm = new ListViewItem(arr);
                ZleceniaListView.Items.Add(itm);
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
        }

        private void odswiezCzesci()
        {
            try
            {
                int idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);

                Zlecenie zlecenie = controller.pobierzZlecenie(idZlecenia);

                //Add items in the listview
                string[] arr = new string[6];
                ListViewItem itm;
                CzesciListView.Items.Clear();

                foreach (var czesc in zlecenie.czesciDoNaprawy)
                {
                    //Add first item
                    arr[0] = czesc.idCzesci.id.ToString();
                    arr[1] = czesc.idCzesci.nazwa;
                    arr[2] = czesc.idCzesci.opis;
                    arr[3] = czesc.idCzesci.cenaCzesci.ToString();
                    arr[4] = czesc.ilosc.ToString();
                    arr[5] = (czesc.idCzesci.cenaCzesci * czesc.ilosc).ToString();
                    itm = new ListViewItem(arr);
                    CzesciListView.Items.Add(itm);
                }
            }
            catch { }
        }

        private void DodajZlecenieButton_Click(object sender, EventArgs e)
        {
            NoweZlecenieForm noweZlecenieOkno = new NoweZlecenieForm();
            noweZlecenieOkno.ShowDialog();
            this.odswiez();
        }

        private void ZleceniaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);

            odswiezCzesci();

            Zlecenie zlecenie = controller.pobierzZlecenie(idZlecenia);

            textBox1.Text = zlecenie.id.ToString();
            textBox2.Text = zlecenie.idAuta.idKlienta.imie + " " + zlecenie.idAuta.idKlienta.nazwisko;
            textBox3.Text = zlecenie.idAuta.marka + " " + zlecenie.idAuta.model;
            textBox4.Text = zlecenie.idMechanika.imie + " " + zlecenie.idMechanika.nazwisko;
            textBox5.Text = zlecenie.dataZlecenia.ToString();
            textBox6.Text = zlecenie.koszt.ToString();
            textBox7.Text = zlecenie.opisUsterki;
            textBox8.Text = zlecenie.opisNaprawy;


        }

        private void UsuńZlecenieButton_Click(object sender, EventArgs e)
        {
            int idZlecenia;
            try
            {
                idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia", "Nie można usunąć zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć zlecenie o ID: " + idZlecenia, "Usuwanie zlecenia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            controller.usunZlecenie(idZlecenia);
            this.odswiez();
        }

        private void DojajCzescButton_Click(object sender, EventArgs e)
        {
            int idZlecenia;
            try
            {
                idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia", "Nie można dodać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CzesciDoZleceniaForm czesciDoZleceniaOkno = new CzesciDoZleceniaForm(idZlecenia);
            czesciDoZleceniaOkno.ShowDialog();
            controller = new ZleceniaController();
            odswiezCzesci();
        }

        private void UsunCzesciButton_Click(object sender, EventArgs e)
        {
            int idZlecenia;
            int idCzesci;
            try
            {
                idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia lub części", "Nie można usunąć części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć ze zlecenia części o ID: " + idCzesci, "Usuwanie czesci ze zlecenia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            controller.usunCzesciZeZlecenia(idCzesci, idZlecenia);
            odswiezCzesci();
        }

        private void EdytujZlecenieButton_Click(object sender, EventArgs e)
        {
            int idZlecenia;
            try
            {
                idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia", "Nie można edytować zlecenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NoweZlecenieForm oknoEdycji = new NoweZlecenieForm(idZlecenia);
            oknoEdycji.ShowDialog();
            controller = new ZleceniaController();
            this.odswiez();
        }

        private void EdytujCzescButton_Click(object sender, EventArgs e)
        {
            int idZlecenia;
            try
            {
                idZlecenia = Convert.ToInt32(ZleceniaListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia", "Nie można edytować czesci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idCzesci;
            try
            {
                idCzesci = Convert.ToInt32(CzesciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnej czesci", "Nie można edytować czesci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CzesciDoZleceniaForm oknoEdycji = new CzesciDoZleceniaForm(idZlecenia, idCzesci);
            oknoEdycji.ShowDialog();
            controller = new ZleceniaController();
            odswiezCzesci();
        }
    }
}
