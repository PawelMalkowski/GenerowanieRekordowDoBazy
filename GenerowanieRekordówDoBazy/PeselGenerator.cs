using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GenerowanieRekordow
{
    class PeselGenerator
    {

        private readonly Random gen = new Random();
        DateTime RandomDay(int Rok)
        {
            DateTime start = new DateTime(Rok, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public string Generate(int Rok)
        {
            var month = 0;
            DateTime dateTime = RandomDay(Rok);
            if (dateTime >= DateTime.Now)
            {
                return null;
            }

            if (dateTime.Year < 1900 && dateTime.Year > 1800)
            {
                month = dateTime.Month + 80;
            }
            else if (dateTime.Year < 1800)
            {
                return null;
            }
            else if (dateTime.Year > 1900 && dateTime.Year < 2000)
            {
                month = dateTime.Month;
            }
            else if (dateTime.Year >= 2000)
            {
                month = dateTime.Month + 20;
            }


            var datePeselString = dateTime.Year.ToString(CultureInfo.InvariantCulture).Substring(2, 2);
            if (month.ToString(CultureInfo.InvariantCulture).Length < 2)
            {
                datePeselString += "0" + month;
            }
            else
            {
                datePeselString += month;
            }

            if (dateTime.Day.ToString(CultureInfo.InvariantCulture).Length < 2)
            {
                datePeselString += "0" + dateTime.Day.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                datePeselString += dateTime.Day.ToString(CultureInfo.InvariantCulture);
            }

            string Pesel=BuildPeselsFromRandomDigits(datePeselString);
            int lastdig=CalculateControlSum(Pesel);
            Pesel += lastdig;
            return Pesel;

        }




        protected int CalculateControlSum(string pesel)
        {
            var weights = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            var calculator = new CheckSumCalculator();
            var checkSum = calculator.Calculate(weights, pesel.Substring(0, 10));

            return checkSum;
        }

        private string BuildPeselsFromRandomDigits(string peselDateString)
        {
            return peselDateString + gen.Next(0, 9) + gen.Next(0, 9) + gen.Next(0, 9) + gen.Next(0, 9);
        }


    }
}
