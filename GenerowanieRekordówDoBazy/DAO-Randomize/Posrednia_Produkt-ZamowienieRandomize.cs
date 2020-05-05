using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class Posrednia_Produkt_ZamowienieRandomize: Posrednia_Produkt_Zamowienie
    {
        Random random = new Random();
        public Posrednia_Produkt_ZamowienieRandomize(int currentId, List<int> firstList, List<int> secondList, HashSet<long> listCombinationAlreadyUs)
        {
            Id = currentId;
            var kombinacja = RandomCombination(firstList,secondList,listCombinationAlreadyUs);
            Id_Zamowienie = kombinacja.Item2;
            Id_Produkt = kombinacja.Item1;
        }
        private (int, int) RandomCombination(List<int> firstList, List<int> secondList, HashSet<long> listCombinationAlreadyUse)
        {
            long hash1;
            (int, int) combination;
            do
            {
                int firstListIndex = random.Next(0, firstList.Count);
                int secondListIndex = random.Next(0, secondList.Count);
                combination = (firstList[firstListIndex], secondList[secondListIndex]);
                hash1 = ((long)combination.Item1 << 32) | (long)combination.Item2;

            } while (listCombinationAlreadyUse.Contains(hash1));
            listCombinationAlreadyUse.Add(hash1);

            return combination;
        }
    }
}
