using Newtonsoft.Json;
using projektIOv2.Skraper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace projektIOv2
{
    internal class ListaArtykulow
    {
        public List<Artykul> listaArtykulow;
        private List<Artykul> listaArtykulowp;
        private ListBox listBox;
        public ListaArtykulow(ListBox listBox)
        {
            string filePath = "artykuly.json";
            string jsonString = File.ReadAllText(filePath);
            listaArtykulowp = JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            listaArtykulowp.Reverse();
            DateTime dt = new DateTime(2023, 11, 7);
            this.listBox = listBox;
            Update(dt);

        }
        public async Task Update(DateTime dt)
        {
            if (!listaArtykulowp.Any(data => dt.Year == data.Data.Year && dt.Month == data.Data.Month && dt.Day == data.Data.Day))
            {
                Link lnk = new Link();
                lnk.getPageNums(dt);
                listaArtykulow = lnk.getLista;
            }
            else
            {
                listaArtykulow = listaArtykulowp.Where(x => x.Data.Year == dt.Year && x.Data.Month == dt.Month && x.Data.Day == dt.Day).ToList();
                var arts = listaArtykulow.Select(x => new DateTime(x.Data.Year, x.Data.Month, x.Data.Day)).ToHashSet();
                foreach (var item in arts)
                {
                    var at = new Artykul();
                    at.Data = item;
                    at.YEAR = item.ToShortDateString();
                    listaArtykulow.Add(at);
                }
                var arts2 = listaArtykulow.Select(x => new DateTime(x.Data.Year, x.Data.Month, x.Data.Day, x.Data.Hour, 0, 0)).Where(x => x.Hour > 0).ToHashSet();
                foreach (var item in arts2)
                {
                    var at = new Artykul();
                    at.Data = item;
                    at.HOUR = item.ToShortTimeString();
                    listaArtykulow.Add(at);
                }
                listaArtykulow.Sort();

            }
            listBox.ItemsSource = listaArtykulow;
            await Task.CompletedTask;
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
