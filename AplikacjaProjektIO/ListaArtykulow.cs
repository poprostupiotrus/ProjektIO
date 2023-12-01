using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaProjektIO
{
    internal class ListaArtykulow
    {
        public List<Artykul> listaArtykulow;
        public ListaArtykulow()
        {
            string filePath = "../../../resources/artykuly.json";
            string jsonString = File.ReadAllText(filePath);
            listaArtykulow = JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            listaArtykulow.Reverse();
        }
        public Artykul WyszukajArtykul(DateTime time)
        {
            Artykul wynik = listaArtykulow[0];
            foreach(Artykul artykul in listaArtykulow)
            {
                if(DateTime.Compare(artykul.Data,time)<0)
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
