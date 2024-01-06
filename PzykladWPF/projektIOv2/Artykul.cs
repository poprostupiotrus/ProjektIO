using projektIOv2.Skraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2
{
    /// <summary>
    /// Klasa reprezentująca artykuł.
    /// Implementuje interfejs IComparable
    /// </summary>
    public class Artykul : IComparable<Artykul>
    {
        /// <summary>
        /// Pobiera lub ustawia datę artykułu.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nagłówek artykułu.
        /// </summary>
        public string? Naglowek { get; set; }

        /// <summary>
        /// Pobiera lub ustawia date dla listy artykułów
        /// </summary>
        public string? YEAR { get; set; }

        /// <summary>
        /// Pobiera lub ustawia godzine dla listy artykułów
        /// </summary>
        public string? HOUR { get; set; }

        /// <summary>
        /// Pobiera lub ustawia treść artykułu.
        /// </summary>
        public string? Tresc { get; set; }

        /// <summary>
        ///  Pobiera lub ustawia link do artykułu.
        /// </summary>
        public string? Link { get; set; }
        //public DateTime data { get => Data; } nie działa
        //public string naglowek { get => Naglowek; }
        //public string tresc { get => Tresc; }
        //public string link { get => Link; }
        //Dictionary<String, double> GPT;

        /// <summary>
        /// Pobiera lub ustawia słownik GPT artykułu.
        /// </summary>
        public Dictionary<String, double> gpt { get; set; }
        //Dictionary<String, double> BARD;

        /// <summary>
        /// Pobiera lub ustawia słownik BARD artykułu.
        /// </summary>
        public Dictionary<String, double> bard { get; set; }

        /// <summary>
        /// Porównuje obecny artykuł z innym artykułem na podstawie daty.
        /// </summary>
        /// <param name="other">Inny artykuł do porównania.</param>
        /// <returns>Wartość ujemna, jeśli obecny artykuł jest wcześniejszy; wartość dodatnia, jeśli obecny artykuł jest późniejszy; zero, jeśli oba artykuły są takie same.</returns>
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

        /// <summary>
        /// Sprawdza, czy artykuł jest pozytywny dla podanych spółek.
        /// </summary>
        /// <param name="spolki">Lista trzyliterowych symboli spółek.</param>
        /// <returns>True, jeśli artykuł jest pozytywny dla wszystkich spółek; w przeciwnym razie false.</returns>
        public bool isPositive(List<String> spolki)
        {
            return spolki.All(sp => bard[sp] == null || (bard[sp] >= 0)) &&
           spolki.All(sp => gpt[sp] == null || (gpt[sp] >= 0));
        }

        /// <summary>
        /// Sprawdza, czy artykuł jest negatywny dla podanych spółek.
        /// </summary>
        /// <param name="spolki">Lista trzyliterowych symboli spółek.</param>
        /// <returns>True, jeśli artykuł jest negatywny dla wszystkich spółek; w przeciwnym razie false.</returns>
        public bool isNegative(List<String> spolki)
        {
            return spolki.All(sp => bard[sp] != null || (bard[sp] < 0)) &&
           spolki.All(sp => gpt[sp] != null || (gpt[sp] < 0));
        }

        /// <summary>
        /// Aktualizuje artykuł w pamięci podręcznej.
        /// </summary>
        public void UpdateInCache()
        {
            new Cache().UpdateArtykul(this);
        }
    }
}
