using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;
using GenerowanieRekordow;

namespace GenerowanieRekordow.DAO_Randomize
{
    class PracownikRandomize:Pracownik
    {
        bool mezczyzna = true;
        readonly Random random = new Random();
        int NumerImienia=0;
        public PracownikRandomize(int currentId, List<string> Imiona, List<int> Adresy, int Podzial, HashSet<string> Pesele,HashSet<string>Emaile)
        {
            Id = currentId;
            Nazwisko = RandomNazwisko();
            PESEL = RandomPESEL(Pesele); 
            Imie = RandomImie(Imiona,Podzial);
            DrugieImie= RandomImie(Imiona, Podzial);
            Telefon = RandomTelefon();
            Email = RandomEmail(Emaile);
            Adres = RandomAdres(Adresy);
        }
        private string RandomImie(List<string> Imiona,int podzial)
        {
            if (mezczyzna) NumerImienia = random.Next(podzial, Imiona.Count);
            else NumerImienia = random.Next(podzial);
            return Imiona[NumerImienia];
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
        private string RandomPESEL(HashSet<string>Pesele )
        {
            var a = new PeselGenerator();
            string Pesel;
            do
            {
                Pesel = a.Generate(1900);
                if ((Int64.Parse(Pesel) / 10) % 2 == 0) mezczyzna = false;
                else mezczyzna = true;
            } while (Pesele.Contains(Pesel));


            return Pesel;
        
        }
        private string RandomTelefon()
        {
            return random.Next(100000000, 999999999).ToString();
        }
        private string RandomEmail(HashSet<String> Emaile)
        {
            string NazwaEmail = "";
            int r = random.Next(3, 20);
            char[] chars  = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            do
            {
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
            } while (Emaile.Contains(NazwaEmail));
            return NazwaEmail;

        }
        private int RandomAdres(List<int> Adresy)
        {
            int x = random.Next(Adresy.Count);
            return Adresy[x];
        }
    }
}
