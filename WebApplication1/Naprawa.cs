using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serwis_drugi;

namespace serwis_drugi
{
    public class Naprawa : Rower
    {
        public int Koszt { get; set; }

        public int ID { get; set; }

        public Rower Rower { get; set; }
        public int RowerId { get; set; }

        //public Naprawa(int id, DateTime dataPrzyjecia, int koszt) : base(id, dataPrzyjecia)
        //{
        //    ID = id;
        //    DataPrzyjecia = dataPrzyjecia;
        //    Koszt = koszt;
        //}

        public Naprawa()
        {
        }

    }
}









