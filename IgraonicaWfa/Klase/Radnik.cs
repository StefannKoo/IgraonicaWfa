using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraonicaWfa.Klase
{
   public  class Radnik
    {
        public int id_radnik { get; set; }
        public int id_igraonica { get; set; }
        public int id_mjesto { get; set; }
        public string jmbg { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datum_zaposlenja { get; set; }
        public string plata  { get; set; }
        public Mjesto mjesto { get; set; }
        public string RadnikIspis
        {
            get { return string.Format("{0} {1}", ime, prezime); }
        }
        public string IspisUListBox
        {
            get
            {
                return $"Ime {ime},prezime{prezime},mjesto {mjesto.NazivMjesto},jbmg { jmbg},datum zaposlenja{datum_zaposlenja},plata{plata}";
            }
        }
    }
}
