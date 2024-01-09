using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using projektIOv2;
namespace projektIOv2.Skraper
{
    /// <summary>
    /// Klasa obsługująca interakcję z GPT w celu uzyskania odpowiedzi na pytania.
    /// </summary>
    class GptHandler
    {

        /// <summary>
        /// Zapytuje GPT o informacje związane z artykułem.
        /// </summary>
        /// <param name="artykul">Obiekt reprezentujący artykuł.</param>
        /// <param name="zapytanie">Treść zapytania do gpt</param>
        /// <returns>Obiekt reprezentujący artykuł z dodatkowymi informacjami uzyskanymi od GPT.</returns>
        public async Task<Artykul> ZapytajGpt(Artykul artykul,string zapytanie)
        {
            if (!ListaArtykulow.isInternetConnected()) throw new Exception("BRAK POŁĄCZENIA Z INTERNETEM");
            Dictionary<String, double> gptForecast = new Dictionary<String, double>();
            using var api = new OpenAIClient("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");
            var messages = new List<Message>
{
    new Message(Role.System, zapytanie),

};
            var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
            var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
            var choice = response.FirstChoice;
            string[] results = choice.Message.ToString().Split('\n');


            foreach (string line in results)
            {
                //wartosc liczbowa przewidywania
                double forecast = extractNumber(line.Replace(',', '.'));
                if (line.Contains("wzrost"))
                {
                    forecast = Math.Abs(forecast);
                }
                if (line.Contains("spadek"))
                {
                    forecast = -Math.Abs(forecast);
                }
                //tickern spolki
                String tickern = extractFirstThreeLetters(line.Trim());
                //wstaw przewidywanie do listy przewidywan gpt
                if (tickernDictionary.ContainsKey(tickern) || tickernDictionary.ContainsValue(tickern))
                    gptForecast[tickern] = forecast; 
                    
            }
            
            var artykul2= new Artykul() { Link = artykul.Link, Naglowek = artykul.Naglowek, Tresc = artykul.Tresc, bard = artykul.bard, gpt = gptForecast, Data = artykul.Data };
            artykul2.UpdateInCache();
            return artykul2;
        }

        /// <summary>
        /// Wydobywa Tickern spółki z ciągu znaków.
        /// </summary>
        /// <param name="input">Wejściowy ciąg znaków.</param>
        /// <returns>Tickern spółki.</returns>
        private string extractFirstThreeLetters(string input)
        {
            Match match = Regex.Match(input, @"(?<![A-Z])[A-Z]{3}(?![A-Z])");
            if (match.Success && match.Value.Length == 3 && match.Value != "WIG")
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Wydobywa Notowanie z ciągu znaków.
        /// </summary>
        /// <param name="input">Wejściowy ciąg znaków.</param>
        /// <returns>Liczba wydobyta z ciągu znaków.</returns>
        private double extractNumber(string input)
        {
            string pattern = @"[-+]?\d+\.?\d*";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                CultureInfo culture = CultureInfo.InvariantCulture;
                if (float.TryParse(match.Value, NumberStyles.Any, culture, out float result))
                {
                    return result;
                }
            }

            return 0;

        }

        /// <summary>
        /// Słownik którego kluczem jest Tickern społki, a wartością nazwa spółki
        /// </summary>
        private static readonly Dictionary<string, string> tickernDictionary = new Dictionary<string, string>
        {
            {"ALR","ALIOR" },
            {"ALE","ALLEGRO" },
            {"ACP","ASSECOPOL" },
            {"CDR","CDPROJEKT" },
            {"CPS","CYFRPLSAT" },
            {"DNP","DINOPL" },
            {"JSW","JSW" },
            {"KTY","KETY" },
            {"KGH","KGHM" },
            {"KRU","KRUK" },
            {"LPP","LPP" },
            {"MBK","MBANK" },
            {"OPL","ORANGEPL" },
            {"PEO","PEKAO" },
            {"PCO","PEPCO" },
            {"PGE","PGE" },
            {"PKN","PKNORLEN" },
            {"PKO","PKOBP" },
            {"PZU","PZU" },
            {"SPL","SANPL" }
        };
    }
}
