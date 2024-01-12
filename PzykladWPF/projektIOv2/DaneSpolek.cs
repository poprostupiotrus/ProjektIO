using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace projektIOv2
{
    /// <summary>
    /// Klasa przechowująca dane dotyczące spółek.
    /// </summary>
    internal class DaneSpolek
    {
        /// <summary>
        /// Przechowuje liste spółek
        /// </summary>
        List<Spolka> listaSpolek;

        /// <summary>
        /// Właściwość, która odczytuje pole listaSpolek.
        /// </summary>
        public List<Spolka> ListaSpolek { get => listaSpolek; }

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="DaneSpolek"/>.
        /// </summary>
        public DaneSpolek()
        {
            //Trace.WriteLine("Poczatek");
            string filePath = "danespolekWIG20.json";
            string jsonString = File.ReadAllText(filePath);
            ///Trace.WriteLine("po wczytaniu");


            listaSpolek = JsonConvert.DeserializeObject<List<Spolka>>(jsonString);

            Trace.WriteLine("po deserializacji");
        }

        /// <summary>
        /// Znajduje spółkę po nazwie.
        /// </summary>
        /// <param name="nazwa">Nazwa spółki.</param>
        /// <returns>Obiekt reprezentujący spółkę.</returns>
        public Spolka ZnajdzSpolkePoNazwie(string nazwa)
        {
            return listaSpolek?.Find(x => x.Nazwa == nazwa);
        }
    }

}
