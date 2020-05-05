using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class GatunekRandomize:Gatunek
    {
        
        Random random = new Random();
        public GatunekRandomize(int cuurentId,HashSet<string> Gatunki)
        {
            Id = cuurentId;
            Nazwa = RandomNazwa(Gatunki);
        }
        private string RandomNazwa(HashSet<string> Gatunki)
        {
            bool exist = true;
            string NazwaGatunku = "";
            int r = random.Next(3, 10);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            while(exist){
                for (int i = 0; i < r; ++i)
                {
                    NazwaGatunku += chars[random.Next(chars.Length)];
                }
                exist = Gatunki.Contains(NazwaGatunku);
            }
            return NazwaGatunku;
        }
      

    }
}
