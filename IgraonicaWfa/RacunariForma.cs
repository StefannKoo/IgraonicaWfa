using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IgraonicaWfa.Klase;
namespace IgraonicaWfa
{
    public partial class RacunariForma : Form
    {
        string tip_racunara = "";
        int id_dodatog_racunara;
        private List<Racunar> racunari;
        public RacunariForma()
        {
            InitializeComponent();
            OsvjeziComboBoxove();
            pcb1.Image = Properties.Resources.pcLaptop;
            pcb3.Image = Properties.Resources.komponente;
        }
        private void OsvjeziComboBoxove()
        {
            racunari = Helper.UcitajIgraonicu().racunari;
            cmbRacunari1.DataSource = racunari;
            cmbRacunari1.DisplayMember = "RacunarIspis";
            cmbRacunari2.DataSource = racunari;
            cmbRacunari2.DisplayMember = "RacunarIspis";
            cmbRacunari3.DataSource = racunari;
            cmbRacunari3.DisplayMember = "RacunarIspis";
            cmbRacunari1.SelectedItem = null;
            cmbRacunari2.SelectedItem = null;
            cmbRacunari3.SelectedItem = null;
        }
        private void IspisKomponentiZaSvakiRacunar()
        {
            if (cmbRacunari1.Text != "")
            {
                foreach (Racunar r in racunari)
                {
                    if (r.RacunarIspis == cmbRacunari1.Text)
                    {
                        foreach (Komponenta k in r.komponente)
                        {
                            if (k is GrafickaKartica)
                            {
                                GrafickaKartica gk = (GrafickaKartica)k;
                                lblGraficka.Text = gk.IspisGraficka;
                            }
                            if (k is Procesor)
                            {
                                Procesor p = (Procesor)k;
                                lblProcesor.Text = p.IspisProcesor;
                            }
                            if (k is MaticnaPloca)
                            {
                                MaticnaPloca mp = (MaticnaPloca)k;
                                lblMaticna.Text = mp.IspisMaticnaPloca;
                            }
                            if (k is RAM)
                            {
                                RAM ram = (RAM)k;
                                lblRAM.Text = ram.IspisRAM;
                            }
                            if (k is HardDisk)
                            {
                                HardDisk ram = (HardDisk)k;
                                //nema lebele
                            }
                            if (k is DVD)
                            {
                                DVD d = (DVD)k;
                                lblDVD.Text = d.IspisDVD;
                            }
                            if (k is Monitor)
                            {
                                Monitor m = (Monitor)k;
                                lblMonitor.Text = m.IspisMonitor;
                            }
                        }
                    }
                }
            }
        }
        private List<Racunar> ProvjeriRadioButtone2()
        {
            List<Racunar> lista = new List<Racunar>();
            if (radioButton6.Checked)
            {
                foreach (Racunar r in racunari)
                {
                    if (r.tip_racunara == "DESKTOP")
                    {
                        lista.Add(r);
                    }
                }
                return lista;
            }
            if (radioButton5.Checked)
            {
                foreach (Racunar r in racunari)
                {
                    if (r.tip_racunara == "LAPTOP")
                    {
                        lista.Add(r);
                    }
                }
                return lista;
            }
            return racunari;
        }
        private List<Racunar> ProvjeriRadioButtone1()
        {
            List<Racunar> lista = new List<Racunar>();
            if (radioButton1.Checked)
            {
                pcb1.Image = Properties.Resources.Privatni_racunar;
                foreach (Racunar r in racunari)
                {
                    if (r.tip_racunara == "DESKTOP")
                    {
                        lista.Add(r);
                    }
                }
                return lista;
            }
            if (radioButton2.Checked)
            {
                pcb1.Image = Properties.Resources.laptop;
                foreach (Racunar r in racunari)
                {
                    if (r.tip_racunara == "LAPTOP")
                    {
                        lista.Add(r);
                    }
                }
                return lista;
            }
            if (radioButton3.Checked)
            {
                pcb1.Image = Properties.Resources.pcLaptop;
            }
            return racunari;

        }

        private void btnPregledaj_Click(object sender, EventArgs e)
        {
            PonistiVrijednostiZaLabele();
            IspisKomponentiZaSvakiRacunar();
        }

