﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieRekordow.DAO
{
    class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string DrugieImie { get; set; }
        public string Nazwisko { get; set; }
        public string PESEL { get; set; }
        public int Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
