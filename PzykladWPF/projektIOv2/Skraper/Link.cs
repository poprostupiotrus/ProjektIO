using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace projektIOv2.Skraper
{
    /// <summary>
    /// Klasa pobierająca linki z https://biznes.pap.pl/pl/news/listings/
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Właściwość zwracająca liste artykułów.
        /// </summary>
        public List<Artykul> getLista
        {
            get
            {
                if (lista == null || lista.Count() == 0) throw new Exception("NIE UDAŁO SIĘ ZAŁADOWAĆ ŻADNYCH ARTYKUŁÓW");
                return lista;
            }
        }

        private List<Artykul> lista = new List<Artykul>();






        /// <summary>
        /// Dodaje adresy URL dla danej strony i daty.
        /// </summary>
        /// <param name="page">Analizowana strona.</param>
        /// <param name="expectedDate">Oczekiwana data.</param>
        private void addUrlsForPage(HtmlDocument page, DateTime expectedDate)
        {
            bool? isRun = null;



            ServicePointManager.Expect100Continue = false;
            //pobiera tabele z linkami
            var espiTable = page.DocumentNode.SelectSingleNode("//table[contains(@class, 'espi')]");
            if (espiTable != null)
            {
                //przetwarza wiersze
                var rows = espiTable.Descendants("tr");

                foreach (var firstRow in rows)
                {
                    if (firstRow != null)
                    {  
                        //przetwarza komurki
                        var cells = firstRow.Descendants("td");
                        DateTime dateAndTime = DateTime.Now;
                        
                        foreach (var cell in cells)
                        {
                            bool hasClassDni = cell.HasClass("dni");
                            //sprawdza czy jest sens dalej szukać
                            if (hasClassDni && DateTime.TryParseExact(cell.InnerText.Trim(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime timeNow))
                            {
                                if (isRun == true && timeNow != expectedDate) return;
                                if (isRun == null || isRun == false) isRun = timeNow == expectedDate;
                                continue;
                            }

                            //przetwarza date
                            if (cell.HasClass("wdgodz"))
                            {

                                var godzi = expectedDate.Year + "." + formatnum(expectedDate.Month) + "." + formatnum(expectedDate.Day) + " " + cell.InnerText.Trim();

                                dateAndTime = DateTime.ParseExact(godzi, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);


                            }
                            //przetwarza link do artykułu
                            var link = cell.Descendants("a").FirstOrDefault();
                            if (isRun == true && link != null)
                            {
                                string linkText = link.GetAttributeValue("href", "");
                                
                                lista.Add(new Artykul() { Naglowek = link.InnerText, Link = linkText, Data = dateAndTime });

                               }


                        }
                    }
                    else
                    {
                        Console.WriteLine("Brak wierszy w pierwszej tabeli.");
                    }

                }
            }

            
        }

        /// <summary>
        /// Formatuje numer, dodając zerowanie przed liczbami jednocyfrowymi.
        /// </summary>
        /// <param name="num">Liczba do sformatowania.</param>
        /// <returns>Sformatowana liczba jako ciąg znaków.</returns>
        private String formatnum(int num)
        {
            if (num < 10) return "0" + num;
            return "" + num;
        }


        /// <summary>
        /// Pobiera listę dat z danej witryny internetowej na podstawie numeru strony.
        /// </summary>
        /// <param name="pageNum">Numer strony.</param>
        /// <param name="expectedDate">Docelowa data.</param>
        /// <returns>Lista dat.</returns>
        public List<DateTime> getDni(int pageNum, DateTime expectedDate)
        {
            List<DateTime> dateList = new List<DateTime>();
            string url = "https://biznes.pap.pl/pl/news/listings/" + pageNum + ",";


            ServicePointManager.Expect100Continue = false;

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        HtmlDocument document = new HtmlDocument();
                        document.Load(responseStream);

                        //pobiera liste dni
                        var espiTable = document.DocumentNode.SelectNodes("//td[contains(@class, 'dni')]");
                        if (espiTable != null)
                        {
                            foreach (var item in espiTable)
                            {
                                if (DateTime.TryParseExact(item.InnerText.Trim(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
                                {
                                    dateList.Add(date);
                                    //jesli data spelnia oczekiwania to linki zostana dodane
                                    if (date.Equals(expectedDate))
                                    {
                                        Task.Run( () =>  addUrlsForPage(document, expectedDate));
                                        return dateList;
                                    }
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Brak elementów td o klasie 'dni' w dokumencie HTML.");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Błąd podczas wysyłania zapytania GET: " + ex.Message);
            }
            catch (Exception e)
            {

            }

            return dateList;
        }


        /// <summary>
        /// Pobiera numer strony na której jest oczekiwana data.
        /// </summary>
        /// <param name="target">Docelowa data.</param>
        /// <returns>Numer strony.</returns>
        private int getPageNum(DateTime target)
        {
            int left = 1;
            int right = 342;
            List<DateTime> arr;
            while (left <= right)
            {

                int mid = left + (right - left) / 2;
                arr = getDni(mid, target);
                if (arr.Contains(target))
                    return mid;





                if (arr.Any(a => a > target))
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// Pobiera numery stron na podstawie danej daty.
        /// </summary>
        /// <param name="target">Docelowa data.</param>
        /// <returns>Lista numerów stron.</returns>
        public List<int> getPageNums(DateTime target)
        {
            List<int> dateList = new List<int>();
            int pageNum = getPageNum(target);
            if (pageNum == -1) return dateList;
            dateList.Add(pageNum);

            //sprawdz sasiedztwo na prawo
            Thread forwardThread = new Thread(() =>
            {
                for (int i = pageNum + 1; i < 342; i++)
                {
                    List<DateTime> k = getDni(i, target);
                    if (k.Contains(target)) dateList.Add(i);
                    else break;
                }
            });

            //sprawdz sasiedztwo na lewo
            Thread backwardThread = new Thread(() =>
            {
                for (int i = pageNum - 1; i > 0; i--)
                {
                    List<DateTime> k = getDni(i, target);
                    if (k.Contains(target)) dateList.Add(i);
                    else break;
                }
            });


            forwardThread.Start();
            backwardThread.Start();


            forwardThread.Join();
            backwardThread.Join();
            return dateList;
        }


    }
}
