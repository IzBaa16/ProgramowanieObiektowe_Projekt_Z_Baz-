using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serwis_drugi;

namespace serwis_drugi
{
    public class PracownikSerwisu : Osoba
    {
        public int Doswiadczenie { get; set; }

        public PracownikSerwisu(int id, string imie, string nazwisko, int doswiadczenie)
        {
            ID = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Doswiadczenie = doswiadczenie;
        }

        public PracownikSerwisu()
        {
                
        }
    }
}



