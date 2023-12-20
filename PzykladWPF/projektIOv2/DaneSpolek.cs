using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace projektIOv2
{
    internal class DaneSpolek
    {
        List<Spolka> listaSpolek;

        public List<Spolka> ListaSpolek { get => listaSpolek; }

        public DaneSpolek()
        {
            Trace.WriteLine("Poczatek");
            string filePath = "danespolekWIG20.json";
            string jsonString = File.ReadAllText(filePath);
            Trace.WriteLine("po wczytaniu");


            listaSpolek = JsonConvert.DeserializeObject<List<Spolka>>(jsonString);

            Trace.WriteLine("po deserializacji");
        }

        public Spolka ZnajdzSpolkePoNazwie(string nazwa)
        {
            return listaSpolek?.Find(x => x.Nazwa == nazwa);
        }
    }
   
}
