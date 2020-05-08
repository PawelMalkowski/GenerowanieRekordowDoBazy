using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class KlientRandomize:Klient
    {
        public KlientRandomize(int currentId,List<string> Imiona,List<int> Adresy)
        {
            Id = currentId;
            Imie = RandomImie(Imiona);
            Nazwisko = RandomNazwisko();
            Telefon = RandomTelefon();
            Email = RandomEmail();
            Adres = RandomAdres(Adresy);
        }

        readonly Random random = new Random();
        private string RandomImie(List<string> Imiona)
        {
            int r = random.Next(Imiona.Count);
            return Imiona[r];
        }
        private string RandomNazwisko()
        {
            string NazwaNazwisko = "";
            int r = random.Next(3, 15);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            for (int i = 0; i < r; ++i)
            {
                NazwaNazwisko += chars[random.Next(chars.Length)];
            }
            return NazwaNazwisko;
        }
        private string RandomTelefon()
        {
            return random.Next(100000000, 999999999).ToString();
        }
        private string RandomEmail()
        {
            string NazwaEmail = "";
            int r = random.Next(3, 20);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            for (int i = 0; i < r; ++i)
            {
                NazwaEmail += chars[random.Next(chars.Length)];
            }
            NazwaEmail += '@';
            r = random.Next(3, 10);
            for (int i = 0; i < r; ++i)
            {
                NazwaEmail += chars[random.Next(chars.Length)];
            }
            NazwaEmail += '.';
            r = random.Next(2, 3);
            for (int i = 0; i < r; ++i)
            {
                NazwaEmail += chars[random.Next(chars.Length)];
            }
            return NazwaEmail;

        }
        private int RandomAdres(List<int> Adresy)
        {
            int x = random.Next(Adresy.Count);
            return Adresy[x];
        }
    }
}
