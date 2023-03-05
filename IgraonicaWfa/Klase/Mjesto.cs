using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraonicaWfa.Klase
{
    public class Mjesto
    {
        public int id_mjesto { get; set; }
        public string  ptt { get; set; }
        public string naziv { get; set; }
        public string NazivMjesto
        {
            get { return $"{naziv}-{ptt}"; }
        }

    }
}
