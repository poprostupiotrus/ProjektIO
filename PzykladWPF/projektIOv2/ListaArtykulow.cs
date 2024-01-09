using Newtonsoft.Json;
using projektIOv2.Controls;
using projektIOv2.Skraper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace projektIOv2
{
    /// <summary>
    /// klasa odpowiedzialana za manipulacje listą artykułów.
    /// </summary>
    internal class ListaArtykulow
    {
        public List<Artykul> listaArtykulow;
        private List<Artykul> listaArtykulowp;

        /// <summary>
        /// konstruktor bezparametrowy.
        /// </summary>
        public ListaArtykulow()
        {
            string filePath = "artykulyV2.json";
            string jsonString = File.ReadAllText(filePath);
            listaArtykulowp = JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            listaArtykulowp.Reverse();
            DateTime dt = new DateTime(2023, 11, 7);

        }

        /// <summary>
        /// Asynchroniczna metoda do aktualizacji listy artykułów na podstawie podanej daty.
        /// </summary>
        /// <param name="expectedDate">Data, na podstawie której dokonywane jest wyszukiwanie artykułów.</param>
        /// <returns>Asynchronicznie zwraca listę artykułów, która została zaktualizowana zgodnie z podaną datą.</returns>
        /// <exception cref="Exception">Rzucane, gdy podana data jest z przyszłości, brak połączenia z internetem lub wystąpił inny błąd operacyjny.</exception>
        public async Task<List<Artykul>> Update(DateTime expectedDate)
        {
            return await Task.Run(() =>
            {
                if (DateTime.Now < expectedDate)
                {
                    throw new Exception("NIE MOŻESZ WYBRAC DATY Z PRZYSZŁOŚCI");
                    
                }
                if (listaArtykulowp.Any(data => expectedDate.Year == data.Data.Year && expectedDate.Month == data.Data.Month && expectedDate.Day == data.Data.Day))
                {
                    //jesli sa w liscie glownej
                    listaArtykulow = listaArtykulowp.Where(x => x.Data.Year == expectedDate.Year && x.Data.Month == expectedDate.Month && x.Data.Day == expectedDate.Day).ToList();
                }
                else
                {
                    Cache cache = new Cache();
                    if(!cache.HasDate(expectedDate))
                    {
                        //jesli danych nie ma
                        if (!isInternetConnected()) throw new Exception("BRAK POŁĄCZENIA Z INTERNETEM");
                        Link lnk = new Link();
                        lnk.getPageNums(expectedDate);
                        var lista= lnk.getLista;
                        listaArtykulow = lista;
                        cache.SaveList(lista);
                    } else
                    {
                        //jesli dane w cache
                        listaArtykulow=cache.GetListFromDate(expectedDate);
                    }
                    
                }
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


                return listaArtykulow;

            });
        }

        /// <summary>
        /// Wyszukuje artykuł na podstawie podanej daty.
        /// </summary>
        /// <param name="time">Data, na podstawie której dokonywane jest wyszukiwanie.</param>
        /// <returns>
        /// Zwraca artykuł, którego data jest najbliższa podanej dacie i wcześniejsza.
        /// Jeśli nie ma artykułów spełniających warunek, zwraca pierwszy artykuł z listy (jeśli lista nie jest pusta).
        /// </returns>
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
        public Artykul WyszukajArtykulDlaWykresu(DateTime time)
        {
            Artykul wynik = listaArtykulowp[0];
            foreach (Artykul artykul in listaArtykulowp)
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


        /// <summary>
        /// Sprawdza, czy istnieje połączenie z internetem
        /// </summary>
        /// <returns>
        /// Zwraca true, jeśli połączenie z internetem istnieje, a ping do serwera www.google.com jest udany.
        /// Zwraca false, jeśli połączenie z internetem nie istnieje lub wystąpił błąd podczas pingowania.
        /// </returns>
        public static bool isInternetConnected()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("www.google.com", 1000); // Możesz zmienić na inny adres URL
                    return (reply != null && reply.Status == IPStatus.Success);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
