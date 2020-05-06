using GenerowanieRekordow.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenerowanieRekordówDoBazy
{
    public class ValidationValue
    {
        int maxValue = 24000;
        List<string> Errors = new List<string>();
        private string errorsValueToHight = "Wartość dla tabeli {0} jest za duża (max {1})";
        private string errorsNotEnoughtCombination = "Nie można utworzyć odpowiedniej ilość kombinacji dla tabeli {0}  (max {1})";
        public ValidationValue(Dictionary<string,int> valuesToInsert,bool clearDatabese, PreperAllListForRandomize allLists)
        {
            if (clearDatabese) checkMaxValueWithRemoving(valuesToInsert);
            else
            {
                checkMaxValueWithoutRemoving(allLists, valuesToInsert);
                CheckConnectionTableWithoutRemoving(allLists, valuesToInsert);
            }
        }
        private void checkMaxValueWithRemoving(Dictionary<string, int> valuesToInsert)
        {
            if (valuesToInsert["Adres"] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Adres", maxValue.ToString()));
            if (valuesToInsert["Akcesorie"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Akcesorie", maxValue.ToString()));
            if (valuesToInsert["Firma"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Firma", maxValue .ToString()));
            if (valuesToInsert["Gatunek"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Gatunek", maxValue.ToString()));
            if (valuesToInsert["Klient"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Klient", maxValue.ToString()));
            if (valuesToInsert["Kraj"] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Kraj", maxValue .ToString()));
            if (valuesToInsert["Podgatunek"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Podgatunek", maxValue.ToString()));
            if (valuesToInsert["Pokarm"] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Pokarm", maxValue.ToString()));
            if (valuesToInsert["PokarmGatunek"] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "PokarmGatunek", maxValue.ToString()));
            if (valuesToInsert["ProduktZamowienie"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "ProduktZamowienie", maxValue.ToString()));
            if (valuesToInsert["UzytkownikFirma"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "UzytkownikFirma", maxValue.ToString()));
            if (valuesToInsert["Pracownik"]  > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Pracownik", maxValue.ToString()));
            if (valuesToInsert["Uzytkownik"] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Uzytkownik", maxValue.ToString()));
            if (valuesToInsert["Zamowienie"]> maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Zamowienie", maxValue.ToString()));
            if (valuesToInsert["Zwierze"] > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Zwierze", maxValue.ToString()));
        }
        private void checkMaxValueWithoutRemoving(PreperAllListForRandomize allLists, Dictionary<string, int> valuesToInsert)
        {
            if (valuesToInsert["Adres"] + allLists.AdresyIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Adres", (maxValue - allLists.AdresyIdList.Count).ToString()));
            if (valuesToInsert["Akcesorie"] + allLists.CountAkcesorie > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Akcesorie", (maxValue - allLists.CountAkcesorie).ToString()));
            if (valuesToInsert["Firma"] + allLists.ProducenciIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Firma", (maxValue - allLists.ProducenciIdList.Count).ToString()));
            if (valuesToInsert["Gatunek"] + allLists.GatunkiIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Gatunek", (maxValue - allLists.GatunkiIdList.Count).ToString()));
            if (valuesToInsert["Klient"] + allLists.CountKlient > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Klient", (maxValue - allLists.CountKlient).ToString()));
            if (valuesToInsert["Kraj"] + allLists.CountKraj > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Kraj", (maxValue - allLists.CountKraj).ToString()));
            if (valuesToInsert["Podgatunek"] + allLists.CountPodgatunek > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Podgatunek", (maxValue - allLists.CountPodgatunek).ToString()));
            if (valuesToInsert["Pokarm"] + allLists.PokarmyIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Pokarm", (maxValue - allLists.PokarmyIdList.Count).ToString()));
            if (valuesToInsert["PokarmGatunek"] + allLists.CombinatioInDBPokarmGatunek.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "PokarmGatunek", (maxValue - allLists.CombinatioInDBPokarmGatunek.Count).ToString()));
            if (valuesToInsert["ProduktZamowienie"] + allLists.CombinatioInDBPokarmGatunek.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "ProduktZamowienie", (maxValue - allLists.CombinatioInDBPokarmGatunek.Count).ToString()));
            if (valuesToInsert["UzytkownikFirma"] + allLists.CombinatioInDBUzytkownikFirma.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "UzytkownikFirma", (maxValue - allLists.CombinatioInDBUzytkownikFirma.Count).ToString()));
            if (valuesToInsert["Pracownik"] + allLists.CountPracownik > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Pracownik", (maxValue - allLists.CountPracownik).ToString()));
            if (valuesToInsert["Uzytkownik"] + allLists.UzytkownicyIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Uzytkownik", (maxValue - allLists.UzytkownicyIdList.Count).ToString()));
            if (valuesToInsert["Zamowienie"] + allLists.ZamowieniaIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Zamowienie", (maxValue - allLists.ZamowieniaIdList.Count).ToString()));
            if (valuesToInsert["Zwierze"] + allLists.ZwierzetaIdList.Count > maxValue)
                Errors.Add(String.Format(errorsValueToHight, "Zwierze", (maxValue - allLists.ZwierzetaIdList.Count).ToString()));
        }
        private void CheckConnectionTableWithoutRemoving(PreperAllListForRandomize allLists, Dictionary<string, int> valuesToInsert)
        {
            if ((allLists.PokarmyIdList.Count + valuesToInsert["Pokarm"]) *
                (allLists.GatunkiIdList.Count + valuesToInsert["Gatunek"]) <
                allLists.CombinatioInDBPokarmGatunek.Count + valuesToInsert["PokarmGatunek"])
                Errors.Add(String.Format(errorsNotEnoughtCombination, "PokarmGatunek",
                          (allLists.PokarmyIdList.Count + valuesToInsert["Pokarm"]) *
                          (allLists.GatunkiIdList.Count + valuesToInsert["Gatunek"])).ToString());
            if ((allLists.ProduktyIdList.Count + valuesToInsert["Akcesorie"] + valuesToInsert["Pokarm"] + valuesToInsert["Zwierze"]) *
                (allLists.ZamowieniaIdList.Count + valuesToInsert["Zamowienie"]) <
                allLists.CombinatioInDBProduktZamowienie.Count + valuesToInsert["PokarmGatunek"])
                Errors.Add(String.Format(errorsNotEnoughtCombination, "PokarmGatunek",
                          (allLists.ProduktyIdList.Count + valuesToInsert["Akcesorie"] + valuesToInsert["Pokarm"] + valuesToInsert["Zwierze"]) *
                          (allLists.ZamowieniaIdList.Count + valuesToInsert["Zamowienie"])).ToString());
            if ((allLists.UzytkownicyIdList.Count + valuesToInsert["Uzytkownik"]) *
              (allLists.ProducenciIdList.Count + valuesToInsert["Firma"]) <
              allLists.CombinatioInDBUzytkownikFirma.Count + valuesToInsert["UzytkownikFirma"])
                Errors.Add(String.Format(errorsNotEnoughtCombination, "UzytkownikFirma",
                          (allLists.UzytkownicyIdList.Count + valuesToInsert["Uzytkownik"]) *
                          (allLists.ProducenciIdList.Count + valuesToInsert["Firma"])).ToString());
        }
    }
}
