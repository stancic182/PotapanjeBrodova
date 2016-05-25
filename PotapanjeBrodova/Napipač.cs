using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Napipač : IPucač

    {
        public Napipač(Mreža mreža,int duljinaBroda)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;
        }
         public Polje UputiPucanj()
        {
            // Dohvati listu svih Kandidata
            List<Polje> polja = DajKandidateZaVertikalniBrod().ToList();
            polja.AddRange(DajKandidateZaVertikalniBrod());
   
            //slučanim odabirom odaberi jednog
            int index = slučajni.Next(0, polja.Count());
            return polja[index];
        }

        public IEnumerable<Polje> DajKandidateZaHorizontalniBrod()
        {
            List<Polje> kandidati = new List<Polje>();
            var slobodna = mreža.DajSlobodnaPolja();
            for (int r = 0; r < mreža.Redaka; ++r)
            {
                int brojačPolja = 0;
                for (int s = 0; s < mreža.Stupaca; s++)
                {
                    Polje p = new Polje(r, s);
                    if (slobodna.Contains(p))
                        ++brojačPolja;
                    else
                        brojačPolja = 0;

                    if (brojačPolja >=  duljinaBroda)
                       {
                            for (int ss = s - duljinaBroda + 1; ss <= s; ++ss)
                            {

                                kandidati.Add(new Polje(ss, r));
                            }
                        }
                }

            }
            return kandidati;

        }
        public IEnumerable<Polje> DajKandidateZaVertikalniBrod()
        {
            List<Polje> kandidati = new List<Polje>();
            var slobodna = mreža.DajSlobodnaPolja();
            for (int s = 0; s < mreža.Redaka; ++s)
            {
                int brojačPolja = 0;
                for (int r = 0; r < mreža.Stupaca; r++)
                {
                    Polje p = new Polje(r, s);
                    if (slobodna.Contains(p))
                        ++brojačPolja;
                    else
                        brojačPolja = 0;

                    if (brojačPolja >= duljinaBroda)
                    {
                        for (int rr = r - duljinaBroda +1 ; rr <= s; ++rr)
                        {
                            kandidati.Add(new Polje(rr, s));
                        }
                    }
                }

            }
            return kandidati;

        }

        public void EvidentiranjRezultat(RezultatGađanja rezultat)
        {
            throw new NotImplementedException();
        }

        private Mreža mreža;
        private int duljinaBroda;
        private Random slučajni = new Random();

    }
   
}
