using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraonicaWfa.Klase
{
    public class Igraonica
    {
        public int id_igraonica { get; set; }
        public string reg_broj { get; set; }
        public string vlasnik  { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public string br_telefona { get; set; }
        public List<Mjesto> mjesta { get; set; } = new List<Mjesto>();
        public List<Racunar> racunari { get; set; } = new List<Racunar>();
        public List<Radnik> radnici { get; set; } = new List<Radnik>();
    }
}
