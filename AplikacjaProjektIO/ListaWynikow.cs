using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaProjektIO
{
    internal class ListaWynikow
    {
        List<WynikiLLM> lista = new List<WynikiLLM>();
        public List<WynikiLLM> Lista { get { return lista; } }
        public ListaWynikow(Artykul artykul, List<Spolka> spolki)
        {
            double wynikGPT;
            double wynikBARD;
            foreach(Spolka spolka in spolki)
            {
                if (artykul.gpt.ContainsKey(spolka.Ticker))
                {
                    wynikGPT = artykul.gpt[spolka.Ticker];
                }
                else
                {
                    wynikGPT = 0;
                }
                if (artykul.bard.ContainsKey(spolka.Ticker))
                {
                    wynikBARD = artykul.bard[spolka.Ticker];
                }
                else { wynikBARD = 0;}
                lista.Add(new WynikiLLM(spolka.Ticker, wynikGPT, wynikBARD));
                lista.Reverse();
            }
        }
    }
    internal class WynikiLLM
    {
        string ticker;
        public string Ticker { get => ticker; }
        double wynikGPT;
        public double WynikGPT { get => wynikGPT; }
        double wynikBARD;
        public double WynikBARD { get => wynikBARD; }
        public WynikiLLM(string ticker, double wynikGPT, double wynikBARD)
        {
            this.ticker = ticker;
            this.wynikGPT = wynikGPT;
            this.wynikBARD = wynikBARD;
        }
    }
}
