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
    public partial class MagazynyForm : Form
    {
        MagazynyController controller = new MagazynyController();

        public MagazynyForm()
        {
            InitializeComponent();

            MagazynyListView.View = View.Details;
            MagazynyListView.GridLines = true;
            MagazynyListView.FullRowSelect = true;

            //Add column header
            MagazynyListView.Columns.Add("ID", 40);
            MagazynyListView.Columns.Add("Adres", 200);
            MagazynyListView.Columns.Add("Nazwa", 100);

            this.odswiezMagazyny();

            CzesciListView.View = View.Details;
            CzesciListView.GridLines = true;
            CzesciListView.FullRowSelect = true;

            //Add column header
            CzesciListView.Columns.Add("ID", 40);
            CzesciListView.Columns.Add("Nazwa", 100);
            CzesciListView.Columns.Add("Opis", 200);
            CzesciListView.Columns.Add("Cena", 70);
            CzesciListView.Columns.Add("Ilość", 40);
        }

        private void odswiezMagazyny()
        {
            var magazyny = controller.pobierzWszystkieMagazyny();

            //Add items in the listview
            string[] arr = new string[3];
            ListViewItem itm;

            MagazynyListView.Items.Clear();
            //Add first item
            foreach (var magazyn in magazyny)
            {
                arr[0] = magazyn.id.ToString();
                arr[1] = magazyn.adres;
                arr[2] = magazyn.nazwa;

                itm = new ListViewItem(arr);
                MagazynyListView.Items.Add(itm);
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void odswiezCzesci()
        {
            try
            {
                int idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);

                Magazyn magazyn = controller.pobierzMagazyn(idMagazynu);

                CzesciListView.Items.Clear();
                foreach (var czesc in magazyn.czesci)
                {
                    //Add items in the listview
                    string[] arr = new string[5];
                    ListViewItem itm;


                    //Add first item
                    arr[0] = czesc.idCzesci.id.ToString();
                    arr[1] = czesc.idCzesci.nazwa;
                    arr[2] = czesc.idCzesci.opis;
                    arr[3] = czesc.idCzesci.cenaCzesci.ToString();
                    arr[4] = czesc.ilosc.ToString();
                    itm = new ListViewItem(arr);
                    CzesciListView.Items.Add(itm);
                }
            }
            catch { }
        }

        private void MagazynyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);

            Magazyn magazyn = controller.pobierzMagazyn(idMagazynu);

            odswiezCzesci();

            textBox1.Text = magazyn.id.ToString();
            textBox2.Text = magazyn.adres;
            textBox3.Text = magazyn.nazwa;
        }

        private void DodajMagazynButton_Click(object sender, EventArgs e)
        {
            NowyMagazynForm nowyMagazynOkno = new NowyMagazynForm();
            nowyMagazynOkno.ShowDialog();
            odswiezMagazyny();
        }

        private void DodajCzescButton_Click(object sender, EventArgs e)
        {
            int idMagazynu;
            try
            {
                idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);
            }
            catch
            {
                idMagazynu = -1;
            }
            CzesciDoMagazynuForm czesciDoMagazynuOkno = new CzesciDoMagazynuForm(-1, idMagazynu);
            czesciDoMagazynuOkno.ShowDialog();
            controller = new MagazynyController();
            odswiezCzesci();
        }

        private void UsunCzescutton_Click(object sender, EventArgs e)
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

            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć z magazynu części o ID: " + idCzesci, "Usuwanie czesci z magazynu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            controller.usunCzesciZMagazynu(idCzesci, idMagazynu);
            odswiezCzesci();
        }

        private void UsunMagazynButton_Click(object sender, EventArgs e)
        {
            int idMagazynu;
            try
            {
                idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego magazynu", "Nie można usunąć magazynu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (DialogResult.No == MessageBox.Show("Czy na pewno chcesz usunąć magazyn o ID: " + idMagazynu, "Usuwanie magazynu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            try
            {
                controller.usunMagazyn(idMagazynu);
            }
            catch (Exception exc)
            {
                string mes = exc.Message;
                MessageBox.Show(mes, "Nie można usunąć magazynu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.odswiezMagazyny();
        }

        private void EdytujMagazynButton_Click(object sender, EventArgs e)
        {
            int idMagazynu;
            try
            {
                idMagazynu = Convert.ToInt32(MagazynyListView.FocusedItem.Text);
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono żadnego magazynu", "Nie można edytować magazynu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NowyMagazynForm oknoEdycji = new NowyMagazynForm(idMagazynu);
            oknoEdycji.ShowDialog();
            controller = new MagazynyController();
            odswiezMagazyny();
        }

        private void EdytujCzesciButton_Click(object sender, EventArgs e)
        {   
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
            
            CzesciDoMagazynuForm oknoEdycji = new CzesciDoMagazynuForm(idCzesci, idMagazynu);
            oknoEdycji.ShowDialog();
            controller = new MagazynyController();
            odswiezCzesci();
        }
    }
}
