using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraonicaWfa.Klase
{
   public  class Racunar
    {
        public int id_racunar { get; set; }
        public int br_racunara { get; set; }
        public string mrezno_ime { get; set; }
        public int id_tip_racunara { get; set; }
        public string tip_racunara { get; set; }
        List<Komponenta> listaKomponenti = new List<Komponenta>();
        public string RacunarIspis
        {
            get { return $"{br_racunara} - {mrezno_ime}"; }
        }
        public List<Komponenta> komponente { get; set; } = new List<Komponenta>();

    }
  
}
