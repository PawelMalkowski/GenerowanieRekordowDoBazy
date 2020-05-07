using System;
using System.Collections.Generic;
using System.Text;
using GenerowanieRekordow.DAO_Randomize;


namespace GenerowanieRekordówDoBazy
{
    class InsertObjectToDatabase
    {
        private readonly DbConnection dbConnection = new DbConnection();
        public int[] progress = new int[15];
        public void InsertKraje(HashSet<KrajRandomize> Kraje)
        {
            string tabel = "KRAJ";
            string columns = "ID,KRAJ";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
           foreach(var kraj in Kraje)
           {
                ++progress[0];
                values.Add(kraj.Id+" , '"+kraj.Nazwa+"'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

        public void InsertGatunki(HashSet<GatunekRandomize> Gatunki)
        {
            string tabel = "GATUNEK";
            string columns = "ID,NAZWA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
           foreach(var gatunek in Gatunki)
           {
                ++progress[1];
                values.Add(gatunek.Id+" , '"+gatunek.Nazwa+"'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

        public void InsertPodgatunki(HashSet<PodgatunekRandomize> Podgatunki)
        {
            string tabel = "PODGATUNEK";
            string columns = "ID,NAZWA,ID_GATUNEK";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var podgatunek in Podgatunki)
            {
                ++progress[2];
                values.Add(podgatunek.Id + " , '" + podgatunek.Nazwa + "' , "+podgatunek.Id_gatunek);
                if (i==200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;   
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

        public void InsertAdresy(HashSet<AdresRandomize> Adresy)
        {
            string tabel = "ADRES";
            string columns = "KLIENT_ID,KRAJ,MIEJSCOWOSC,ULICA,NRDOMU,NRMIESZKANIA,KODPOCZTOWY";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var adres in Adresy)
            {
                ++progress[3];
                values.Add(adres.Id + ","+adres.Kraj+ " , '"+adres.Miejscowosc+"' , '"+adres.Ulica+" ' ,"+adres.NumerDomu+","+adres.NumerMieszkania+",'"+adres.KodPocztowy+"'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

        public void InsertFirmy(HashSet<FirmaRandomize> Firmy)
        {
            string tabel = "FIRMA";
            string columns = "ID,NAZWA,NIP,ADRES,TELEFON,EMAIL";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var firma in Firmy)
            {
                ++progress[4];
                values.Add(firma.Id + ", '" + firma.Nazwa + "' , '" + firma.NIP + "' , " + firma.Adres + "  ," + firma.Telefon + ",'" + firma.Email + "'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertUzytkownik(HashSet<UzytkownikRandomize> Uzytkownicy)
        {
            string tabel = "UZYTKOWNIK";
            string columns = "ID,LOGIN,HASLO,EMAIL";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var uzytkownik in Uzytkownicy)
            {
                ++progress[5];
                values.Add(uzytkownik.Id + ", '" + uzytkownik.Login + "' , '" + uzytkownik.Haslo + "' , '" + uzytkownik.Email + "'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertPracownicy(HashSet<PracownikRandomize> Pracownicy)
        {
            string tabel = "PRACOWNIK";
            string columns = "ID,IMIE,DRUGIEIMIE,NAZIWSKO,PESEL,ADRES,TELEFON,EMAIL";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var pracownik in Pracownicy)
            {
                ++progress[6];
                values.Add(pracownik.Id + ", '" + pracownik.Imie + "' , '" + pracownik.DrugieImie + "' , '" + pracownik.Nazwisko + "','"+pracownik.PESEL+"',"+pracownik.Adres+",'"+pracownik.Telefon+"','"+pracownik.Email+"'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

        public void InsertKlient(HashSet<KlientRandomize> Klienci)
        {
            string tabel = "KLIENT";
            string columns = "ID,IMIE,NAZWISKO,TELEFON,EMAIL,ADRES";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var klient in Klienci)
            {
                ++progress[7];
                values.Add(klient.Id + ", '" + klient.Imie +  "' , '" + klient.Nazwisko + "'," + klient.Telefon + ",'" + klient.Email + "'," + klient.Adres);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertProdukty(HashSet<ProduktRandomize> Produkty)
        {
            string tabel = "PRODUKT";
            string columns = "ID,ILOSC,WAGA,CENA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var produkt in Produkty)
            {
                values.Add(produkt.Id + "," + produkt.Ilosc + ",'" + produkt.Waga + "','" +produkt.Cena+"'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertAkcesoria(HashSet<AkcesorieRandomize> Akcesoria)
        {
            string tabel = "AKCESORIE";
            string columns = "ID,NAZWA,PRODUCENT,ZWIERZE";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var akcesorie in Akcesoria)
            {
                ++progress[8];
                values.Add(akcesorie.ID + ",'" + akcesorie.Nazwa + "'," + akcesorie.Producent + "," + akcesorie.Zwierze);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertPokarmy(HashSet<PokarmRandomize> Pokarmy)
        {
            string tabel = "POKARM";
            string columns = "ID,PRODUCENT,ZWIERZE,KALORIE,NAZWA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var pokarm in Pokarmy)
            {
                ++progress[9];
                values.Add(pokarm.Id + "," + pokarm.Producent+ "," + pokarm.Zwierze + "," + pokarm.Kalorie+ ",'"+pokarm.Nazwa+"'");
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertPokarmGatunek(HashSet<Posrednia_Pokarm_GatunekRandomize> PokarmGatunek)
        {
            string tabel = "POSREDNIA_POKARM_GATUNEK";
            string columns = "ID,ID_GATUNEK,ID_POKARM";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var pokarmgatunek in PokarmGatunek)
            {
                ++progress[10];
                values.Add(pokarmgatunek.Id + "," + pokarmgatunek.Id_Gatunek + "," + pokarmgatunek.Id_Pokarm);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertZamowienia(HashSet<ZamowieniaRandomize> Zamowienia)
        {
            string tabel = "ZAMOWIENIA";
            string columns = "ID,DATA_ZLOZENIA,STATUS,PRZESYLKA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var zamowienie in Zamowienia)
            {
                ++progress[11];
                values.Add(zamowienie.Id + "," + "to_date('"+zamowienie.Data_zlozenia.Year+"/"+zamowienie.Data_zlozenia.Month+"/"+zamowienie.Data_zlozenia.Day+"', 'RR/MM/DD')  ," + zamowienie.Status+","+zamowienie.Przesylka);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertUzytkownikFirma(HashSet<Posrednia_Uzytkownik_FirmaRadmoize> UzytkownikFirma)
        {
            string tabel = "POSREDNIA";
            string columns = "ID,ID_USER,ID_FIRMA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var uzytkownikFirma in UzytkownikFirma)
            {
                ++progress[12];
                values.Add(uzytkownikFirma.Id + "," + uzytkownikFirma.Id_User + "," + uzytkownikFirma.Id_Firma);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }
        public void InsertZwierzeta(HashSet<ZwierzeRandomize> Zwierzeta)
        {
            string tabel = "ZWIERZE";
            string columns = "ID,GATUNEK,PODGATUNEK,OJCIEC,MATKA,WAGA,WIEK,LICENCJA,TRANSPORT,HODOWLA,DOSTAWCA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            
            foreach (var zwierze in Zwierzeta)
            {
                ++progress[13];
                string MatkaString, OjciecString;
                if (zwierze.Matka == 0) MatkaString = "null";
                else MatkaString = zwierze.Matka.ToString();
                if (zwierze.Ojciec == 0) OjciecString = "null";
                else OjciecString = zwierze.Ojciec.ToString();
                values.Add(zwierze.Id + "," + zwierze.Gatunek + "," + zwierze.Podgatunek+","+OjciecString+","+MatkaString+",'"+zwierze.Waga+"',"+zwierze.Wiek+","+zwierze.Licencja+","+zwierze.Transport+","+zwierze.Hodowla+","+zwierze.Dostawca);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

        public void InsertProduktZamowienie(HashSet<Posrednia_Produkt_ZamowienieRandomize> ProduktZamowienie)
        {
            string tabel = "POSREDNIA_PRODUK_ZAMOWIENIE";
            string columns = "ID,ID_ZAMOWIENIE,ID_PRODUKT";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var produktzamowienie in ProduktZamowienie)
            {
                ++progress[14];
                values.Add(produktzamowienie.Id + "," + produktzamowienie.Id_Zamowienie+ "," + produktzamowienie.Id_Produkt);
                if (i == 200)
                {
                    dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
                    values.Clear();
                    i = 0;
                }
                else ++i;
            }
            dbConnection.InsertObjectToDatabaseTodatbase(tabel, columns, values);
        }

    }
}
