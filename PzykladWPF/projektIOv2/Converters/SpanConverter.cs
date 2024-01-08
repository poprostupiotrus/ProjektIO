using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace projektIOv2.Converters
{


    /// <summary>
    /// Konwerter przyporządkowujący nazwę spółki do tickera.
    /// </summary>
    public class SpanConverter : IValueConverter
    {
        

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
