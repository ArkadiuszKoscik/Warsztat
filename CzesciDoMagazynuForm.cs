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
    public partial class CzesciDoMagazynuForm : Form
    {
        MagazynyController controller = new MagazynyController();
        int idCzesci;
        int idMagazynu;
        int idRekordu = -1;

        public CzesciDoMagazynuForm(int idCzesci = -1, int idMagazynu = -1)
        {
            InitializeComponent();

            this.idMagazynu = idMagazynu;
            this.idCzesci = idCzesci;

            if(idCzesci >= 0 && idMagazynu >= 0)          //edycja
            {
                var dostepnaCzesc = controller.pobierzDostepnoscCzesci(idCzesci, idMagazynu);
                idRekordu = dostepnaCzesc.id;
                IloscTextBox.Text = dostepnaCzesc.ilosc.ToString();
                CzesciComboBox.Text = dostepnaCzesc.idCzesci.nazwa;
                MagazynyComboBox.Text = dostepnaCzesc.idMagazynu.adres + "   " + dostepnaCzesc.idMagazynu.nazwa;
                CzesciComboBox.Enabled = false;
                MagazynyComboBox.Enabled = false;
            }
            else                                        //dodawanie
            {
                var magazyny = controller.pobierzWszystkieMagazyny();
                int index = 0;

                foreach (var magazyn in magazyny)
                {
                    MagazynyComboBox.Items.Add(magazyn.adres + "   " + magazyn.nazwa);
                    if (magazyn.id == idMagazynu)
                        MagazynyComboBox.SelectedIndex = index;
                    index++;
                }

                var czesci = controller.pobierzWszystkieCzesci();
                index = 0;

                foreach (var czesc in czesci)
                {
                    CzesciComboBox.Items.Add(czesc.nazwa);
                    if (czesc.id == idCzesci)
                        CzesciComboBox.SelectedIndex = index;
                    index++;
                }                                    
            }

        }

        private void AnulujButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            int ilosc;
            try
            {
                ilosc = Convert.ToInt32(IloscTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Wpisano błędną ilość", "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idRekordu >= 0)          //edycja
            {
                controller.edyujCzescWMagazynie(idRekordu, ilosc);
            }
            else                        //dodawanie
            {
                int indeks = MagazynyComboBox.SelectedIndex;
                if (indeks < 0)
                {
                    MessageBox.Show("Nie zaznaczono żadnego magazynu", "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var magazyny = controller.pobierzWszystkieMagazyny();
                idMagazynu = magazyny.ElementAt(indeks).id;

                indeks = CzesciComboBox.SelectedIndex;
                if (indeks < 0)
                {
                    MessageBox.Show("Nie zaznaczono żadnej części", "Nie można zapisać części", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var czesci = controller.pobierzWszystkieCzesci();
                idCzesci = czesci.ElementAt(indeks).id;

                controller.dodajCzescDoMagazynu(idCzesci, idMagazynu, ilosc);
            }
            
            Close();
        }
    }
}