        private void ton1_CheckedChanged_1(object sender, EventArgs e)
        {
            cmbRacunari1.DataSource = ProvjeriRadioButtone1();
            cmbRacunari1.DisplayMember = "RacunarIspis";
            cmbRacunari1.SelectedItem = null;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            cmbRacunari2.DataSource = ProvjeriRadioButtone2();
            cmbRacunari2.DisplayMember = "RacunarIspis";
            cmbRacunari2.SelectedItem = null;
        }
        private void UkloniRacunar()
        {
            if (cmbRacunari2.Text != "")
            {
                foreach (Racunar r in racunari)
                {
                    if (r.RacunarIspis == cmbRacunari2.Text)
                    {
                        Helper.ObrisiRacunar(r);
                        racunari = Helper.UcitajIgraonicu().racunari;
                        OsvjeziComboBoxove();

                    }
                }
            }
        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            UkloniRacunar();
            MessageBox.Show("Uspjesno ste uklonili racunar!", "Brisanje racunara", MessageBoxButtons.OKCancel);
        }
        private bool ValidujPoljaZaUnosRacunara()
        {
            int br_racunara;
            int br_jezgara;
            int frekvencija;
            if (!int.TryParse(txtBoxBrRacunara.Text, out br_racunara))
            {
                MessageBox.Show("Nije dobar unos u polje za br racunara");
                return false;
            }
            if (txtBoxMreznoIme.TextLength < 1)
            {
                MessageBox.Show("Unesite vrijednost u polje za mrezno ime");
                return false;
            }
            if (txtBoxGrafickaProizvodjac.TextLength < 1 || txtBoxGrafickaNaziv.TextLength < 1 || txtBoxGrafickaKolicinaMemorije.TextLength < 1)
            {
                MessageBox.Show("Morate da popunite sva polja za graficku karticu");
                return false;
            }
            if (txtBoxMaticnaProizvodjac.TextLength < 1 || txtBoxCipset.TextLength < 1)
            {
                MessageBox.Show("Popunite sva polja  za unos maticne ploce");
                return false;
            }
            if (!int.TryParse(txtBoxBrojJezgara.Text, out br_jezgara))
            {
                MessageBox.Show("Morate unjeti broj u polje za broj jezgara za procesor");
                return false;
            }
            if (!int.TryParse(txtBoxProcesorFrekevencija.Text, out frekvencija))
            {
                MessageBox.Show("Morate unjeti pravilnu vrijednost za frekevenciju");
                return false;
            }
            if (txtBoxProcesorProizvodjac.TextLength < 1)
            {
                MessageBox.Show("Unesite vrijednost u polje za proizvodjaca");
                return false;
            }
            if (txtBoxRamTip.TextLength < 1 || txtBoxRamProizvodjac.TextLength < 1 || txtBoxRamKapacitet.TextLength < 1)
            {
                MessageBox.Show("Unesite vrijednosti u sva polja za ram");
                return false;
            }
            return true;
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (ValidujPoljaZaUnosRacunara())
            {
                if (tip_racunara != "")
                {
                    Racunar r = new Racunar();
                    r.br_racunara = int.Parse(txtBoxBrRacunara.Text);
                    r.mrezno_ime = txtBoxMreznoIme.Text;
                    r.id_tip_racunara = Helper.VratiIdZaTipRacunara(tip_racunara);
                    id_dodatog_racunara = Helper.DodajRacunar(r);

                    GrafickaKartica gk = new GrafickaKartica();
                    gk.id_racunar = id_dodatog_racunara;
                    gk.id_tip_komponente = Helper.VratiIdZaTipKomponente("graficka_karta");
                    gk.kolicina_memorije = txtBoxGrafickaKolicinaMemorije.Text;
                    gk.ime_proizvoda = txtBoxGrafickaProizvodjac.Text;
                    gk.ime = txtBoxGrafickaNaziv.Text;
                    Helper.DodajGrafickuZaNoviRacunar(gk);

                    MaticnaPloca mp = new MaticnaPloca();
                    mp.id_racunar = id_dodatog_racunara;
                    mp.id_tip_komponente = Helper.VratiIdZaTipKomponente("maticna_ploca");
                    mp.ime_proizvoda = txtBoxMaticnaProizvodjac.Text;
                    mp.cipset = txtBoxCipset.Text;
                    Helper.DodajMaticnuPlocuZaNoviRacunar(mp);

                    Procesor pr = new Procesor();
                    pr.id_racunar = id_dodatog_racunara;
                    pr.id_tip_komponente = Helper.VratiIdZaTipKomponente("procesor");
                    pr.ime_proizvoda = txtBoxProcesorProizvodjac.Text;
                    pr.broj_jezgara = int.Parse(txtBoxBrojJezgara.Text);
                    pr.frekvencija_rada = txtBoxProcesorFrekevencija.Text;
                    Helper.DodajProcesorZaNoviRacunar(pr);

                    RAM ram = new RAM();
                    ram.id_racunar = id_dodatog_racunara;
                    ram.id_tip_komponente = Helper.VratiIdZaTipKomponente("ram");
                    ram.ime_proizvoda = txtBoxRamProizvodjac.Text;
                    ram.kolicina_memorije = txtBoxRamKapacitet.Text;
                    ram.tip_ram = txtBoxRamTip.Text;
                    Helper.DodajRAMZaNoviRacunar(ram);

                    ResetujTextBoxoveZaUnosRacunara();
                    OsvjeziComboBoxove();
                    MessageBox.Show("Dodali ste novi racunar!", "Dodavanje racunara u sistem", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Cekirajte vrijednost za tip racunara");
                }
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja za unos");
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLaptopDodavanje.Checked)
            {
                tip_racunara = "LAPTOP";
                pcb2.Image = Properties.Resources.laptop;
            }
            if (rdbDesktopDodavanje.Checked)
            {
                tip_racunara = "DESKTOP";
                pcb2.Image = Properties.Resources.Privatni_racunar;
            }
        }
        private void PonistiVrijednostiZaLabele()
        {
            lblDVD.Text = "";
            lblGraficka.Text = "";
            lblMaticna.Text = "";
            lblMonitor.Text = "";
            lblProcesor.Text = "";
            lblRAM.Text = "";
        }
        private void ResetujTextBoxoveZaUnosRacunara()
        {
            txtBoxBrojJezgara.Text = "";
            txtBoxBrRacunara.Text = "";
            txtBoxCipset.Text = "";
            txtBoxGrafickaKolicinaMemorije.Text = "";
            txtBoxGrafickaNaziv.Text = "";
            txtBoxGrafickaProizvodjac.Text = "";
            txtBoxMaticnaProizvodjac.Text = "";
            txtBoxMreznoIme.Text = "";
            txtBoxProcesorFrekevencija.Text = "";
            txtBoxProcesorProizvodjac.Text = "";
            txtBoxRamKapacitet.Text = "";
            txtBoxRamProizvodjac.Text = "";
            txtBoxRamTip.Text = "";
        }

        private void cmbRacunari3_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbKomponente.Items.Clear();
            foreach (Racunar r in racunari)
            {
                if (r.RacunarIspis == cmbRacunari3.Text)
                {
                    for (int i = 0; i < r.komponente.Count; i++)
                    {
                        if (r.komponente[i] is GrafickaKartica)
                        {
                            GrafickaKartica gk = (GrafickaKartica)r.komponente[i];
                            cmbKomponente.Items.Add(gk.IspisGraficka);
                        }
                        if (r.komponente[i] is Procesor)
                        {
                            Procesor pr = (Procesor)r.komponente[i];
                            cmbKomponente.Items.Add(pr.IspisProcesor);
                        }
                        if (r.komponente[i] is MaticnaPloca)
                        {
                            MaticnaPloca mp = (MaticnaPloca)r.komponente[i];
                            cmbKomponente.Items.Add(mp.IspisMaticnaPloca);
                        }
                        if (r.komponente[i] is RAM)
                        {
                            RAM ram = (RAM)r.komponente[i];
                            cmbKomponente.Items.Add(ram.IspisRAM);
                        }
                        if (r.komponente[i] is Monitor)
                        {
                            Monitor mon = (Monitor)r.komponente[i];
                            cmbKomponente.Items.Add(mon.IspisMonitor);
                        }

                        if (r.komponente[i] is HardDisk)
                        {
                            HardDisk hd = (HardDisk)r.komponente[i];
                            cmbKomponente.Items.Add(hd.IspisHardDisk);
                        }
                        if (r.komponente[i] is DVD)
                        {
                            DVD dvd = (DVD)r.komponente[i];
                            cmbKomponente.Items.Add(dvd.IspisDVD);
                        }
                    }
                }
            }
        }

        private void cmbKomponente_SelectedValueChanged(object sender, EventArgs e)
        {
            string prva_tri_slova=cmbKomponente.Text.Substring(0,3);
            switch (prva_tri_slova)
            {
                case "Gra":
                    pcb3.Image = Properties.Resources.graficka;
                    break;
                case "Pro":
                    pcb3.Image = Properties.Resources.procesor;
                    break;
                case "Mat":
                    pcb3.Image = Properties.Resources.maticna;
                    break;
                case "Har":
                    pcb3.Image = Properties.Resources.harddisk;
                    break;
                case "RAM":
                    pcb3.Image = Properties.Resources.ram;
                    break;
                case "DVD":
                    pcb3.Image = Properties.Resources.dvd;
                    break;
                case "Mon":
                    pcb3.Image = Properties.Resources.monitor;
                    break;
                default:
                    break;
            }
        }

        private void btnZamjeni_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}


    
    

