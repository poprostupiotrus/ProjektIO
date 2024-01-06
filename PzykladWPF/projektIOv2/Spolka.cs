using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2 {

    /// <summary>
    /// Klasa reprezentująca spółkę.
    /// </summary>
    internal class Spolka
    {
        string nazwa;
        string ticker;
        Dictionary<DateTime, double> notowania;
    /// <summary>
    /// Nazwa spółki.
    /// </summary>
    public string Nazwa { get => nazwa; }

    /// <summary>
    /// Symbol tickera spółki.
    /// </summary>
    public string Ticker { get => ticker; }

    /// <summary>
    /// Słownik przechowujący daty notowań i odpowiadające im wartości.
    /// </summary>
    public Dictionary<DateTime, double> Notowania { get => notowania; }

    /// <summary>
    /// Inicjalizuje nową instancję klasy <see cref="Spolka"/>.
    /// </summary>
    /// <param name="nazwa">Nazwa spółki.</param>
    /// <param name="ticker">Symbol tickera spółki.</param>
    /// <param name="notowania">Słownik przechowujący daty notowań i odpowiadające im wartości.</param>
    public Spolka(string nazwa, string ticker, Dictionary<DateTime, double> notowania)
        {
            this.nazwa = nazwa;
            this.ticker = ticker;
            this.notowania = notowania;
        }
    }
}
