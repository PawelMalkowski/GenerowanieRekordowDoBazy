using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class ProduktRandomize:Produkt
    {
        readonly Random Random = new Random();
        public ProduktRandomize(int Currentid)
        {
            Id = Currentid;
            Ilosc = RandomIlosc();
            Waga = WagaRandomize();
            Cena = CenaRandomize();
        }
        private int RandomIlosc()
        {
            return Random.Next(1, 1000);
        }
        private double WagaRandomize()
        {
            return (double)Random.Next(1, 10000) / 100;
        }
        private double CenaRandomize()
        {
            return (double)Random.Next(1, 1000000) / 100;
        }
    }
}
