using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2
{
    public class Artykul : IComparable<Artykul>
    {
        public DateTime Data { get; set; }
        public string? Naglowek { get; set; }

        public string? YEAR { get; set; }
        public string? HOUR { get; set; }
        public string? Tresc { get; set; }
        public string? Link { get; set; }
        //public DateTime data { get => Data; } nie działa
        //public string naglowek { get => Naglowek; }
        //public string tresc { get => Tresc; }
        //public string link { get => Link; }
        //Dictionary<String, double> GPT;
        public Dictionary<String, double> gpt { get; set; }
        //Dictionary<String, double> BARD;
        public Dictionary<String, double> bard { get; set; }


        public int CompareTo(Artykul other)
        {
            int cmp = Data.CompareTo(other.Data);
            if (cmp != 0)
                return cmp;
            else if (Tresc == null)
                return -1;
            else if (other.Tresc == null)
                return 1;


            return cmp;
        }

        public bool isPositive(List<String> spolki)
        {
            return spolki.All(sp => bard[sp] == null || (bard[sp] >= 0)) &&
           spolki.All(sp => gpt[sp] == null || (gpt[sp] >= 0));
        }

        public bool isNegative(List<String> spolki)
        {
            return spolki.All(sp => bard[sp] != null || (bard[sp] < 0)) &&
           spolki.All(sp => gpt[sp] != null || (gpt[sp] < 0));
        }
    }
}
