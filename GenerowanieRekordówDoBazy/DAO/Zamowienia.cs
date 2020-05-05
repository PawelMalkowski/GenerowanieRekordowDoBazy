using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieRekordow.DAO
{
    class Zamowienia
    {
        public int Id { get; set; }
        public DateTime Data_zlozenia { get; set; }
        public int Status { get; set; }
        public int Przesylka { get; set; }
    }
}
