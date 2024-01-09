using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace projektIOv2.Skraper
{
    /// <summary>
    /// Klasa pobierajaca tresć artykułu.
    /// </summary>
    class Tresc : Artykul
    {
        private string path;

        /// <summary>
        /// Konstruktor klasy Tresc przyjmujący ścieżkę do artykułu.
        /// </summary>
        /// <param name="path">Ścieżka do artykułu</param>
        public Tresc(string path)
        {
            this.Link = path;

        }

        /// <summary>
        /// Konstruktor klasy Tresc przyjmujący obiekt klasy Artykul.
        /// </summary>
        /// <param name="artykul">Obiekt klasy Artykul.</param>
        public Tresc(Artykul artykul)
        {
            this.Link = artykul.Link;
            this.Naglowek = artykul.Naglowek;

        }

        /// <summary>
        /// Asynchroniczna metoda pobierająca informacje o artykule i przeprowadzająca analizę przy użyciu GPT.
        /// </summary>
        /// <returns>Obiekt klasy Artykul z dodatkowymi informacjami uzyskanymi od GPT.</returns>
        public async Task<Artykul> get()
        {
            var ob= await Task.Run(() =>
            {
                return init();
            });
            
                String txt = "Indeks WIG20 jest indeksem cenowym największych spółek giełdowych w Polsce. Wartość indeksu obliczana jest na podstawie obrotów i cen akcji 20 spółek giełdowych.podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20:\r\n 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)' \r\n Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20,  odpowiedź ma być w postaci listy, której elementami są: '<Nazwa spółki> <Przewidywanie>' i nic, poza tym(przewidywanie liczba z przedzialu <-10;10> gdzie -10 to wysokie prawdopodobienstwo spatku notowania danej spółki, \r\n 10-wysokie prawdopodobieństwo ze artykuł wplynie pozytywnie na notowania spolki,Nazwa spółki- trzyliterowy TICKERN spolki). Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:\r\n'JSW -1\r\nALE +4\r\n...'\r\nTreść artykułu na podstawie którego masz wypisać wyniki:\r\n               ";
                String query = txt + ob.Naglowek + ob.Tresc;
                GptHandler gptHandler = new GptHandler();
                return await gptHandler.ZapytajGpt(ob, query);
            
        }

        /// <summary>
        /// Metoda inicjalizująca obiekt klasy Artykul na podstawie pobranej treści artykułu z witryny internetowej.
        /// </summary>
        /// <returns>Obiekt klasy Artykul z zainicjalizowanymi danymi.</returns>
        Artykul init()
        {
            string url = "https://biznes.pap.pl" + Link;

            if (!ListaArtykulow.isInternetConnected()) throw new Exception("BRAK POŁĄCZENIA Z INTERNETEM");
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


                        // Pobierz cały tekst z elementu o id "dataContent"
                        var dataContent = doc.DocumentNode.SelectSingleNode("//*[@id='dataContent']");

                        if (dataContent != null)
                        {
                            var paragraphs = dataContent.Descendants("p");
                            string dataContentText = string.Join(Environment.NewLine, paragraphs.Select(p => p.InnerText.Trim()));

                            //usun zbedne znaki nowej lini
                            Tresc = dataContentText.Replace("\n\n", "\n");
                                
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
