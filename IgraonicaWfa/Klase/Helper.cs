using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace IgraonicaWfa.Klase
{
    public static class Helper
    {
        public static string VratiKonString(string ime)
        {
            return ConfigurationManager.ConnectionStrings[ime].ConnectionString;
        }
        public static Igraonica UcitajIgraonicu()
        {
            Igraonica ig;
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                ig = con.QuerySingle<Igraonica>("dbo.PupuniIgraonica", commandType: CommandType.StoredProcedure);

                ig.racunari = con.Query<Racunar>("dbo.UcitajRacunare @id_igraonica", new { id_igraonica = ig.id_igraonica }).ToList();
                foreach (Racunar racunar in ig.racunari)
                {
                    racunar.tip_racunara = con.QuerySingle<string>("dbo.Vrati_Tip_Racunara @id_tip_racunara", new { id_tip_racunara = racunar.id_tip_racunara });
                    List<Komponenta> kom = new List<Komponenta>();
                    kom = con.Query<Komponenta>("dbo.Ucitaj_Komponente_Osnovno @id_racunar", new { id_racunar = racunar.id_racunar }).ToList();
                    foreach (Komponenta k in kom)
                    {
                        k.vrsta_komponente = con.QuerySingle<string>("dbo.UcitajVrstuKomponente @id_tip_komponente", new { id_tip_komponente = k.id_tip_komponente });
                        switch (k.vrsta_komponente)
                        {
                            case "graficka_karta":
                                GrafickaKartica gk = new GrafickaKartica();
                                //Ucitati podatke za graficku za dati racunr
                                gk = con.QuerySingle<GrafickaKartica>("dbo.UcitajGraficku @id_racunar", new { id_racunar = k.id_racunar });
                                racunar.komponente.Add(gk);
                                break;
                            case "procesor":
                                Procesor pr = new Procesor();
                                //Ucitati podatke za procesor -||-
                                pr = con.QuerySingle<Procesor>("dbo.UcitajProcesor @id_racunar", new { id_racunar = k.id_racunar });
                                racunar.komponente.Add(pr);
                                break;
                            case "maticna_ploca":
                                MaticnaPloca mp = new MaticnaPloca();
                                //Ucitati za maticnu
                                mp = con.QuerySingle<MaticnaPloca>("dbo.MaticnaPloca @id_racunar", new { id_racunar = k.id_racunar });
                                racunar.komponente.Add(mp);
                                break;

                            case "ram":
                                RAM r = new RAM();
                                //Ucitati za ram
                                r = con.QuerySingle<RAM>("dbo.UcitajRam @id_racunar", new { id_racunar = k.id_racunar });
                                racunar.komponente.Add(r);
                                break;
                            case "monitor":
                                Monitor m = new Monitor();
                                //Ucitati za monitor
                                m = con.QuerySingle<Monitor>("dbo.UcitajMonitor @id_racunar", new { id_racunar = k.id_racunar });
                                racunar.komponente.Add(m);
                                break;
                            case "dvd":
                                DVD dvd = new DVD();
                                //Ucitati za ram
                                dvd = con.QuerySingle<DVD>("dbo.UcitajDvD1 @id_racunar", new { id_racunar = k.id_racunar });
                                racunar.komponente.Add(dvd);
                                break;
                            default:
                                break;

                        }
                    }
                }

                ig.radnici = con.Query<Radnik>("dbo.PopuniRadnike @id_igraonica", new { id_igraonica = ig.id_igraonica }).ToList();

                ig.mjesta = con.Query<Mjesto>("dbo.IzlistajMjestaIgraonica", commandType: CommandType.StoredProcedure).ToList();

                foreach (Radnik r in ig.radnici)
                {
                    r.mjesto = con.QuerySingle<Mjesto>("dbo.PopuniMjestRadnicima @id_mjesto", new { id_mjesto = r.id_mjesto });
                }
            }

            return ig;
        }
        public static void DodajRadnika(Radnik r)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@jmbg", r.jmbg);
                p.Add("@ime", r.ime);
                p.Add("@prezime", r.prezime);
                p.Add("@datum_zaposlenja", r.datum_zaposlenja);
                p.Add("@plata", r.plata);
                p.Add("@id_igraonica", r.id_igraonica);
                p.Add("@id_mjesto", r.id_mjesto);

                con.Execute("dbo.DodajNovogRadnika", p, commandType: CommandType.StoredProcedure);
            }
        }
        public static List<Mjesto> UcitajMjestaIzBaze()
        {
            List<Mjesto> mjesta;
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                mjesta = con.Query<Mjesto>("dbo.UcitajMjesta", commandType: CommandType.StoredProcedure).ToList();
            }
            return mjesta;
        }
        //Metoda dodaje mjesto u bazu i vraca id unjetog mjesta jer nam je potreban kao strani kljuc
        public static int DodajMjesto(Mjesto mj)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@ptt", mj.ptt);
                p.Add("@naziv", mj.naziv);
                p.Add("id_mjesto", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("dbo.DodajMjesto", p, commandType: CommandType.StoredProcedure);
                mj.id_mjesto = p.Get<int>("id_mjesto");
            }
            return mj.id_mjesto;
        }
        public static void IzbrisiRadnika(Radnik r)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                con.Execute("dbo.IzbrisiRadnika @id_radnik", new { id_radnik = r.id_radnik });
            }
        }
        public static void ObrisiRacunar(Racunar racunar)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                con.Execute("dbo.ObrisiRacunar @id_racunar", new { id_racunar = racunar.id_racunar });
            }
        }
        public static int DodajRacunar(Racunar r)
        {
            int id_dodatog_racunara;
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@br_racunara", r.br_racunara);
                p.Add("@mrezno_ime", r.mrezno_ime);
                p.Add("@id_igraonica", UcitajIgraonicu().id_igraonica);
                p.Add("@id_tip_racunara", r.id_tip_racunara);
                p.Add("id_racunar", 0, DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("dbo.DodajRacunar", p, commandType: CommandType.StoredProcedure);
                id_dodatog_racunara = p.Get<int>("id_racunar");
            }
            return id_dodatog_racunara;
        }
        public static int VratiIdZaTipRacunara(string tip)
        {
            int id;
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                id = con.QuerySingle<int>("dbo.VratiIdZaTipRacunara @tip_racunara", new { tip_racunara = tip });
                
            }
            return id;
        }
        public static int VratiIdZaTipKomponente(string vrsta)
        {
            int id;
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                id = con.QuerySingle<int>("dbo.Vrati_Tip_Komponente @vrsta_komponenta", new { vrsta_komponenta = vrsta });
            }
            return id;
        }
        public static void DodajGrafickuZaNoviRacunar(GrafickaKartica graficka)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@ime_proizvoda", graficka.ime_proizvoda);
                p.Add("@id_racunar", graficka.id_racunar);
                p.Add("@ime", graficka.ime);
                p.Add("@kolicina_memorije", graficka.kolicina_memorije);
                p.Add("@id_tip_komponente", graficka.id_tip_komponente);
                con.Execute("dbo.DodajGraficku", p, commandType: CommandType.StoredProcedure);
            }
        }
        public static void DodajMaticnuPlocuZaNoviRacunar(MaticnaPloca mp)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@ime_proizvoda", mp.ime_proizvoda);
                p.Add("@id_racunar", mp.id_racunar);
                p.Add("@cipset", mp.cipset);
                p.Add("@id_tip_komponente", mp.id_tip_komponente);
                con.Execute("dbo.DodajMaticnuPlocu", p, commandType: CommandType.StoredProcedure);
            }
        }
        public static void DodajProcesorZaNoviRacunar(Procesor pr)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@ime_proizvoda", pr.ime_proizvoda);
                p.Add("@id_racunar", pr.id_racunar);
                p.Add("@frekvencija_rada", pr.frekvencija_rada);
                p.Add("@broj_jezgara", pr.broj_jezgara);
                p.Add("@id_tip_komponente", pr.id_tip_komponente);
                con.Execute("dbo.DodajProcesor", p, commandType: CommandType.StoredProcedure);
            }
        }
        public static void DodajRAMZaNoviRacunar(RAM ram)
        {
            using (IDbConnection con = new SqlConnection(VratiKonString("baza")))
            {
                var p = new DynamicParameters();
                p.Add("@ime_proizvoda", ram.ime_proizvoda);
                p.Add("@id_racunar", ram.id_racunar);
                p.Add("@kolicina_memorije", ram.kolicina_memorije);
                p.Add("@tip_ram", ram.tip_ram);
                p.Add("@id_tip_komponente", ram.id_tip_komponente);
                con.Execute("dbo.DodajRAM", p, commandType: CommandType.StoredProcedure);
            }
        }

    }
}

