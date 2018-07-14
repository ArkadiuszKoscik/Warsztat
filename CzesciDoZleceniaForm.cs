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
    public partial class CzesciDoZleceniaForm : Form
    {
        ZleceniaController controller = new ZleceniaController();
        int idZlecenia;
        int idCzesci;

        public CzesciDoZleceniaForm(int idZlecenia = -1, int idCzesci = -1)
        {
            InitializeComponent();

            if(idCzesci >= 0)
            {
                var potrzebnaCzesc = controller.pobierzCzesciZeZlecenia(idCzesci, idZlecenia);
                idZlecenia = potrzebnaCzesc.idZlecenia.id;
                IloscTextBox.Text = potrzebnaCzesc.ilosc.ToString();
                CzesciComboBox.Text = controller.pobierzCzesciZeZlecenia(idCzesci, idZlecenia).idCzesci.nazwa;
                CzesciComboBox.Enabled = false;
            }

            this.idZlecenia = idZlecenia;
            this.idCzesci = idCzesci;

            var czesci = controller.pobierzWszystkieCzesci();

            foreach (var czesc in czesci)
            {
                CzesciComboBox.Items.Add(czesc.nazwa);
            }
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {          
            int ilosc;
            //if (IloscTextBox.Text.Length == 0)
            //{
            //    MessageBox.Show("Nie podano ilości", "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            try
            {
                ilosc = Convert.ToInt32(IloscTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Wpisano błędną ilość", "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idCzesci >= 0)
            {
                PotrzebnaCzesc potrzebnaCzesc = controller.pobierzCzesciZeZlecenia(idCzesci, idZlecenia);
                try
                {
                    controller.edytujCzesciNaZleceniu(potrzebnaCzesc.id, ilosc);
                }
                catch (Exception exc)
                {
                    string mes = exc.Message;
                    MessageBox.Show(mes, "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (idCzesci < 0)
                {
                    int indeks = CzesciComboBox.SelectedIndex;
                    if (indeks < 0)
                    {
                        MessageBox.Show("Nie zaznaczono żadnej części", "Nie można dodać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var czesci = controller.pobierzWszystkieCzesci();
                    idCzesci = czesci.ElementAt(indeks).id;
                }

                try
                {
                    controller.dodajCzescDoZlecenia(idCzesci, idZlecenia, ilosc);
                }
                catch (Exception exc)
                {
                    string mes = exc.Message;
                    MessageBox.Show(mes, "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Close();
        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
