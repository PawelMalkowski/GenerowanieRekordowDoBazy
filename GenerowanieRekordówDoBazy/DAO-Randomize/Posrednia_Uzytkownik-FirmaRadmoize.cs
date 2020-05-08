using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class Posrednia_Uzytkownik_FirmaRadmoize: Posrednia_Uzytkownik_Firma
    {
        readonly Random random = new Random();
        public Posrednia_Uzytkownik_FirmaRadmoize(int currentId, List<int> firstList, List<int> secondList, HashSet<long> listCombinationAlreadyUse)
        {
            Id = currentId;
            var kombinacja = RandomCombination(firstList, secondList,listCombinationAlreadyUse);
            Id_User = kombinacja.Item1;
            Id_Firma = kombinacja.Item2;
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
