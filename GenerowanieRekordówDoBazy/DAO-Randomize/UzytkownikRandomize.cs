using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerowanieRekordow.DAO;
using System.Security.Cryptography;

namespace GenerowanieRekordow.DAO_Randomize
{
    class UzytkownikRandomize:Uzytkownik
    {
        readonly Random Random = new Random();
        public UzytkownikRandomize(int currentId, HashSet<string> Loginy, HashSet<string> Emaile)
        {
            Id = currentId;
            Login = RandomLogin(Loginy);
            Haslo = RandomHaslo();
            Email = RandomEmail(Emaile);
        }

        private string RandomLogin(HashSet<string>Loginy)
        {
            string NazwaLogin = "";
            do
            {
                int r = Random.Next(3, 20);
                char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                for (int i = 0; i < r; ++i)
                {
                    NazwaLogin += chars[Random.Next(chars.Length)];
                }
            } while (Loginy.Contains(NazwaLogin));
            return NazwaLogin;
        }
   
        private string RandomHaslo()
        {
            string NazwaHaslo = "";
            string HashedPassword;

                int r = Random.Next(8, 30);
                char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                for (int i = 0; i < r; ++i)
                {
                    NazwaHaslo += chars[Random.Next(chars.Length)];
                }

                SHA256 sHA = SHA256.Create();
                HashedPassword = GethHash(sHA, NazwaHaslo);

            return HashedPassword;
        }

        private string GethHash(SHA256 hashAlgorithm, string input)
        {

            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));


            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private string RandomEmail(HashSet<String> Emaile)
        {
            string NazwaEmail = "";
            int r = Random.Next(3, 20);
            char[] chars = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            do
            {
                for (int i = 0; i < r; ++i)
                {
                    NazwaEmail += chars[Random.Next(chars.Length)];
                }
                NazwaEmail += '@';
                r = Random.Next(3, 10);
                for (int i = 0; i < r; ++i)
                {
                    NazwaEmail += chars[Random.Next(chars.Length)];
                }
                NazwaEmail += '.';
                r = Random.Next(2, 3);
                for (int i = 0; i < r; ++i)
                {
                    NazwaEmail +=chars[ Random.Next(chars.Length)];
                }
            } while (Emaile.Contains(NazwaEmail));

            return NazwaEmail;

        }

    }
}
