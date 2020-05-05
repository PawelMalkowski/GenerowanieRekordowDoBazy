using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class PokarmRandomize:Pokarm
    {
        Random Random = new Random();
        public PokarmRandomize(int CurrentInt,List<int> Producenci, List<int> Zwierzeta)
        {
            Id = CurrentInt;
            Producent = RandomProducent(Producenci);
            Zwierze = RandomZwierze(Zwierzeta);
            Kalorie = RandomKalorie();
            Nazwa = RandomNazwa();
        }
        private int RandomProducent(List<int> Producenci)
        {
            int r = Random.Next(Producenci.Count);
            return Producenci[r];
        }
        private int RandomZwierze(List<int> Zwierzeta)
        {
            int r = Random.Next(Zwierzeta.Count);
            return Zwierzeta[r];
        }
        private string RandomKalorie()
        {
            return Random.Next(100, 3000).ToString();
        }
        private string RandomNazwa()
        {
            string RNazwa = "";
            int r = Random.Next(3, 15);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            for (int i = 0; i < r; ++i)
            {
                RNazwa += chars[Random.Next(chars.Length)];
            }
            return RNazwa;
        }

    }
}
