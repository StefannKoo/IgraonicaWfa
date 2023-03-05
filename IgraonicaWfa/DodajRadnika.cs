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
    public partial class DodajRadnika : Form
    {
        DateTime datum;
        int plata;
        List<Mjesto> mjesta;
        public DodajRadnika()
        {
            InitializeComponent();
            mjesta = Helper.UcitajMjestaIzBaze();
            comboBox1.DataSource = mjesta;
            comboBox1.DisplayMember = "naziv";
            comboBox1.SelectedItem = null;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidujFormu())
            {
                Radnik radnik = new Radnik();
                radnik.ime = textBox1.Text;
                radnik.prezime = textBox2.Text;
                radnik.jmbg = textBox3.Text;
                radnik.datum_zaposlenja = DateTime.Parse(textBox4.Text);
                radnik.plata = textBox5.Text;
                radnik.id_igraonica = Helper.UcitajIgraonicu().id_igraonica;

                if (comboBox1.SelectedItem != null)
                {
                    radnik.mjesto = (Mjesto)comboBox1.SelectedItem;
                    List<Mjesto> l = Helper.UcitajMjestaIzBaze();
                    foreach (Mjesto m in l)
                    {
                        if (m.naziv == radnik.mjesto.naziv)
                        {
                            radnik.id_mjesto = m.id_mjesto;
                        }
                    }
                }
                else
                {
                    Mjesto mjesto = new Mjesto();
                    mjesto.naziv = textBox7.Text;
                    mjesto.ptt = textBox6.Text;
                    int id= Helper.DodajMjesto(mjesto);//metoda vraca id zadnjeg unjetog mjesta u bazi
                    radnik.mjesto = mjesto;
                    radnik.id_mjesto = id;
                }
                Helper.DodajRadnika(radnik);
                DialogResult = DialogResult.OK;
            }
            else { MessageBox.Show("Morate unjeti pravilne vrijednosti u sva polja"); }
        }
        private bool ValidujFormu()
        {
            if(textBox1.Text.Length<1)
            {
                return false;
            }
            if(textBox2.Text.Length<1)
            {
                return false;
            }
            if(textBox3.Text.Length<1)
            {
                return false;
            }
            if(!DateTime.TryParse(textBox4.Text,out datum))
            {
                return false;
            }
            if(!int.TryParse(textBox5.Text,out plata))
            {
                return false;
            }
            if (comboBox1.SelectedItem == null)
            {
                if(textBox6.Text.Length<1)
                {
                    return false;
                }
                if(textBox7.Text.Length<1)
                {
                    return false;
                }
            }
            else if(comboBox1.SelectedValue!=null && (textBox6.Text.Length>0 || textBox7.Text.Length>0))
            {
                return false;
            }
            return true;
        }
    }
}
