using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieRekordow.DAO
{
    class Pokarm
    {
        public int Id { get; set; }
        public int Producent { get; set; }
        public int Zwierze { get; set; }
        public string Kalorie { get; set; }
        public string Nazwa { get; set; }
    }
}
