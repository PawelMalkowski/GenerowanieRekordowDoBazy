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
        public int recordsIsdone;
        public string inserts="";
        public void InsertKraje(HashSet<KrajRandomize> Kraje)
        {
            string tabel = "KRAJ";
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,KRAJ";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
           foreach(var kraj in Kraje)
           {
                ++recordsIsdone;
                ++progress[5];
                values.Add(kraj.Id+" , '"+kraj.Nazwa+"'");
                inserts+= "INSERT INTO " +tabel+ " ("+columns+") VALUES ("+kraj.Id + " , '" + kraj.Nazwa + "');"+Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,NAZWA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
           foreach(var gatunek in Gatunki)
           {
                ++recordsIsdone;
                ++progress[3];
                values.Add(gatunek.Id+" , '"+gatunek.Nazwa+"'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES ("+ gatunek.Id + " , '" + gatunek.Nazwa + "');" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,NAZWA,ID_GATUNEK";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var podgatunek in Podgatunki)
            {
                ++recordsIsdone;
                ++progress[6];
                values.Add(podgatunek.Id + " , '" + podgatunek.Nazwa + "' , "+podgatunek.Id_gatunek);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + podgatunek.Id + " , '" + podgatunek.Nazwa + "' , " + podgatunek.Id_gatunek + ");" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "KLIENT_ID,KRAJ,MIEJSCOWOSC,ULICA,NRDOMU,NRMIESZKANIA,KODPOCZTOWY";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var adres in Adresy)
            {
                ++recordsIsdone;
                ++progress[0];
                values.Add(adres.Id + ","+adres.Kraj+ " , '"+adres.Miejscowosc+"' , '"+adres.Ulica+" ' ,"+adres.NumerDomu+","+adres.NumerMieszkania+",'"+adres.KodPocztowy+"'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + adres.Id + "," + adres.Kraj + " , '" + adres.Miejscowosc + "' , '" + adres.Ulica + " ' ," + adres.NumerDomu + "," + adres.NumerMieszkania + ",'" + adres.KodPocztowy + "');" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,NAZWA,NIP,ADRES,TELEFON,EMAIL";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var firma in Firmy)
            {
                ++recordsIsdone;
                ++progress[2];
                values.Add(firma.Id + ", '" + firma.Nazwa + "' , '" + firma.NIP + "' , " + firma.Adres + "  ," + firma.Telefon + ",'" + firma.Email + "'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + firma.Id + ", '" + firma.Nazwa + "' , '" + firma.NIP + "' , " + firma.Adres + "  ," + firma.Telefon + ",'" + firma.Email + "');" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,LOGIN,HASLO,EMAIL";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var uzytkownik in Uzytkownicy)
            {
                ++recordsIsdone;
                ++progress[12];
                values.Add(uzytkownik.Id + ", '" + uzytkownik.Login + "' , '" + uzytkownik.Haslo + "' , '" + uzytkownik.Email + "'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + uzytkownik.Id + ", '" + uzytkownik.Login + "' , '" + uzytkownik.Haslo + "' , '" + uzytkownik.Email + "');" + Environment.NewLine;

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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,IMIE,DRUGIEIMIE,NAZIWSKO,PESEL,ADRES,TELEFON,EMAIL";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var pracownik in Pracownicy)
            {
                ++recordsIsdone;
                ++progress[11];
                values.Add(pracownik.Id + ", '" + pracownik.Imie + "' , '" + pracownik.DrugieImie + "' , '" + pracownik.Nazwisko + "','"+pracownik.PESEL+"',"+pracownik.Adres+",'"+pracownik.Telefon+"','"+pracownik.Email+"'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + pracownik.Id + ", '" + pracownik.Imie + "' , '" + pracownik.DrugieImie + "' , '" + pracownik.Nazwisko + "','" + pracownik.PESEL + "'," + pracownik.Adres + ",'" + pracownik.Telefon + "','" + pracownik.Email + "');" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,IMIE,NAZWISKO,TELEFON,EMAIL,ADRES";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var klient in Klienci)
            {
                ++recordsIsdone;
                ++progress[4];
                values.Add(klient.Id + ", '" + klient.Imie +  "' , '" + klient.Nazwisko + "'," + klient.Telefon + ",'" + klient.Email + "'," + klient.Adres);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + klient.Id + ", '" + klient.Imie + "' , '" + klient.Nazwisko + "'," + klient.Telefon + ",'" + klient.Email + "'," + klient.Adres + ");" + Environment.NewLine;
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
        public void InsertProdukty(HashSet<ProduktRandomize> Produkty ,int index)
        {
            string tabel = "PRODUKT";
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,ILOSC,WAGA,CENA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var produkt in Produkty)
            {
                ++recordsIsdone;
                ++progress[index];
                values.Add(produkt.Id + "," + produkt.Ilosc + ",'" + produkt.Waga + "','" +produkt.Cena+"'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + produkt.Id + "," + produkt.Ilosc + ",'" + produkt.Waga + "','" + produkt.Cena + "');" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,NAZWA,PRODUCENT,ZWIERZE";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var akcesorie in Akcesoria)
            {
                ++recordsIsdone;
                ++progress[1];
                values.Add(akcesorie.ID + ",'" + akcesorie.Nazwa + "'," + akcesorie.Producent + "," + akcesorie.Zwierze);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + akcesorie.ID + ",'" + akcesorie.Nazwa + "'," + akcesorie.Producent + "," + akcesorie.Zwierze+ ");" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,PRODUCENT,ZWIERZE,KALORIE,NAZWA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var pokarm in Pokarmy)
            {
                ++recordsIsdone;
                ++progress[7];
                values.Add(pokarm.Id + "," + pokarm.Producent+ "," + pokarm.Zwierze + "," + pokarm.Kalorie+ ",'"+pokarm.Nazwa+"'");
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + pokarm.Id + "," + pokarm.Producent + "," + pokarm.Zwierze + "," + pokarm.Kalorie + ",'" + pokarm.Nazwa + "');" + Environment.NewLine;

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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,ID_GATUNEK,ID_POKARM";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var pokarmgatunek in PokarmGatunek)
            {
                ++recordsIsdone;
                ++progress[8];
                values.Add(pokarmgatunek.Id + "," + pokarmgatunek.Id_Gatunek + "," + pokarmgatunek.Id_Pokarm);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + pokarmgatunek.Id + "," + pokarmgatunek.Id_Gatunek + "," + pokarmgatunek.Id_Pokarm + ");" + Environment.NewLine;

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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,DATA_ZLOZENIA,STATUS,PRZESYLKA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var zamowienie in Zamowienia)
            {
                ++recordsIsdone;
                ++progress[13];
                values.Add(zamowienie.Id + "," + "to_date('"+zamowienie.Data_zlozenia.Year+"/"+zamowienie.Data_zlozenia.Month+"/"+zamowienie.Data_zlozenia.Day+"', 'RR/MM/DD')  ," + zamowienie.Status+","+zamowienie.Przesylka);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + zamowienie.Id + "," + "to_date('" + zamowienie.Data_zlozenia.Year + "/" + zamowienie.Data_zlozenia.Month + "/" + zamowienie.Data_zlozenia.Day + "', 'RR/MM/DD')  ," + zamowienie.Status + "," + zamowienie.Przesylka + ");" + Environment.NewLine;

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
            ++recordsIsdone;
            string tabel = "POSREDNIA";
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,ID_USER,ID_FIRMA";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var uzytkownikFirma in UzytkownikFirma)
            {
                ++recordsIsdone;
                ++progress[10];
                values.Add(uzytkownikFirma.Id + "," + uzytkownikFirma.Id_User + "," + uzytkownikFirma.Id_Firma);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + uzytkownikFirma.Id + "," + uzytkownikFirma.Id_User + "," + uzytkownikFirma.Id_Firma + ");" + Environment.NewLine;
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
            inserts += "-- " + tabel + Environment.NewLine;
            string columns = "ID,GATUNEK,PODGATUNEK,OJCIEC,MATKA,WAGA,WIEK,LICENCJA,TRANSPORT,HODOWLA,DOSTAWCA";
            HashSet<string> values = new HashSet<string>();
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
                values.Add(zwierze.Id + "," + zwierze.Gatunek + "," + zwierze.Podgatunek+","+OjciecString+","+MatkaString+",'"+zwierze.Waga+"',"+zwierze.Wiek+","+zwierze.Licencja+","+zwierze.Transport+","+zwierze.Hodowla+","+zwierze.Dostawca);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + zwierze.Id + "," + zwierze.Gatunek + "," + zwierze.Podgatunek + "," + OjciecString + "," + MatkaString + ",'" + zwierze.Waga + "'," + zwierze.Wiek + "," + zwierze.Licencja + "," + zwierze.Transport + "," + zwierze.Hodowla + "," + zwierze.Dostawca + ");" + Environment.NewLine;
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
            inserts += "-- " + tabel +Environment.NewLine;
            string columns = "ID,ID_ZAMOWIENIE,ID_PRODUKT";
            HashSet<string> values = new HashSet<string>();
            int i = 0;
            foreach (var produktzamowienie in ProduktZamowienie)
            {
                ++recordsIsdone;
                ++progress[9];
                values.Add(produktzamowienie.Id + "," + produktzamowienie.Id_Zamowienie+ "," + produktzamowienie.Id_Produkt);
                inserts += "INSERT INTO " + tabel + " (" + columns + ") VALUES (" + produktzamowienie.Id + "," + produktzamowienie.Id_Zamowienie + "," + produktzamowienie.Id_Produkt + ");" + Environment.NewLine;
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
