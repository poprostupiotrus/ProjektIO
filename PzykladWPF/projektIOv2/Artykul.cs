using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2
{
    public class Artykul
    {
        public DateTime Data;
        public string Naglowek;
        public string? NAGLOWEK { get=> Naglowek; set { Naglowek = value; } }
        public string? YEAR { get; set; }
        public string? HOUR { get; set; }
        public string? TRESC { get => Tresc; set { Tresc = value; } }
        public string Tresc;
        public string Link;
        //public DateTime data { get => Data; } nie działa
        //public string naglowek { get => Naglowek; }
        //public string tresc { get => Tresc; }
        //public string link { get => Link; }
        Dictionary<String, double> GPT;
        public Dictionary<String, double> gpt { get; set; }
        Dictionary<String, double> BARD;
        public Dictionary<String, double> bard { get; set; }
    }
}
