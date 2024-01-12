using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;


namespace projektIOv2
{
    /// <summary>
    /// Konwerter przyporządkowujący nazwę spółki do tickera.
    /// </summary>
    public class NameConverter : IValueConverter
    {
        /// <summary>
        /// Przechowuje klucze jako ticker, a wartosc to pelne nazwy spółek
        /// </summary>
        private static readonly Dictionary<string, string> tickernDictionary = new Dictionary<string, string>
        {
            {"ALR","ALIOR" },
            {"ALE","ALLEGRO" },
            {"ACP","ASSECOPOL" },
            {"CDR","CDPROJEKT" },
            {"CPS","CYFRPLSAT" },
            {"DNP","DINOPL" },
            {"JSW","JSW" },
            {"KTY","KETY" },
            {"KGH","KGHM" },
            {"KRU","KRUK" },
            {"LPP","LPP" },
            {"MBK","MBANK" },
            {"OPL","ORANGEPL" },
            {"PEO","PEKAO" },
            {"PCO","PEPCO" },
            {"PGE","PGE" },
            {"PKN","PKNORLEN" },
            {"PKO","PKOBP" },
            {"PZU","PZU" },
            {"SPL","SANPL" }
        };

        /// <summary>
        /// Konwertuje ticker na nazwę spółki.
        /// </summary>
        /// <param name="value">Ticker spółki.</param>
        /// <param name="targetType">Typ docelowy.</param>
        /// <param name="parameter">Parametr konwertera.</param>
        /// <param name="culture">Informacje o kulturze.</param>
        /// <returns>Nazwa spółki przypisana do tickera.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return tickernDictionary[value.ToString()];
        }


        /// <summary>
        /// Nie jest używane w tym konwerterze.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
