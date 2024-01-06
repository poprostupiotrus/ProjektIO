using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Management;
using System.Text.Json.Serialization;
using System.Xml;

class Program
{
    /// <summary>
    /// Formatuje datę z jednego formatu na drugi.
    /// </summary>
    /// <param name="dataString">Data w formie ciągu znaków.</param>
    /// <returns>Sformatowana data w formie ciągu znaków w nowym formacie lub informacja o błędzie parsowania daty.</returns>
    static string SformatujDate(string dataString)
    {

        string formatWejsciowy = "dd.MM.yyyy HH:mm:ss";


        string nowyFormat = "yyyy-MM-dd HH:mm:ss";

        if (DateTime.TryParseExact(dataString, formatWejsciowy, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
        {
            return data.ToString(nowyFormat);
        }
        else
        {
            return "Błąd parsowania daty.";
        }
    }

    /// <summary>
    /// Pobiera listę z danymi z określonej tabeli i id.
    /// </summary>
    /// <param name="tabela">Nazwa tabeli w bazie danych.</param>
    /// <param name="id">Identyfikator rekordu w tabeli.</param>
    /// <returns>Słownik z danymi z bazy danych.</returns>
    static Dictionary<String, Double> getLista(string tabela, long id)
    {
        string selectQuery2 = $"SELECT Tickern,notowanie FROM {tabela} WHERE IDt1={id} and notowanie not like 0";
        Dictionary<String, Double> lista = new Dictionary<String, Double>();
        using (MySqlConnection connection23 = new MySqlConnection(connectionString))
        {
            connection23.Open();
            using (MySqlCommand cmd2 = new MySqlCommand(selectQuery2, connection23))
            {

                using (MySqlDataReader reader2 = cmd2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        lista[reader2.GetString("Tickern")] = reader2.GetDouble("notowanie");
                    }
                }
            }
        }
        return lista;
    }

    private static string connectionString = "Server=localhost;Database=wiadomosci;User ID=test4;Password=123;";

    static void Main()
    {

        List<Wpis> wpisy = new List<Wpis>();


        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string selectQuery = "SELECT id,h1,p,czas,link FROM t1 WHERE czas BETWEEN '2023-11-07 00:00:00' and '2023-11-15 23:59:59' and p not like '' and h1 not like \"%tabela%\" and h1 not like \"%tabele%\"";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64("id");
                            string h1 = reader.GetString("h1");
                            string p = reader.GetString("p");
                            string link = "https://biznes.pap.pl" + reader.GetString("link");
                            string czas = SformatujDate(reader.GetString("czas"));
                            Dictionary<String, Double> listagpt = getLista("gpt", id);
                            Dictionary<String, Double> listabard = getLista("bard", id);

                            wpisy.Add(new Wpis { Data = czas, Naglowek = h1, Tresc = p.Replace("\n", "").Replace("\r", ""), Link = link, GPT = listagpt, BARD = listabard });


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas pobierania danych: {ex.Message}");
            }
        }

        string json = JsonConvert.SerializeObject(wpisy, Formatting.Indented);

        string sciezkaPliku = "artykuly.json";

        File.WriteAllText(sciezkaPliku, json);

        Console.WriteLine("Plik JSON został utworzony i zapisany.");
        Console.ReadKey();
    }
}

/// <summary>
/// Reprezentuje pojedynczy wpis z bazy danych.
/// </summary>
class Wpis
{
    /// <summary>
    /// Data artykółu.
    /// </summary>
    public string Data { get; set; }

    /// <summary>
    /// Nagłówek artykułu.
    /// </summary>
    public string Naglowek { get; set; }

    /// <summary>
    /// Treść artykułu.
    /// </summary>
    public string Tresc { get; set; }

    /// <summary>
    /// Link do artykułu
    /// </summary>
    public string Link { get; set; }

    /// <summary>
    /// Przewidywania gpt w formie słownika tickern-przewidywanie
    /// </summary>
    public Dictionary<String, Double> GPT { get; set; }

    /// <summary>
    /// Przewidywania google bard w formie słownika tickern-przewidywanie
    /// </summary>
    public Dictionary<String, Double> BARD { get; set; }
}