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
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InformacijeIgraonica inf = new InformacijeIgraonica();
            inf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Radnici rad = new Radnici();
            rad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RacunariForma r = new RacunariForma();
            r.Show();
        }
    }
}
