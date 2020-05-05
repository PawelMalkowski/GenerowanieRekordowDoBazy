using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class AdresRandomize:Adres
    {
        readonly Random random = new Random();
        public AdresRandomize(int CurrentId,List<int> Kraje, List<string> Miejscowosci)
        {
            Id = CurrentId;
            Kraj = RandomKraj(Kraje);
            Miejscowosc = RandomMiejscowosc(Miejscowosci);
            Ulica = RandomUlica();
            NumerDomu = RandomNumerDomu();
            NumerMieszkania = RandomNumerMieszkania();
            KodPocztowy = RandomKodPocztowy();

        }
        private int RandomKraj(List<int> Kraje) 
        {
            int r = random.Next(Kraje.Count);
            return Kraje[r];
        }
        private string RandomMiejscowosc(List<string> Miejscowosci)
        {
            
            int r = random.Next(Miejscowosci.Count);
            return Miejscowosci[r];
        }
        private string RandomUlica()
        {
            string NazwaUlicy="";
            int r = random.Next(3, 15);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            for(int i = 0; i < r; ++i)
            {
                NazwaUlicy += chars[random.Next(chars.Length)];
            }
            return NazwaUlicy;
        }
        private string RandomNumerDomu()
        {
            return random.Next(1, 999).ToString();
        }
        private string RandomNumerMieszkania()
        {
            if (random.NextDouble() > 0.5) return random.Next(1, 99).ToString();
            else return "null";
        }
        private string RandomKodPocztowy()
        {
            return random.Next(1, 99).ToString() + random.Next(100, 999);
        }

    }
}
