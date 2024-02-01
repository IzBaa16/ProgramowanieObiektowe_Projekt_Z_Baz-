using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serwis_drugi
{
    public class Narzedzie
    {
        public int ID { get; set; }
        public string Rodzaj { get; set; }
        public int Wytrzymalosc { get; set; }

        public Narzedzie(int id, string rodzaj, int wytrzymalosc)
        {
            ID = id;
            Rodzaj = rodzaj;
            Wytrzymalosc = wytrzymalosc;
        }

        public Narzedzie()
        {
                
        }
    }
}
