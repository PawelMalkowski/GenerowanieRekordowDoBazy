using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class ZamowieniaRandomize:Zamowienia
    {
        readonly Random Random = new Random();
        public ZamowieniaRandomize(int currenId,int Rok, List<int> Statusy, List<int> Przesylki)
        {
            Id = currenId;
            Data_zlozenia = RandomData_zlozenia(Rok);
            Status = RandomStatus(Statusy);
            Przesylka = RandomPrzesylki(Przesylki);
        }


       private DateTime RandomData_zlozenia(int Rok)
        {
            DateTime start = new DateTime(Rok, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Random.Next(range));
        }
        private int RandomStatus(List<int> Statusy)
        {
            int stausLiczba;
            stausLiczba = Statusy[Random.Next(Statusy.Count)];
            return stausLiczba;
        }
        private int RandomPrzesylki(List<int> Przesylki)
        {
            int PrzesylkiLiczba;
            PrzesylkiLiczba = Przesylki[Random.Next(Przesylki.Count)];
            return PrzesylkiLiczba;
        }


    }
}
