using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;


/// <summary>
/// Klasa skrapująca linki do artykułow.
/// </summary>
internal class Link
{
    /// <summary>
    /// Lista linków.
    /// </summary>
    public List<String> getLista
    {
        get
        {
            return lista;
        }
    }
    private List<String> lista = new List<string>();

    /// <summary>
    /// Dodaje linki z określonej strony do listy.
    /// </summary>
    /// <param name="num">Numer strony do pobrania (domyślnie 1).</param>
    public void addApage(int num = 1)
    {
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

                    var espiTable = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'espi')]");
                    if (espiTable != null)
                    {
                        var rows = espiTable.Descendants("tr");

                        foreach (var firstRow in rows)
                        {
                            if (firstRow != null)
                            {
                                var cells = firstRow.Descendants("td");

                                foreach (var cell in cells)
                                {
                                    var link = cell.Descendants("a").FirstOrDefault();
                                    if (link != null)
                                    {
                                        string linkText = link.GetAttributeValue("href", "");
                                        lista.Add(linkText);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Brak wierszy w pierwszej tabeli.");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Brak tabeli o klasie 'espi' w dokumencie HTML.");
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


