using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GenerowanieRekordówDoBazy
{
    class PreperListFromTxt
    {
        public int podzial;

        public List<string> GetListMiejscowosci()
        {
            List<string> MiejscowoscList=new List<string>();
            using (StreamReader sr = new StreamReader("MiejscowosciWPolsce.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    MiejscowoscList.Add(sr.ReadLine());
                }
            }
            return MiejscowoscList;
        }

        public List<string> GetKrajeList()
        {
            List<string> KrajeList = new List<string>();
            using (StreamReader sr = new StreamReader("panstwa.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    KrajeList.Add(sr.ReadLine());
                }
            }
            return KrajeList;
        }
        public List<string> GetImionaList()
        {
            List<string> ImionaList = new List<string>() ;
            string Imie;
            string[] Rozdzielone;
            int liczba=0;
           
            using (StreamReader sr = new StreamReader("Imiona.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    Imie = sr.ReadLine();
                    if (Imie == "") podzial = ImionaList.Count;
                    else { 
                    Rozdzielone= Imie.Split("\t");
                    liczba = int.Parse(Rozdzielone[1]) / 100;
                    ImionaList.AddRange(Enumerable.Repeat(Rozdzielone[0], liczba));
                    }
                }
            }
            return ImionaList;
                
        }
        public string[] GetScriptList()
        {
            List<string> ScriptList = new List<string>();
            string script;
            string[] Separate;

            using (StreamReader sr = new StreamReader("skryptdb.txt"))
            {
                    
                    script = sr.ReadToEnd();
                script = script.Replace(System.Environment.NewLine, " ");
                script=Regex.Replace(script, @"\t|\n|\r", "");
                script = script.Replace(@"\"""," ");
                Separate = script.Split(";");
            
            }
            return Separate;

        }
    }
}
