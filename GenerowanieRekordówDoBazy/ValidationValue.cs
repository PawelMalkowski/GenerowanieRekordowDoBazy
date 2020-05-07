using GenerowanieRekordow.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenerowanieRekordówDoBazy
{
    public class ValidationValue
    {
        int maxValue = 24000;
        public List<string> Errors = new List<string>();
        private string errorValueToHight = "Wartość dla tabeli {0} jest za duża (max {1})";
        private string errorNotEnoughtCombination = "Nie można utworzyć odpowiedniej ilość kombinacji dla tabeli {0}  (max {1})";
        private string errorNoValueToCreatForeignKey = "Aby utworzyć tabelę {0} należy utworzyć choć jeden rekor w tabeli {1}";
        public ValidationValue(Dictionary<string,uint> valuesToInsert,bool clearDatabese, PreperAllListForRandomize allLists)
        {
            if (clearDatabese)
            {
                CheckMaxValueWithRemoving(allLists, valuesToInsert);
                CheckConnectionTableWithoutRemoving(valuesToInsert);
            }
            else
            {
                CheckMaxValueWithoutRemoving(allLists, valuesToInsert);
                CheckConnectionTableWithRemoving(allLists, valuesToInsert);
                CheckPossibilityToCreatForeignKeyWithoutRemoving(allLists,valuesToInsert);

            }
        }
        private void CheckMaxValueWithRemoving(PreperAllListForRandomize allLists,Dictionary<string, uint> valuesToInsert)
        {
            if (valuesToInsert["Adres"] > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Adres", maxValue.ToString()));
            if (valuesToInsert["Akcesorie"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Akcesorie", maxValue.ToString()));
            if (valuesToInsert["Firma"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Firma", maxValue .ToString()));
            if (valuesToInsert["Gatunek"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Gatunek", maxValue.ToString()));
            if (valuesToInsert["Klient"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Klient", maxValue.ToString()));
            if (valuesToInsert["Kraj"] > allLists.KrajeListWithoutRemove.Count)
                Errors.Add(String.Format(errorValueToHight, "Kraj", allLists.KrajeListWithoutRemove.Count.ToString()));
            if (valuesToInsert["Podgatunek"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Podgatunek", maxValue.ToString()));
            if (valuesToInsert["Pokarm"] > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Pokarm", maxValue.ToString()));
            if (valuesToInsert["PokarmGatunek"] > maxValue)
                Errors.Add(String.Format(errorValueToHight, "PokarmGatunek", maxValue.ToString()));
            if (valuesToInsert["ProduktZamowienie"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "ProduktZamowienie", maxValue.ToString()));
            if (valuesToInsert["UzytkownikFirma"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "UzytkownikFirma", maxValue.ToString()));
            if (valuesToInsert["Pracownik"]  > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Pracownik", maxValue.ToString()));
            if (valuesToInsert["Uzytkownik"] > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Uzytkownik", maxValue.ToString()));
            if (valuesToInsert["Zamowienie"]> maxValue)
                Errors.Add(String.Format(errorValueToHight, "Zamowienie", maxValue.ToString()));
            if (valuesToInsert["Zwierze"] > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Zwierze", maxValue.ToString()));
        }
        private void CheckMaxValueWithoutRemoving(PreperAllListForRandomize allLists, Dictionary<string, uint> valuesToInsert)
        {
            if (valuesToInsert["Adres"] + allLists.AdresyIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Adres", (maxValue - allLists.AdresyIdList.Count).ToString()));
            if (valuesToInsert["Akcesorie"] + allLists.CountAkcesorie > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Akcesorie", (maxValue - allLists.CountAkcesorie).ToString()));
            if (valuesToInsert["Firma"] + allLists.ProducenciIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Firma", (maxValue - allLists.ProducenciIdList.Count).ToString()));
            if (valuesToInsert["Gatunek"] + allLists.GatunkiIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Gatunek", (maxValue - allLists.GatunkiIdList.Count).ToString()));
            if (valuesToInsert["Klient"] + allLists.CountKlient > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Klient", (maxValue - allLists.CountKlient).ToString()));
            if (valuesToInsert["Kraj"]  > allLists.KrajeList.Count)
                Errors.Add(String.Format(errorValueToHight, "Kraj", allLists.KrajeList.Count.ToString()));
            if (valuesToInsert["Podgatunek"] + allLists.CountPodgatunek > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Podgatunek", (maxValue - allLists.CountPodgatunek).ToString()));
            if (valuesToInsert["Pokarm"] + allLists.PokarmyIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Pokarm", (maxValue - allLists.PokarmyIdList.Count).ToString()));
            if (valuesToInsert["PokarmGatunek"] + allLists.CombinatioInDBPokarmGatunek.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "PokarmGatunek", (maxValue - allLists.CombinatioInDBPokarmGatunek.Count).ToString()));
            if (valuesToInsert["ProduktZamowienie"] + allLists.CombinatioInDBPokarmGatunek.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "ProduktZamowienie", (maxValue - allLists.CombinatioInDBPokarmGatunek.Count).ToString()));
            if (valuesToInsert["UzytkownikFirma"] + allLists.CombinatioInDBUzytkownikFirma.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "UzytkownikFirma", (maxValue - allLists.CombinatioInDBUzytkownikFirma.Count).ToString()));
            if (valuesToInsert["Pracownik"] + allLists.CountPracownik > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Pracownik", (maxValue - allLists.CountPracownik).ToString()));
            if (valuesToInsert["Uzytkownik"] + allLists.UzytkownicyIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Uzytkownik", (maxValue - allLists.UzytkownicyIdList.Count).ToString()));
            if (valuesToInsert["Zamowienie"] + allLists.ZamowieniaIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Zamowienie", (maxValue - allLists.ZamowieniaIdList.Count).ToString()));
            if (valuesToInsert["Zwierze"] + allLists.ZwierzetaIdList.Count > maxValue)
                Errors.Add(String.Format(errorValueToHight, "Zwierze", (maxValue - allLists.ZwierzetaIdList.Count).ToString()));
        }
        private void CheckConnectionTableWithRemoving(PreperAllListForRandomize allLists, Dictionary<string, uint> valuesToInsert)
        {
            if ((allLists.PokarmyIdList.Count + valuesToInsert["Pokarm"]) *
                (allLists.GatunkiIdList.Count + valuesToInsert["Gatunek"]) <
                allLists.CombinatioInDBPokarmGatunek.Count + valuesToInsert["PokarmGatunek"])
                Errors.Add(String.Format(errorNotEnoughtCombination, "PokarmGatunek",
                          (allLists.PokarmyIdList.Count + valuesToInsert["Pokarm"]) *
                          (allLists.GatunkiIdList.Count + valuesToInsert["Gatunek"])).ToString());
            if ((allLists.ProduktyIdList.Count + valuesToInsert["Akcesorie"] + valuesToInsert["Pokarm"] + valuesToInsert["Zwierze"]) *
                (allLists.ZamowieniaIdList.Count + valuesToInsert["Zamowienie"]) <
                allLists.CombinatioInDBProduktZamowienie.Count + valuesToInsert["PokarmGatunek"])
                Errors.Add(String.Format(errorNotEnoughtCombination, "PokarmGatunek",
                          (allLists.ProduktyIdList.Count + valuesToInsert["Akcesorie"] + valuesToInsert["Pokarm"] + valuesToInsert["Zwierze"]) *
                          (allLists.ZamowieniaIdList.Count + valuesToInsert["Zamowienie"])).ToString());
            if ((allLists.UzytkownicyIdList.Count + valuesToInsert["Uzytkownik"]) *
              (allLists.ProducenciIdList.Count + valuesToInsert["Firma"]) <
              allLists.CombinatioInDBUzytkownikFirma.Count + valuesToInsert["UzytkownikFirma"])
                Errors.Add(String.Format(errorNotEnoughtCombination, "UzytkownikFirma",
                          (allLists.UzytkownicyIdList.Count + valuesToInsert["Uzytkownik"]) *
                          (allLists.ProducenciIdList.Count + valuesToInsert["Firma"])).ToString());
        }
        private void CheckConnectionTableWithoutRemoving(Dictionary<string, uint> valuesToInsert)
        {
            if ( valuesToInsert["Pokarm"] * valuesToInsert["Gatunek"] < valuesToInsert["PokarmGatunek"])
                Errors.Add(String.Format(errorNotEnoughtCombination, "PokarmGatunek", (valuesToInsert["Pokarm"] * valuesToInsert["Gatunek"])).ToString());
            if ((valuesToInsert["Akcesorie"] + valuesToInsert["Pokarm"] + valuesToInsert["Zwierze"]) * valuesToInsert["Zamowienie"] <
                valuesToInsert["PokarmGatunek"])
                Errors.Add(String.Format(errorNotEnoughtCombination, "PokarmGatunek",
                          ((valuesToInsert["Akcesorie"] + valuesToInsert["Pokarm"] + valuesToInsert["Zwierze"]) *  valuesToInsert["Zamowienie"]).ToString()));
            if (valuesToInsert["Uzytkownik"] * valuesToInsert["Firma"] < valuesToInsert["UzytkownikFirma"])
                Errors.Add(String.Format(errorNotEnoughtCombination, "UzytkownikFirma",
                           (valuesToInsert["Uzytkownik"] * valuesToInsert["Firma"])).ToString());
        }

        private void CheckPossibilityToCreatForeignKeyWithoutRemoving(PreperAllListForRandomize alllists , Dictionary<string, uint> valuesToInsert)
        {
            if (valuesToInsert["Adres"] > 0)
            {
                if (alllists.KrajeIdList.Count == 0 && valuesToInsert["Kraj"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Adres", "Kraj"));
                }
            }

            if(valuesToInsert["Akcesorie"] > 0)
            {
                if(alllists.GatunkiIdList.Count==0 & valuesToInsert["Gatunek"] == 0)
                { 
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Akcesorie", "Gatunek"));
                }
                if(alllists.ProducenciIdList.Count==0 & valuesToInsert["Firma"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Akcesorie", "Firma"));
                }
            }
            if (valuesToInsert["Firma"] > 0)
            {
                if (alllists.AdresyIdList.Count == 0 && valuesToInsert["Adres"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Firma", "Adres"));
                }
            }
            if (valuesToInsert["Klient"] > 0)
            {
                if (alllists.AdresyIdList.Count == 0 && valuesToInsert["Adres"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Klient", "Adres"));
                }
            }
            if (valuesToInsert["Podgatunek"] > 0)
            {
                if (alllists.GatunkiIdList.Count == 0 && valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Podgatunek", "Gatunek"));
                }
            }
            if (valuesToInsert["Pokarm"] > 0)
            {
                if (alllists.ProducenciIdList.Count == 0 && valuesToInsert["Firma"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Pokarm", "Firma"));
                }
                if (alllists.GatunkiIdList.Count == 0 && valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Pokarm", "Gatunek"));
                }
            }
            if (valuesToInsert["Pracownik"] > 0)
            {
                if (alllists.AdresyIdList.Count == 0 && valuesToInsert["Adres"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Pracownik", "Adres"));
                }
            }
            if (valuesToInsert["Zwierze"] > 0)
            {
                if (alllists.GatunkiIdList.Count == 0 && valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Zwierze", "Gatunek"));
                }
                if (alllists.CountPodgatunek == 0 && valuesToInsert["Podgatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Zwierze", "Podgatunek"));
                }
                if (alllists.ProducenciIdList.Count == 0 && valuesToInsert["Firma"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Zwierze", "Firma"));
                }
            }
        }
        private void CheckPossibilityToCreatForeignKeyWithRemoving(PreperAllListForRandomize alllists, Dictionary<string, uint> valuesToInsert)
        {
            if (valuesToInsert["Adres"] > 0)
            {
                if (valuesToInsert["Kraj"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Adres", "Kraj"));
                }
            }

            if (valuesToInsert["Akcesorie"] > 0)
            {
                if (valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Akcesorie", "Gatunek"));
                }
                if (alllists.ProducenciIdList.Count == 0 & valuesToInsert["Firma"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Akcesorie", "Firma"));
                }
            }
            if (valuesToInsert["Firma"] > 0)
            {
                if (valuesToInsert["Adres"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Firma", "Adres"));
                }
            }
            if (valuesToInsert["Klient"] > 0)
            {
                if (valuesToInsert["Adres"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Klient", "Adres"));
                }
            }
            if (valuesToInsert["Podgatunek"] > 0)
            {
                if (valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Podgatunek", "Gatunek"));
                }
            }
            if (valuesToInsert["Pokarm"] > 0)
            {
                if (valuesToInsert["Firma"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Pokarm", "Firma"));
                }
                if (valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Pokarm", "Gatunek"));
                }
            }
            if (valuesToInsert["Pracownik"] > 0)
            {
                if (valuesToInsert["Adres"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Pracownik", "Adres"));
                }
            }
            if (valuesToInsert["Zwierze"] > 0)
            {
                if (valuesToInsert["Gatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Zwierze", "Gatunek"));
                }
                if (valuesToInsert["Podgatunek"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Zwierze", "Podgatunek"));
                }
                if (valuesToInsert["Firma"] == 0)
                {
                    Errors.Add(String.Format(errorNoValueToCreatForeignKey, "Zwierze", "Firma"));
                }
            }
        }
    }
}
