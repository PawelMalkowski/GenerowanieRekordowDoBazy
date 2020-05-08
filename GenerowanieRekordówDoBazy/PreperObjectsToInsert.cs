using GenerowanieRekordow.DAO_Randomize;
using OracleInternal.SqlAndPlsqlParser.LocalParsing;
using System;
using System.Collections.Generic;

namespace GenerowanieRekordówDoBazy
{
   class PreperObjectsToInsert
    {
        private static readonly DbConnection DbConnection = new DbConnection();
        private PreperAllListForRandomize allLists;
        public int cleanStatus=0;
        public bool clearDbisFinish = false;
        public bool isFinish = false;
        public string inserts;
        public readonly InsertObjectToDatabase insertObjectToDatabase = new InsertObjectToDatabase();
        public void StartInsert(PreperAllListForRandomize Lists,bool clearDatabese, Dictionary<string,uint> ValuesToInsert)
        {
            allLists = Lists;
            if (clearDatabese) PreperEmptyDatabase();
            clearDbisFinish = true;
            FillTableKraje(ValuesToInsert["Kraj"]);
            FillTableGatunek(ValuesToInsert["Gatunek"]);
            FillTablePodGatunek(ValuesToInsert["Podgatunek"]);
            FillTableAdres(ValuesToInsert["Adres"]);
            FillTableFirma(ValuesToInsert["Firma"]);
            FillTableUzytkownik(ValuesToInsert["Uzytkownik"]);
            FillTablePracownik(ValuesToInsert["Pracownik"]);
            FillTableKlient(ValuesToInsert["Klient"]);
            FillTableAkcesorie(ValuesToInsert["Akcesorie"]);
            FillTablePokarm(ValuesToInsert["Pokarm"]);
            FillTablePokarmGatunek(ValuesToInsert["PokarmGatunek"]);
            FillTableZamowienia(ValuesToInsert["Zamowienie"]); 
            FillTableUzytkownikFirma(ValuesToInsert["UzytkownikFirma"]);
            FillTableZwierzeta(ValuesToInsert["Zwierze"]);
            FillTableProduktZamowienie(ValuesToInsert["Zamowienie"]);
            while (insertObjectToDatabase.taskRunning) ;
            inserts = insertObjectToDatabase.inserts.ToString();
            isFinish = true;
        }

        private void FillTableKraje(uint ileRekordów)
        {
            HashSet<KrajRandomize> KrajToFilleTable = new HashSet<KrajRandomize>();
            int krajelistLastId;
            if (allLists.KrajeIdList.Count == 0) krajelistLastId = 0;
            else krajelistLastId = allLists.KrajeIdList[^1];
            for (int i = 0; i < ileRekordów; ++i)
            {
                KrajRandomize kraj = new KrajRandomize(++krajelistLastId,allLists.KrajeList);
                
                allLists.KrajeList.RemoveAt(kraj.IdKraj);
                allLists.KrajeIdList.Add(krajelistLastId);
                KrajToFilleTable.Add(kraj);
            }
             if(ileRekordów > 0) allLists.KrajeList.Clear();
            insertObjectToDatabase.InsertKraje(KrajToFilleTable);

            
        }

