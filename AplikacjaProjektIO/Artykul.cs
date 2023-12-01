using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AplikacjaProjektIO
{
    internal class Artykul
    {
        public DateTime Data;
        public string Naglowek;
        public string Tresc;
        public string Link;
        //public DateTime data { get => Data; } nie działa
        //public string naglowek { get => Naglowek; }
        //public string tresc { get => Tresc; }
        //public string link { get => Link; }
        Dictionary<String, double> GPT;
        public Dictionary<String, double> gpt;
        Dictionary<String, double> BARD;
        public Dictionary<String, double> bard;
    }
}
