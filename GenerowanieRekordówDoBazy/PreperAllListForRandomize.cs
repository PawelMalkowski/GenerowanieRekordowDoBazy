using System.Collections.Generic;
using System.Linq;

namespace GenerowanieRekordówDoBazy
{
    public class PreperAllListForRandomize
    {


        private readonly PreperListFromDateBase FromDateBase = new PreperListFromDateBase();
        private readonly PreperListFromTxt FromTxt = new PreperListFromTxt();
        public List<string> KrajeList;
        public List<string> KrajeListWithoutRemove;
        public List<int> ProducenciIdList;
        public List<int> ZwierzetaIdList;
        public List<int> AdresyIdList;
        public HashSet<string> GatunkiHashSet;
        public HashSet<string> PodGatunkiHashSet;
        public List<int> KrajeIdList;
        public List<int> GatunkiIdList;
        public HashSet<string> LoginyHashSet;
        public HashSet<string> EmaileHashSet;
        public HashSet<string> NipHashSet;
        public HashSet<string> PESELHashSet;
        public List<string> MiejscowsciList;
        public List<string> ImionaiList;
        public HashSet<string> PracownicyEmaileHashSet;
        public List<int> PokarmyIdList;
        public List<int> ProduktyIdList;
        public List<int> ZamowieniaIdList;
        public List<int> UzytkownicyIdList;
        public HashSet<KeyValuePair<int, int>> CombinatioInDBPokarmGatunek;
        public HashSet<KeyValuePair<int, int>> CombinatioInDBProduktZamowienie;
        public HashSet<KeyValuePair<int, int>> CombinatioInDBUzytkownikFirma;
        public List<int> StatusyList;
        public List<int> WysylkaList;
        public HashSet<KeyValuePair<int, int>> GatuenkPodgatunekList;
        public int PodgatuenkLastId;
        public int KrajLastId;
        public int PracownikLastId;
        public int KlientLastId;
        public int PokarmGatunekLastId;
        public int UzytkownikFirmaLastId;
        public int ProduktZamowienieCount;
        public int przedzial;
        public int AkcesorieLastId;
        public int CountAkcesorie;
        public int CountKlient;
        public int CountKraj;
        public int CountPodgatunek;
        public int CountPokarmGatunek;
        public int CountProduktZamowienie;
        public int CountUzytkownikFirma;
        public int CountPracownik;
        public string[] ScriptList;

        public PreperAllListForRandomize()
        {
            ScriptList = FromTxt.GetScriptList();
            KrajeList = KrajeListCreate();
            KrajeListWithoutRemove = FromTxt.GetKrajeList();
            ProducenciIdList = FromDateBase.GetProducenciIdList();
            ZwierzetaIdList = FromDateBase.GetZwierzetaIdList();
            AdresyIdList = FromDateBase.GetAdresyIdList();
            GatunkiHashSet = FromDateBase.GetGatunkiHashSet();
            PodGatunkiHashSet = FromDateBase.GetPodGatunkiHashSet();
            KrajeIdList = FromDateBase.GetKrajeIdList();
            GatunkiIdList = FromDateBase.GetGatunkiIdList();
            PokarmyIdList = FromDateBase.GetPokarmyIdList();
            ProduktyIdList = FromDateBase.GetProduktyIdList();
            ZamowieniaIdList = FromDateBase.GetZamowieniaIdList();
            UzytkownicyIdList = FromDateBase.GetUzytkownicyIdList();
            CombinatioInDBPokarmGatunek = FromDateBase.GetPokarmGatunekList();
            CombinatioInDBProduktZamowienie = FromDateBase.GetProduktZamowienieList();
            CombinatioInDBUzytkownikFirma = FromDateBase.GetUzytkownikFirmaList();
            LoginyHashSet = FromDateBase.GetLoginyHashSet();
            EmaileHashSet = FromDateBase.GetEmaileHashSet();
            NipHashSet = FromDateBase.GetHNipHashSet();
            PESELHashSet = FromDateBase.GetPESELHashSet();
            MiejscowsciList = FromTxt.GetListMiejscowosci();
            ImionaiList = FromTxt.GetImionaList();
            PracownicyEmaileHashSet = FromDateBase.GetEmailePracownikHashSet();
            StatusyList = FromDateBase.GetStatusyList();
            WysylkaList = FromDateBase.GetWysylkaList();
            GatuenkPodgatunekList = FromDateBase.GetGatuenkPodgatunekList();
            PodgatuenkLastId = FromDateBase.GetLastIdPodgatunek();
            PracownikLastId = FromDateBase.GetLastIdPracownik();
            KlientLastId = FromDateBase.GetLastIdKlient();
            PokarmGatunekLastId = FromDateBase.GetLastIdPokarmGatunek();
            UzytkownikFirmaLastId = FromDateBase.GetLastIdUzytkownikFirma();
            ProduktZamowienieCount = FromDateBase.GetLastIdUzytkownikFirma();
            AkcesorieLastId = FromDateBase.GetLastIAkcesoria();
            przedzial = FromTxt.podzial;
            CountAkcesorie = FromDateBase.GetCountAkceosire();
            CountKlient = FromDateBase.GetCountKlient();
            CountKraj = FromDateBase.GetCountKraj();
            CountPodgatunek = FromDateBase.GetCountPodgatunek();
            CountPracownik = FromDateBase.GetCountPracownik();
    }
        public List<string> KrajeListCreate()
        {
            List<string> AllCountries = FromTxt.GetKrajeList();
            List<string> AlrredyInDataBase = FromDateBase.GetKrajeList();
            List<string> Reamining= AllCountries.Except(AlrredyInDataBase).ToList();
            KrajLastId = Reamining.Count;
            return Reamining;
        }


        public HashSet<long> AddCombinationAlreadyInDataBase(HashSet<KeyValuePair<int, int>> CombinatioInDBPokarmGatunek)
        {
            var combinations=new HashSet<long>();
            foreach (var PokarmGatunki in CombinatioInDBPokarmGatunek)
            {
                long hash1 = ((long)PokarmGatunki.Key << 32) | (long)PokarmGatunki.Value;
                combinations.Add(hash1);
            }
            return combinations;
        }

    }
}
