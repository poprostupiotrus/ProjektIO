using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            var ob= await Task.Run(() =>
            {
                return init();
            });
            
                String txt = "Indeks WIG20 jest indeksem cenowym największych spółek giełdowych w Polsce. Wartość indeksu obliczana jest na podstawie obrotów i cen akcji 20 spółek giełdowych.podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20:\r\n 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)' \r\n Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20,  odpowiedź ma być w postaci listy, której elementami są: '<Nazwa spółki> <Przewidywanie>' i nic, poza tym(przewidywanie liczba z przedzialu <-10;10> gdzie -10 to wysokie prawdopodobienstwo spatku notowania danej spółki, \r\n 10-wysokie prawdopodobieństwo ze artykuł wplynie pozytywnie na notowania spolki,Nazwa spółki- trzyliterowy TICKERN spolki). Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:\r\n'JSW -1\r\nALE +4\r\n...'\r\nTreść artykułu na podstawie którego masz wypisać wyniki:\r\n               ";
                String query = txt + ob.Naglowek + ob.Tresc;
                if (ob.Tresc == null) MessageBox.Show("mamy null");
                GptHandler gptHandler = new GptHandler();
                return await gptHandler.ZapytajGpt(ob, query);
            
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
