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
    public partial class MechanicyForm : Form
    {
        ZleceniaController controller = new ZleceniaController();

        public MechanicyForm()
        {
            InitializeComponent();

            MechanicyListView.View = View.Details;
            MechanicyListView.GridLines = true;
            MechanicyListView.FullRowSelect = true;

            //Add column header
            MechanicyListView.Columns.Add("ID", 40);
            MechanicyListView.Columns.Add("Imie", 100);
            MechanicyListView.Columns.Add("Nazwisko", 100);
            MechanicyListView.Columns.Add("Pensja", 70);

            this.odswiezMechanikow();

            ZleceniaListView.View = View.Details;
            ZleceniaListView.GridLines = true;
            ZleceniaListView.FullRowSelect = true;

            //Add column header
            ZleceniaListView.Columns.Add("ID", 40);
            ZleceniaListView.Columns.Add("Opis usterki", 100);
            ZleceniaListView.Columns.Add("Data zlecenia", 100);
            ZleceniaListView.Columns.Add("Koszt", 70);
            ZleceniaListView.Columns.Add("Auto", 100);
            ZleceniaListView.Columns.Add("Właściciel", 100);
        }

        private void odswiezMechanikow()
        {
            var mechanicy = controller.pobierzWszystkichMechanikow();

            //Add items in the listview
            string[] arr = new string[5];
            ListViewItem itm;

            MechanicyListView.Items.Clear();
            //Add first item
            foreach (Mechanik mechanik in mechanicy)
            {
                arr[0] = mechanik.id.ToString();
                arr[1] = mechanik.imie;
                arr[2] = mechanik.nazwisko;
                arr[3] = mechanik.pensja.ToString();
                itm = new ListViewItem(arr);
                MechanicyListView.Items.Add(itm);
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void odswiezZlecenia()
        {
            try
            {
                int idMechanika = Convert.ToInt32(MechanicyListView.FocusedItem.Text);
                Mechanik mechanik = controller.pobierzMechanika(idMechanika);

                ZleceniaListView.Items.Clear();
                foreach (var zlecenie in mechanik.zlecenia)
                {
                    //Add items in the listview
                    string[] arr = new string[6];
                    ListViewItem itm;


                    //Add first item
                    arr[0] = zlecenie.id.ToString();
                    arr[1] = zlecenie.opisUsterki;
                    arr[2] = zlecenie.dataZlecenia.ToString();
                    arr[3] = zlecenie.koszt.ToString();
                    arr[4] = zlecenie.idAuta.marka + " " + zlecenie.idAuta.model;
                    arr[5] = zlecenie.idAuta.idKlienta.imie + " " + zlecenie.idAuta.idKlienta.nazwisko;
                    itm = new ListViewItem(arr);
                    ZleceniaListView.Items.Add(itm);
                }
            }
            catch { }
        }

        private void MechanicyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMechanika = Convert.ToInt32(MechanicyListView.FocusedItem.Text);
            Mechanik mechanik = controller.pobierzMechanika(idMechanika);

            odswiezZlecenia();

            textBox1.Text = mechanik.id.ToString();
            textBox2.Text = mechanik.imie;
            textBox3.Text = mechanik.nazwisko;
            textBox4.Text = mechanik.pensja.ToString();
        }

        private void UsunMechanikaButton_Click(object sender, EventArgs e)
        {
            int idMechanika;
            try
            {
                idMechanika = Convert.ToInt32(MechanicyListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego mechanika", "Nie można usunąć mechanika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć mechanika o ID: " + idMechanika, "Usuwanie mechanika", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;
            try
            {
                controller.usunMechanika(idMechanika);
            }
            catch (Exception exc)
            {
                string mes = exc.Message;
                MessageBox.Show(mes, "Nie można usunąć mechanika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            odswiezMechanikow();
        }

        private void DodajMechanikaButton_Click(object sender, EventArgs e)
        {
            NowyMechanikForm nowyMechanikOkno = new NowyMechanikForm();
            nowyMechanikOkno.ShowDialog();
            odswiezMechanikow();
        }

        private void EdytujMechanikaButton_Click(object sender, EventArgs e)
        {
            int idMechanika;
            try
            {
                idMechanika = Convert.ToInt32(MechanicyListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego mechanika", "Nie można edytować mechanika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NowyMechanikForm oknoEdycji = new NowyMechanikForm(idMechanika);
            oknoEdycji.ShowDialog();
            controller = new ZleceniaController();
            odswiezMechanikow();
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }


    }
}
