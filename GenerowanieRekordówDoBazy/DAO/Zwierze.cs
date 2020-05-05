using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieRekordow.DAO
{
    class Zwierze
    {
        public int Id { get; set; }
        public int Gatunek { get; set; }
        public int Podgatunek { get; set; }
        public int Ojciec { get; set; }
        public int Matka { get; set; }
        public double Waga { get; set; }
        public int Wiek { get; set; }
        public int Licencja { get; set; }
        public int Transport { get; set; }
        public int Hodowla { get; set; }
        public int Dostawca { get; set; }
    }
}
