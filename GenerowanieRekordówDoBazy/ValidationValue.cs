using System;
using System.Collections.Generic;
using System.Text;

namespace GenerowanieRekordówDoBazy
{
    public class ValidationValue
    {
        int maxValue = 24000;
        List<string> Errors = new List<string>();
        private string errorsValueToHight = "Value for the table {0} to hight (max {1})";
        public ValidationValue(Dictionary<string,int> valuesToInsert,bool clearDatabese, PreperAllListForRandomize allLists)
        {
            int AdresyCount, FirmyCount, GatunkiCount,PokarmyCount;
            if (allLists.AdresyIdList.Count == 0) AdresyCount = 0;
            else AdresyCount= allLists.AdresyIdList[allLists.AdresyIdList.Count - 1];
            if (allLists.ProducenciIdList.Count == 0) FirmyCount = 0;
            else FirmyCount = allLists.ProducenciIdList[allLists.ProducenciIdList.Count - 1];
            if (allLists.GatunkiIdList.Count == 0) GatunkiCount = 0;
            else GatunkiCount = allLists.GatunkiIdList[allLists.GatunkiIdList.Count - 1];
            if(allLists.PokarmyIdList.Count==0) PokarmyCount

            if (valuesToInsert["Adres"] + AdresyCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Adres", (maxValue - AdresyCount).ToString()));
            if (valuesToInsert["Akcesorie"] + allLists.AkcesorieCaount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Akcesorie", (maxValue - allLists.AkcesorieCaount).ToString()));
            if (valuesToInsert["Firma"] + FirmyCount> maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Firma", (maxValue - FirmyCount).ToString()));
            if (valuesToInsert["Gatunek"] +  GatunkiCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Gatunek", (maxValue - GatunkiCount).ToString()));
            if (valuesToInsert["Klient"] + allLists.KlientCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Klient", (maxValue - allLists.KlientCount).ToString()));
            if (valuesToInsert["Kraj"] + allLists.KrajeCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Kraj", (maxValue - allLists.KrajeCount).ToString()));
            if (valuesToInsert["Podgatunek"] + allLists.LastIdPodgatuenk > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Podgatunek", (maxValue - allLists.LastIdPodgatuenk).ToString()));
            if (valuesToInsert["Pokarm"] + allLists.PokarmyIdList[allLists.PokarmyIdList.Count-1] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Pokarm", (maxValue - allLists.PokarmyIdList[allLists.PokarmyIdList.Count - 1]).ToString()));
            if (valuesToInsert["PokarmGatunek"] + allLists.PokarmGatunekCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "PokarmGatunek", (maxValue - allLists.PokarmGatunekCount).ToString()));
            if (valuesToInsert["ProduktZamowienie"] + allLists.ProduktZamowienieCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "ProduktZamowienie", (maxValue - allLists.ProduktZamowienieCount).ToString()));
            if (valuesToInsert["UzytkownikFirma"] + allLists.UzytkownikFirmaCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "UzytkownikFirma", (maxValue - allLists.UzytkownikFirmaCount).ToString()));
            if (valuesToInsert["Pracownik"] + allLists.PracownikCount > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Pracownik", (maxValue - allLists.PracownikCount).ToString()));
            if (valuesToInsert["Uzytkownik"] + allLists.UzytkownicyIdList[allLists.UzytkownicyIdList.Count-1] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Uzytkownik", (maxValue - allLists.UzytkownicyIdList[allLists.UzytkownicyIdList.Count - 1]).ToString()));
            if (valuesToInsert["Zamowienie"] + allLists.ZamowieniaIdList[allLists.ZamowieniaIdList.Count-1] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Zamowienie", (maxValue - allLists.ZamowieniaIdList[allLists.ZamowieniaIdList.Count - 1]).ToString()));
            if (valuesToInsert["Zwierze"] + allLists.ZwierzetaIdList[allLists.ZwierzetaIdList.Count-1] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Zwierze", (maxValue - allLists.ZwierzetaIdList[allLists.ZwierzetaIdList.Count - 1]).ToString()));
        }
    }
}
