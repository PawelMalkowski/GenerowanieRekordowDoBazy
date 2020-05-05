using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public List<List<int>> PokarmGatunekList;
        public List<List<int>> ProduktZamowieniaList;
        public List<List<int>> UzytkownikFirmaList;
        public List<List<int>> PokarmGatunekListWithoutRemoving;
        public List<List<int>> ProduktZamowieniaListWithoutRemoving;
        public List<List<int>> UzytkownikFirmaListWithoutRemoving;
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
        public int LastIdPodgatuenk;
        public int KrajeCount;
        public int PracownikCount;
        public int KlientCount;
        public int PokarmGatunekCount;
        public int UzytkownikFirmaCount;
        public int ProduktZamowienieCount;
        public int przedzial;
        public int AkcesorieCaount;
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
            LastIdPodgatuenk = FromDateBase.GetLastIdPodgatunek();
            PracownikCount = FromDateBase.GetLastIdPracownik();
            KlientCount = FromDateBase.GetLastIdKlient();
            PokarmGatunekCount = FromDateBase.GetLastIdPokarmGatunek();
            UzytkownikFirmaCount = FromDateBase.GetLastIdUzytkownikFirma();
            ProduktZamowienieCount = FromDateBase.GetLastIdUzytkownikFirma();
            AkcesorieCaount = FromDateBase.GetLastIAkcesoria();
            przedzial = FromTxt.podzial;

        }
        public List<string> KrajeListCreate()
        {
            List<string> AllCountries = FromTxt.GetKrajeList();
            List<string> AlrredyInDataBase = FromDateBase.GetKrajeList();
            List<string> Reamining= AllCountries.Except(AlrredyInDataBase).ToList();
            KrajeCount = Reamining.Count;
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
