using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class AkcesorieRandomize:Akcesorie
    {
        readonly Random random = new Random();

        public AkcesorieRandomize(int Currentid,List<int> Producenci, List<int> Zwierzeta)
        {
            ID = Currentid;
            Nazwa = RandomNazwa();
            Producent = RandomProducent(Producenci);
            Zwierze = RandomZwierze(Zwierzeta);
        }
        private string RandomNazwa()
        {
            string NazwaAkcesoria = "";
            int r = random.Next(3, 15);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            for (int i = 0; i < r; ++i)
            {
                NazwaAkcesoria += chars[random.Next(chars.Length)];
            }
            return NazwaAkcesoria;
        }
        private int RandomProducent(List<int> Producenci)
        {
            int r = random.Next(Producenci.Count);
            return Producenci[r];
        }
        private int RandomZwierze(List<int> Zwierzeta)
        {
            int r = random.Next(Zwierzeta.Count);
            return Zwierzeta[r];
        }

    }
}
