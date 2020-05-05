using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class KrajRandomize:Kraj
    {
        Random random = new Random();
        public int IdKraj;
        public KrajRandomize(int Currentid, List<string> Kraje)
        {
            Id = Currentid;
            Nazwa = RandomKraj(Kraje);
        }
        private string RandomKraj(List<string> Kraje)
        {
            IdKraj = random.Next(Kraje.Count);
            return Kraje[IdKraj];
        } 
    }
   
}
