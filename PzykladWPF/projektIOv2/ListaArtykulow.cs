using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2
{
    internal class ListaArtykulow
    {
        public List<Artykul> listaArtykulow;
        public ListaArtykulow()
        {
            string filePath = "artykuly.json";
            string jsonString = File.ReadAllText(filePath);
            listaArtykulow = JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            listaArtykulow.Reverse();
         //  listaArtykulow=listaArtykulow.Where(x => x.Data.Year == 2023 && x.Data.Month ==11 && x.Data.Day == 7).ToList();
             var arts = listaArtykulow.Select(x => new DateTime(x.Data.Year, x.Data.Month, x.Data.Day)).ToHashSet();
            foreach (var item in arts)
            {
                var at = new Artykul();
                at.Data = item;
                at.YEAR = item.ToShortDateString();
                listaArtykulow.Add(at);
            }
            var arts2 = listaArtykulow.Select(x => new DateTime(x.Data.Year, x.Data.Month, x.Data.Day,x.Data.Hour,0,0)).Where(x => x.Hour > 0).ToHashSet();
            foreach (var item in arts2)
            {
                var at = new Artykul();
                at.Data = item;
                at.HOUR = item.ToShortTimeString();
                listaArtykulow.Add(at);
            }
            listaArtykulow.Sort((a, b) => a.Data.CompareTo(b.Data));

        }
        public Artykul WyszukajArtykul(DateTime time)
        {
            Artykul wynik = listaArtykulow[0];
            foreach (Artykul artykul in listaArtykulow)
            {
                if (DateTime.Compare(artykul.Data, time) < 0)
                {
                    wynik = artykul;
                }
                else
                {
                    continue;
                }
            }
            return wynik;
        }
    }
}
