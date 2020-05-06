using System;
using System.Collections.Generic;
using System.Text;

namespace GenerowanieRekordówDoBazy
{
    class PreperListFromDateBase
    {
        private static  readonly DbConnection DbConnection = new DbConnection();
        

        public List<string> GetKrajeList()
        {
           List<string> KrajeList= DbConnection.GetStringList("Kraj", "Kraj");
            return KrajeList;
        }
        public List<int> GetProducenciIdList()
        {
            List<int> ProducenciIdList = DbConnection.GetIntList("Firma", "ID");
            return ProducenciIdList;
        }
        public List<int> GetZwierzetaIdList()
        {
            List<int> ZwierzetaIdList = DbConnection.GetIntList("Zwierze", "Id");
            return ZwierzetaIdList;
        }
        public List<int> GetAdresyIdList()
        {
            List<int> AdresyIdList = DbConnection.GetIntList("Adres", "Klient_id");
            return AdresyIdList;
        }
        public HashSet<string> GetGatunkiHashSet()
        {
            HashSet<string> GatunkHashSet = DbConnection.GetStringHashSet("Gatunek", "Nazwa");
            return GatunkHashSet;
        }
        public HashSet<string> GetPodGatunkiHashSet()
        {
            HashSet<string> PodGatunkHashSet = DbConnection.GetStringHashSet("Podgatunek", "Nazwa");
            return PodGatunkHashSet;
        }
        public List<int> GetKrajeIdList()
        {
            List<int> KrajeIdList = DbConnection.GetIntList("Kraj", "Id");
            return KrajeIdList;
        }
        public List<int> GetGatunkiIdList()
        {
            List<int> GatunkIdiList = DbConnection.GetIntList("Gatunek", "Id");
            return GatunkIdiList;
        }
        public List<int> GetPokarmyIdList()
        {
            List<int> PokarmIdiList = DbConnection.GetIntList("Pokarm", "Id");
            return PokarmIdiList;
        }
        public List<int> GetProduktyIdList()
        {
            List<int> ProduktIdiList = DbConnection.GetIntList("Produkt", "Id");
            return ProduktIdiList;
        }
        public List<int> GetUzytkownicyIdList()
        {
            List<int> UzytkownikIdiList = DbConnection.GetIntList("Uzytkownik", "Id");
            return UzytkownikIdiList;
        }
        public List<int> GetZamowieniaIdList()
        {
            List<int> ZamowieniaIdiList = DbConnection.GetIntList("ZAMOWIENIA", "Id");
            return ZamowieniaIdiList;
        }
        public HashSet<string> GetLoginyHashSet()
        {
            HashSet<string> LoginyiList = DbConnection.GetStringHashSet("Uzytkownik", "Login");
            return LoginyiList;
        }
        public HashSet<string> GetEmaileHashSet()
        {
            HashSet<string> HaslaiList = DbConnection.GetStringHashSet("Uzytkownik", "Email");
            return HaslaiList;
        }
        public HashSet<string> GetHNipHashSet()
        {
            HashSet<string> NipyiList = DbConnection.GetStringHashSet("Firma", "Nip");
            return NipyiList;
        }
        public HashSet<string> GetPESELHashSet()
        {
            HashSet<string> NipyiList = DbConnection.GetStringHashSet("Pracownik", "PESEL");
            return NipyiList;
        }
        public HashSet<KeyValuePair<int,int>> GetPokarmGatunekList()
        {
            HashSet<KeyValuePair<int, int>> PokarmGatunekList = DbConnection.GetIntPairHashSet("POSREDNIA_POKARM_GATUNEK", "ID_POKARM","ID_GATUNEK");

            return PokarmGatunekList;
        }
        public HashSet<KeyValuePair<int, int>> GetProduktZamowienieList()
        {
            HashSet<KeyValuePair<int, int>> ProduktZamowienieList = DbConnection.GetIntPairHashSet("POSREDNIA_PRODUK_ZAMOWIENIE", "ID_PRODUKT", "ID_ZAMOWIENIE" );

            return ProduktZamowienieList;
        }
        public HashSet<KeyValuePair<int, int>> GetUzytkownikFirmaList()
        {
            HashSet<KeyValuePair<int, int>> UzytkownikFirmaList = DbConnection.GetIntPairHashSet("POSREDNIA", "ID_USER", "ID_FIRMA");

            return UzytkownikFirmaList;
        }
        public HashSet<string> GetEmailePracownikHashSet()
        {
            HashSet<string> HaslaiList = DbConnection.GetStringHashSet("PRACOWNIK", "Email");
            return HaslaiList;
        }
        public List<int> GetStatusyList()
        {
            List<int> StatusyList = DbConnection.GetIntList("STATUS", "ID");
            return StatusyList;
        }
        public List<int> GetWysylkaList()
        {
            List<int> WysylkaList = DbConnection.GetIntList("WYSYLKA", "ID");
            return WysylkaList;
        }
        public HashSet<KeyValuePair<int, int>> GetGatuenkPodgatunekList()
        {
            HashSet<KeyValuePair<int, int>> GatunekPodgatunekList = DbConnection.GetIntPairHashSet("PODGATUNEK", "ID", "ID_GATUNEK");
            return GatunekPodgatunekList;
        }
        public int GetLastIdPodgatunek()
        {
            int LastId = DbConnection.GetLastId("PODGATUNEK", "ID");
            return LastId;
        }
        public int GetLastIdPracownik()
        {
            int LastId = DbConnection.GetLastId("UZYTKOWNIK", "ID");
            return LastId;
        }
        public int GetLastIdKlient()
        {
            int LastId = DbConnection.GetLastId("KLIENT", "ID");
            return LastId;
        }
        public int GetLastIdPokarmGatunek()
        {
            int LastId = DbConnection.GetLastId("POSREDNIA_POKARM_GATUNEK", "ID");
            return LastId;
        }
        public int GetLastIdUzytkownikFirma()
        {
            int LastId = DbConnection.GetLastId("POSREDNIA", "ID");
            return LastId;
        }
        public int GetLastIdProduktZamowienie()
        {
            int LastId = DbConnection.GetLastId("POSREDNIA_PRODUK_ZAMOWIENIE", "ID");
            return LastId;
        }
        public int GetLastIAkcesoria()
        {
            int LastId = DbConnection.GetLastId("AKCESORIE", "ID");
            return LastId;
        }

        public int GetCountAkceosire()
        {
            int Count = DbConnection.GetCount("AKCESORIE");
            return Count;
        }
        public int GetCountKlient()
        {
            int Count = DbConnection.GetCount("KLIENT");
            return Count;
        }
        public int GetCountKraj()
        {
            int Count = DbConnection.GetCount("KRAJ");
            return Count;
        }
        public int GetCountPodgatunek()
        {
            int Count = DbConnection.GetCount("PODGATUNEK");
            return Count;
        }

        public int GetCountPracownik()
        {
            int Count = DbConnection.GetCount("PRACOWNIK");
            return Count;
        }
    }
}
