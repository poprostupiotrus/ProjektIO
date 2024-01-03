using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace projektIOv2.Skraper
{
    public class Link
    {
        public List<Artykul> getLista
        {
            get
            {
                return lista;
            }
        }

        private List<Artykul> lista = new List<Artykul>();







        private void addUrlsForPage(HtmlDocument doc, DateTime dt)
        {
            bool? isRun = null;



            ServicePointManager.Expect100Continue = false;

            var espiTable = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'espi')]");
            if (espiTable != null)
            {
                var rows = espiTable.Descendants("tr");

                foreach (var firstRow in rows)
                {
                    if (firstRow != null)
                    {
                        var cells = firstRow.Descendants("td");
                        DateTime godz = DateTime.Now;
                        var txtd = "";
                        foreach (var cell in cells)
                        {
                            bool b1 = cell.HasClass("dni");

                            if (b1 && DateTime.TryParseExact(cell.InnerText.Trim(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime result))
                            {
                                txtd = cell.InnerText.Trim();
                                if (isRun == true && result != dt) return;
                                if (isRun == null || isRun == false) isRun = result == dt;
                                continue;
                            }
                            if (cell.HasClass("wdgodz"))
                            {

                                var godzi = dt.Year + "." + formatnum(dt.Month) + "." + formatnum(dt.Day) + " " + cell.InnerText.Trim();

                                godz = DateTime.ParseExact(godzi, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);


                            }
                            var link = cell.Descendants("a").FirstOrDefault();
                            if (isRun == true && link != null)
                            {
                                string linkText = link.GetAttributeValue("href", "");
                                //MessageBox.Show(godz.ToLongDateString());
                                lista.Add(new Artykul() { Naglowek = link.InnerText, Link = linkText, Data = godz });

                                //new Thread(() => { tresclist.Add(new Tresc(linkText)); }   ).Start();
                            }


                        }
                    }
                    else
                    {
                        Console.WriteLine("Brak wierszy w pierwszej tabeli.");
                    }

                }
            }

            //await Task.CompletedTask;
        }

        String formatnum(int num)
        {
            if (num < 10) return "0" + num;
            return "" + num;
        }



        public List<DateTime> getDni(int num, DateTime dt)
        {
            List<DateTime> lista = new List<DateTime>();
            string url = "https://biznes.pap.pl/pl/news/listings/" + num + ",";


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
                        HtmlDocument doc = new HtmlDocument();
                        doc.Load(responseStream);

                        var espiTable = doc.DocumentNode.SelectNodes("//td[contains(@class, 'dni')]");
                        if (espiTable != null)
                        {
                            foreach (var item in espiTable)
                            {
                                if (DateTime.TryParseExact(item.InnerText.Trim(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime result))
                                {
                                    lista.Add(result);
                                    if (result.Equals(dt))
                                    {
                                        Task.Run( () =>  addUrlsForPage(doc, dt));
                                        return lista;
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

            return lista;
        }



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

        public List<int> getPageNums(DateTime target)
        {
            List<int> wyniki = new List<int>();
            int key = getPageNum(target);
            if (key == -1) return wyniki;
            wyniki.Add(key);
            Thread forwardThread = new Thread(() =>
            {
                for (int i = key + 1; i < 342; i++)
                {
                    List<DateTime> k = getDni(i, target);
                    if (k.Contains(target)) wyniki.Add(i);
                    else break;
                }
            });


            Thread backwardThread = new Thread(() =>
            {
                for (int i = key - 1; i > 0; i--)
                {
                    List<DateTime> k = getDni(i, target);
                    if (k.Contains(target)) wyniki.Add(i);
                    else break;
                }
            });


            forwardThread.Start();
            backwardThread.Start();


            forwardThread.Join();
            backwardThread.Join();
            return wyniki;
        }


    }
}
