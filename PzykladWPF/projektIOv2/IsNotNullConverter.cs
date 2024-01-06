using System;
using System.Globalization;
using System.Windows.Data;

namespace projektIOv2
{
    /// <summary>
    /// Konwerter wartości, który sprawdza, czy wartość nie jest równa null.
    /// </summary>
    public class IsNotNullConverter : IValueConverter
    {

        /// <summary>
        /// Konwertuje wartość na logiczną wartość, sprawdzając, czy wartość nie jest równa null.
        /// </summary>
        /// <param name="value">Wartość do sprawdzenia.</param>
        /// <param name="targetType">Typ docelowy (nieużywany).</param>
        /// <param name="parameter">Dodatkowy parametr (nieużywany).</param>
        /// <param name="culture">Informacje o kulturze (nieużywane).</param>
        /// <returns>True, jeśli wartość nie jest równa null; w przeciwnym razie false.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }


        /// <summary>
        /// Konwertuje wartość z powrotem (metoda nie jest obsługiwana i zawsze rzuca wyjątek <see cref="NotImplementedException"/>).
        /// </summary>
        /// <param name="value">Wartość do konwersji z powrotem (nieużywane).</param>
        /// <param name="targetType">Typ docelowy (nieużywany).</param>
        /// <param name="parameter">Dodatkowy parametr (nieużywany).</param>
        /// <param name="culture">Informacje o kulturze (nieużywane).</param>
        /// <returns>Wyjątek <see cref="NotImplementedException"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




}
