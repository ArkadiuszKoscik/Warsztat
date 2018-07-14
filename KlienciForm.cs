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
    public partial class KlienciForm : Form
    {
        ZleceniaController controller = new ZleceniaController();

        public KlienciForm()
        {
            InitializeComponent();

            KlienciListView.View = View.Details;
            KlienciListView.GridLines = true;
            KlienciListView.FullRowSelect = true;

            //Add column header
            KlienciListView.Columns.Add("ID", 40);
            KlienciListView.Columns.Add("Imie", 100);
            KlienciListView.Columns.Add("Nazwisko", 100);
            KlienciListView.Columns.Add("Telefon", 100);

            this.odswiezKlientow();

           AutaListView.View = View.Details;
           AutaListView.GridLines = true;
           AutaListView.FullRowSelect = true;

            //Add column header
            AutaListView.Columns.Add("ID", 40);
            AutaListView.Columns.Add("Marka", 100);
            AutaListView.Columns.Add("Model", 100);
            AutaListView.Columns.Add("Rocznik", 100);
            AutaListView.Columns.Add("VIN", 100);
        }

        private void odswiezKlientow()
        {
            var klienci = controller.pobierzWszystkichKlientow();

            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;
            
            KlienciListView.Items.Clear();
            //Add first item
            foreach (var klient in klienci)
            {
                arr[0] = klient.id.ToString();
                arr[1] = klient.imie;
                arr[2] = klient.nazwisko.ToString();
                arr[3] = klient.telefon;
                itm = new ListViewItem(arr);
                KlienciListView.Items.Add(itm);
            }
        }

        private void odswiezAuta()
        {
            try
            {
                int idKlienta = Convert.ToInt32(KlienciListView.FocusedItem.Text); 
                Klient klient = controller.pobierzKlienta(idKlienta);
            
                AutaListView.Items.Clear();
                foreach (var auto in klient.pojazdy)
                {
                    //Add items in the listview
                    string[] arr = new string[5];
                    ListViewItem itm;

                
                    //Add first item
                    arr[0] = auto.id.ToString();
                    arr[1] = auto.marka;
                    arr[2] = auto.model;
                    arr[3] = auto.rocznik.ToString();
                    arr[4] = auto.vin;
                    itm = new ListViewItem(arr);
                    AutaListView.Items.Add(itm);
                }
            }
            catch { }
        }
        
        private void DodajKlientaButton_Click(object sender, EventArgs e)
        {
            NowyKlientForm nowyKlientOkno = new NowyKlientForm();
            nowyKlientOkno.ShowDialog();

            this.odswiezKlientow();
        }

        private void KlienciListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            odswiezAuta();
        }

        private void UsunKlientabutton_Click(object sender, EventArgs e)
        {
            int idKlienta;
            try
            {
                idKlienta = Convert.ToInt32(KlienciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego klienta", "Nie można usunąć klienta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć klienta o ID: " + idKlienta, "Usuwanie klienta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            try
            {
                controller.usunKlienta(idKlienta);
            }
            catch (Exception exc)
            {
                string mes = exc.Message;
                MessageBox.Show(mes, "Nie można usunąć klienta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.odswiezKlientow();
        }

        private void DodajAutoButton_Click(object sender, EventArgs e)
        {
            int idKlienta;
            try
            {
                idKlienta = Convert.ToInt32(KlienciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego klienta", "Nie można dodać auta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NoweAutoForm noweAutoOkno = new NoweAutoForm(idKlienta);
            noweAutoOkno.ShowDialog();

            controller = new ZleceniaController();
            this.odswiezAuta();
        }

        private void UsunAutoButton_Click(object sender, EventArgs e)
        {
            int idAuta;
            try
            {
                idAuta = Convert.ToInt32(AutaListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego auta", "Nie można usunąć auta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć auto o ID: " + idAuta, "Usuwanie auta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;
            try
            {
                controller.usunAuto(idAuta);
            }
            catch (Exception exc)
            {
                string mes = exc.Message;
                MessageBox.Show(mes, "Nie można usunąć auta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            odswiezAuta();
        }

        private void EdytujKlientaButton_Click(object sender, EventArgs e)
        {
            int idKlienta;
            try
            {
                idKlienta = Convert.ToInt32(KlienciListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego klienta", "Nie można edytować klienta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NowyKlientForm OknoEdycji = new NowyKlientForm(idKlienta);
            OknoEdycji.ShowDialog();
            controller = new ZleceniaController();
            odswiezKlientow();
        }

        private void EdytujAutoButton_Click(object sender, EventArgs e)
        {
            int idAuta;
            try
            {
                idAuta = Convert.ToInt32(AutaListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego auta", "Nie można edytować auta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NoweAutoForm oknoEdycji = new NoweAutoForm(-1, idAuta);
            oknoEdycji.ShowDialog();
            controller = new ZleceniaController();
            odswiezAuta();

        }
    }
}
