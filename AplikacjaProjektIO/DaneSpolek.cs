using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AplikacjaProjektIO
{
    internal class DaneSpolek
    {
        List<Spolka> listaSpolek;
        public List<Spolka> ListaSpolek { get => listaSpolek; }
        public DaneSpolek()
        {
            string filePath = "../../../resources/danespolekWIG20.json";
            string jsonString = File.ReadAllText(filePath);
            listaSpolek = JsonConvert.DeserializeObject<List<Spolka>>(jsonString);
            listaSpolek.Reverse();
        }
        public Spolka ZnajdzSpolkePoNazwie(string nazwa)
        {
            return listaSpolek.FirstOrDefault(x => x.Nazwa == nazwa);
        }
    }
}
