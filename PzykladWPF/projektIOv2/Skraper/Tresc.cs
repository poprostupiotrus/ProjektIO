using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2.Skraper
{
    class Tresc : Artykul
    {
        private string path;

        public Tresc(string path)
        {
            this.Link = path;

        }

        public Tresc(Artykul art)
        {
            this.Link = art.Link;
            this.Naglowek = art.Naglowek;

        }
        public async Task<Artykul> get()
        {
            return await Task.Run(() =>
            {
                return init();
            });
        }
        Artykul init()
        {
            string url = "https://biznes.pap.pl" + Link;


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

                        // Pobierz treść z nagłówka H1
                        var depeszaHeader = doc.DocumentNode.SelectSingleNode("//h1");
                        string depeszaContent = depeszaHeader?.InnerText.Trim();


                        Naglowek = depeszaContent;
                        Console.WriteLine();

                        //czas
                        var depeszaTime = doc.DocumentNode.SelectSingleNode("//*[@class='datadepeszy']");
                        string timeContent = (depeszaTime?.InnerText.Trim()).Substring(0, 16) + ":00";
                        string czas = timeContent.Replace(".", "-");
                        Data = DateTime.ParseExact(czas, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);


                        // Pobierz cały tekst z elementu o id "dataContent", pomijając dwa ostatnie paragrafy
                        var dataContent = doc.DocumentNode.SelectSingleNode("//*[@id='dataContent']");

                        if (dataContent != null)
                        {
                            var paragraphs = dataContent.Descendants("p");
                            string dataContentText = string.Join(Environment.NewLine, paragraphs.Select(p => p.InnerText.Trim()));

                            
                            Tresc = dataContentText.Replace("\n\n", "\n");
                                ;///.Substring(0, dataContentText.IndexOf("Więcej na: http://biznes.pap.pl"));
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Błąd podczas wysyłania zapytania GET: " + ex.Message);
            }
            return this;

        }

    }
}
