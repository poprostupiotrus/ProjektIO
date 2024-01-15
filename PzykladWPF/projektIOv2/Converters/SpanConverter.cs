using System;
using System.Globalization;
using System.Windows.Data;

namespace projektIOv2.Converters
{


    /// <summary>
    /// Konwerter zwracajacy 2 dla wartosci null, w pozostałych przypadkach 1
    /// Przydatny w layoucie gdy trzeba ukryc elementy bez danych
    /// </summary>
    public class SpanConverter : IValueConverter
    {
        

        /// <summary>
        /// zwraca liczbe w zaleznosci od tego czy wartość to null.
        /// </summary>
        /// <param name="value">Dowolny obiekt</param>
        /// <param name="targetType">Typ docelowy.</param>
        /// <param name="parameter">Parametr konwertera.</param>
        /// <param name="culture">Informacje o kulturze.</param>
        /// <returns>2 gdy value to null, w przeciwnym przypadku 1</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 2; return 1;
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
