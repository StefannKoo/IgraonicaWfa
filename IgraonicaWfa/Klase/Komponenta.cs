using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraonicaWfa.Klase
{
   public  class Komponenta
    {
        public int id_komponenta { get; set; }
        public string ime_proizvoda { get; set; }
        public int id_tip_komponente { get; set; }
        public string vrsta_komponente { get; set; }
        public int id_racunar { get; set; }
    }
    public class GrafickaKartica:Komponenta
    {
        public string ime { get; set; }
        public string kolicina_memorije { get; set; }

        public string IspisGraficka {
            get { return $"Graficka: {ime_proizvoda} { ime } { kolicina_memorije}"; }
        }
    }
    public class Monitor : Komponenta
    {
        public float dimenzija { get; set; }
        public string   ime { get; set; }
        public string IspisMonitor
        {
            get { return $"Monitor:{ime_proizvoda} {ime} { dimenzija }"; }

        }
    }
    public class RAM : Komponenta
    {
        public string tip_ram { get; set; }
        public string kolicina_memorije { get; set; }
        public string IspisRAM
        {
            get { return $"RAM:{ime_proizvoda} { tip_ram} { kolicina_memorije}"; }
        }
    }
    public class HardDisk : Komponenta
    {
        public string brzina_obrtaja { get; set; }
        public string kapacitet { get; set; }
        public string IspisHardDisk
        {
            get { return $"HardDisk:{ime_proizvoda} { brzina_obrtaja } { kapacitet}"; }
        }
    }
    public class DVD : Komponenta
    {
        public string brzina_obrtaja { get; set; }
        public string IspisDVD
        {
            get { return $"DVD:{ime_proizvoda} { brzina_obrtaja }"; }
        }
    }
    public class MaticnaPloca : Komponenta
    {
        public string cipset { get; set; }
        public string IspisMaticnaPloca
        {
            get { return $"Maticna:{ime_proizvoda} { cipset }"; }
        }
    }
    public class Procesor : Komponenta
    {
        public string frekvencija_rada { get; set; }
        public int broj_jezgara { get; set; }
        public string IspisProcesor
        {
            get { return $"Procesor:{ime_proizvoda} { frekvencija_rada } { broj_jezgara}"; }
        }
    }
                            
}
                        
