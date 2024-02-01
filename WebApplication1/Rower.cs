using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace serwis_drugi
{
    public class Rower
    {
        public int ID { get; set; }
        public DateTime DataPrzyjecia { get; set; }



        public Rower(int id, DateTime dataPrzyjecia)
        {
            ID = id;
            DataPrzyjecia = dataPrzyjecia;

        }

        public Rower()
        {
            
        }
    }
}
