using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace projektIOv2
{
    public class NameConverter : IValueConverter
    {
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

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return tickernDictionary[value.ToString()];
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
