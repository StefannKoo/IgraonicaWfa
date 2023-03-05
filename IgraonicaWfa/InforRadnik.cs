using IgraonicaWfa.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraonicaWfa
{
    public partial class InforRadnik : Form
    {
        Radnik radnik;
        public InforRadnik(Radnik r)
        {
            InitializeComponent();
            radnik = r;
            PopuniInfORadniku();
        }
        private void PopuniInfORadniku()
        {
            lblIme.Text = radnik.ime;
            lblPrezime.Text = radnik.prezime;
            lblJbmg.Text = radnik.jmbg;
            lblPlata.Text = radnik.plata;
            lblDatumZaposlenja.Text = radnik.datum_zaposlenja.ToString();
            lblMjesto.Text = radnik.mjesto.naziv;
        }
    }
}