        private void FillTableGatunek(uint ileRekordów)
        {
            HashSet<GatunekRandomize> GatunekToFilleTable = new HashSet<GatunekRandomize>();
            int gatuneklistLastId = allLists.PodgatuenkLastId;
            if (allLists.GatunkiIdList.Count == 0) gatuneklistLastId = 0;
            else gatuneklistLastId = allLists.GatunkiIdList[^1];
            for (int i = 0; i < ileRekordów; ++i)
            {
                GatunekRandomize gatunek = new GatunekRandomize(++gatuneklistLastId,allLists.GatunkiHashSet);
                allLists.GatunkiHashSet.Add(gatunek.Nazwa);
                allLists.GatunkiIdList.Add(gatuneklistLastId);
                GatunekToFilleTable.Add(gatunek); 
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertGatunki(GatunekToFilleTable);
        }

        private void FillTablePodGatunek(uint ileRekordów)
        {
            int podgatunekLastid=allLists.PodgatuenkLastId;

            HashSet<PodgatunekRandomize> PodGatunekToFilleTable = new HashSet<PodgatunekRandomize>();
            for (int i = 0; i < ileRekordów; ++i)
            {
                PodgatunekRandomize podgatunek = new PodgatunekRandomize(++podgatunekLastid,allLists.GatunkiIdList,allLists.PodGatunkiHashSet);
                allLists.PodGatunkiHashSet.Add(podgatunek.Nazwa);
                
                allLists.GatuenkPodgatunekList.Add(new KeyValuePair<int, int>(podgatunek.Id, podgatunek.Id_gatunek));
                PodGatunekToFilleTable.Add(podgatunek);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertPodgatunki(PodGatunekToFilleTable);
        }

        private void FillTableAdres(uint ileRekordów)
        {
            int adreslistLastId;
            if (allLists.AdresyIdList.Count == 0) adreslistLastId = 0;
            else adreslistLastId = allLists.AdresyIdList[^1];
            HashSet<AdresRandomize> AdresyToFilleTable = new HashSet<AdresRandomize>();
            for (int i = 0; i < ileRekordów; ++i)
            {
                AdresRandomize Adresy = new AdresRandomize(++adreslistLastId,allLists.KrajeIdList, allLists.MiejscowsciList);
                allLists.AdresyIdList.Add(adreslistLastId);
                AdresyToFilleTable.Add(Adresy);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertAdresy(AdresyToFilleTable);
            allLists.MiejscowsciList.Clear();
            allLists.KrajeIdList.Clear();
        }

        private void FillTableFirma(uint ileRekordów)
        {
            HashSet<FirmaRandomize> FirmyToFilleTable = new HashSet<FirmaRandomize>();
            int maxindex;
            if (allLists.ProducenciIdList.Count == 0) maxindex=0;
            else maxindex=allLists.ProducenciIdList[^1];
            for (int i = 0; i < ileRekordów; ++i)
            {
                FirmaRandomize Firma = new FirmaRandomize(++maxindex,allLists.AdresyIdList, allLists.NipHashSet);
                allLists.ProducenciIdList.Add(maxindex);
                allLists.NipHashSet.Add(Firma.NIP);
                FirmyToFilleTable.Add(Firma);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertFirmy(FirmyToFilleTable);
            allLists.NipHashSet.Clear();
        }

        private void FillTableUzytkownik(uint ileRekordów)
        {
            HashSet<UzytkownikRandomize> UzytkownicyToFilleTable = new HashSet<UzytkownikRandomize>();
            int maxindex;
            if (allLists.UzytkownicyIdList.Count == 0) maxindex=0;
            else maxindex = allLists.UzytkownicyIdList[^1];
            for (int i = 0; i < ileRekordów; ++i)
            {
                UzytkownikRandomize uzytkownik = new UzytkownikRandomize(++maxindex,allLists.LoginyHashSet,allLists.EmaileHashSet);
                allLists.LoginyHashSet.Add(uzytkownik.Login);
                allLists.EmaileHashSet.Add(uzytkownik.Email);
                allLists.UzytkownicyIdList.Add(maxindex);
                UzytkownicyToFilleTable.Add(uzytkownik);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertUzytkownik(UzytkownicyToFilleTable);
            allLists.LoginyHashSet.Clear();
            allLists.EmaileHashSet.Clear();
        }

        private void FillTablePracownik(uint ileRekordów)
        {
            HashSet<PracownikRandomize> UzytkownicyToFilleTable = new HashSet<PracownikRandomize>();
            int maxindex = allLists.PracownikLastId;
            for (int i = 0; i < ileRekordów; ++i)
            {
                PracownikRandomize pracownik = new PracownikRandomize(++maxindex,allLists.ImionaiList,allLists.AdresyIdList,allLists.przedzial,allLists.PESELHashSet,allLists.PracownicyEmaileHashSet);
                allLists.PracownicyEmaileHashSet.Add(pracownik.Email);
                allLists.PESELHashSet.Add(pracownik.PESEL);
                UzytkownicyToFilleTable.Add(pracownik);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertPracownicy(UzytkownicyToFilleTable);
            allLists.PracownicyEmaileHashSet.Clear();
            allLists.PESELHashSet.Clear();

        }

        private void FillTableKlient(uint ileRekordów)
        {
            HashSet<KlientRandomize> KlienciToFilleTable = new HashSet<KlientRandomize>();
            int maxindex = allLists.KlientLastId;
            for (int i = 0; i < ileRekordów; ++i)
            {
                KlientRandomize klient = new KlientRandomize(++maxindex,allLists.ImionaiList, allLists.AdresyIdList);
                KlienciToFilleTable.Add(klient);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertKlient(KlienciToFilleTable);
            allLists.ImionaiList.Clear();
            allLists.AdresyIdList.Clear();
        }

        private void FillTableAkcesorie(uint ileRekordów)
        {
            HashSet<ProduktRandomize> ProduktyToFilleTable = new HashSet<ProduktRandomize>();
            HashSet<AkcesorieRandomize> AkcesorieToFilleTable = new HashSet<AkcesorieRandomize>();
            int maxindex;
            if (allLists.ProduktyIdList.Count == 0) maxindex = 0;
            else maxindex = allLists.ProduktyIdList[^1];

            for (int i = 0; i < ileRekordów; ++i)
            {
                ProduktRandomize produkty = new ProduktRandomize(++maxindex);
                AkcesorieRandomize akcesorie = new AkcesorieRandomize(maxindex, allLists.ProducenciIdList, allLists.GatunkiIdList);
                allLists.ProduktyIdList.Add(maxindex);
                ProduktyToFilleTable.Add(produkty);
                AkcesorieToFilleTable.Add(akcesorie);                  
            }
            if (ileRekordów > 0)
            {
                insertObjectToDatabase.InsertProdukty(ProduktyToFilleTable, 1);
                insertObjectToDatabase.InsertAkcesoria(AkcesorieToFilleTable);
            }
        }

        private void FillTablePokarm(uint ileRekordów)
        {
            HashSet<ProduktRandomize> ProduktyToFilleTable = new HashSet<ProduktRandomize>();
            HashSet<PokarmRandomize> PokarmyToFilleTable = new HashSet<PokarmRandomize>();
            int maxindex;
            if (allLists.ProduktyIdList.Count == 0) maxindex = 0;
            else maxindex = allLists.ProduktyIdList[^1];

            for (int i = 0; i < ileRekordów; ++i)
            {
                ProduktRandomize produkty = new ProduktRandomize(++maxindex);
                PokarmRandomize Pokarm = new PokarmRandomize(maxindex,allLists.ProducenciIdList,allLists.GatunkiIdList);
                allLists.ProduktyIdList.Add(maxindex);
                allLists.PokarmyIdList.Add(maxindex);
                ProduktyToFilleTable.Add(produkty);
                PokarmyToFilleTable.Add(Pokarm);
            }
            if (ileRekordów > 0)
            {
                insertObjectToDatabase.InsertProdukty(ProduktyToFilleTable, 7);
                insertObjectToDatabase.InsertPokarmy(PokarmyToFilleTable);
            }
        }

        private void FillTablePokarmGatunek(uint ileRekordów)
        {
            int maxindex=allLists.PokarmGatunekLastId;
       
            HashSet<Posrednia_Pokarm_GatunekRandomize> PokarmGatunekToFilleTable = new HashSet<Posrednia_Pokarm_GatunekRandomize>();
            HashSet<long> CombinationInDb=  allLists.AddCombinationAlreadyInDataBase(allLists.CombinatioInDBPokarmGatunek);
            for (int i = 0; i < ileRekordów; ++i)
            {
                Posrednia_Pokarm_GatunekRandomize pokarmGatunek = new Posrednia_Pokarm_GatunekRandomize(++maxindex,allLists.PokarmyIdList,allLists.GatunkiIdList,CombinationInDb);
                PokarmGatunekToFilleTable.Add(pokarmGatunek);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertPokarmGatunek(PokarmGatunekToFilleTable);
            allLists.PokarmyIdList.Clear();
        }

        private void FillTableZamowienia(uint ileRekordów)
        {
            int maxindex;
            if (allLists.ZamowieniaIdList.Count == 0) maxindex = 0;
            else maxindex = allLists.ZamowieniaIdList[^1];
            HashSet<ZamowieniaRandomize> ZamowieniaToFilleTable = new HashSet<ZamowieniaRandomize>();
            
            for (int i = 0; i < ileRekordów; ++i)
            {
                ZamowieniaRandomize zamowienie = new ZamowieniaRandomize(++maxindex,10,allLists.StatusyList,allLists.WysylkaList);
                allLists.ZamowieniaIdList.Add(maxindex);
                ZamowieniaToFilleTable.Add(zamowienie);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertZamowienia(ZamowieniaToFilleTable);
        }

        private void FillTableUzytkownikFirma(uint ileRekordów)
        {
            int maxindex = allLists.UzytkownikFirmaLastId;
            HashSet<Posrednia_Uzytkownik_FirmaRadmoize> UzytkownikFirmaToFilleTable = new HashSet<Posrednia_Uzytkownik_FirmaRadmoize>();
            HashSet<long> CombinationInDb = allLists.AddCombinationAlreadyInDataBase(allLists.CombinatioInDBUzytkownikFirma);
            for (int i = 0; i < ileRekordów; ++i)
            {
                Posrednia_Uzytkownik_FirmaRadmoize uzytkownikFirma = new Posrednia_Uzytkownik_FirmaRadmoize(++maxindex,allLists.UzytkownicyIdList,allLists.ProducenciIdList,CombinationInDb);
                UzytkownikFirmaToFilleTable.Add(uzytkownikFirma);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertUzytkownikFirma(UzytkownikFirmaToFilleTable);
            allLists.UzytkownicyIdList.Clear();
        }

        private void FillTableZwierzeta(uint ileRekordów)
        {
            HashSet<ProduktRandomize> ProduktyToFilleTable = new HashSet<ProduktRandomize>();
            HashSet<ZwierzeRandomize> ZwierzeToFilleTable = new HashSet<ZwierzeRandomize>();
            int maxindex;
            if (allLists.ProduktyIdList.Count == 0) maxindex = 0;
            else maxindex = allLists.ProduktyIdList[^1];

            for (int i = 0; i < ileRekordów; ++i)
            {
                ProduktRandomize produkty = new ProduktRandomize(++maxindex);
                ZwierzeRandomize zwierze = new ZwierzeRandomize(maxindex,allLists.GatunkiIdList,allLists.GatuenkPodgatunekList,allLists.ZwierzetaIdList,allLists.ProducenciIdList);
                allLists.ZwierzetaIdList.Add(maxindex);
                allLists.ProduktyIdList.Add(maxindex);
                ProduktyToFilleTable.Add(produkty);
                ZwierzeToFilleTable.Add(zwierze);
            }
            if (ileRekordów > 0) 
            {
                insertObjectToDatabase.InsertProdukty(ProduktyToFilleTable, 14);
                insertObjectToDatabase.InsertZwierzeta(ZwierzeToFilleTable);
            }
               
            allLists.GatunkiIdList.Clear();
            allLists.PodGatunkiHashSet.Clear();
            allLists.ZwierzetaIdList.Clear();
            allLists.ProducenciIdList.Clear();
        }

        private void FillTableProduktZamowienie(uint ileRekordów)
        {
            int maxindex = allLists.ProduktZamowienieCount;
            HashSet<Posrednia_Produkt_ZamowienieRandomize> ProduktZamowienieToFilleTable = new HashSet<Posrednia_Produkt_ZamowienieRandomize>();
            HashSet<long> CombinationInDb = allLists.AddCombinationAlreadyInDataBase(allLists.CombinatioInDBUzytkownikFirma);
            for (int i = 0; i < ileRekordów; ++i)
            {
                Posrednia_Produkt_ZamowienieRandomize produktZamowienie = new Posrednia_Produkt_ZamowienieRandomize(++maxindex, allLists.ProduktyIdList, allLists.ZamowieniaIdList, CombinationInDb);
                ProduktZamowienieToFilleTable.Add(produktZamowienie);
            }
            if (ileRekordów > 0) insertObjectToDatabase.InsertProduktZamowienie(ProduktZamowienieToFilleTable);
            allLists.ProduktyIdList.Clear();
            allLists.ZamowieniaIdList.Clear();
        }


        private void PreperEmptyDatabase()
        {
            ClearDataBase();
            allLists.KrajeList = allLists.KrajeListWithoutRemove;
            allLists.ProducenciIdList.Clear();
            allLists.ZwierzetaIdList.Clear();
            allLists.AdresyIdList.Clear();
            allLists.GatunkiHashSet.Clear();
            allLists.PodGatunkiHashSet.Clear();
            allLists.KrajeIdList.Clear();
            allLists.GatunkiIdList.Clear();
            allLists.LoginyHashSet.Clear();
            allLists.NipHashSet.Clear();
            allLists.PESELHashSet.Clear();
            allLists.EmaileHashSet.Clear();
            allLists.ProduktyIdList.Clear();
            allLists.ZamowieniaIdList.Clear();
            allLists.UzytkownicyIdList.Clear();
            allLists.CombinatioInDBUzytkownikFirma.Clear();
            allLists.GatuenkPodgatunekList.Clear();
            allLists.PokarmyIdList.Clear();
            allLists.PracownikLastId = 0;
            allLists.PodgatuenkLastId = 0;
            allLists.UzytkownikFirmaLastId = 0;
            allLists.ProduktZamowienieCount = 0;
            allLists.PokarmGatunekLastId = 0;
            allLists.KlientLastId = 0;
        }
        private void ClearDataBase()
        {
            //DbConnection.DeleteDataFromTable("ZWIERZE");
            //DbConnection.DeleteDataFromTable("POSREDNIA_PRODUK_ZAMOWIENIE");
            //DbConnection.DeleteDataFromTable("POSREDNIA");
            //DbConnection.DeleteDataFromTable("PODGATUNEK");
            //DbConnection.DeleteDataFromTable("POSREDNIA_POKARM_GATUNEK");
            //DbConnection.DeleteDataFromTable("POKARM");
            //DbConnection.DeleteDataFromTable("AKCESORIE");
            //DbConnection.DeleteDataFromTable("KLIENT");
            //DbConnection.DeleteDataFromTable("PRACOWNIK");
            //DbConnection.DeleteDataFromTable("PRODUKT");
            //DbConnection.DeleteDataFromTable("UZYTKOWNIK");
            //DbConnection.DeleteDataFromTable("PRODUKT");
            //DbConnection.DeleteDataFromTable("FIRMA");
            //DbConnection.DeleteDataFromTable("ADRES");
            //DbConnection.DeleteDataFromTable("GATUNEK");
            //DbConnection.DeleteDataFromTable("KRAJ");
            //DbConnection.DeleteDataFromTable("Zamowienia");
            foreach (string query in allLists.ScriptList)
            {
                ++cleanStatus;
                DbConnection.Insertquery(query);
            }
                
        }
    }
}
