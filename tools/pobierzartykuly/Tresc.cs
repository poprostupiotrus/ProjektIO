using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Linq;
using System.Net;

class Tresc
{
    private string path;

    public Tresc(string path)
    {
        this.path = path;
        init();
    }
    public string Czas { get => czas; }
    public string Tytul { get => tytul; }
    public string Trescc { get => tresc; }
    private string czas { get; set; }
    private string tytul { get; set; }
    private string tresc { get; set; }
    void init()
    {
        string url = "https://biznes.pap.pl"+path;

        
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

                    
                    tytul=depeszaContent;
                    Console.WriteLine();

                    //czas
                    var depeszaTime = doc.DocumentNode.SelectSingleNode("//*[@class='datadepeszy']");
                    string timeContent = (depeszaTime?.InnerText.Trim()).Substring(0, 16) + ":00";
                    czas=timeContent.Replace(".", "-");
                    DateTime data = DateTime.ParseExact(czas, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    czas = data.ToString("yyyy-MM-dd HH:mm:ss");

                    // Pobierz cały tekst z elementu o id "dataContent", pomijając dwa ostatnie paragrafy
                    var dataContent = doc.DocumentNode.SelectSingleNode("//*[@id='dataContent']");

                    if (dataContent != null)
                    {
                        var paragraphs = dataContent.Descendants("p").Take(dataContent.Descendants("p").Count() - 2);
                        string dataContentText = string.Join(Environment.NewLine, paragraphs.Select(p => p.InnerText.Trim()));

                        
                        tresc=dataContentText;
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Błąd podczas wysyłania zapytania GET: " + ex.Message);
        }

        
    }
}
