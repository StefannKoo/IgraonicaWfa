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
    public partial class InformacijeIgraonica : Form
    {
        Igraonica igr;
        List<Mjesto> lista;
        public InformacijeIgraonica()
        {
            InitializeComponent();
            igr= Helper.UcitajIgraonicu();
            lista = igr.mjesta;
            cmbIspostave.DataSource = lista;
            cmbIspostave.DisplayMember = "NazivMjesto";
            PopuniInformacije();
        }
        private void PopuniInformacije()
        {
            lblNaziv.Text = igr.naziv;
            lblVlasnik.Text = igr.vlasnik;
            lblAdresa.Text = igr.adresa;
            lblBrTel.Text = igr.br_telefona;
            lblRegBr.Text = igr.reg_broj;
        }
    }
}
