using System;
using System.Collections.Generic;
using System.Text;
using GenerowanieRekordow.DAO;
using System.Linq;

namespace GenerowanieRekordow.DAO_Randomize
{
    class ZwierzeRandomize:Zwierze
    {
        private readonly Random random= new Random();

        private List<KeyValuePair<int, int>> Podgatunki;
        public ZwierzeRandomize(int currentId,List<int>GatunekList, HashSet<KeyValuePair<int, int>> GatuenkPodgatunekList, List<int> zwierzeta,List<int>Firmy)
        {
            Id = currentId;
            Gatunek = RandomGatunek(GatunekList,GatuenkPodgatunekList);
            Podgatunek = RandomPodgatunek();
            Ojciec = RandomOjciec(zwierzeta);
            Matka= RandomMatka(zwierzeta);
            Waga = randomWaga();
            Wiek = randomWiek();
            Licencja = randomLicencja();
            Transport = randomTransport();
            Hodowla = RandomHodowla(Firmy);
            Dostawca = RandomDostawca(Firmy);

        }

        private int RandomGatunek(List<int> GatunekList, HashSet<KeyValuePair<int, int>> GatuenkPodgatunekList)
        {
            int numberOfIndex;
            do
            {
                numberOfIndex = random.Next(GatunekList.Count);
                Podgatunki = GatuenkPodgatunekList.Where(x => x.Value == numberOfIndex+1).ToList();
            } while (Podgatunki.Count == 0);
            return GatunekList[numberOfIndex];
        }
        private int RandomPodgatunek()
        {
            int numberOfIndex = random.Next(Podgatunki.Count);

            return Podgatunki[numberOfIndex].Key;
        }


        private int RandomOjciec(List<int> zwierzeta)
        {
            if(random.NextDouble() > 0.5 && zwierzeta.Count > 0)
            {
                int numberOfIndex = random.Next(zwierzeta.Count);
                return zwierzeta[numberOfIndex];
            }
            return 0;
        }
        private int RandomMatka(List<int> zwierzeta)
        {
            if (random.NextDouble() < 0.5 && zwierzeta.Count>0)
            {
                int numberOfIndex = random.Next(zwierzeta.Count);
                return zwierzeta[numberOfIndex];
            }
            return 0;
        }
        private double randomWaga()
        {
            return (double)random.Next(1, 10000) / 100;
        }
        private int randomWiek()
        {
            return random.Next(0, 100);
        }
        private int randomLicencja()
        {
            return random.Next(1,2);
        }
        private int randomTransport()
        {
            return random.Next(1,2);
        }
        private int RandomHodowla(List<int> Firmy)
        {
            int numberOfIndex = random.Next(Firmy.Count);
            return Firmy[numberOfIndex];
        }
        private int RandomDostawca(List<int> Firmy)
        {
            int numberOfIndex = random.Next(Firmy.Count);
            return Firmy[numberOfIndex];
        }
    }
}
