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
    public partial class Radnici : Form
    {
        List<Radnik> radnici;
        public Radnici()
        {
            InitializeComponent();
            radnici = Helper.UcitajIgraonicu().radnici;
            cmbRadnici.DataSource = radnici;
            cmbRadnici.DisplayMember = "RadnikIspis";
            cmbRadnici.SelectedItem = null;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbRadnici.Text != "")
            {
                Radnik radnik = (Radnik)cmbRadnici.SelectedItem;
                InforRadnik inf = new InforRadnik(radnik);
                inf.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajRadnika dr = new DodajRadnika();
            DialogResult d= dr.ShowDialog();
            if(d==DialogResult.OK)
            {
                radnici = Helper.UcitajIgraonicu().radnici;
                cmbRadnici.DataSource = radnici;
                cmbRadnici.DisplayMember = "RadnikIspis";
                cmbRadnici.SelectedItem = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(cmbRadnici.SelectedItem!=null)
            {
                foreach (Radnik radnik in radnici)
                {
                   if(cmbRadnici.Text==radnik.RadnikIspis)
                    {
                        Helper.IzbrisiRadnika(radnik);
                        radnici = Helper.UcitajIgraonicu().radnici;
                        cmbRadnici.DataSource = radnici;
                        cmbRadnici.DisplayMember = "RadnikIspis";
                        cmbRadnici.SelectedItem = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati vrijednos u kombo box");
            }
        }
    }
}
