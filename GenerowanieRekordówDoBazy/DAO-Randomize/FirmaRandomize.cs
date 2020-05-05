using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;

namespace GenerowanieRekordow.DAO_Randomize
{
    class FirmaRandomize:Firma
    {
        readonly Random random = new Random();
        public FirmaRandomize(int currentId,List<int> Adresy, HashSet<string> NipList)
        {
            Id = currentId;
            Nazwa = RandomNazwa();
            NIP = RandomNip(NipList);
            Adres = RandomAdres(Adresy);
            Telefon = RandomTelefon();
            Email = RandomEmail();
        }
        private long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result |= (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }
        private string RandomNazwa()
        {
            string NazwaFirma = "";
            int r = random.Next(3, 15);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };
            for (int i = 0; i < r; ++i)
            {
                NazwaFirma += chars[random.Next(chars.Length)];
            }
            return NazwaFirma;
        }
        private string RandomNip(HashSet<string>NipList)
        {
            string NIP;
            do
            {
                NIP = LongRandom(1000000000, 9999999999, random).ToString();
            } while (NipList.Contains(NIP));
            return NIP;
        }
        private int RandomAdres(List<int>Adresy)
        {
            int x = random.Next(Adresy.Count);
            return Adresy[x];
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
            r = random.Next(2,3);
            for (int i = 0; i < r; ++i)
            {
                NazwaEmail += chars[random.Next(chars.Length)];
            }
            return NazwaEmail;
            
        }
     
    }
}
