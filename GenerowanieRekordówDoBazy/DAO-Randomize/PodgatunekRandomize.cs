
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class PodgatunekRandomize:Podgatunek
    {
        readonly Random random = new Random();
        public PodgatunekRandomize(int CurrentId, List<int> Gatunki, HashSet<String> Podgatunki)
        {
            Id = CurrentId;
            Nazwa = RandomNazwa(Podgatunki);
            Id_gatunek = RandomGatunek(Gatunki);

        }
        private string RandomNazwa(HashSet<String> Podgatunki)
        {
            bool exist = true;
            string NazwaPodgatunku = "";
            int r = random.Next(3, 10);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            while (exist)
            {
                for (int i = 0; i < r; ++i)
                {
                    NazwaPodgatunku += chars[random.Next(chars.Length)];
                }
                exist = Podgatunki.Contains(NazwaPodgatunku);
            }
            return NazwaPodgatunku;
        }
        private int RandomGatunek(List<int> Gatunki)
        {
            int x = random.Next(Gatunki.Count);
            return Gatunki[x];
        }

    }
}
