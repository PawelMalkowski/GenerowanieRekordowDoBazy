using System;
using System.Collections.Generic;
using System.Text;
using GenerowanieRekordow.DAO_Randomize;
using System.Threading.Tasks;


namespace GenerowanieRekordówDoBazy
{
    class InsertObjectToDatabase
    {
        private readonly DbConnection dbConnection = new DbConnection();
        public int[] progress = new int[15];
        public int recordsIsdone;
        volatile public StringBuilder inserts= new StringBuilder();
        volatile public bool taskRunning;
        public string insertToAdd = "INSERT INTO  {0} (  {1} ) VALUES ( {2} );"+Environment.NewLine;
        public void InsertKraje(HashSet<KrajRandomize> Kraje)
        {
            string tabel = "KRAJ";
            inserts.Append( "-- " + tabel + Environment.NewLine);
            string columns = "ID,KRAJ";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            int i = 0;
            string QueryFormat= "{0} , '{1}'";
            string var;
            foreach (var kraj in Kraje)
           {
                ++recordsIsdone;
                ++progress[5];
                var = String.Format(QueryFormat,kraj.Id,kraj.Nazwa);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }

        public void InsertGatunki(HashSet<GatunekRandomize> Gatunki)
        {
            string tabel = "GATUNEK";
            inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,NAZWA";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            int i = 0;
            string QueryFormat = "{0} , '{1}'";
            string var;
            foreach (var gatunek in Gatunki)
           {
                ++recordsIsdone;
                ++progress[3];
                var = String.Format(QueryFormat, gatunek.Id, gatunek.Nazwa);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }

        public void InsertPodgatunki(HashSet<PodgatunekRandomize> Podgatunki)
        {
            string tabel = "PODGATUNEK";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,NAZWA,ID_GATUNEK";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},'{1}',{2}";
            string var;
            int i = 0;
            foreach (var podgatunek in Podgatunki)
            {
                ++recordsIsdone;
                ++progress[6];
                var = String.Format(QueryFormat, podgatunek.Id, podgatunek.Nazwa, podgatunek.Id_gatunek);
                values.Add(var);
                if (i==200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;   
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }

        public void InsertAdresy(HashSet<AdresRandomize> Adresy)
        {
            string tabel = "ADRES";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "KLIENT_ID,KRAJ,MIEJSCOWOSC,ULICA,NRDOMU,NRMIESZKANIA,KODPOCZTOWY";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            int i = 0;
            string QueryFormat = "{0},{1},'{2}','{3}',{4},{5},'{6}'";
            string var;
            foreach (var adres in Adresy)
            {
                ++recordsIsdone;
                ++progress[0];
                var = String.Format(QueryFormat, adres.Id, adres.Kraj, adres.Miejscowosc, adres.Ulica, adres.NumerDomu, adres.NumerMieszkania, adres.KodPocztowy);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }

        public void InsertFirmy(HashSet<FirmaRandomize> Firmy)
        {
            string tabel = "FIRMA";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,NAZWA,NIP,ADRES,TELEFON,EMAIL";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},'{1}',{2},{3},{4},'{5}'";
            string var;
            int i = 0;
            foreach (var firma in Firmy)
            {
                ++recordsIsdone;
                ++progress[2];
                var = String.Format(QueryFormat, firma.Id, firma.Nazwa, firma.NIP, firma.Adres,firma.Telefon ,firma.Email);
                values.Add(var);

                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertUzytkownik(HashSet<UzytkownikRandomize> Uzytkownicy)
        {
            string tabel = "UZYTKOWNIK";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,LOGIN,HASLO,EMAIL";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},'{1}','{2}','{3}'";
            string var;
            int i = 0;
            foreach (var uzytkownik in Uzytkownicy)
            {
                ++recordsIsdone;
                ++progress[12];
                var = String.Format(QueryFormat, uzytkownik.Id, uzytkownik.Login, uzytkownik.Haslo, uzytkownik.Email);
                values.Add(var);

                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertPracownicy(HashSet<PracownikRandomize> Pracownicy)
        {
            string tabel = "PRACOWNIK";
            inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,IMIE,DRUGIEIMIE,NAZIWSKO,PESEL,ADRES,TELEFON,EMAIL";
            string QueryFormat = "{0},'{1}','{2}','{3}','{4}',{5},{6},'{7}'";
            string var;
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            int i = 0;
            foreach (var pracownik in Pracownicy)
            {
                ++recordsIsdone;
                ++progress[11];
                var = String.Format(QueryFormat, pracownik.Id, pracownik.Imie, pracownik.DrugieImie, pracownik.Nazwisko, pracownik.PESEL, pracownik.Adres, pracownik.Telefon, pracownik.Email);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }

        public void InsertKlient(HashSet<KlientRandomize> Klienci)
        {
            string tabel = "KLIENT";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,IMIE,NAZWISKO,TELEFON,EMAIL,ADRES";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},'{1}','{2}',{3},'{4}',{5}";
            string var;
            int i = 0;
            foreach (var klient in Klienci)
            {
                ++recordsIsdone;
                ++progress[4];
                var = String.Format(QueryFormat, klient.Id, klient.Imie, klient.Nazwisko, klient.Telefon, klient.Email, klient.Adres);
                values.Add(var); 
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertProdukty(HashSet<ProduktRandomize> Produkty ,int index)
        {
            string tabel = "PRODUKT";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,ILOSC,WAGA,CENA";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},{1},'{2}','{3}'";
            string var;
            int i = 0;
            foreach (var produkt in Produkty)
            {
                ++recordsIsdone;
                ++progress[index];
                var = String.Format(QueryFormat, produkt.Id, produkt.Ilosc, produkt.Waga, produkt.Cena);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertAkcesoria(HashSet<AkcesorieRandomize> Akcesoria)
        {
            string tabel = "AKCESORIE";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,NAZWA,PRODUCENT,ZWIERZE";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},'{1}',{2},{3}";
            string var;
            int i = 0;
            foreach (var akcesorie in Akcesoria)
            {
                ++recordsIsdone;
                ++progress[1];
                var = String.Format(QueryFormat, akcesorie.ID , akcesorie.Nazwa , akcesorie.Producent , akcesorie.Zwierze);
                values.Add(var);

                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertPokarmy(HashSet<PokarmRandomize> Pokarmy)
        {
            string tabel = "POKARM";
            inserts.Append("-- " + tabel + Environment.NewLine); 
            string columns = "ID,PRODUCENT,ZWIERZE,KALORIE,NAZWA";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},{1},{2},{3},'{4}'";
            string var;
            int i = 0;
            foreach (var pokarm in Pokarmy)
            {
                ++recordsIsdone;
                ++progress[7];
                var = String.Format(QueryFormat, pokarm.Id, pokarm.Producent, pokarm.Zwierze, pokarm.Kalorie, pokarm.Nazwa);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertPokarmGatunek(HashSet<Posrednia_Pokarm_GatunekRandomize> PokarmGatunek)
        {
            string tabel = "POSREDNIA_POKARM_GATUNEK";
            inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,ID_GATUNEK,ID_POKARM";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},{1},{2}";
            string var;
            int i = 0;
            foreach (var pokarmgatunek in PokarmGatunek)
            {
                ++recordsIsdone;
                ++progress[8];
                var = String.Format(QueryFormat, pokarmgatunek.Id, pokarmgatunek.Id_Gatunek, pokarmgatunek.Id_Pokarm);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertZamowienia(HashSet<ZamowieniaRandomize> Zamowienia)
        {
           
            string tabel = "ZAMOWIENIA";
            inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,DATA_ZLOZENIA,STATUS,PRZESYLKA";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0} , to_date('{1}/{2}/{3}', 'RR/MM/DD') ,{4},{5}";
            string var;
            int i = 0;
            foreach (var zamowienie in Zamowienia)
            {
                ++recordsIsdone;
                ++progress[13];
                var = String.Format(QueryFormat, zamowienie.Id, zamowienie.Data_zlozenia.Year, zamowienie.Data_zlozenia.Month, zamowienie.Data_zlozenia.Day, zamowienie.Status, zamowienie.Przesylka);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertUzytkownikFirma(HashSet<Posrednia_Uzytkownik_FirmaRadmoize> UzytkownikFirma)
        {
            ++recordsIsdone;
            string tabel = "POSREDNIA";
            inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,ID_USER,ID_FIRMA";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},{1},{2}";
            string var;
            int i = 0;
            foreach (var uzytkownikFirma in UzytkownikFirma)
            {
                ++recordsIsdone;
                ++progress[10];
                var = String.Format(QueryFormat ,uzytkownikFirma.Id, uzytkownikFirma.Id_User, uzytkownikFirma.Id_Firma);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }
        public void InsertZwierzeta(HashSet<ZwierzeRandomize> Zwierzeta)
        {
            string tabel = "ZWIERZE";
            inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,GATUNEK,PODGATUNEK,OJCIEC,MATKA,WAGA,WIEK,LICENCJA,TRANSPORT,HODOWLA,DOSTAWCA";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            string QueryFormat = "{0},{1},{2},{3},{4},'{5}',{6},{7},{8},{9},{10}";
            string var;
            int i = 0;
            
            foreach (var zwierze in Zwierzeta)
            {
                ++recordsIsdone;
                ++progress[14];
                string MatkaString, OjciecString;
                if (zwierze.Matka == 0) MatkaString = "null";
                else MatkaString = zwierze.Matka.ToString();
                if (zwierze.Ojciec == 0) OjciecString = "null";
                else OjciecString = zwierze.Ojciec.ToString();
                var = String.Format(QueryFormat, zwierze.Id, zwierze.Gatunek, zwierze.Podgatunek, OjciecString, MatkaString, zwierze.Waga, zwierze.Wiek, zwierze.Licencja, zwierze.Transport, zwierze.Hodowla, zwierze.Dostawca);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning) ;
            Task.Run(() => AddTableToString(Allvalues, tabel, columns));
        }

        public async void InsertProduktZamowienie(HashSet<Posrednia_Produkt_ZamowienieRandomize> ProduktZamowienie)
        {
            
            string tabel = "POSREDNIA_PRODUK_ZAMOWIENIE";
            if (ProduktZamowienie.Count>0) inserts.Append("-- " + tabel + Environment.NewLine);
            string columns = "ID,ID_ZAMOWIENIE,ID_PRODUKT";
            HashSet<string> values = new HashSet<string>();
            HashSet<string> Allvalues = new HashSet<string>();
            int i = 0;
            string QueryFormat = "{0},{1},{2}";
            string var;
            foreach (var produktzamowienie in ProduktZamowienie)
            {
                ++recordsIsdone;
                ++progress[9];
                var = String.Format(QueryFormat, produktzamowienie.Id, produktzamowienie.Id_Zamowienie, produktzamowienie.Id_Produkt);
                values.Add(var);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    Allvalues.UnionWith(values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
            Allvalues.UnionWith(values);
            while (taskRunning);
            AddTableToString(Allvalues, tabel, columns);
        }
        private void AddTableToString(HashSet<String> Allvalues,string table, string columns)
        {
            taskRunning = true;
             foreach (string value in Allvalues)
            {
                inserts.Append(String.Format(insertToAdd, table, columns, value));
            }
            taskRunning = false;

        }

    }
}
