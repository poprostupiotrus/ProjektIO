using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projektIOv2.Skraper
{
    class GptHandler
    {
        private List<string> brakinfo = new List<string>
    {
        "Brak wpływu", "Nie jestem w stanie", "nie jest możliwe", "brakuje informacji",
        "Brak informacji", "Brak konkretnej informacji", "Nie mogę odpowiedzieć", "nie zawiera",
        "nie dotyczy", "Nie można przewidzieć", "Nie ma w podanym artykule informacji",
        "brak powiązania", "Brak przewidywań", "ogólnikowy", "Nie można udzielić",
        "nie pozwala", "nie można", "nie ma informacji"
    };

        public async Task<Artykul> ZapytajGpt(Artykul x,string art)
        {
            Dictionary<String, double> lista = new Dictionary<String, double>();
            using var api = new OpenAIClient("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");
            var messages = new List<Message>
{
    new Message(Role.System, art),

};
            var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
            var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
            var choice = response.FirstChoice;
            string[] wynik = choice.Message.ToString().Split('\n');

            Console.WriteLine(string.Join("\n", wynik));

            foreach (string line in wynik)
            {
                double liczba2 = (double)ExtractNumber(line.Replace(',', '.'));
                if (line.Contains("wzrost"))
                {
                    liczba2 = Math.Abs(liczba2);
                }
                if (line.Contains("spadek"))
                {
                    liczba2 = -Math.Abs(liczba2);
                }
                var t = ExtractFirstThreeLetters(line.Trim());
                if (tickernDictionary.ContainsKey(t) || tickernDictionary.ContainsValue(t))
                    lista[t]= liczba2;
                    
            }
            
            return new Artykul() { Link=x.Link, Naglowek=x.Naglowek, Tresc=x.Tresc,bard=x.bard,gpt=lista, Data=x.Data};
        }

        public string ExtractFirstThreeLetters(string input)
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

        public float ExtractNumber(string input)
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

        private async Task<String> GetGptResponse(string input)
        {
            using var api = new OpenAIClient("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");
            var messages = new List<Message>
{
    new Message(Role.System, input),

};
            var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
            var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
            var choice = response.FirstChoice;
            return choice.Message;
        }

        public bool NieistotnyArtykul(List<(string, float)> lista)
        {
            foreach ((string zmienna, _) in lista)
            {
                if (brakinfo.Any(wyraz => (wyraz.ToLower()).Contains(zmienna.ToLower())))
                {
                    return true;
                }
            }
            return false;
        }

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
