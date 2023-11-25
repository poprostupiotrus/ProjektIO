using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaProjektIO
{
    internal class Spolka
    {
        string nazwa;
        string ticker;
        Dictionary<DateTime, double> notowania;
        public string Nazwa { get => nazwa; }
        public Dictionary<DateTime, double> Notowania { get => notowania; }
        public Spolka(string nazwa, string ticker, Dictionary<DateTime, double> notowania)
        {
            this.nazwa = nazwa;
            this.ticker = ticker;
            this.notowania = notowania;
        }
    }
}
