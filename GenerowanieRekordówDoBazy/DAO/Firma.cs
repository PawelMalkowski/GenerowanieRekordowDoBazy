using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieRekordow.DAO
{
    class Firma
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string NIP { get; set; }
        public int Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
